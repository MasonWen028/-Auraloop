using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendController : Controller
    {
        private readonly ISendService _sendService;
        private readonly RequestContext _context;

        public SendController(ISendService sendService, RequestContext context)
        {
            _sendService = sendService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("album")]
        public async Task<IActionResult> Album([FromBody] SendAlbumRequestModel requestModel)
        {
            try
            {
                var response = await _sendService.Album(requestModel);
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
        public async Task<IActionResult> Playlist([FromBody] SendPlaylistRequestModel requestModel)
        {
            try
            {
                var response = await _sendService.Playlist(requestModel);
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
        public async Task<IActionResult> Song([FromBody] SendSongRequestModel requestModel)
        {
            try
            {
                var response = await _sendService.Song(requestModel);
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
        [HttpPost("text")]
        public async Task<IActionResult> Text([FromBody] SendTextRequestModel requestModel)
        {
            try
            {
                var response = await _sendService.Text(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
