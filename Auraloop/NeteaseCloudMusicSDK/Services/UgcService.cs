using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class UgcService : IUgcService
    {
        private readonly NetEaseApiClient _client;

        public UgcService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch brief introduction of album
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> AlbumGet(long albumId)
        {
            try
            {
                var option = new RequestOptions("/api/rep/ugc/album/get", new { albumId });
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch brief introduction of album with ID: {albumId}", ex);
            }
        }

        /// <summary>
        /// Fetch brief introduction for artist
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> ArtistGet(long artistId)
        {
            try
            {
                var option = new RequestOptions("/api/rep/ugc/artist/get", new
                {
                    artistId
                });

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch brief introduction for artist with ID: {artistId}", ex);
            }
        }

        /// <summary>
        /// Search artist by Id or keyword
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> ArtistSearch(UgcArtistSearchRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/rep/ugc/artist/search", requestModel);

                return await _client.HandleRequestAsync(option);

            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to search aritist by id or keyword with model: {JsonConvert.SerializeObject(requestModel)}", ex);
            }
        }

        /// <summary>
        /// Fetch the list of content contribute by user
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Detail(UgcDetailRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/rep/ugc/detail", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch content list by user with model: {JsonConvert.SerializeObject(requestModel)}", ex);
            }
        }

        /// <summary>
        /// Fetch MV brief introduction
        /// </summary>
        /// <param name="mvId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> MvGet(long mvId)
        {
            try
            {
                var option = new RequestOptions("/api/rep/ugc/mv/get", new { mvId });

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch brief introduction of MV with ID: {mvId}", ex);
            }
        }

        /// <summary>
        /// Fetch song brief introduction
        /// </summary>
        /// <param name="songId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> SongGet(long songId)
        {
            try
            {
                var option = new RequestOptions("/api/rep/ugc/song/get", new { songId });

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch song brief introdution with ID: {songId}", ex);
            }
        }

        /// <summary>
        /// Fetch the point, Yunbei count claimed by user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> UserDevote()
        {
            try
            {
                var option = new RequestOptions("/api/rep/ugc/user/devote");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the point, Yunbei count claimed by user", ex);
            }
        }
    }
}
