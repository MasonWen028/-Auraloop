using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopController : Controller
    {
        private readonly ITopService _topService;
        private readonly RequestContext _context;

        public TopController(ITopService topService, RequestContext context)
        {
            _topService = topService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("album")]
        public async Task<IActionResult> Album([FromBody] TopAlbumRequestModel requestModel)
        {
            try
            {
                var response = await _topService.Album(requestModel);
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
        [HttpGet("artists")]
        public async Task<IActionResult> Artists([FromQuery] Int32 limit, Int32 offset)
        {
            try
            {
                var response = await _topService.Artists(limit, offset);
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
        public async Task<IActionResult> List([FromQuery] Int64 id)
        {
            try
            {
                var response = await _topService.List(id);
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
        [HttpPost("mv")]
        public async Task<IActionResult> Mv([FromBody] TopMvRequestModel requestModel)
        {
            try
            {
                var response = await _topService.Mv(requestModel);
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
        public async Task<IActionResult> Playlist([FromBody] TopPlaylistRequestModel requestModel)
        {
            try
            {
                var response = await _topService.Playlist(requestModel);
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
        [HttpPost("playlisthighquality")]
        public async Task<IActionResult> PlaylistHighquality([FromBody] TopPlaylistHighqualityRequestModel requestModel)
        {
            try
            {
                var response = await _topService.PlaylistHighquality(requestModel);
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
        [HttpGet("song")]
        public async Task<IActionResult> Song([FromQuery] Int32 areaId)
        {
            try
            {
                var response = await _topService.Song(areaId);
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
        [HttpGet("artistrankings")]
        public async Task<IActionResult> ArtistRankings()
        {
            try
            {
                var response = await _topService.ArtistRankings();
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
        public async Task<IActionResult> Detail()
        {
            try
            {
                var response = await _topService.Detail();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
