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
    public class PersonalizedService : IPersonalizedService
    {
        private readonly NetEaseApiClient _client;

        public PersonalizedService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch recommended FM
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Djprogram()
        {
            try
            {
                var options = new RequestOptions($"/api/personalized/djprogram", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch recommended FM", ex);
            }
        }

        //TODO 
        public Task<ApiResponse> GetRecommendations(PersonalizedRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetch recommended MV
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Mv()
        {
            try
            {
                var options = new RequestOptions($"/api/personalized/mv", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch recommended MV", ex);
            }
        }

        /// <summary>
        /// Fetch newsong for current user
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Newsong(PersonalizedNewsongRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/personalized/newsong", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch newsong for current user", ex);
            }
        }

        /// <summary>
        /// Fetch personal radios
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> PersonalFm()
        {
            try
            {
                var options = new RequestOptions($"/api/v1/radio/get", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch personal radios.", ex);
            }
        }

        /// <summary>
        /// Set the radio model for current user
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> PersonalFmMode(PersonalFmModeRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/radio/get", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to set personal radios mode.", ex);
            }
        }

        /// <summary>
        /// Fetch specialized content for current user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Privatecontent()
        {
            try
            {
                var options = new RequestOptions($"/api/personalized/privatecontent", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch specialized content for current user", ex);
            }
        }

        /// <summary>
        /// Fetch specialized content list for current user
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> PrivatecontentList(PersonalizedPrivatecontentListRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/v2/privatecontent/list", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch specialized content for current user", ex);
            }
        }
    }
}
