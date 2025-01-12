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
    public class SigninService : ISigninService
    {
        private readonly NetEaseApiClient _client;

        public SigninService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch sigh info
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> SignHappyInfo()
        {
            try
            {
                var option = new RequestOptions("/api/sign/happy/info", null, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch sign info", ex);
            }
        }

        /// <summary>
        /// Query about the progress of sign in
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> SigninProgress(SigninProgressRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/act/modules/signin/v2/progress", requestModel, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to query about the progress of sign in with moduleId: {requestModel.ModuleId}", ex);
            }
        }
    }
}
