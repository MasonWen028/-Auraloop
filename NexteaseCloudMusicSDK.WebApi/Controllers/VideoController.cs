using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        private readonly RequestContext _context;

        public VideoController(IVideoService videoService, RequestContext context)
        {
            _videoService = videoService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("categorylist")]
        public async Task<IActionResult> CategoryList([FromBody] VideoCategoryListRequestModel requestModel)
        {
            try
            {
                var response = await _videoService.CategoryList(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("detail")]
        public async Task<IActionResult> Detail([FromQuery] Int64 id)
        {
            try
            {
                var response = await _videoService.Detail(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("detailinfo")]
        public async Task<IActionResult> DetailInfo([FromQuery] Int64 vid)
        {
            try
            {
                var response = await _videoService.DetailInfo(vid);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("group")]
        public async Task<IActionResult> Group([FromBody] VideoGroupRequestModel requestModel)
        {
            try
            {
                var response = await _videoService.Group(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("grouplist")]
        public async Task<IActionResult> GroupList()
        {
            try
            {
                var response = await _videoService.GroupList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("sub")]
        public async Task<IActionResult> Sub([FromQuery] Int64 id, Boolean subscribe)
        {
            try
            {
                var response = await _videoService.Sub(id, subscribe);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("timelineall")]
        public async Task<IActionResult> TimelineAll([FromBody] VideoTimelineRequestModel requestModel)
        {
            try
            {
                var response = await _videoService.TimelineAll(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("timelinerecommend")]
        public async Task<IActionResult> TimelineRecommend([FromBody] VideoTimelineRecommendRequestModel requestModel)
        {
            try
            {
                var response = await _videoService.TimelineRecommend(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("url")]
        public async Task<IActionResult> Url([FromQuery] Int64 id, Int32 resolution)
        {
            try
            {
                var response = await _videoService.Url(id, resolution);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
