using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CloudController : Controller
    {
        private readonly ICloudService _cloudService;
        private readonly RequestContext _context;

        public CloudController(ICloudService cloudService, RequestContext context)
        {
            _cloudService = cloudService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("uploadsong")]
        public async Task<IActionResult> UploadSong([FromBody] SongUploadRequestModel requestModel)
        {
            try
            {
                var response = await _cloudService.UploadSong(requestModel);
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
        [HttpPost("importsongs")]
        public async Task<IActionResult> ImportSongs([FromBody] SongImportRequestModel requestModel)
        {
            try
            {
                var response = await _cloudService.ImportSongs(requestModel);
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
        [HttpPost("matchsong")]
        public async Task<IActionResult> MatchSong([FromBody] SongMatchRequestModel requestModel)
        {
            try
            {
                var response = await _cloudService.MatchSong(requestModel);
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
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] CloudSearchRequestModel requestModel)
        {
            try
            {
                var response = await _cloudService.Search(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
