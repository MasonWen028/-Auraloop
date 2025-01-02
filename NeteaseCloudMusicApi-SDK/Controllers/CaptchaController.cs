using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class CaptchaController : Controller
    {
        private readonly GenericService _genericService;

        public CaptchaController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("captcha/sent")]
        public async Task<IActionResult> CaptchaSent()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/sms/captcha/sent",
                    OptionType = "weapi",
                    Data = new CaptchaSentRequestModel()
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
        [Route("captcha/verify")]
        public async Task<IActionResult> CaptchaVerify()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/sms/captcha/verify",
                    OptionType = "weapi",
                    Data = new CaptchaVerifyRequestModel()
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
