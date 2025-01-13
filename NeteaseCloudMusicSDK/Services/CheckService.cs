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
    public class CheckService: ICheckService
    {
        private readonly NetEaseApiClient _client;

        public CheckService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        /// TODO verify the response, get playable data from  body.data[0].code == 200
        public async Task<ApiResponse> CheckMusic(CheckMusicRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/song/enhance/player/url");

                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to check music playable with ID '{requestModel.MusicId}'.", ex);
            }
        }
    }
}
