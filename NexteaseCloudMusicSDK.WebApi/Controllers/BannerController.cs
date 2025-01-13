using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly RequestContext _context;

        public BannerController(IBannerService bannerService, RequestContext context)
        {
            _bannerService = bannerService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("s")]
        public async Task<IActionResult> GetBanners([FromQuery] String clientType)
        {
            try
            {
                var response = await _bannerService.GetBanners(clientType);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
