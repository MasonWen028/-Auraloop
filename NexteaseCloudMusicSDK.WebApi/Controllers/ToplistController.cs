using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToplistController : Controller
    {
        private readonly IToplistService _toplistService;
        private readonly RequestContext _context;

        public ToplistController(IToplistService toplistService, RequestContext context)
        {
            _toplistService = toplistService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("")]
        public async Task<IActionResult> Toplist()
        {
            try
            {
                var response = await _toplistService.Toplist();
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
        [HttpPost("artist")]
        public async Task<IActionResult> ToplistArtist([FromBody] ToplistArtistRequestModel requestModel)
        {
            try
            {
                var response = await _toplistService.ToplistArtist(requestModel);
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
        [HttpGet("detail")]
        public async Task<IActionResult> ToplistDetail()
        {
            try
            {
                var response = await _toplistService.ToplistDetail();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
