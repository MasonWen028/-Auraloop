using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [Route("login/cellphone")]
        public async Task<IActionResult> LoginCellphone()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/w/login/cellphone",
                    OptionType = "weapi",
                    Data = new LoginCellphoneRequestModel()
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

        [HttpPost]
        [Route("login/qr/check")]
        public async Task<IActionResult> LoginQrCheck()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/login/qrcode/client/login",
                    OptionType = "weapi",
                    Data = new LoginQrCheckRequestModel()
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

        [HttpPost]
        [Route("login/qr/create")]
        public async Task<IActionResult> LoginQrCreate()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "https://music.163.com/login?codekey=${query.key}",
                    OptionType = "",
                    Data = new LoginQrCreateRequestModel()
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

        [HttpPost]
        [Route("login/qr/key")]
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

        [HttpPost]
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
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
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
    }
}
