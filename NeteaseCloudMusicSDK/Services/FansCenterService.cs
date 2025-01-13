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
    public class FansCenterService: IFansCenterService
    {
        private readonly NetEaseApiClient _client;


        public FansCenterService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetAgeDistribution()
        {
            try
            {
                var options = new RequestOptions($"/api/fanscenter/basicinfo/age/get");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get age distribution.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetGenderDistribution()
        {
            try
            {
                var options = new RequestOptions($"/api/fanscenter/basicinfo/gender/get");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get gender distribution.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetOverview()
        {
            try
            {
                var options = new RequestOptions($"/api/fanscenter/overview/get");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get fans overview.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetProvinceDistribution()
        {
            try
            {
                var options = new RequestOptions($"/api/fanscenter/basicinfo/province/get");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get fans overview.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetTrendList(FansCenterTrendRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/fanscenter/trend/list", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get fans overview.", ex);
            }
        }
    }
}
