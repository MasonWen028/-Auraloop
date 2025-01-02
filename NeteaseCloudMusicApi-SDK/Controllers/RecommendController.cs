using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class RecommendController : Controller
    {
        private readonly GenericService _genericService;

        public RecommendController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("recommend/resource")]
        public async Task<IActionResult> RecommendResource()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/discovery/recommend/resource",
                    OptionType = "weapi",
                    Data = new RecommendResourceRequestModel()
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
        [Route("recommend/songs")]
        public async Task<IActionResult> RecommendSongs()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v3/discovery/recommend/songs",
                    OptionType = "weapi",
                    Data = new RecommendSongsRequestModel()
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
        [Route("recommend/songs/dislike")]
        public async Task<IActionResult> RecommendSongsDislike()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v2/discovery/recommend/dislike",
                    OptionType = "weapi",
                    Data = new RecommendSongsDislikeRequestModel()
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
