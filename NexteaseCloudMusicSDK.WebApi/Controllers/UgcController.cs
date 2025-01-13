using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UgcController : Controller
    {
        private readonly IUgcService _ugcService;
        private readonly RequestContext _context;

        public UgcController(IUgcService ugcService, RequestContext context)
        {
            _ugcService = ugcService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("album")]
        public async Task<IActionResult> AlbumGet([FromQuery] Int64 albumId)
        {
            try
            {
                var response = await _ugcService.AlbumGet(albumId);
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
        [HttpGet("artist")]
        public async Task<IActionResult> ArtistGet([FromQuery] Int64 artistId)
        {
            try
            {
                var response = await _ugcService.ArtistGet(artistId);
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
        [HttpPost("artistsearch")]
        public async Task<IActionResult> ArtistSearch([FromBody] UgcArtistSearchRequestModel requestModel)
        {
            try
            {
                var response = await _ugcService.ArtistSearch(requestModel);
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
        [HttpPost("detail")]
        public async Task<IActionResult> Detail([FromBody] UgcDetailRequestModel requestModel)
        {
            try
            {
                var response = await _ugcService.Detail(requestModel);
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
        public async Task<IActionResult> MvGet([FromQuery] Int64 mvId)
        {
            try
            {
                var response = await _ugcService.MvGet(mvId);
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
        public async Task<IActionResult> SongGet([FromQuery] Int64 songId)
        {
            try
            {
                var response = await _ugcService.SongGet(songId);
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
        [HttpGet("userdevote")]
        public async Task<IActionResult> UserDevote()
        {
            try
            {
                var response = await _ugcService.UserDevote();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
