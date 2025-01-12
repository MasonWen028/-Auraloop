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
    public class SheetService : ISheetService
    {
        private readonly NetEaseApiClient _client;

        public SheetService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> List(SheetListRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/music/sheet/list/v1", requestModel);
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to fetch sheet list with ID: {requestModel.Id}", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Preview(SheetPreviewRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/music/sheet/preview/info", requestModel);
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to preview sheet with ID: {requestModel.Id}", ex);
            }
        }
    }
}
