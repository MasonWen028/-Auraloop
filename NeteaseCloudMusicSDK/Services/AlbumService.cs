using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    /// <summary>
    /// Defines methods to interact with album-related functionalities in the Netease Cloud Music API.
    /// </summary>
    public class AlbumService : IAlbumService
    {
        private readonly NetEaseApiClient _client;

        /// <summary>
        /// Defines methods to interact with album-related functionalities in the Netease Cloud Music API.
        /// </summary>
        public AlbumService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetAlbum(string id)
        {
            ValidateId(id);
            try
            {
                var options = new RequestOptions($"/api/v1/album/{id}");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get album with ID '{id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> AlbumDetail(string id)
        {
            ValidateId(id);
            try
            {
                var options = new RequestOptions($"/api/vipmall/albumproduct/detail", new { id = id }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get album details for ID '{id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> AlbumDetailDynamic(string id)
        {
            ValidateId(id);
            try
            {
                var options = new RequestOptions($"/api/album/detail/dynamic", new { id = id }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get dynamic details for album ID '{id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> AlbumList(AlbumListRequestModel requestModel)
        {
            ValidateRequestModel(requestModel);
            try
            {
                var options = new RequestOptions($"/api/vipmall/albumproduct/list", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album list.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> AlbumListStyle(AlbumListRequestModel requestModel)
        {
            ValidateRequestModel(requestModel);
            try
            {
                var options = new RequestOptions($"/api/vipmall/appalbum/album/style", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album list by style.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> AlbumNew(AlbumNewRequestModel requestModel)
        {
            ValidateRequestModel(requestModel);
            try
            {
                var options = new RequestOptions($"/api/album/new", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get new albums.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> AlbumNewest()
        {
            try
            {
                var options = new RequestOptions($"/api/discovery/newAlbum", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get the newest albums.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> AlbumPrivilege(string id)
        {
            ValidateId(id);
            try
            {
                var options = new RequestOptions($"/api/album/privilege", new { id = id }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get album privileges for ID '{id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> AlbumSongsaleboard(AlbumSongsaleboardRequestModel requestModel)
        {
            ValidateRequestModel(requestModel);
            if (requestModel.Type == "year" && !requestModel.Year.HasValue)
            {
                requestModel.Year = DateTime.Now.Year;
            }
            try
            {
                var options = new RequestOptions($"/api/feealbum/songsaleboard/{requestModel.Type}/type", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album songsaleboard.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> AlbumSub(int t, string id)
        {
            ValidateId(id);
            if (t < 0)
            {
                throw new ArgumentException("Parameter 't' must be a non-negative integer.", nameof(t));
            }
            try
            {
                string type = t == 1 ? "sub" : "unsub";

                var options = new RequestOptions($"/api/album/{type}", new { id = id }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to subscribe to album with ID '{id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> AlbumSublist(AlbumSublistRequestModel requestModel)
        {
            ValidateRequestModel(requestModel);
            try
            {
                var options = new RequestOptions($"/api/album/sublist", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album subscription list.", ex);
            }
        }

        // Validation Helpers

        private void ValidateId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or empty.", nameof(id));
            }
            if (!long.TryParse(id, out _))
            {
                throw new ArgumentException("ID must be a valid numeric value.", nameof(id));
            }
        }

        private void ValidateRequestModel(object requestModel)
        {
            if (requestModel == null)
            {
                throw new ArgumentException("Request model cannot be null.", nameof(requestModel));
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetAlbumsByArtist(ArtistAlbumRequestModel requestModel)
        {
            if (requestModel.ArtistId == 0)
            {
                throw new ArgumentException("Artist Id can not be 0.", nameof(requestModel));
            }

            try
            {
                var options = new RequestOptions($"/api/artist/albums/{requestModel.ArtistId}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album subscription list.", ex);
            }
        }
    }
}
