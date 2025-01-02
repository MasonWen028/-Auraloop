using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost]
        [Route("comment/hot")]
        public async Task<IActionResult> CommentHot()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/resource/hotcomments/${query.type}${query.id}",
                    OptionType = "weapi",
                    Data = new CommentHotRequestModel()
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

        [HttpPost]
        [Route("comment/like")]
        public async Task<IActionResult> CommentLike()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/comment/${query.t}",
                    OptionType = "weapi",
                    Data = new CommentLikeRequestModel()
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

        [HttpPost]
        [Route("comment/new")]
        public async Task<IActionResult> CommentNew()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v2/resource/comments",
                    OptionType = "weapi",
                    Data = new CommentNewRequestModel()
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
