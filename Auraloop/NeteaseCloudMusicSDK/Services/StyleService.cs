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
    public class StyleService : IStyleService
    {
        private readonly NetEaseApiClient _client;

        public StyleService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch albums by tag id with pagination
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Album(StyleRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/style-tag/home/album", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch albums by tag with ID: {requestModel.TagId}", ex);
            }
        }

        /// <summary>
        /// Fetch aritists by tag id with pagination
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Artist(StyleRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/style-tag/home/artist", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch artists by tag with ID: {requestModel.TagId}", ex);
            }
        }

        /// <summary>
        /// Fetch details of a style
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Detail(long tagId)
        {
            try
            {
                var option = new RequestOptions("/api/style-tag/home/head", new { tagId }, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch details by tag with ID: {tagId}", ex);
            }
        }


        /// <summary>
        /// Fetch all style tags
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> List()
        {
            try
            {
                var option = new RequestOptions("/api/tag/list/get", null, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch style tags", ex);
            }
        }


        /// <summary>
        /// Fetch playlists by tag id
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Playlist(StyleRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/style-tag/home/playlist", requestModel, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch playlist by tag with ID: {requestModel.TagId}", ex);
            }
        }

        /// <summary>
        /// Fetch the prefered style tags
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Preference()
        {
            try
            {
                var option = new RequestOptions("/api/tag/my/preference/get", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch prefered style tags", ex);
            }
        }


        /// <summary>
        /// Fetch songs of style tag
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Song(StyleRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/style-tag/home/song", requestModel, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch songs of tag with ID: {requestModel.TagId}", ex);
            }
        }
    }
}
