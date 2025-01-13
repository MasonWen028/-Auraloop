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
    public class CalendarService: ICalendarService
    {
        private readonly NetEaseApiClient _client;

        public CalendarService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetCalendarDetails(CalendarRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/mcalendar/detail", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get calendar.", ex);
            }
        }
    }
}
