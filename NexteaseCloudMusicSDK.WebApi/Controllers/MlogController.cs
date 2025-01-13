using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MlogController : Controller
    {
        private readonly IMlogService _mlogService;
        private readonly RequestContext _context;

        public MlogController(IMlogService mlogService, RequestContext context)
        {
            _mlogService = mlogService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("musicrcmd")]
        public async Task<IActionResult> MusicRcmd([FromBody] MlogMusicRcmdRequestModel requestModel)
        {
            try
            {
                var response = await _mlogService.MusicRcmd(requestModel);
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
        [HttpPost("tovideo")]
        public async Task<IActionResult> ToVideo([FromBody] MlogToVideoRequestModel requestModel)
        {
            try
            {
                var response = await _mlogService.ToVideo(requestModel);
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
        public async Task<IActionResult> Url([FromBody] MlogUrlRequestModel requestModel)
        {
            try
            {
                var response = await _mlogService.Url(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
