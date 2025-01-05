using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class AlbumController : Controller
    {
        private readonly GenericService _genericService;

        public AlbumController(GenericService genericService)
        {
            _genericService = genericService;
        }

        /// <summary>
        /// Get album details by ID
        /// </summary>
        /// <param name="id">The unique identifier of the album</param>
        /// <returns>Album details</returns>
        /// <response code="200">Returns the album details</response>
        /// <response code="500">If there is a server error</response>
        [HttpGet]
        [Route("album")]
        [SwaggerOperation(
            Summary = "Get Album by ID",
            Description = "Retrieves the details of an album using its unique identifier.",
            OperationId = "GetAlbumById",
            Tags = new[] { "Album" }
        )]
        [SwaggerResponse(200, "Album details retrieved successfully.")]
        [SwaggerResponse(500, "An error occurred while processing your request.")]
        public async Task<IActionResult> Album([FromQuery]string id)
        {
            try
            {
                //return Ok(new { a = 1 });
                var apiModel = new ApiModel
                {
                    ApiEndpoint = $"/api/v1/album/{id}",
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

        [HttpGet]
        [Route("album/detail")]
        [SwaggerOperation(
            Summary = "Get Album Details",
            Description = "Retrieves detailed information about an album based on its ID.",
            OperationId = "GetAlbumDetail",
            Tags = new[] { "Album" }
        )]
        [SwaggerResponse(200, "Album details retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "The request parameters are invalid.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> AlbumDetail([FromQuery]string id)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/vipmall/albumproduct/detail",
                    OptionType = "weapi",
                    Data = new AlbumDetailRequestModel()
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

        [HttpGet]
        [Route("album/detail/dynamic")]
        [SwaggerOperation(
            Summary = "Get Dynamic Album Details",
            Description = "Retrieves dynamic details about an album based on its ID. This may include real-time information or dynamically generated metadata.",
            OperationId = "GetAlbumDetailDynamic",
            Tags = new[] { "Album" }
        )]
        [SwaggerResponse(200, "Dynamic album details retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "The request parameters are invalid.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> AlbumDetailDynamic([FromQuery]string id)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/album/detail/dynamic",
                    OptionType = "weapi",
                    Data = new AlbumDetailDynamicRequestModel()
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

        [HttpGet]
        [Route("album/list")]
        [SwaggerOperation(
            Summary = "Retrieve Album List",
            Description = "Fetches a list of albums based on pagination, region, and type. Supports filtering by area and type.",
            OperationId = "GetAlbumList",
            Tags = new[] { "Album" }
        )]
        [SwaggerResponse(200, "List of albums retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid parameters provided.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> AlbumList([FromQuery]int limit, [FromQuery]int offset, [FromQuery]bool total, [FromQuery]string? area, [FromQuery]int type)
        {
            try
            {
                if (string.IsNullOrEmpty(area))
                {
                    area = "ALL";
                }
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/vipmall/albumproduct/list",
                    OptionType = "weapi",
                    Data = new AlbumListRequestModel()
                    {
                        Limit = limit,
                        Offset = offset,
                        Total = total,
                        Area = area,
                        Type = type,
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

        [HttpGet]
        [Route("album/list/style")]
        [SwaggerOperation(
            Summary = "Retrieve Styled Album List",
            Description = "Fetches a styled list of albums based on pagination and region. Supports filtering by area.",
            OperationId = "GetAlbumListStyle",
            Tags = new[] { "Album" }
        )]
        [SwaggerResponse(200, "Styled list of albums retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid parameters provided.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> AlbumListStyle([FromQuery]int limit, [FromQuery]int offset, [FromQuery]bool total, [FromQuery]string? area)
        {
            try
            {
                if (string.IsNullOrEmpty(area))
                {
                    area = "Z_H";
                }
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/vipmall/appalbum/album/style",
                    OptionType = "weapi",
                    Data = new AlbumListStyleRequestModel()
                    {
                        Limit = limit,
                        Offset = offset,
                        Total = total,
                        Area = area,
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

        [HttpGet]
        [Route("album/new")]
        [SwaggerOperation(
            Summary = "Retrieve New Albums",
            Description = "Fetches a list of new albums based on pagination and region. Supports filtering by area.",
            OperationId = "GetNewAlbums",
            Tags = new[] { "Album" }
        )]
        [SwaggerResponse(200, "New albums retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid parameters provided.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> AlbumNew([FromQuery] int limit, [FromQuery] int offset, [FromQuery] bool total, [FromQuery]string? area)
        {
            try
            {
                if (string.IsNullOrEmpty(area))
                {
                    area = "ALL";
                }
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/album/new",
                    OptionType = "weapi",
                    Data = new AlbumNewRequestModel()
                    {
                        Limit = limit,
                        Offset = offset,
                        Total = total,
                        Area = area,
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

        [HttpGet]
        [Route("album/newest")]
        [SwaggerOperation(
            Summary = "Retrieve Newest Albums",
            Description = "Fetches the newest albums available in the discovery section.",
            OperationId = "GetNewestAlbums",
            Tags = new[] { "Album" }
        )]
        [SwaggerResponse(200, "Newest albums retrieved successfully.", typeof(object))]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> AlbumNewest()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/discovery/newAlbum",
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

        [HttpGet]
        [Route("album/privilege")]
        [SwaggerOperation(
            Summary = "Retrieve Album Privileges",
            Description = "Fetches privilege information for a specific album based on its ID.",
            OperationId = "GetAlbumPrivileges",
            Tags = new[] { "Album" }
        )]
        [SwaggerResponse(200, "Album privilege information retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid or missing album ID.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> AlbumPrivilege([FromQuery]string id)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/album/privilege",
                    OptionType = "weapi",
                    Data = new AlbumPrivilegeRequestModel()
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

        [HttpGet]
        [Route("album/songsaleboard")]
        [SwaggerOperation(
            Summary = "Retrieve Album Song Sale Board",
            Description = "Fetches the album song sale board based on album type, sale type (daily or otherwise), and year.",
            OperationId = "GetAlbumSongSaleBoard",
            Tags = new[] { "Album" }
        )]
        [SwaggerResponse(200, "Album song sale board retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid parameters provided.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> AlbumSongsaleboard([FromQuery]int albumType, [FromQuery]string type, [FromQuery]string? year)
        {
            try
            {
                if (string.IsNullOrEmpty(type))
                {
                    type = "daily";
                }


                var apiModel = new ApiModel
                {
                    ApiEndpoint = $"/api/feealbum/songsaleboard/{type}/type",
                    OptionType = "weapi",
                    Data = new AlbumSongsaleboardRequestModel()
                    {
                        AlbumType = albumType, 
                        Year = year
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

        [HttpGet]
        [Route("album/sub")]
        [SwaggerOperation(
            Summary = "Subscribe or Unsubscribe Album",
            Description = "Subscribes to or unsubscribes from an album based on the provided action type (`t`) and album ID (`id`).",
            OperationId = "AlbumSubscribeUnsubscribe",
            Tags = new[] { "Album" }
        )]
        [SwaggerResponse(200, "Album subscription or unsubscription action completed successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid parameters provided.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> AlbumSub([FromQuery]int t, [FromQuery]string id)
        {
            try
            {
                string qt = t == 1 ? "sub" : "unsub";
                var apiModel = new ApiModel
                {
                    ApiEndpoint = $"/api/album/{qt}",
                    OptionType = "weapi",
                    Data = new AlbumSubRequestModel()
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

        [HttpGet]
        [Route("album/sublist")]
        [SwaggerOperation(
            Summary = "Retrieve Album Subscription List",
            Description = "Fetches a paginated list of albums the user is subscribed to, based on the provided `limit` and `offset`.",
            OperationId = "GetAlbumSubscriptionList",
            Tags = new[] { "Album" }
        )]
        [SwaggerResponse(200, "Album subscription list retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid parameters provided.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> AlbumSublist([FromQuery]int limit, [FromQuery]int offset)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/album/sublist",
                    OptionType = "weapi",
                    Data = new AlbumSublistRequestModel()
                    {
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
    }
}
