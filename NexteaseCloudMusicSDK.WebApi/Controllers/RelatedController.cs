using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatedController : Controller
    {
        private readonly IRelatedService _relatedService;
        private readonly RequestContext _context;

        public RelatedController(IRelatedService relatedService, RequestContext context)
        {
            _relatedService = relatedService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("allvideo")]
        public async Task<IActionResult> AllVideo([FromQuery] String id)
        {
            try
            {
                var response = await _relatedService.AllVideo(id);
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
        [HttpGet("playlist")]
        public async Task<IActionResult> Playlist([FromQuery] String id)
        {
            try
            {
                var response = await _relatedService.Playlist(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
