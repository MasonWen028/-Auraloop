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
    public class ShareService : IShareService
    {
        private readonly NetEaseApiClient _client;

        public ShareService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Share resource
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Resource(ShareResourceRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/share/friends/resource", requestModel);
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to share resource with ID: {requestModel.ResourceId}", ex);
            }
        }
    }
}
