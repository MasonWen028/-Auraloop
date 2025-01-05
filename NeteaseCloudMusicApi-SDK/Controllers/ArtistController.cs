using Microsoft.AspNetCore.Mvc;
using NeteaseCloudMusicApi_SDK.Models.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ArtistController : Controller
    {
        private readonly GenericService _genericService;

        public ArtistController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpGet]
        [Route("artist/album")]
        [SwaggerOperation(
            Summary = "Retrieve Albums by Artist ID",
            Description = "Fetches a list of all albums by a specific artist ID. Supports pagination with limit and offset.",
            OperationId = "GetArtistAlbums",
            Tags = new[] { "Artist", "Album" }
        )]
        [SwaggerResponse(200, "Artist albums retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Could be due to missing or invalid parameters.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> ArtistAlbum([FromQuery]int id, [FromQuery]int limit = 50, [FromQuery]int offset = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = $"/api/artist/albums/{id}",
                    OptionType = "weapi",
                    Data = new ArtistAlbumRequestModel()
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

        [HttpGet]
        [Route("artist")]
        public async Task<IActionResult> Artist([FromQuery]string id)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = $"//api/v1/artist/{id}",
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
        [Route("artist/desc")]
        public async Task<IActionResult> ArtistDesc()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/introduction",
                    OptionType = "weapi",
                    Data = new ArtistDescRequestModel()
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

        [HttpGet]
        [Route("artist/detail")]
        public async Task<IActionResult> ArtistDetail([FromQuery]string id)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/head/info/get",
                    OptionType = "weapi",
                    Data = new ArtistDetailRequestModel()
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
        [Route("artist/detail/dynamic")]
        public async Task<IActionResult> ArtistDetailDynamic()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/detail/dynamic",
                    OptionType = "weapi",
                    Data = new ArtistDetailDynamicRequestModel()
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
        [Route("artist/fans")]
        public async Task<IActionResult> ArtistFans()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/fans/get",
                    OptionType = "weapi",
                    Data = new ArtistFansRequestModel()
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
        [Route("artist/follow/count")]
        public async Task<IActionResult> ArtistFollowCount()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/follow/count/get",
                    OptionType = "weapi",
                    Data = new ArtistFollowCountRequestModel()
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

        [HttpGet]
        [Route("artist/list")]
        [SwaggerOperation(
         Summary = "Retrieve Artist List",
         Description = "Fetches a list of artists based on type, area, initial letter, pagination, and limit parameters. Supports filtering and sorting options.",
         OperationId = "GetArtistList",
         Tags = new[] { "Artist" }
     )]
        [SwaggerResponse(200, "Artist list retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Could be due to missing or invalid parameters.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> ArtistList([FromQuery] ArtistListRequestModel requestModel)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/artist/list",
                    OptionType = "weapi",
                    Data = new
                    {
                        initial = int.TryParse(requestModel.Initial, out var numericInitial)
                        ? numericInitial
                        : string.IsNullOrEmpty(requestModel.Initial)
                            ? (int?)null
                            : (int?)char.ToUpper(requestModel.Initial[0]),

                        offset = requestModel.Offset > 0 ? requestModel.Offset : 0,

                        limit = requestModel.Limit > 0 ? requestModel.Limit : 30,
                        total = true,
                        type = (int)requestModel.Type != -1 ? ((int)requestModel.Type).ToString() : "1",
                        area = (int)requestModel.Area
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
        /// Retrieve Music Videos by Artist ID
        /// </summary>
        /// <param name="id">The unique identifier of the artist.</param>
        /// <param name="limit">The number of music videos to return (default: 50).</param>
        /// <param name="offset">The starting index for pagination (default: 0).</param>
        /// <returns>A list of music videos by the specified artist.</returns>
        [HttpGet]
        [Route("artist/mv")]
        [SwaggerOperation(
            Summary = "Retrieve Music Videos by Artist ID",
            Description = "Fetches a list of music videos by a specific artist ID. Supports pagination with limit and offset.",
            OperationId = "GetArtistMvs",
            Tags = new[] { "Artist", "MusicVideo" }
        )]
        [SwaggerResponse(200, "Artist music videos retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Could be due to missing or invalid parameters.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> ArtistMv([FromQuery]long id, [FromQuery] int limit = 50, [FromQuery] int offset = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/mvs",
                    OptionType = "weapi",
                    Data = new ArtistMvRequestModel()
                    {
                        ArtistId = id,
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

        /// <summary>
        /// Retrieve the Newest Music Videos of All Artists
        /// </summary>
        /// <param name="limit">The maximum number of music videos to return (default: 50).</param>
        /// <param name="before">A timestamp to fetch music videos before this time. Defaults to the current time.</param>
        /// <returns>A list of the newest music videos from all artists.</returns>
        [HttpGet]
        [Route("artist/new/mv")]
        [SwaggerOperation(
            Summary = "Retrieve Newest Music Videos of All Artists",
            Description = "Fetches a list of the newest music videos from all artists. Supports pagination with limit and allows fetching videos before a specified timestamp.",
            OperationId = "GetNewestArtistMvs",
            Tags = new[] { "Artist", "MusicVideo", "Newest" }
        )]
        [SwaggerResponse(200, "Newest music videos retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Could be due to missing or invalid parameters.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> ArtistNewMv([FromQuery] int limit = 50, [FromQuery]long before = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/sub/artist/new/works/mv/list",
                    OptionType = "weapi",
                    Data = new
                    {
                        limit = limit > 0 ? limit : 20,

                        startTimestamp = before > 0 ? before : DateTimeOffset.Now.ToUnixTimeMilliseconds()
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
        [Route("artist/new/song")]
        public async Task<IActionResult> ArtistNewSong()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/sub/artist/new/works/song/list",
                    OptionType = "weapi",
                    Data = new ArtistNewSongRequestModel()
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

        [HttpGet]
        [Route("artist/songs")]
        [SwaggerOperation(
            Summary = "Retrieve Songs by Artist ID",
            Description = "Fetches a list of songs by a specific artist ID. Supports pagination with limit and offset, and sorting options like 'hot' or 'time'.",
            OperationId = "GetArtistSongs",
            Tags = new[] { "Artist", "Songs" }
        )]
        [SwaggerResponse(200, "Artist songs retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Could be due to missing or invalid parameters.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> ArtistSongs([FromQuery]string id, [FromQuery]int limit = 50, [FromQuery]int offset = 0, [FromQuery]string order = "hot" )
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/artist/songs",
                    OptionType = "weapi",
                    Data = new ArtistSongsRequestModel()
                    {
                        Id = id,
                        Order = order,
                        Limit = limit,
                        Offset = offset,
                        PrivateCloud = "true",
                        WorkType = 1,
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
        [Route("artist/sub")]
        public async Task<IActionResult> ArtistSub([FromQuery] long id, [FromQuery]SubType t = SubType.Sub)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = $"/api/artist/{(int)t}",
                    OptionType = "weapi",
                    Data = new ArtistSubRequestModel()
                    {
                        ArtistId = id,
                        ArtistIds = new long[] { id }
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
        /// Fetch artist subscribed by user with pagination
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("artist/sublist")]
        [SwaggerOperation(summary: "Fetch artist subscribed by user")]
        public async Task<IActionResult> ArtistSublist([FromQuery]int limit = 50, [FromQuery]int offset = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/sublist",
                    OptionType = "weapi",
                    Data = new ArtistSublistRequestModel()
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

        /// <summary>
        /// Subscribe or Unsubscribe an Artist
        /// </summary>
        /// <param name="id">The unique identifier of the artist.</param>
        /// <param name="t">The operation type: 1 to subscribe, any other value to unsubscribe.</param>
        /// <returns>A response indicating the result of the subscription or unsubscription operation.</returns>
        [HttpGet]
        [Route("artist/sub")]
        [SwaggerOperation(
            Summary = "Subscribe or Unsubscribe an Artist",
            Description = "Allows subscribing or unsubscribing to an artist. Use `t=1` for subscribing and any other value for unsubscribing.",
            OperationId = "SubscribeOrUnsubscribeArtist",
            Tags = new[] { "Artist", "Subscription" }
        )]
        [SwaggerResponse(200, "Subscription or unsubscription operation successful.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Could be due to missing or invalid parameters.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> ArtistSub([FromQuery]string id, [FromQuery]int t)
        {
            try
            {
                string subType = t == 1 ? "sub" : "unsub";
                var apiModel = new ApiModel
                {
                    ApiEndpoint = $"/api/artist/{subType}",
                    OptionType = "weapi",
                    Data = new
                    {
                        artistId = id,
                        artistIds = new string[] { id }
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
        [Route("artist/top/song")]
        public async Task<IActionResult> ArtistTopSong()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/top/song",
                    OptionType = "weapi",
                    Data = new ArtistTopSongRequestModel()
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
        [Route("artist/video")]
        public async Task<IActionResult> ArtistVideo()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mlog/artist/video",
                    OptionType = "weapi",
                    Data = new ArtistVideoRequestModel()
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
