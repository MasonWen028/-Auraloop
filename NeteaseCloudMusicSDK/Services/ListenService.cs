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
    public class ListenService: IListenService
    {
        private readonly NetEaseApiClient _client;

        public ListenService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> RealtimeReport(ListenDataRealtimeReportRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/content/activity/listen/data/realtime/report", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get listening foot print for {requestModel.Type}", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Report(ListenDataReportRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/content/activity/listen/data/realtime/report", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get listening foot print for {requestModel.Type}", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> TodaySongs()
        {
            try
            {
                var options = new RequestOptions($"/api/content/activity/listen/data/today/song/play/rank");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get listening foot print for today", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Total()
        {
            try
            {
                var options = new RequestOptions($"/api/content/activity/listen/data/total");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get listening total hours", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> YearReport()
        {
            try
            {
                var options = new RequestOptions($"/api/content/activity/listen/data/year/report");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get annual report", ex);
            }
        }
    }
}
