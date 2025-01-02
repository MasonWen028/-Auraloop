using Microsoft.AspNetCore.Mvc;
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
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("video/detail")]
        public async Task<IActionResult> VideoDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloudvideo/v1/video/detail",
                    OptionType = "weapi",
                    Data = new VideoDetailRequestModel()
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
        [Route("video/detail/info")]
        public async Task<IActionResult> VideoDetailInfo()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "R_VI_62_${query.vid}",
                    OptionType = "weapi",
                    Data = new VideoDetailInfoRequestModel()
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
                return Ok(result.data);
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
                return Ok(result.data);
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
                return Ok(result.data);
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
                return Ok(result.data);
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
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("video/url")]
        public async Task<IActionResult> VideoUrl()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloudvideo/playurl",
                    OptionType = "weapi",
                    Data = new VideoUrlRequestModel()
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
