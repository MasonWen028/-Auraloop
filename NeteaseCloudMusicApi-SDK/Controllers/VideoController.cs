using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class VideoController : Controller
    {
        private readonly GenericService _genericService;

        public VideoController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("video/category/list")]
        public async Task<IActionResult> VideoCategoryList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloudvideo/category/list",
                    OptionType = "weapi",
                    Data = new VideoCategoryListRequestModel()
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
        /// Fecth the details of Video
        /// </summary>
        /// <param name="id">video id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("video/detail")]
        [SwaggerOperation(summary: "Fecth the details of Video")]
        public async Task<IActionResult> VideoDetail([FromQuery]long id)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloudvideo/v1/video/detail",
                    OptionType = "weapi",
                    Data = new VideoDetailRequestModel()
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

        /// <summary>
        /// Fetch count of like, forward and comment
        /// </summary>
        /// <param name="vid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("video/detail/info")]
        [SwaggerOperation(summary: "Fetch count of like, forward and comment")]
        public async Task<IActionResult> VideoDetailInfo([FromQuery]long vid)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/comment/commentthread/info",
                    OptionType = "weapi",
                    Data = new VideoDetailInfoRequestModel()
                    {
                        Threadid = $"R_VI_62_{vid}"
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
        [Route("video/group")]
        public async Task<IActionResult> VideoGroup()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/videotimeline/videogroup/otherclient/get",
                    OptionType = "weapi",
                    Data = new VideoGroupRequestModel()
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
        [Route("video/group/list")]
        public async Task<IActionResult> VideoGroupList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloudvideo/group/list",
                    OptionType = "weapi",
                    Data = new VideoGroupListRequestModel()
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
        [Route("video/sub")]
        public async Task<IActionResult> VideoSub()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloudvideo/video/${query.t}",
                    OptionType = "weapi",
                    Data = new VideoSubRequestModel()
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
        [Route("video/timeline/all")]
        public async Task<IActionResult> VideoTimelineAll()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/videotimeline/otherclient/get",
                    OptionType = "weapi",
                    Data = new VideoTimelineAllRequestModel()
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
        [Route("video/timeline/recommend")]
        public async Task<IActionResult> VideoTimelineRecommend()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/videotimeline/get",
                    OptionType = "weapi",
                    Data = new VideoTimelineRecommendRequestModel()
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
        /// Fetch the url of video
        /// </summary>
        /// <param name="id">Video id</param>
        /// <param name="r">resolution of video</param>
        /// <returns></returns>
        [HttpGet]
        [Route("video/url")]
        [SwaggerOperation(summary: "Fetch the url of video")]
        public async Task<IActionResult> VideoUrl([FromQuery]long id, [FromQuery]int r = 1080)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloudvideo/playurl",
                    OptionType = "weapi",
                    Data = new VideoUrlRequestModel()
                    {
                        Ids = $"[{id}]",
                        Resolution = r
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
