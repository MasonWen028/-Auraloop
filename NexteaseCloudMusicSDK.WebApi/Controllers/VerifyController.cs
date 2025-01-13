using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerifyController : Controller
    {
        private readonly IVerifyService _verifyService;
        private readonly RequestContext _context;

        public VerifyController(IVerifyService verifyService, RequestContext context)
        {
            _verifyService = verifyService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("checkqrcodestatus")]
        public async Task<IActionResult> CheckQrCodeStatus([FromQuery] String qrCode)
        {
            try
            {
                var response = await _verifyService.CheckQrCodeStatus(qrCode);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
