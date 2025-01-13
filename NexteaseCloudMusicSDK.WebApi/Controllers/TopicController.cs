using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly RequestContext _context;

        public TopicController(ITopicService topicService, RequestContext context)
        {
            _topicService = topicService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("detail")]
        public async Task<IActionResult> Detail([FromBody] TopicDetailRequestModel requestModel)
        {
            try
            {
                var response = await _topicService.Detail(requestModel);
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
        [HttpPost("detaileventhot")]
        public async Task<IActionResult> DetailEventHot([FromBody] TopicDetailRequestModel requestModel)
        {
            try
            {
                var response = await _topicService.DetailEventHot(requestModel);
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
        [HttpPost("sublist")]
        public async Task<IActionResult> Sublist([FromBody] TopicSublistRequestModel requestModel)
        {
            try
            {
                var response = await _topicService.Sublist(requestModel);
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
        [HttpGet("hot")]
        public async Task<IActionResult> Hot()
        {
            try
            {
                var response = await _topicService.Hot();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
