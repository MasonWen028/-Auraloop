using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThresholdController : Controller
    {
        private readonly IThresholdService _thresholdService;
        private readonly RequestContext _context;

        public ThresholdController(IThresholdService thresholdService, RequestContext context)
        {
            _thresholdService = thresholdService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("detail")]
        public async Task<IActionResult> ThresholdDetailGet()
        {
            try
            {
                var response = await _thresholdService.ThresholdDetailGet();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
