using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimiController : Controller
    {
        private readonly ISimiService _simiService;
        private readonly RequestContext _context;

        public SimiController(ISimiService simiService, RequestContext context)
        {
            _simiService = simiService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("artist")]
        public async Task<IActionResult> Artist([FromQuery] Int64 artistId)
        {
            try
            {
                var response = await _simiService.Artist(artistId);
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
        [HttpGet("mv")]
        public async Task<IActionResult> Mv([FromQuery] Int64 mvId)
        {
            try
            {
                var response = await _simiService.Mv(mvId);
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
        [HttpPost("playlist")]
        public async Task<IActionResult> Playlist([FromBody] SimiPlaylistRequestModel requestModel)
        {
            try
            {
                var response = await _simiService.Playlist(requestModel);
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
        [HttpPost("song")]
        public async Task<IActionResult> Song([FromBody] SimiSongRequestModel requestModel)
        {
            try
            {
                var response = await _simiService.Song(requestModel);
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
        [HttpPost("user")]
        public async Task<IActionResult> User([FromBody] SimiUserRequestModel requestModel)
        {
            try
            {
                var response = await _simiService.User(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
