using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

        public Task<ApiResponse> HighqualityTags()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Hot()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> ImportNameTaskCreate(PlaylistImportNameTaskRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> MyLike(PlaylistMyLikeRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> NameUpdate(PlaylistNameUpdateRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> OrderUpdate(PlaylistOrderUpdateRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> PlaylistImportTaskStatus(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Privacy(PlaylistPrivacyRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Subscribe(PlaylistSubscribeRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Subscribers(PlaylistSubscribersRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> TagsUpdate(PlaylistTagsUpdateRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> tDetail(PlaylistDetailRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> TrackAdd(PlaylistTrackAddRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> TrackAll(PlaylistTrackAllRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> TrackDelete(PlaylistTrackDeleteRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> TracksManipulate(PlaylistTracksManipulateRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Update(PlaylistUpdateRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdatePlaycount(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> VideoRecent()
        {
            throw new NotImplementedException();
        }
    }
}
