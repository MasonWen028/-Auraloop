using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class PlaymodeController : Controller
    {
        private readonly GenericService _genericService;

        public PlaymodeController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("playmode/intelligence/list")]
        public async Task<IActionResult> PlaymodeIntelligenceList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playmode/intelligence/list",
                    OptionType = "weapi",
                    Data = new PlaymodeIntelligenceListRequestModel()
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
        [Route("playmode/song/vector")]
        public async Task<IActionResult> PlaymodeSongVector()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playmode/song/vector/get",
                    OptionType = "weapi",
                    Data = new PlaymodeSongVectorRequestModel()
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
