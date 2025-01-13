using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : Controller
    {
        private readonly ISongService _songService;
        private readonly RequestContext _context;

        public SongController(ISongService songService, RequestContext context)
        {
            _songService = songService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("chorus")]
        public async Task<IActionResult> Chorus([FromQuery] Int64 id)
        {
            try
            {
                var response = await _songService.Chorus(id);
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
        public async Task<IActionResult> Detail([FromBody] SongDetailRequestModel requestModel)
        {
            try
            {
                var response = await _songService.Detail(requestModel);
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
        [HttpPost("downlist")]
        public async Task<IActionResult> Downlist([FromBody] PaginatedRequestModel requestModel)
        {
            try
            {
                var response = await _songService.Downlist(requestModel);
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
        [HttpGet("downloadurl")]
        public async Task<IActionResult> DownloadUrl([FromQuery] Int64 id, Int32 bitrate)
        {
            try
            {
                var response = await _songService.DownloadUrl(id, bitrate);
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
        [HttpGet("downloadurlv1")]
        public async Task<IActionResult> DownloadUrlV1([FromQuery] Int64 id, String level)
        {
            try
            {
                var response = await _songService.DownloadUrlV1(id, level);
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
        [HttpGet("dynamiccover")]
        public async Task<IActionResult> DynamicCover([FromQuery] Int64 id)
        {
            try
            {
                var response = await _songService.DynamicCover(id);
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
        [HttpPost("likecheck")]
        public async Task<IActionResult> LikeCheck([FromBody] Int64[] ids)
        {
            try
            {
                var response = await _songService.LikeCheck(ids);
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
        [HttpPost("monthdownlist")]
        public async Task<IActionResult> Monthdownlist([FromBody] PaginatedRequestModel requestModel)
        {
            try
            {
                var response = await _songService.Monthdownlist(requestModel);
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
        [HttpGet("musicdetail")]
        public async Task<IActionResult> MusicDetail([FromQuery] Int64 id)
        {
            try
            {
                var response = await _songService.MusicDetail(id);
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
        [HttpPost("orderupdate")]
        public async Task<IActionResult> OrderUpdate([FromBody] SongOrderUpdateRequestModel requestModel)
        {
            try
            {
                var response = await _songService.OrderUpdate(requestModel);
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
        [HttpPost("url")]
        public async Task<IActionResult> Ur([FromBody] SongUrlRequestModel requestModel)
        {
            try
            {
                var response = await _songService.Url(requestModel);
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
        [HttpPost("url/v1")]
        public async Task<IActionResult> UrlV1([FromBody] SongUrlV1RequestModel requestModel)
        {
            try
            {
                var response = await _songService.UrlV1(requestModel);
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
        [HttpGet("wikisummary")]
        public async Task<IActionResult> WikiSummary([FromQuery] Int64 id)
        {
            try
            {
                var response = await _songService.WikiSummary(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
