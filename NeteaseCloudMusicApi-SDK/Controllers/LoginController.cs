using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QRCoder;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {
        private readonly GenericService _genericService;

        public LoginController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/w/login",
                    OptionType = "weapi",
                    Data = new LoginRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Handles user login using their cellphone credentials.
        /// </summary>
        /// <param name="requestModel">
        /// A model containing the user's phone number, country code, and either a CAPTCHA or password for authentication.
        /// </param>
        /// <returns>
        /// An HTTP 200 response with the login details, including cookies and user data if the login is successful.
        /// An HTTP 500 response is returned if an error occurs.
        /// </returns>
        /// <remarks>
        /// This endpoint accepts the user's phone number and either a CAPTCHA or password for authentication.
        /// - If a CAPTCHA is provided, it takes precedence over the password.
        /// - The password can be provided as plain text or as an MD5 hash.
        /// - Combines cookies into a single string and modifies the JSON response to replace the `avatarImgId_str` key with `avatarImgIdStr`.
        /// </remarks>

        [HttpGet]
        [Route("login/cellphone")]
        [SwaggerOperation(
            Summary = "Login with Cellphone",
            Description = "Handles user login using their cellphone. This endpoint supports CAPTCHA or password-based authentication."
        )]
        [SwaggerResponse(200, "Successfully logged in.", typeof(object))]
        [SwaggerResponse(500, "Internal server error.")]
        public async Task<IActionResult> LoginCellphone([FromQuery] LoginCellphoneRequestModel requestModel)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/w/login/cellphone",
                    OptionType = "weapi",
                    Data = new
                    {
                        type = "1",
                        https = "true",
                        phone = requestModel.Phone,
                        countrycode = string.IsNullOrEmpty(requestModel.CountryCode) ? "86" : requestModel.CountryCode,
                        captcha = requestModel.Captcha,
                        password = !string.IsNullOrEmpty(requestModel.Captcha)
            ? requestModel.Captcha
            : !string.IsNullOrEmpty(requestModel.Md5Password)
                ? requestModel.Md5Password
                : requestModel.Password.CalculateMd5(),
                        rememberLogin = "true"
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);

                var jsonObject = JObject.Parse(result.data);

                int code = (int)jsonObject["code"];

                if (code == 200) // TODO get the code inside the data out, use it for conditional checks
                {
                    var jsonString = result.data;
                    jsonString = jsonString.Replace("avatarImgId_str", "avatarImgIdStr");
                    var modifiedBody = JsonConvert.DeserializeObject<dynamic>(jsonString);

                    // Combine cookies into a single string separated by semicolons
                    var cookieString = string.Join(";", result.cookie);

                    // Construct the updated result object
                    return Ok(new
                    {
                        status = 200,
                        body = new
                        {
                            cookie = cookieString,
                            // Include the modified body with replaced keys
                            modifiedBody
                        },
                        cookie = result.cookie
                    });
                }
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Check the State of a QR Code Login
        /// </summary>
        /// <param name="key">The unique key associated with the QR code.</param>
        /// <returns>The current state of the QR code login process, including whether the QR code has been scanned, approved, or expired.</returns>
        [HttpGet]
        [Route("login/qr/check")]
        [SwaggerOperation(
            Summary = "Check QR Code Login State",
            Description = "Checks the state of a QR code login using the provided unique key. The response includes the current status, such as whether the QR code has been scanned, approved, or expired.",
            OperationId = "CheckQrCodeLoginState",
            Tags = new[] { "Login", "QR Code" }
        )]
        [SwaggerResponse(200, "QR code login state retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Could be due to missing or invalid key.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> LoginQrCheck([FromQuery]string key)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/login/qrcode/client/login",
                    OptionType = "weapi",
                    Data = new LoginQrCheckRequestModel()
                    {
                        Key = key,
                        Type = 3
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);

                var response = new
                {
                    status = 200,
                    body = new
                    {
                        result.data,
                        cookie = string.Join(";", result.cookie) 
                    },
                    cookie = result.cookie
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Generate a QR code for login.
        /// </summary>
        /// <param name="key">The unique key used for constructing the login URL.</param>
        /// <param name="qrimg">Flag indicating whether a QR code image should be generated.</param>
        /// <returns>A response containing the login URL and optionally a QR code image.</returns>
        /// <remarks>
        /// This endpoint creates a login URL and optionally generates a QR code based on the provided key.
        /// The QR code is returned as a Base64-encoded string if the `qrimg` parameter is set to true.
        /// </remarks>
        /// <response code="200">Successfully generated the login URL and QR code (if requested).</response>
        /// <response code="500">An error occurred while processing the request.</response>
        [HttpGet]
        [Route("login/qr/create")]
        [SwaggerOperation(
            Summary = "Generate a login QR code",
            Description = "Creates a login URL and optionally generates a QR code as a Base64-encoded string."
        )]
        [SwaggerResponse(200, "Successfully generated the login URL and QR code (if requested).", typeof(object))]
        [SwaggerResponse(500, "Internal server error.")]
        public async Task<IActionResult> GenerateQrUrl([FromQuery] string key, [FromQuery] bool qrimg = false)
        {
            try
            {
                // Construct the URL
                string url = $"https://music.163.com/login?codekey={key}";

                // Generate QR code if requested
                string qrCodeImage = string.Empty;
                if (qrimg)
                {
                    qrCodeImage = await GenerateQrCodeAsync(url);
                }

                // Create the response
                var response = new
                {
                    code = 200,
                    status = 200,
                    body = new
                    {
                        code = 200,
                        data = new
                        {
                            qrurl = url,
                            qrimg = qrCodeImage
                        }
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Generates a QR code as a Base64 encoded image string for the given URL.
        /// </summary>
        /// <param name="url">The URL to encode in the QR code.</param>
        /// <returns>A Base64 encoded QR code image string.</returns>
        private async Task<string> GenerateQrCodeAsync(string url)
        {
            using var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                byte[] qrCodeImage = qrCode.GetGraphic(20);
                var base64Image = Convert.ToBase64String(qrCodeImage.ToArray());
                return $"data:image/png;base64,{base64Image}";
            }
        }

        /// <summary>
        /// Generate a Unique Key for QR Code Login
        /// </summary>
        /// <returns>A unique key (unikey) required for initiating QR code login.</returns>
        [HttpGet]
        [Route("login/qr/key")]
        [SwaggerOperation(
            Summary = "Generate Unique Key for QR Code Login",
            Description = "Creates a unikey required for generating a QR code for login. This key is used to associate the QR code with the login process.",
            OperationId = "GenerateQrLoginKey",
            Tags = new[] { "Login", "QR Code" }
        )]
        [SwaggerResponse(200, "Unique key generated successfully.", typeof(object))]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> LoginQrKey()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/login/qrcode/unikey",
                    OptionType = "weapi",
                    Data = new LoginQrKeyRequestModel()
                    {
                        Type = 3
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("login/refresh")]
        public async Task<IActionResult> LoginRefresh()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/login/token/refresh",
                    OptionType = "weapi",
                    Data = new LoginRefreshRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);

                var jsonObject = JObject.Parse(result.data);

                int code = (int)jsonObject["code"];

                if (code == 200)
                {
                    // Construct the updated result object
                    var updatedResult = new
                    {
                        status = 200, // Set the HTTP status
                        body = new
                        {
                            data = result.data // Spread the original `body` into the `data` field
                        },
                        cookie = result.cookie // Include the original cookies
                    };

                    return Ok(updatedResult);
                }

                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("login/status")]
        public async Task<IActionResult> LoginStatus()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/w/nuser/account/get",
                    OptionType = "weapi",
                    Data = new LoginStatusRequestModel()
                    {
                        
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);

                var jsonObject = JObject.Parse(result.data);

                int code = (int)jsonObject["code"];

                if (code == 200)
                {
                    // Construct the updated result object
                    var updatedResult = new
                    {
                        status = 200, // Set the HTTP status
                        body = new
                        {
                            data = result.data // Spread the original `body` into the `data` field
                        },
                        cookie = result.cookie // Include the original cookies
                    };

                    return Ok(updatedResult);
                }


                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
