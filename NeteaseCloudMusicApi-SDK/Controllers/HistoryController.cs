using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class HistoryController : Controller
    {
        private readonly GenericService _genericService;

        public HistoryController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("history/recommend/songs")]
        public async Task<IActionResult> HistoryRecommendSongs()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/discovery/recommend/songs/history/recent",
                    OptionType = "weapi",
                    Data = new HistoryRecommendSongsRequestModel()
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
        [Route("history/recommend/songs/detail")]
        public async Task<IActionResult> HistoryRecommendSongsDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/discovery/recommend/songs/history/detail",
                    OptionType = "weapi",
                    Data = new HistoryRecommendSongsDetailRequestModel()
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
