using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Extensions;
using NeteaseCloudMusicSDK.Models.Response;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class LoginService : ILoginService
    {
        private readonly NetEaseApiClient _client;

        public LoginService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// create qr code by url
        /// </summary>
        /// <param name="key"></param>
        /// <param name="qrimg"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GenerateQrUrl(string key, bool qrimg = false)
        {
            string url = $"https://music.163.com/login?codekey={key}";

            // Generate QR code if requested
            string qrCodeImage = string.Empty;
            if (qrimg)
            {
                qrCodeImage = await GenerateQrCodeAsync(url);
            }

            return new ApiResponse
            {
                IsSuccess = true,
                Data = new
                {
                    qrurl = url,
                    qrimg = qrCodeImage
                }
            };
        }

        /// <summary>
        /// Generates a QR code as a Base64 encoded image string for the given URL.
        /// </summary>
        /// <param name="url">The URL to encode in the QR code.</param>
        /// <returns>A Base64 encoded QR code image string.</returns>
        private async Task<string> GenerateQrCodeAsync(string url)
        {
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
                {
                    byte[] qrCodeImage = qrCode.GetGraphic(20);
                    var base64Image = Convert.ToBase64String(qrCodeImage.ToArray());
                    return $"data:image/png;base64,{base64Image}";
                }
            }
        }


        /// <summary>
        /// login by username and password, password should not be encrypted.
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Login(LoginRequestModel requestModel)
        {
            try
            {
                requestModel.Password = requestModel.Password.CalculateMd5();
                var options = new RequestOptions($"/api/w/login", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to login in by username and password.", ex);
            }
        }

        /// <summary>
        /// login by cellphone and captch/ password
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> LoginCellphone(LoginCellphoneRequestModel requestModel)
        {
            try
            {
                if (requestModel.Captch == 0)
                {
                    if (string.IsNullOrEmpty(requestModel.Password))
                    {
                        throw new ArgumentException("the field of captch and password can not be null at same time");
                    }
                    requestModel.Password = requestModel.Password.CalculateMd5();
                }
                
                var options = new RequestOptions($"/api/w/login/cellphone", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to login in by cellphone.", ex);
            }
        }

        /// <summary>
        /// check the status of current key, if it has been logged in, it will bring cookies with field like "MUSIC_U"
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> LoginQrCheck(string key)
        {
            try
            {
                var options = new RequestOptions($"/api/login/qrcode/client/login", new { 
                    key, 
                    type = 3 });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album subscription list.", ex);
            }
        }

        /// <summary>
        /// Fetch unique key for login use
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> LoginQrKey()
        {
            try
            {
                var options = new RequestOptions($"/api/login/qrcode/unikey", new
                {
                    type = 3
                });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch unique key for login", ex);
            }
        }

        /// <summary>
        /// Refresh the login token
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> LoginRefresh()
        {
            try
            {
                var options = new RequestOptions($"/api/login/token/refresh");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to refresh user token", ex);
            }
        }

        /// <summary>
        /// Fetch user login status
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> LoginStatus()
        {
            try
            {
                var options = new RequestOptions($"/api/w/nuser/account/get");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch user login status", ex);
            }
        }

        /// <summary>
        /// logout
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Logout()
        {
            try
            {
                var options = new RequestOptions($"/api/logout");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch user login status", ex);
            }
        }
    }
}
