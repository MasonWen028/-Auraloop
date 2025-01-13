using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StyleController : Controller
    {
        private readonly IStyleService _styleService;
        private readonly RequestContext _context;

        public StyleController(IStyleService styleService, RequestContext context)
        {
            _styleService = styleService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("album")]
        public async Task<IActionResult> Album([FromBody] StyleRequestModel requestModel)
        {
            try
            {
                var response = await _styleService.Album(requestModel);
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
        public async Task<IActionResult> Artist([FromBody] StyleRequestModel requestModel)
        {
            try
            {
                var response = await _styleService.Artist(requestModel);
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
        public async Task<IActionResult> Detail([FromQuery] Int64 tagId)
        {
            try
            {
                var response = await _styleService.Detail(tagId);
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
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                var response = await _styleService.List();
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
        public async Task<IActionResult> Playlist([FromBody] StyleRequestModel requestModel)
        {
            try
            {
                var response = await _styleService.Playlist(requestModel);
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
        [HttpGet("preference")]
        public async Task<IActionResult> Preference()
        {
            try
            {
                var response = await _styleService.Preference();
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
        public async Task<IActionResult> Song([FromBody] StyleRequestModel requestModel)
        {
            try
            {
                var response = await _styleService.Song(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
