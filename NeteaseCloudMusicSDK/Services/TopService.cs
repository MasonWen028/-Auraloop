using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class TopService : ITopService
    {
        private readonly NetEaseApiClient _client;

        public TopService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch top albums
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Album(TopAlbumRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/discovery/new/albums/area", requestModel, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch top albums", ex);
            }
        }


        public Task<ApiResponse> ArtistRankings()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetch top artists by pagination
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task<ApiResponse> Artists(int limit = 100, int offset = 0)
        {
            try
            {
                var option = new RequestOptions("/api/artist/top", new { limit, offset, total = true}, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch top artists", ex);
            }
        }

        public Task<ApiResponse> Detail()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetch ranked list by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> List(long id)
        {
            try
            {
                var option = new RequestOptions("/api/playlist/v4/detail", new { id, n = 500, s = 0 });

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch ranked list by ID: {id}", ex);
            }
        }

        /// <summary>
        /// Fetch the ranked list of MV
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Mv(TopMvRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/mv/toplist", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the ranked list of MVs", ex);
            }
        }

        /// <summary>
        /// Fetch the ranked playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Playlist(TopPlaylistRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/playlist/list", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the ranked playlist", ex);
            }
        }


        /// <summary>
        /// Fetch high quality playlist ranked
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> PlaylistHighquality(TopPlaylistHighqualityRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/playlist/highquality/list", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch high quality ranked playlist", ex);
            }
        }


        /// <summary>
        /// Fetch ranked top songs
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Song(int areaId = 0)
        {
            try
            {
                var option = new RequestOptions("/api/v1/discovery/new/songs", new { areaId, total = true }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch ranked top songs", ex);
            }
        }
    }
}
