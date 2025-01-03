using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class UgcController : Controller
    {
        private readonly GenericService _genericService;

        public UgcController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("ugc/album/get")]
        public async Task<IActionResult> UgcAlbumGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/album/get",
                    OptionType = "weapi",
                    Data = new UgcAlbumGetRequestModel()
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
        [Route("ugc/artist/get")]
        public async Task<IActionResult> UgcArtistGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/artist/get",
                    OptionType = "weapi",
                    Data = new UgcArtistGetRequestModel()
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

        /// <summary>
        /// Search Artists by Keyword
        /// </summary>
        /// <param name="keyword">The keyword used to search for artists.</param>
        /// <param name="limit">The maximum number of artists to return (default: 10).</param>
        /// <returns>A list of artists matching the provided keyword.</returns>
        [HttpGet]
        [Route("ugc/artist/search")]
        [SwaggerOperation(
            Summary = "Search Artists by Keyword",
            Description = "Fetches a list of artists based on a given keyword. Supports limiting the number of results with the `limit` parameter.",
            OperationId = "SearchArtistsByKeyword",
            Tags = new[] { "Artist", "Artist" }
        )]
        [SwaggerResponse(200, "Artists retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Could be due to missing or invalid parameters.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> UgcArtistSearch([FromQuery]string keyword, [FromQuery]int limit = 10)
        {
            try
            {

                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/artist/search",
                    OptionType = "weapi",
                    Data = new UgcArtistSearchRequestModel()
                    {
                        Keyword = keyword,
                        Limit = limit
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
        [Route("ugc/detail")]
        public async Task<IActionResult> UgcDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/detail",
                    OptionType = "weapi",
                    Data = new UgcDetailRequestModel()
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
        [Route("ugc/mv/get")]
        public async Task<IActionResult> UgcMvGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/mv/get",
                    OptionType = "weapi",
                    Data = new UgcMvGetRequestModel()
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
        [Route("ugc/song/get")]
        public async Task<IActionResult> UgcSongGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/song/get",
                    OptionType = "weapi",
                    Data = new UgcSongGetRequestModel()
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
        [Route("ugc/user/devote")]
        public async Task<IActionResult> UgcUserDevote()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/user/devote",
                    OptionType = "weapi",
                    Data = new UgcUserDevoteRequestModel()
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
