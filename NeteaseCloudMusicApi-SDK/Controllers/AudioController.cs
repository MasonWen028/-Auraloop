using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class AudioController : Controller
    {
        private readonly GenericService _genericService;

        public AudioController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("audio/match")]
        public async Task<IActionResult> AudioMatch()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = @"https://interface.music.163.com/api/music/audio/match?sessionId=0123456789abcdef&algorithmCode=shazam_v2&duration=${
      query.duration
    }&rawdata=${encodeURIComponent(query.audioFP)}&times=1&decrypt=1",
                    OptionType = "",
                    Data = new AudioMatchRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
