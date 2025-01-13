using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SigninController : Controller
    {
        private readonly ISigninService _signinService;
        private readonly RequestContext _context;

        public SigninController(ISigninService signinService, RequestContext context)
        {
            _signinService = signinService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("progress")]
        public async Task<IActionResult> SigninProgress([FromBody] SigninProgressRequestModel requestModel)
        {
            try
            {
                var response = await _signinService.SigninProgress(requestModel);
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
        [HttpGet("signhappyinfo")]
        public async Task<IActionResult> SignHappyInfo()
        {
            try
            {
                var response = await _signinService.SignHappyInfo();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
