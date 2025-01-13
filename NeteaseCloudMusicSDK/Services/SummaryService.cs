using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly NetEaseApiClient _client;

        public SummaryService(NetEaseApiClient client)
        {
            _client = client;
        }


        /// <summary>
        /// Fetch the annual report
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> SummaryAnnual(SummaryAnnualRequestModel requestModel)
        {
            try
            {
                string dataType = (requestModel.Year == 2017 || requestModel.Year == 2018 || requestModel.Year == 2019) ? "userdata" : "data";
                var option = new RequestOptions($"/api/activity/summary/annual/{requestModel.Year}/{dataType}");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch annual report", ex);
            }
        }
    }
}
