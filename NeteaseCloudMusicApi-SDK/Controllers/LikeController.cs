using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class LikeController : Controller
    {
        private readonly GenericService _genericService;

        public LikeController(GenericService genericService)
        {
            _genericService = genericService;
        }


        /// <summary>
        /// Favorite adn Unforvorite song
        /// </summary>
        /// <param name="id">song id</param>
        /// <param name="like">like it or not</param>
        /// <returns></returns>
        [HttpGet]
        [Route("like")]
        [SwaggerOperation(summary: "Favorite adn Unforvorite song")]
        public async Task<IActionResult> Like([FromQuery]long id, [FromQuery]bool like)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/radio/like",
                    OptionType = "weapi",
                    Data = new LikeRequestModel()
                    {
                        TrackId = id,
                         Like = like,
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
