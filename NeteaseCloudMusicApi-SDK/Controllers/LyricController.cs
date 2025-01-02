using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class LyricController : Controller
    {
        private readonly GenericService _genericService;

        public LyricController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("lyric")]
        public async Task<IActionResult> Lyric()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/lyric",
                    OptionType = "weapi",
                    Data = new LyricRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("lyric/new")]
        public async Task<IActionResult> LyricNew()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/lyric/v1",
                    OptionType = "weapi",
                    Data = new LyricNewRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
