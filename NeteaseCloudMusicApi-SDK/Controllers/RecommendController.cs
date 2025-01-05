using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

        /// <summary>
        /// Fetch daily recomended playlist
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("recommend/resource")]
        [SwaggerOperation(
            summary: "Fetch daily recomended playlist"
        )]
        public async Task<IActionResult> RecommendResource()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/discovery/recommend/resource",
                    OptionType = "weapi"
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
        /// Fetch daily recommended songs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("recommend/songs")]
        [SwaggerOperation(
            summary: "Fetch daily recommended songs"
        )]
        public async Task<IActionResult> RecommendSongs()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v3/discovery/recommend/songs",
                    OptionType = "weapi"
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
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
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
