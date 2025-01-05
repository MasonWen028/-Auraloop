using Microsoft.AspNetCore.Mvc;
using NeteaseCloudMusicApi_SDK.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class PlaylistController : Controller
    {
        private readonly GenericService _genericService;

        public PlaylistController(GenericService genericService)
        {
            _genericService = genericService;
        }

        /// <summary>
        /// Fetch playlist categories.
        /// </summary>
        /// <remarks>
        /// This endpoint retrieves a list of available playlist categories for filtering or browsing playlists.
        /// </remarks>
        /// <returns>
        /// A list of playlist categories or an error response in case of failure.
        /// </returns>
        [HttpGet]
        [Route("playlist/catlist")]
        [SwaggerOperation(
            Summary = "Fetch Playlist Categories",
            Description = "Retrieves a list of available playlist categories for filtering or browsing playlists.",
            OperationId = "GetPlaylistCategories",
            Tags = new[] { "Playlist", "Categories" }
        )]
        [SwaggerResponse(200, "Successfully retrieved playlist categories.", typeof(object))]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> PlaylistCatlist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/catalogue",
                    OptionType = "weapi",
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
        [Route("playlist/cover/update")]
        public async Task<IActionResult> PlaylistCoverUpdate()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/cover/update",
                    OptionType = "weapi",
                    Data = new PlaylistCoverUpdateRequestModel()
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
        /// Create new play list
        /// </summary>
        /// <param name="requestModel">
        /// name: playlist name
        /// privacy: keep it secret or not, nullable
        /// type: it's a normal, video or shared playlist, nullable
        /// </param>
        /// <returns></returns>
        [HttpGet]
        [Route("playlist/create")]
        [SwaggerOperation(
            Summary = "Create playlist",
            Description = "Create a playlist by name, privacy and its type",
            OperationId = "CreatePlaylist",
            Tags = new[] { "Playlist", "Create" }
        )]
        [SwaggerResponse(200, "Playlist created successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Parameters are missing or invalid.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> PlaylistCreate([FromQuery] PlaylistCreateRequestModel requestModel)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/create",
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
        /// Delete a playlist by its id
        /// </summary>
        /// <param name="id">the unique identifier of playlist</param>
        /// <returns></returns>
        [HttpPost]
        [Route("playlist/delete")]
        [SwaggerOperation(
            summary: "Delete Playlist",
            description: "Remove a playlist by its id",
            OperationId = "DeletePlaylist",
            Tags = new[] { "Playlist", "Delete" }
        )]
        [SwaggerResponse(200, "Playlist Deleted successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Parameters are missing or invalid.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> PlaylistDelete([FromQuery] string id)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/remove",
                    OptionType = "weapi",
                    Data = new PlaylistDeleteRequestModel()
                    {
                        Ids = "[" + id + "]"
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
        [Route("playlist/desc/update")]
        public async Task<IActionResult> PlaylistDescUpdate()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/desc/update",
                    OptionType = "weapi",
                    Data = new PlaylistDescUpdateRequestModel()
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
        /// Fetches the details of a playlist by its ID.
        /// </summary>
        /// <remarks>
        /// This endpoint retrieves the details of a playlist based on the provided playlist ID.
        /// Additional optional parameters can be included in the request.
        /// </remarks>
        /// <param name="requestModel">The request model containing the playlist ID and other optional parameters.</param>
        /// <response code="200">Returns the playlist details.</response>
        /// <response code="400">If the request parameters are invalid.</response>
        /// <response code="500">If an internal server error occurs.</response>
        [HttpGet]
        [Route("playlist/detail")]
        [SwaggerOperation(
            Summary = "Fetch Playlist Details",
            Description = "Retrieves detailed information about a playlist based on the provided playlist ID and other optional parameters.",
            OperationId = "GetPlaylistDetail",
            Tags = new[] { "Playlist", "Details" }
        )]
        [SwaggerResponse(200, "Playlist details retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Parameters are missing or invalid.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> PlaylistDetail([FromQuery] PlaylistDetailRequestModel requestModel)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v6/playlist/detail",
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
        [Route("playlist/detail/dynamic")]
        public async Task<IActionResult> PlaylistDetailDynamic()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/detail/dynamic",
                    OptionType = "weapi",
                    Data = new PlaylistDetailDynamicRequestModel()
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
        [Route("playlist/detail/rcmd/get")]
        public async Task<IActionResult> PlaylistDetailRcmdGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/detail/rcmd/get",
                    OptionType = "weapi",
                    Data = new PlaylistDetailRcmdGetRequestModel()
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
        /// Fetch high-quality playlist tags.
        /// </summary>
        /// <remarks>
        /// This endpoint retrieves a list of high-quality playlist tags for filtering or categorizing playlists.
        /// </remarks>
        /// <returns>
        /// A list of high-quality playlist tags or an error response in case of failure.
        /// </returns>
        [HttpGet]
        [Route("playlist/highquality/tags")]
        [SwaggerOperation(
            Summary = "Fetch High-Quality Playlist Tags",
            Description = "Retrieves a list of high-quality playlist tags that can be used for filtering or categorizing playlists.",
            OperationId = "GetHighQualityPlaylistTags",
            Tags = new[] { "Playlist", "Tags" }
        )]
        [SwaggerResponse(200, "Successfully retrieved high-quality playlist tags.", typeof(object))]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> PlaylistHighqualityTags()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/highquality/tags",
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
        [Route("playlist/hot")]
        public async Task<IActionResult> PlaylistHot()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/hottags",
                    OptionType = "weapi",
                    Data = new PlaylistHotRequestModel()
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
        [Route("playlist/import/name/task/create")]
        public async Task<IActionResult> PlaylistImportNameTaskCreate()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/import/name/task/create",
                    OptionType = "weapi",
                    Data = new PlaylistImportNameTaskCreateRequestModel()
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
        [Route("playlist/import/task/status")]
        public async Task<IActionResult> PlaylistImportTaskStatus()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/import/task/status/v2",
                    OptionType = "weapi",
                    Data = new PlaylistImportTaskStatusRequestModel()
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
        [Route("playlist/mylike")]
        public async Task<IActionResult> PlaylistMylike()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mlog/playlist/mylike/bytime/get",
                    OptionType = "weapi",
                    Data = new PlaylistMylikeRequestModel()
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
        [Route("playlist/name/update")]
        public async Task<IActionResult> PlaylistNameUpdate()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/update/name",
                    OptionType = "weapi",
                    Data = new PlaylistNameUpdateRequestModel()
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
        [Route("playlist/order/update")]
        public async Task<IActionResult> PlaylistOrderUpdate()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/order/update",
                    OptionType = "weapi",
                    Data = new PlaylistOrderUpdateRequestModel()
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
        /// Publish a privacy playlist
        /// </summary>
        /// <param name="id">the unique indentifier of the targeted playlist</param>
        /// <param name="privacy">publish it or keep it privacy, 0 publish</param>
        /// <returns></returns>
        [HttpGet]
        [Route("playlist/privacy")]
        [SwaggerOperation(
            summary: "Publish a privacy playlist",
            description: "Publish a privacy playlist",
            OperationId = "PlaylistPrivacy",
            Tags = new string[] { "Playlist", "Privacy" }
        )]
        [SwaggerResponse(200, "Published playlist successfully")]
        [SwaggerResponse(500, "Errors occured")]
        [SwaggerResponse(301, "Nedd Login")]
        public async Task<IActionResult> PlaylistPrivacy([FromQuery] long id, [FromQuery] int privacy = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/update/privacy",
                    OptionType = "weapi",
                    Data = new PlaylistPrivacyRequestModel()
                    {
                        Id = id,
                        Privacy = privacy
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
        /// Subscrible or unsubscrible a playlist
        /// </summary>
        /// <param name="id">the indentifier of the playlist</param>
        /// <param name="subOpType">subcrible or unsubscrible, 1 for sub, others for unsub</param>
        /// <returns></returns>
        
        [HttpGet]
        [Route("playlist/subscribe")]
        [SwaggerOperation(
            summary: "Subscribe or unsubsribe a playlist",
            description: "subscribe or unsubscribe a playlist by id, 1 for subscribe, others for unsubscribe",
            OperationId = "PlaylistSub",
            Tags =  new string[] { "Playlist", "Subscribe" }
        )]
        [SwaggerResponse(200, "Subscribe/unsubscribe successfully")]
        public async Task<IActionResult> PlaylistSubscribe([FromQuery]long id, [FromQuery]SubOpType subOpType)
        {
            try
            {

                var apiModel = new ApiModel
                {
                    ApiEndpoint = $"/api/playlist/{subOpType}",
                    OptionType = "weapi",
                    Data = new PlaylistSubscribeRequestModel()
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

        [HttpPost]
        [Route("playlist/subscribers")]
        public async Task<IActionResult> PlaylistSubscribers()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/subscribers",
                    OptionType = "weapi",
                    Data = new PlaylistSubscribersRequestModel()
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
        [Route("playlist/tags/update")]
        public async Task<IActionResult> PlaylistTagsUpdate()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/tags/update",
                    OptionType = "weapi",
                    Data = new PlaylistTagsUpdateRequestModel()
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
        /// Add or remove song from targeted playlist
        /// </summary>
        /// <param name="pid">the unique indentifier of play list</param>
        /// <param name="tracks">track ids</param>
        /// <param name="Optype">add|del</param>
        /// <returns></returns>
        [HttpPost]
        [Route("playlist/tracks")]
        [SwaggerOperation(
            summary: "Add/Remove song from playlist",
            description: "Add/Remove a buntch of tracks from playlist",
            OperationId = "PlaylistTracks",
            Tags = new string[] { "Playlist", "Tracks" }
        )]
        [SwaggerResponse(200, "Operate successfuly")]
        public async Task<IActionResult> PlaylistTracks([FromQuery]long pid, [FromQuery] long[] tracks, [FromQuery]Optype Optype = Optype.add)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/manipulate/tracks",
                    OptionType = "weapi",
                    Data = new PlaylistTracksRequestModel()
                    {
                        Op = Optype.ToString(),
                        Pid = pid,
                        TrackIds = JsonConvert.SerializeObject(tracks),
                        Imme = "true"
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
        [Route("playlist/track/add")]
        public async Task<IActionResult> PlaylistTrackAdd()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/track/add",
                    OptionType = "weapi",
                    Data = new PlaylistTrackAddRequestModel()
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
        /// Fetch all tracks from a specific playlist with pagination.
        /// </summary>
        /// <param name="Id">The unique identifier of the playlist.</param>
        /// <param name="Limit">The maximum number of tracks to return. Default is 50.</param>
        /// <param name="Offset">The number of tracks to skip before starting to collect the result set. Default is 0.</param>
        /// <returns>A paginated list of tracks from the specified playlist or an error response if the operation fails.</returns>
        [HttpGet]
        [Route("playlist/track/all")]
        [SwaggerOperation(
            Summary = "Fetch Playlist Tracks",
            Description = "Retrieves a paginated list of tracks from a playlist by its ID. Supports pagination using the `Limit` and `Offset` parameters.",
            OperationId = "GetPlaylistTracks",
            Tags = new[] { "Playlist", "Tracks" }
        )]
        [SwaggerResponse(200, "Successfully retrieved the tracks from the playlist.", typeof(object))]
        [SwaggerResponse(400, "Failed to fetch playlist details due to invalid parameters or other issues.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> PlaylistTrackAll([FromQuery]long Id, [FromQuery]int Limit = 50, [FromQuery]int Offset = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v6/playlist/detail",
                    OptionType = "weapi",
                    Data = new PlaylistTrackAllRequestModel()
                    {
                        Id = Id,
                        N = 100000,
                        S = 8
                    }
                };

                // Step 1: Get all song id from server
                var result = await _genericService.HandleRequestAsync(apiModel);

                if (result.status != 200)
                {
                    // Explicit handling for known failure case
                    return BadRequest(new { Message = "Failed to fetch playlist details.", Status = result.status });
                }

                var resData = JObject.Parse(result.body);
                var trackIds = resData["playlist"]["trackIds"];
                var slicedIds = trackIds
                    .Skip(Offset) // Skip to the offset
                    .Take(Limit) // Take only the limit
                    .Select(item => new { id = item["id"] }) // Map to anonymous objects
                    .ToList();

                var sondRequestData = new { c = JsonConvert.SerializeObject(slicedIds.ToArray()) };

                var songApiModel = new ApiModel()
                {
                    ApiEndpoint = "/api/v3/song/detail",
                    Data = sondRequestData,
                    OptionType = "weapi"
                };
                var songRes = await _genericService.HandleRequestAsync(songApiModel);

                return Ok(songRes.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("playlist/track/delete")]
        public async Task<IActionResult> PlaylistTrackDelete()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/track/delete",
                    OptionType = "weapi",
                    Data = new PlaylistTrackDeleteRequestModel()
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

        //TODO Edit the playlist
        [HttpPost]
        [Route("playlist/update")]
        public async Task<IActionResult> PlaylistUpdate([FromQuery]long id, [FromQuery]string name, [FromQuery] string[]? tags, [FromQuery] string desc = "")
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "",
                    OptionType = "weapi",
                    Data = new PlaylistUpdateRequestModel()
                    {
                        
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
        [Route("playlist/update/playcount")]
        public async Task<IActionResult> PlaylistUpdatePlaycount()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/update/playcount",
                    OptionType = "weapi",
                    Data = new PlaylistUpdatePlaycountRequestModel()
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
        [Route("playlist/video/recent")]
        public async Task<IActionResult> PlaylistVideoRecent()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/video/recent",
                    OptionType = "weapi",
                    Data = new PlaylistVideoRecentRequestModel()
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
