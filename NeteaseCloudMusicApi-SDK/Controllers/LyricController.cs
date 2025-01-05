using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Fetch lyric corresponding to song
        /// </summary>
        /// <param name="id">song id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("lyric/new")]
        [SwaggerOperation(summary: "Fetch lyric corresponding to song")]
        public async Task<IActionResult> LyricNew([FromQuery]long id)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/lyric/v1",
                    OptionType = "weapi",
                    Data = new LyricNewRequestModel()
                    {
                        Id = id
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
