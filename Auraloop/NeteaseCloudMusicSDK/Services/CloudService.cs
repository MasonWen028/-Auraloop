using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class CloudService: ICloudService
    {
        private readonly NetEaseApiClient _client;
        public CloudService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> ImportSongs(SongImportRequestModel requestModel)
        {
            requestModel.Id = requestModel.Id ?? -2;
            requestModel.Artist = string.IsNullOrEmpty(requestModel.Artist) ? "未知" : requestModel.Artist;
            requestModel.Album = string.IsNullOrEmpty(requestModel.Album) ? "未知" : requestModel.Album;

            var checkData = new
            {
                uploadType = 0,
                songs = JsonConvert.SerializeObject(new[]
                {
                    new
                    {
                        md5 = requestModel.Md5,
                        songId = requestModel.Id,
                        bitrate = requestModel.Bitrate,
                        fileSize = requestModel.FileSize
                    }
                })
            };
            var checkOption = new RequestOptions("/api/cloud/upload/check/v2", checkData);

            var checkResponse = await _client.HandleRequestAsync(checkOption);

            if (checkResponse?.StatusCode != 200 || checkResponse.Data == null)
            {
                return new ApiResponse
                {
                    StatusCode = checkResponse?.StatusCode ?? 500,
                    ErrorMessage = "Failed to check upload status."
                };
            }
            var checkObj = JObject.Parse(checkResponse.Data.ToString());

            var songData = checkObj["Data"].FirstOrDefault();
            if (songData != null)
            {
                var songUploadable = (int)songData["Upload"] != 2;

                if (!songUploadable) // Cannot import
                {
                    return new ApiResponse
                    {
                        StatusCode = 400,
                        ErrorMessage = "File cannot be imported."
                    };
                }
                var songId = (long)songData["SongId"];

                var importData = new
                {
                    uploadType = 0,
                    songs = JsonConvert.SerializeObject(new[]
                    {
                        new
                        {
                            songId = songId,
                            bitrate = requestModel.Bitrate,
                            song = requestModel.Song,
                            artist = requestModel.Artist,
                            album = requestModel.Album,
                            fileName = $"{requestModel.Song}.{requestModel.FileType}"
                        }
                    })
                };

                var uploadOption = new RequestOptions("/api/cloud/user/song/import", importData);

                return await _client.HandleRequestAsync(uploadOption);
            }

            return new ApiResponse
            {
                StatusCode = 500,
                ErrorMessage = "Failed to import songs for cloud."
            };
        }

        /// <inheritdoc/>
        public Task<ApiResponse> MatchSong(SongMatchRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ApiResponse> Search(CloudSearchRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<ApiResponse> UploadSong(SongUploadRequestModel requestModel)
        {
            throw new NotImplementedException();
        }
    }
}
