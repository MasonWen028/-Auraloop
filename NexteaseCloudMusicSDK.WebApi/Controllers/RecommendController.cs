using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecommendController : Controller
    {
        private readonly IRecommendService _recommendService;
        private readonly RequestContext _context;

        public RecommendController(IRecommendService recommendService, RequestContext context)
        {
            _recommendService = recommendService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("resource")]
        public async Task<IActionResult> Resource()
        {
            try
            {
                var response = await _recommendService.Resource();
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
        [HttpGet("songs")]
        public async Task<IActionResult> Songs()
        {
            try
            {
                var response = await _recommendService.Songs();
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
        [HttpPost("songsdislike")]
        public async Task<IActionResult> SongsDislike([FromBody] RecommendSongsDislikeRequestModel requestModel)
        {
            try
            {
                var response = await _recommendService.SongsDislike(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
