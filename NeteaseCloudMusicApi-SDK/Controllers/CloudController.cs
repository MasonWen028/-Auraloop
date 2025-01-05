using Microsoft.AspNetCore.Mvc;
using NeteaseCloudMusicApi_SDK.Models.Dtos.RequestModels.cloud;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class CloudController : Controller
    {
        private readonly GenericService _genericService;

        private readonly HttpClient _httpClient = new HttpClient(new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(5),
            PooledConnectionIdleTimeout = TimeSpan.FromMinutes(2),
            KeepAlivePingPolicy = HttpKeepAlivePingPolicy.WithActiveRequests,
            KeepAlivePingTimeout = TimeSpan.FromSeconds(15)
        });

        public CloudController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("cloud")]
        [SwaggerOperation(
            Summary = "Upload Song to Cloud",
            Description = "Uploads a song file to the cloud. The process includes validation, checking if the file already exists, token generation, fetching upload URLs, uploading the file, submitting metadata, and publishing the song.",
            OperationId = "UploadSongToCloud",
            Tags = new[] { "Cloud", "Tested" }
        )]
        [SwaggerResponse(200, "Song uploaded and published successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Could be due to missing file, unsupported file format, or file size exceeding the limit.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> Cloud([FromForm] SongUploadRequestModel requestModel)
        {
            try
            {
                // Step 1: Validate the file
                if (requestModel.SongFile == null)
                {
                    return BadRequest(new { Message = "No file uploaded. Please upload a valid music file." });
                }

                const long maxFileSize = 104857600; // 100 MB
                if (requestModel.SongFile.Length > maxFileSize)
                {
                    return BadRequest(new { Message = "File size exceeds the 100 MB limit." });
                }

                string filename = Path.GetFileNameWithoutExtension(requestModel.SongFile.FileName)
                    .Replace(" ", "")
                    .Replace(".", "_");

                string md5Hash = Md5Helper.CalculateMd5(requestModel.SongFile);
                long fileSize = requestModel.SongFile.Length;


                var allowedExtensions = new[] { "mp3", "flac", "wav" };
                var ext = Path.GetExtension(requestModel.SongFile.FileName)?.ToLower().TrimStart('.') ?? "";
                if (!allowedExtensions.Contains(ext))
                {
                    return BadRequest(new { Message = "Unsupported file format. Please upload an MP3, FLAC, or WAV file." });
                }

                // Step 2: Check whether the file had been uploaded or not
                // when needUpload is false, return aleady uploaded
                bool needUpload = await CheckIfUploadIsRequired(ext, md5Hash, fileSize);
                if (!needUpload)
                {
                    return Ok(new { Message = "The file already exists in the cloud." });
                }

                // Step 3: get token for upload file
                // Get Token & ResourceId from the response
                var (Token, objectKey, ResourceId, Bucket) = await RequestToken(filename, ext, md5Hash);

                // Step 4: fetch upload url for target bucket from server.
                // Get objectKey
                string uploadUrl = await GetUploadEndpoint(Bucket);

                //tokenResponse.Result.ObjectKey.Replace("/", "%2F");

                // Step 5: Execute the action of uploading.
                await UploadFile(requestModel.SongFile, uploadUrl, objectKey, Token, md5Hash);

                string songName = "My Song"; // Extract metadata if needed
                string album = "Unknown Album";
                string artist = "Unknown Artist";

                // Step 6: Submit this file / song to cloud
                await SubmitCloudInfo(md5Hash, filename, songName, album, artist, ResourceId);

                // Step 7: Publish this song
                await PublishSong("0");


                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloud/upload/check",
                    OptionType = "weapi",
                    Data = new CloudRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// reuqest uploading url from bucket
        /// </summary>
        /// <param name="bucket"></param>
        /// <returns></returns>
        private async Task<string> GetUploadEndpoint(string bucket)
        {
            var lbsResponse = await _httpClient.GetStringAsync($"https://wanproxy.127.net/lbs?version=1.0&bucketname={bucket}");
            if (!string.IsNullOrEmpty(lbsResponse))
            {
                var lbsRes = JsonConvert.DeserializeObject<LbsResponse>(lbsResponse);
                if (lbsRes !=null && !string.IsNullOrEmpty(lbsRes.Lbs))
                {
                    return lbsRes.Lbs;
                }
            }
            return "";
        }

        /// <summary>
        /// executing the file upload
        /// </summary>
        /// <param name="songFile"></param>
        /// <param name="uploadUrl"></param>
        /// <param name="objectKey"></param>
        /// <param name="token"></param>
        /// <param name="md5"></param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        private async Task UploadFile(IFormFile songFile, string uploadUrl, string objectKey, string token, string md5)
        {
            using (var stream = songFile.OpenReadStream())
            {
                var content = new StreamContent(stream);
                content.Headers.Add("x-nos-token", token);
                content.Headers.Add("Content-MD5", md5);
                content.Headers.Add("Content-Type", "audio/mpeg");
                content.Headers.ContentLength = songFile.Length;

                var uploadEndpoint = $"{uploadUrl}/jd-musicrep-privatecloud-audio-public/{objectKey}?offset=0&complete=true&version=1.0";
                var response = await _httpClient.PostAsync(uploadEndpoint, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Upload failed: {response.StatusCode}");
                }
            }
        }

        /// <summary>
        /// submit song infomation
        /// </summary>
        /// <param name="md5"></param>
        /// <param name="filename"></param>
        /// <param name="songName"></param>
        /// <param name="album"></param>
        /// <param name="artist"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        private async Task SubmitCloudInfo(string md5, string filename, string songName, string album, string artist, long resourceId)
        {
            var cloudInfoData = new
            {
                md5,
                songid = "0",
                filename,
                song = songName ?? filename,
                album = album ?? "Unknown Album",
                artist = artist ?? "Unknown Artist",
                bitrate = "999000",
                resourceId
            };

            var apiModel = new ApiModel
            {
                ApiEndpoint = "/api/nos/token/alloc",
                OptionType = "",
                Data = cloudInfoData
            };

            var submitResponse = await _genericService.HandleRequestAsync(apiModel);
        }


        /// <summary>
        /// publish uploaded song
        /// </summary>
        /// <param name="songId"></param>
        /// <returns></returns>
        private async Task PublishSong(string songId)
        {
            var publishData = new { songid = songId };

            var apiModel = new ApiModel
            {
                ApiEndpoint = "/api/nos/token/alloc",
                OptionType = "",
                Data = publishData
            };

            var publishResponse = await _genericService.HandleRequestAsync(apiModel);
        }

        /// <summary>
        /// request uploading token
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="ext"></param>
        /// <param name="md5"></param>
        /// <returns></returns>
        private async Task<(string, string, long, string)> RequestToken(string filename, string ext, string md5)
        {

            var tokenAllocRequestModel = new TokenallocRequestModel()
            {
                Bucket = "jd-musicrep-privatecloud-audio-public",
                FileName = filename,
                Md5 = md5,
                Ext = ext
            };

            var tokenApiModel = new ApiModel
            {
                ApiEndpoint = "/api/nos/token/alloc",
                OptionType = "",
                Data = tokenAllocRequestModel
            };

            var tokenResponse = await _genericService.HandleRequestAsync(tokenApiModel);
            //TODO get ResourceId and UploadUrl
            var tokenRes = JsonConvert.DeserializeObject<TokenResponse>(tokenResponse.body);

            return (tokenRes.Result.Token, tokenRes.Result.ObjectKey, tokenRes.Result.ResourceId, tokenRes.Result.Bucket);

        }



        /// <summary>
        /// check whether current file had been uploaded before
        /// </summary>
        /// <param name="ext">the extension name of file</param>
        /// <param name="md5">the md5 value of file</param>
        /// <param name="fileSize">the file length</param>
        /// <returns></returns>
        private async Task<bool> CheckIfUploadIsRequired(string ext, string md5, long fileSize)
        {
            var checkRequestModel = new UploadCheckRequestModel
            {
                Bitrate = "999000",
                Ext = ext,
                Length = fileSize,
                Md5 = md5,
                SongId = "0",
                Version = 1
            };

            var checkApiModel = new ApiModel
            {
                ApiEndpoint = "/api/cloud/upload/check",
                Data = checkRequestModel
            };



            var checkResponse = await _genericService.HandleRequestAsync(checkApiModel);
            var checkRes = JsonConvert.DeserializeObject<CheckResponse>(checkResponse.body);

            return checkRes == null ? false : checkRes.NeedUpload;
        }


        [HttpPost]
        [Route("cloud/import")]
        public async Task<IActionResult> CloudImport()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloud/upload/check/v2",
                    OptionType = "weapi",
                    Data = new CloudImportRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("cloud/match")]
        public async Task<IActionResult> CloudMatch([FromQuery]long uid, [FromQuery]long sid, [FromQuery]long asid)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloud/user/song/match",
                    OptionType = "weapi",
                    Data = new CloudMatchRequestModel()
                    {
                        UserId = uid,
                        SongId = sid,
                        AdjustSongId = asid
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
