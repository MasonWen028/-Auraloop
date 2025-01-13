using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;
        private readonly RequestContext _context;

        public RegisterController(IRegisterService registerService, RequestContext context)
        {
            _registerService = registerService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("anonymous")]
        public async Task<IActionResult> RegisterAnonymous()
        {
            try
            {
                var response = await _registerService.RegisterAnonymous();
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
        [HttpPost("cellphone")]
        public async Task<IActionResult> RegisterCellphone([FromBody] RegisterCellphoneRequestModel requestModel)
        {
            try
            {
                var response = await _registerService.RegisterCellphone(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
