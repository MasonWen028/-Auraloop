using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

        /// <summary>
        /// Fetch a list of intelligent play mode recommendations based on a song and playlist.
        /// </summary>
        /// <param name="id">The unique identifier of the song to base recommendations on.</param>
        /// <param name="pid">The unique identifier of the playlist associated with the recommendations.</param>
        /// <param name="sid">
        /// The unique identifier of the starting song for recommendations. If not provided, the value of `id` is used.
        /// </param>
        /// <returns>
        /// A list of intelligent play mode recommendations based on the input parameters, or an error response in case of failure.
        /// </returns>
        [HttpGet]
        [Route("playmode/intelligence/list")]
        [SwaggerOperation(
            Summary = "Fetch Intelligent Play Mode Recommendations",
            Description = "Retrieves a list of intelligent play mode recommendations based on a song and playlist. If a starting song ID (`sid`) is not provided, the song ID (`id`) will be used.",
            OperationId = "GetIntelligentPlayModeRecommendations",
            Tags = new[] { "Playmode", "Intelligence", "Recommendations" }
        )]
        [SwaggerResponse(200, "Successfully retrieved intelligent play mode recommendations.", typeof(object))]
        [SwaggerResponse(400, "Bad request. Invalid or missing parameters.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> PlaymodeIntelligenceList([FromQuery]long id, [FromQuery]long pid, [FromQuery]long? sid)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playmode/intelligence/list",
                    OptionType = "weapi",
                    Data = new PlaymodeIntelligenceListRequestModel()
                    {
                        PlaylistId = pid,
                        Type = "fromPlayOne",
                        SongId = id,
                        StartMusicId = sid ?? id,
                        Count = 1
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
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
