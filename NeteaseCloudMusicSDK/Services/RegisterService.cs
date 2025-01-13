using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Extensions;
using NeteaseCloudMusicSDK.Models.Response;
using NeteaseCloudMusicSDK.Utils;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly NetEaseApiClient _client;

        public RegisterService(NetEaseApiClient client)
        {
            _client = client;
        }

       
        /// <inheritdoc />
        public async Task<ApiResponse> RegisterAnonymous()
        {

            try
            {
                string deviceId = Guid.NewGuid().ToString("N");
                string encodedId = CryptoUtils.CloudMusicDllEncodeId(deviceId);
                var strToBase64 = (deviceId + encodedId).ToBase64Str();
                var option = new RequestOptions("", new { username = strToBase64 }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to register an anonymous account", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> RegisterCellphone(RegisterCellphoneRequestModel requestModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(requestModel.Password))
                {
                    requestModel.Password = requestModel.Password.CalculateMd5();
                }

                var option = new RequestOptions("/api/register/cellphone", requestModel);

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to register an account with phone: {requestModel.Phone}", ex);
            }
        }
    }
}
