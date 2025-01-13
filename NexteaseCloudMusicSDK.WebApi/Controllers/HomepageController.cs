using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomepageController : Controller
    {
        private readonly IHomepageService _homepageService;
        private readonly RequestContext _context;

        public HomepageController(IHomepageService homepageService, RequestContext context)
        {
            _homepageService = homepageService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("blockpage")]
        public async Task<IActionResult> GetBlockPage([FromBody] HomepageBlockPageRequestModel requestModel)
        {
            try
            {
                var response = await _homepageService.GetBlockPage(requestModel);
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
        [HttpGet("dragonball")]
        public async Task<IActionResult> GetDragonBall()
        {
            try
            {
                var response = await _homepageService.GetDragonBall();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
