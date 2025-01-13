using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaptchaController : Controller
    {
        private readonly ICaptchaService _captchaService;
        private readonly RequestContext _context;

        public CaptchaController(ICaptchaService captchaService, RequestContext context)
        {
            _captchaService = captchaService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("sent")]
        public async Task<IActionResult> CaptchaSent([FromQuery] Int64 Phone, Int32 Ctcode)
        {
            try
            {
                var response = await _captchaService.CaptchaSent(Phone, Ctcode);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("verify")]
        public async Task<IActionResult> CaptchaVerify([FromBody] CaptchaVerifyRequestModel requestModel)
        {
            try
            {
                var response = await _captchaService.CaptchaVerify(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
