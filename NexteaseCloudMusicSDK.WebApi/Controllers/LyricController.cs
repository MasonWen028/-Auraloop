using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LyricController : Controller
    {
        private readonly ILyricService _lyricService;
        private readonly RequestContext _context;

        public LyricController(ILyricService lyricService, RequestContext context)
        {
            _lyricService = lyricService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("s")]
        public async Task<IActionResult> GetLyrics([FromQuery] Int64 songId)
        {
            try
            {
                var response = await _lyricService.GetLyrics(songId);
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
        [HttpGet("advanceds")]
        public async Task<IActionResult> GetAdvancedLyrics([FromQuery] Int64 songId)
        {
            try
            {
                var response = await _lyricService.GetAdvancedLyrics(songId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
