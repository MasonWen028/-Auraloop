using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class TopController : Controller
    {
        private readonly GenericService _genericService;

        public TopController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("top/album")]
        public async Task<IActionResult> TopAlbum()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/discovery/new/albums/area",
                    OptionType = "weapi",
                    Data = new TopAlbumRequestModel()
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
        /// Fetch top songs by Area with pagination
        /// </summary>
        /// <param name="areaId">All = 0, Chinese = 7, Western = 96, Korean = 16, Japanese = 8</param>
        /// <param name="limit">page size</param>
        /// <param name="offset">page number</param>
        /// <returns></returns>
        [HttpGet]
        [Route("top/artists")]
        [SwaggerOperation(summary: "Fetch top songs by Area with pagination")]
        public async Task<IActionResult> TopArtists([FromQuery]MusicRegion areaId = MusicRegion.All, [FromQuery]int limit = 100, [FromQuery]int offset = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/top",
                    OptionType = "weapi",
                    Data = new TopArtistsRequestModel()
                    {
                        AreaId = areaId,
                        Limit = limit,
                        Offset = offset,
                        Total = true
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
        [Route("top/list")]
        public async Task<IActionResult> TopList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/v4/detail",
                    OptionType = "weapi",
                    Data = new TopListRequestModel()
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

        [HttpPost]
        [Route("top/mv")]
        public async Task<IActionResult> TopMv()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mv/toplist",
                    OptionType = "weapi",
                    Data = new TopMvRequestModel()
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
        /// Fetch High-Quality Top Playlists
        /// </summary>
        /// <remarks>
        /// This endpoint retrieves a list of top playlists based on the specified parameters.
        /// It supports filtering by category (`cat`), setting the maximum number of playlists to retrieve (`limit`),
        /// and specifying an offset for pagination (`offset`).
        /// </remarks>
        /// <param name="requestModel">
        /// The request model containing query parameters such as category, limit, and offset.
        /// </param>
        /// <returns>
        /// A list of top playlists or an error response in case of failure.
        /// </returns>
        [HttpGet]
        [Route("top/playlist")]
        [SwaggerOperation(
            Summary = "Fetch Top Playlists",
            Description = "Retrieves a list of top playlists based on category, limit, and pagination offset.",
            OperationId = "GetTopPlaylists",
            Tags = new[] { "Playlist",  "Top" }
        )]
        [SwaggerResponse(200, "Successfully retrieved high-quality top playlists.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Missing or incorrect parameters.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> TopPlaylist([FromQuery] TopPlaylistHighqualityRequestModel requestModel)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/list",
                    OptionType = "weapi",
                    Data = requestModel
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
        /// Fetch High-Quality Top Playlists
        /// </summary>
        /// <remarks>
        /// This endpoint retrieves a list of high-quality top playlists based on the specified parameters.
        /// It supports filtering by category (`cat`), setting the maximum number of playlists to retrieve (`limit`),
        /// and specifying an offset for pagination (`offset`).
        /// </remarks>
        /// <param name="requestModel">
        /// The request model containing query parameters such as category, limit, and offset.
        /// </param>
        /// <returns>
        /// A list of high-quality top playlists or an error response in case of failure.
        /// </returns>
        [HttpGet]
        [Route("top/playlist/highquality")]
        [SwaggerOperation(
            Summary = "Fetch High-Quality Top Playlists",
            Description = "Retrieves a list of high-quality top playlists based on category, limit, and pagination offset.",
            OperationId = "GetHighQualityTopPlaylists",
            Tags = new[] { "Playlist", "HighQuality", "Top" }
        )]
        [SwaggerResponse(200, "Successfully retrieved high-quality top playlists.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Missing or incorrect parameters.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> TopPlaylistHighquality([FromQuery] TopPlaylistHighqualityRequestModel requestModel)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/highquality/list",
                    OptionType = "weapi",
                    Data = requestModel
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
        [Route("top/song")]
        public async Task<IActionResult> TopSong()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/discovery/new/songs",
                    OptionType = "weapi",
                    Data = new TopSongRequestModel()
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
