using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController : Controller
    {
        private readonly IMusicService _musicService;
        private readonly RequestContext _context;

        public MusicController(IMusicService musicService, RequestContext context)
        {
            _musicService = musicService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("startlistening")]
        public async Task<IActionResult> StartMusicListening([FromQuery] Int64 SongId)
        {
            try
            {
                var response = await _musicService.StartMusicListening(SongId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
