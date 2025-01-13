using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using NeteaseCloudMusicSDK.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class ArtistService: IArtistService
    {
        private readonly NetEaseApiClient _client;

        /// <summary>
        /// Defines methods to interact with album-related functionalities in the Netease Cloud Music API.
        /// </summary>
        public ArtistService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetArtistDescription(long artistId)
        {
            if (artistId <= 0)
            {
                throw new Exception($"Artist id can not lower than 1.");
            }
            try
            {
                var options = new RequestOptions($"/api/artist/introduction", new { id = artistId });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get artist with ID '{artistId}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetArtistDetails(long artistId)
        {
            if (artistId <= 0)
            {
                throw new Exception($"Artist id can not lower than 1.");
            }
            try
            {
                var options = new RequestOptions($"/api/artist/head/info/get", new { id = artistId });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get artist with ID '{artistId}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetArtistFansCount(long artistId)
        {
            if (artistId <= 0)
            {
                throw new Exception($"Artist id can not lower than 1.");
            }
            try
            {
                var options = new RequestOptions($"/api/artist/follow/count/get", new { id = artistId });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get artist with ID '{artistId}'.", ex);
            }
        } 

        /// <inheritdoc/>
        public async Task<ApiResponse> GetArtistMVs(long artistId, int limit = 50, int offset = 0)
        {

            if (artistId <= 0)
            {
                throw new Exception($"Artist id can not lower than 1.");
            }
            try
            {
                var options = new RequestOptions($"/api/artist/mvs", new ArtistMvRequestModel {
                    ArtistId = artistId,
                    Limit = limit,
                    Offset = offset
                });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get artist with ID '{artistId}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetArtistVideos(ArtistVideoRequestModel requestModel)
        {
            if (requestModel.ArtistId <= 0)
            {
                throw new Exception($"Artist id can not lower than 1.");
            }

            try
            {
                var options = new RequestOptions($"/api/mlog/artist/video", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get artist videos with request '{requestModel.ArtistId}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetDynamicArtistDetails(long artistId)
        {
            if (artistId <= 0)
            {
                throw new Exception($"Artist id can not lower than 1.");
            }
            try
            {
                var options = new RequestOptions($"/api/artist/detail/dynamic", new
                {
                    id = artistId
                });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get artist with ID '{artistId}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetFilteredArtists(ArtistListRequestModel requestModel)
        {
            try
            {
                requestModel.Initial = requestModel.Initial.ProcessInitial();
                var options = new RequestOptions($"/api/v1/artist/list", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get artist list by '{JsonConvert.SerializeObject(requestModel)}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetNewMVs(ArtistNewMvRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/sub/artist/new/works/mv/list", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get artist list by '{JsonConvert.SerializeObject(requestModel)}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetNewSongsByArtist(ArtistNewSongRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions("/api/sub/artist/new/works/song/list", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get artist list by '{JsonConvert.SerializeObject(requestModel)}'.", ex);
            }
        }


        /// <inheritdoc/>
        public async Task<ApiResponse> GetSongsByArtist(ArtistSongsRequestModel requestModel)
        {
            if (requestModel.ArtistId <= 0)
            {
                throw new Exception($"Artist id can not lower than 1.");
            }
            try
            {
                var options = new RequestOptions("/api/v1/artist/songs", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get song list of an artist by '{JsonConvert.SerializeObject(requestModel)}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetTopSongsByArtist(long artistId)
        {
            if (artistId <= 0)
            {
                throw new Exception($"Artist id can not lower than 1.");
            }
            try
            {
                var options = new RequestOptions("/api/artist/top/song", new {  id = artistId});
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get artist list by '{artistId}'.", ex);
            }
        }
    }
}
