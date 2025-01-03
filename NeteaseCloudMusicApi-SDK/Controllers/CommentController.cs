using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeteaseCloudMusicApi_SDK.Helpers.RequestClient;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.Design;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class CommentController : Controller
    {
        private readonly GenericService _genericService;

        public CommentController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("comment")]
        public async Task<IActionResult> Comment()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/resource/comments/${query.t}",
                    OptionType = "weapi",
                    Data = new CommentRequestModel()
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
        [Route("comment/album")]
        public async Task<IActionResult> CommentAlbum()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/resource/comments/R_AL_3_${query.id}",
                    OptionType = "weapi",
                    Data = new CommentAlbumRequestModel()
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
        [Route("comment/dj")]
        public async Task<IActionResult> CommentDj()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/resource/comments/A_DJ_1_${query.id}",
                    OptionType = "weapi",
                    Data = new CommentDjRequestModel()
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
        [Route("comment/event")]
        public async Task<IActionResult> CommentEvent()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/resource/comments/${query.threadId}",
                    OptionType = "weapi",
                    Data = new CommentEventRequestModel()
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
        [Route("comment/floor")]
        public async Task<IActionResult> CommentFloor()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/resource/comment/floor/get",
                    OptionType = "weapi",
                    Data = new CommentFloorRequestModel()
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

        [HttpGet]
        [Route("comment/hot")]
        [SwaggerOperation(
            Summary = "Retrieve Hot Comments for a Resource",
            Description = "Fetches the hot comments for a specified resource, such as a song, album, or playlist. Supports pagination with limit and offset.",
            OperationId = "GetHotComments",
            Tags = new[] { "Comment", "Hot", "Tested" } // Marked as tested
        )]
        [SwaggerResponse(200, "Hot comments retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Could be due to missing or invalid parameters.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> CommentHot([FromQuery] CommentHotRequestModel requestModel)
        {
            try
            {
                string t = Cfg.ResourceTypeMap.GetValueOrDefault(((int)requestModel.Type).ToString());

                var apiModel = new ApiModel
                {
                    ApiEndpoint = $"/api/v1/resource/hotcomments/{t}{requestModel.Id}",
                    OptionType = "weapi",
                    Data = new 
                    {
                        rid = requestModel.Id,
                        limit = requestModel.Limit,
                        offset = requestModel.Offset,
                        beforeTime = 0
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
        [Route("comment/hug/list")]
        public async Task<IActionResult> CommentHugList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v2/resource/comments/hug/list",
                    OptionType = "weapi",
                    Data = new CommentHugListRequestModel()
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

        [HttpGet]
        [Route("comment/like")]
        [SwaggerOperation(
            Summary = "Like or Unlike a Comment",
            Description = "Allows liking or unliking a comment on a specific resource. The operation depends on the provided type of resource and comment ID.",
            OperationId = "CommentLikeOrUnlike",
            Tags = new[] { "Comment", "Like" }
        )]
        [SwaggerResponse(200, "Comment liked or unliked successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Could be due to missing or invalid parameters.")]
        [SwaggerResponse(500, "An internal server error occurred.")]

        public async Task<IActionResult> CommentLike([FromQuery] CommentLikeRequestModel requestModel)
        {
            try
            {
                string t = requestModel.Operation == 1 ? "like" : "unlike";
                string type = Cfg.ResourceTypeMap.GetValueOrDefault(((int)requestModel.Type).ToString());
                var apiModel = new ApiModel
                {
                    ApiEndpoint = $"/api/v1/comment/{t}",
                    OptionType = "weapi",
                    Data = new
                    {
                        threadId = type != "A_EV_2_" ? type + requestModel.Id : requestModel.Id.ToString(),
                        commentId = requestModel.Id
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
        [Route("comment/music")]
        public async Task<IActionResult> CommentMusic()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/resource/comments/R_SO_4_${query.id}",
                    OptionType = "weapi",
                    Data = new CommentMusicRequestModel()
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
        [Route("comment/mv")]
        public async Task<IActionResult> CommentMv()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/resource/comments/R_MV_5_${query.id}",
                    OptionType = "weapi",
                    Data = new CommentMvRequestModel()
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
        /// Retrieve Comments for a Song
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("comment/new")]
        [SwaggerOperation(
            Summary = "Retrieve Comments for a Song",
            Description = "Fetches comments associated with a specific song or resource. The request supports pagination, cursor-based navigation, and sorting options.",
            OperationId = "GetSongComments",
            Tags = new[] { "Comment", "Song" }
        )]
        [SwaggerResponse(200, "Comments retrieved successfully.", typeof(object))]
        [SwaggerResponse(400, "Invalid request. Could be due to missing or invalid parameters.")]
        [SwaggerResponse(500, "An internal server error occurred.")]
        public async Task<IActionResult> CommentNew([FromQuery] CommentNewRequestModel requestModel)
        {
            try
            {
                string t = Cfg.ResourceTypeMap.GetValueOrDefault(((int)requestModel.Type).ToString());
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v2/resource/comments",
                    OptionType = "weapi",
                    Data =new { 
                        threadId = t + requestModel.Id,
                        showInner = true,
                        pageNo = requestModel.PageNo,
                        pageSize = requestModel.PageSize,
                        cursor = requestModel.Cursor,
                        sortType = (int)requestModel.SortType,
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
        [Route("comment/playlist")]
        public async Task<IActionResult> CommentPlaylist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/resource/comments/A_PL_0_${query.id}",
                    OptionType = "weapi",
                    Data = new CommentPlaylistRequestModel()
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
        [Route("comment/video")]
        public async Task<IActionResult> CommentVideo()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/resource/comments/R_VI_62_${query.id}",
                    OptionType = "weapi",
                    Data = new CommentVideoRequestModel()
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
