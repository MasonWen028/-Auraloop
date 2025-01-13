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
    public class VerifyService : IVerifyService
    {
        private readonly NetEaseApiClient _client;

        public VerifyService(NetEaseApiClient client)
        {  
            _client = client; 
        }

        /// <summary>
        /// Check the status of qr code key
        /// </summary>
        /// <param name="qrCode"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> CheckQrCodeStatus(string qrCode)
        {
            try
            {
                var option = new RequestOptions("/api/frontrisk/verify/qrcodestatus", new { qrCode }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to verify the qr code: {qrCode}", ex);
            }
        }
    }
}
