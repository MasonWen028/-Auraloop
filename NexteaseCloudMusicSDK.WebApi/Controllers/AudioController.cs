using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AudioController : Controller
    {
        private readonly IAudioService _audioService;
        private readonly RequestContext _context;

        public AudioController(IAudioService audioService, RequestContext context)
        {
            _audioService = audioService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("match")]
        public async Task<IActionResult> MatchAudio([FromBody] AudioMatchRequestModel requestModel)
        {
            try
            {
                var response = await _audioService.MatchAudio(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
