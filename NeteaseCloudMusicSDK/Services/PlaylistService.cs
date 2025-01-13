using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly NetEaseApiClient _client;

        public PlaylistService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetcth the category list for playlist
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Catlist()
        {
            try
            {
                var options = new RequestOptions($"/api/playlist/catalogue", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album subscription list.", ex);
            }
        }

        /// <summary>
        /// Update the cover image of owned playlist 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> CoverUpdate(PlaylistCoverUpdateRequestModel requestModel)
        {
            try
            {
                var uploadInfo = await UploadFileAsync(requestModel.ImgFile, requestModel.ImgFileName);

                var options = new RequestOptions("/api/playlist/cover/update", new { id = requestModel.PlaylistId, coverImgId = uploadInfo }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update targeted playlist with ID: {requestModel.PlaylistId}.", ex);
            }
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name="imageData"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> UploadFileAsync(byte[] imageData, string fileName)
        {
            // Step 1: Get key and token
            var tokenRequestData = new
            {
                bucket = "yyimgs",
                ext = "jpg",
                filename = fileName,
                local = false,
                nos_product = 0,
                return_body = "{\"code\":200,\"size\":\"$(ObjectSize)\"}",
                type = "other"
            };

            var tokenOption = new RequestOptions(
                "/api/nos/token/alloc",
                tokenRequestData);


            var tokenResponse = await _client.HandleRequestAsync(tokenOption);

            if (!tokenResponse.IsSuccess)
            {
                throw new Exception("Failed to allocate token for image upload.");
            }

            var result = tokenResponse.Data;


            // Step 2: Upload the image
            using (var imageContent = new ByteArrayContent(imageData))
            {
                var resultJobj = JObject.Parse(result.ToString());
                var token = resultJobj["token"].ToString();
                var objectKey = resultJobj["objectKey"].ToString();
                var docId = resultJobj["docId"].ToString();
                imageContent.Headers.Add("x-nos-token", token);
                imageContent.Headers.Add("Content-Type", "image/jpeg");

                var uploadUrl = $"https://nosup-hz1.127.net/yyimgs/{objectKey}?offset=0&complete=true&version=1.0";
                var uploadResponse = await _client.PostAsync(uploadUrl, imageContent);

                if (!uploadResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to upload image.");
                }

                return docId;
            }
        }

        /// <summary>
        /// Create playlist by current user
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Create(PlaylistCreateRequestModel requestModel)
        {

            try
            {
                var options = new RequestOptions("/api/playlist/create", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create playlist named {requestModel.Name} .", ex);
            }
        }

        /// <summary>
        /// Delete playlist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Delete(string id)
        {
            try
            {
                var options = new RequestOptions("/api/playlist/remove", new { ids = $"[{id}]"  }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete playlist with ID: {id} .", ex);
            }
        }

        /// <summary>
        /// Update the description for playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> DescUpdate(PlaylistDescUpdateRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions("/api/playlist/remove", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to Update desciption of playlist with ID: {requestModel.PlaylistId} .", ex);
            }
        }

        /// <summary>
        /// Fetch dynamic of playlist
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subscriberLimit"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> DetailDynamic(long id, int subscriberLimit = 8)
        {
            try
            {
                var options = new RequestOptions("/api/playlist/detail/dynamic", new {id, s = subscriberLimit, n = 100000});
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch dynamic of playlist with ID: {id} .", ex);
            }
        }

        /// <summary>
        /// Fetch recommended playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> DetailRcmdGet(PlaylistDetailRcmdRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions("/api/playlist/detail/rcmd/get", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch recommended playlists of playlist with ID: {requestModel.PlaylistId} .", ex);
            }
        }

        /// <summary>
        /// Fetch high quality tags for playlist
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> HighqualityTags()
        {
            try
            {
                var options = new RequestOptions("/api/playlist/highquality/tags", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch high quality tags for playlist.", ex);
            }
        }


        /// <summary>
        /// Fetch hot categories of playlist
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Hot()
        {
            try
            {
                var options = new RequestOptions("/api/playlist/hottags", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch hot categories of playlist.", ex);
            }
        }

        /// <summary>
        /// Import playlist by data/text/link
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> ImportNameTaskCreate(PlaylistImportNameTaskRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions("/api/playlist/import/name/task/create", ImportPlaylistDataProcess(requestModel), "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to import playlist.", ex);
            }
        }

        /// <summary>
        /// Process the data for importing a playlist
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        private static ImportPlaylistParameter ImportPlaylistDataProcess(PlaylistImportNameTaskRequestModel queryModel)
        {
            var data = new ImportPlaylistParameter
            {
                ImportStarPlaylist = queryModel.ImportStarPlaylist
            };

            if (!string.IsNullOrEmpty(queryModel.Local))
            {
                var local = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(queryModel.Local);
                data.MultiSongs = Newtonsoft.Json.JsonConvert.SerializeObject(
                    local.Select(e => new
                    {
                        SongName = e.name,
                        ArtistName = e.artist,
                        AlbumName = e.album
                    })
                );
            }
            else
            {
                var playlistName = queryModel.PlaylistName ?? "导入音乐 " + DateTime.Now.ToString("g");
                var songs = string.Empty;

                if (!string.IsNullOrEmpty(queryModel.Text))
                {
                    songs = Newtonsoft.Json.JsonConvert.SerializeObject(new[]
                    {
                    new
                    {
                        Name = playlistName,
                        Type = string.Empty,
                        Url = $"rpc://playlist/import?text={Uri.EscapeUriString(queryModel.Text)}"
                    }
                });
                }
                else if (!string.IsNullOrEmpty(queryModel.Link))
                {
                    var links = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(queryModel.Link);
                    songs = Newtonsoft.Json.JsonConvert.SerializeObject(
                        links.Select(e => new
                        {
                            Name = playlistName,
                            Type = string.Empty,
                            Url = Uri.EscapeUriString(e)
                        })
                    );
                }

                data.PlaylistName = playlistName;
                data.CreateBusinessCode = null;
                data.ExtParam = null;
                data.TaskIdForLog = string.Empty;
                data.Songs = songs;
            }

            return data;
        }


        /// <summary>
        /// Fetch the playlist liked
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> MyLike(PlaylistMyLikeRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions("/api/mlog/playlist/mylike/bytime/get", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch liked playlist.", ex);
            }
        }

        /// <summary>
        /// Update the name of playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> NameUpdate(PlaylistNameUpdateRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions("/api/playlist/update/name", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update the name of playlist.", ex);
            }
        }


        /// <summary>
        /// Edit the showing order of playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> OrderUpdate(PlaylistOrderUpdateRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions("/api/playlist/order/update", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update the name of playlist.", ex);
            }
        }

        /// <summary>
        /// Fetch the status of playlist import task
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> PlaylistImportTaskStatus(long id)
        {
            try
            {
                var options = new RequestOptions("/api/playlist/order/update", new { taskIds = $"[{id}]" });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the status of playlist import task.", ex);
            }
        }

        /// <summary>
        /// Publish current privacy playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Privacy(PlaylistPrivacyRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions("/api/playlist/update/privacy", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the status of playlist import task.", ex);
            }
        }


        /// <summary>
        /// Sub and Unsub playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Subscribe(PlaylistSubscribeRequestModel requestModel)
        {
            string subOrNot = requestModel.Operation == 1 ? "subscribe" : "unsubscribe";
            try
            {
                var options = new RequestOptions($"/api/playlist/{subOrNot}", new { id = requestModel.PlaylistId });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to {subOrNot}  playlist.", ex);
            }
        }

        /// <summary>
        /// Fetch subsribers for playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Subscribers(PlaylistSubscribersRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/playlist/subscribers", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch subsribers for  playlist with ID: {requestModel.PlaylistId}.", ex);
            }
        }

        /// <summary>
        /// Update the tags of playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> TagsUpdate(PlaylistTagsUpdateRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/playlist/subscribers", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update the tags of playlist.", ex);
            }
        }


        /// <summary>
        /// Fetch details of playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Detail(PlaylistDetailRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/v6/playlist/detail", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch details of playlist.", ex);
            }
        }

        /// <summary>
        /// Add tracks into playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> TrackAdd(PlaylistTrackAddRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/playlist/track/add", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add tracks into playlist.", ex);
            }
        }

        /// <summary>
        /// Fetch all songs in playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> TrackAll(PlaylistTrackAllRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/v6/playlist/detail", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch songs from playlist with ID: {requestModel.PlaylistId}", ex);
            }
        }

        /// <summary>
        /// Remove songs from playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> TrackDelete(PlaylistTrackAddRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/playlist/track/delete", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to remove tracks into playlist.", ex);
            }
        }

        public Task<ApiResponse> TracksManipulate(PlaylistTracksManipulateRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Update(PlaylistUpdateRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update the play count for playlist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> UpdatePlaycount(long id)
        {
            try
            {
                var options = new RequestOptions($"/api/playlist/update/playcount", new { id });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to remove tracks into playlist.", ex);
            }
        }

        /// <summary>
        /// Fetch video added recently
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> VideoRecent()
        {
            try
            {
                var options = new RequestOptions($"/api/playlist/update/playcount", null, "weapi"); 
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to remove tracks into playlist.", ex);
            }
        }
    }
}
