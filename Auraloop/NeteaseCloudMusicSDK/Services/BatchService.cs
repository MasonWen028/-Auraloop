using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class BatchService: IBatchService
    {
        private readonly NetEaseApiClient _client;

        public BatchService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Batch(BatchRequestModel requestModel)
        {
            try
            {
                var regex = new Regex(@"^\/api\/");

                // Filter dictionary
                var data = requestModel.BatchRequests
                    .Where(kv => regex.IsMatch(kv.Key))
                    .ToDictionary(kv => kv.Key, kv => kv.Value);
                var options = new RequestOptions($"/api/batch", data);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get banner ad. for home page.", ex);
            }
        }
    }
}
