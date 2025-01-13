using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordController : Controller
    {
        private readonly IRecordService _recordService;
        private readonly RequestContext _context;

        public RecordController(IRecordService recordService, RequestContext context)
        {
            _recordService = recordService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("recentalbum")]
        public async Task<IActionResult> RecentAlbum([FromQuery] Int32 limit)
        {
            try
            {
                var response = await _recordService.RecentAlbum(limit);
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
        [HttpGet("recentradio")]
        public async Task<IActionResult> RecentRadio([FromQuery] Int32 limit)
        {
            try
            {
                var response = await _recordService.RecentRadio(limit);
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
        [HttpGet("recentplaylist")]
        public async Task<IActionResult> RecentPlaylist([FromQuery] Int32 limit)
        {
            try
            {
                var response = await _recordService.RecentPlaylist(limit);
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
        [HttpGet("recentsong")]
        public async Task<IActionResult> RecentSong([FromQuery] Int32 limit)
        {
            try
            {
                var response = await _recordService.RecentSong(limit);
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
        [HttpGet("recentvideo")]
        public async Task<IActionResult> RecentVideo([FromQuery] Int32 limit)
        {
            try
            {
                var response = await _recordService.RecentVideo(limit);
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
        [HttpGet("recentvoice")]
        public async Task<IActionResult> RecentVoice([FromQuery] Int32 limit)
        {
            try
            {
                var response = await _recordService.RecentVoice(limit);
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
        [HttpGet("recentlistenlist")]
        public async Task<IActionResult> RecentListenList()
        {
            try
            {
                var response = await _recordService.RecentListenList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
