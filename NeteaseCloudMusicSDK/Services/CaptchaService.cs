using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class CaptchaService: ICaptchaService
    {
        private readonly NetEaseApiClient _client;

        public CaptchaService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> CaptchaSent(long Phone, int Ctcode = 86)
        {
            try
            {
                var options = new RequestOptions($"/api/sms/captcha/sent", new { ctcode = Ctcode, cellphone = Phone });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send captch to number: {Phone}.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> CaptchaVerify(CaptchaVerifyRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/sms/captcha/verify", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to verify captch number: {requestModel.Cellphone}, captch: {requestModel.Captcha}.", ex);
            }
        }
    }
}
