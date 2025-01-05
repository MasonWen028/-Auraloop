using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class TopicController : Controller
    {
        private readonly GenericService _genericService;

        public TopicController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("topic/detail")]
        public async Task<IActionResult> TopicDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/act/detail",
                    OptionType = "weapi",
                    Data = new TopicDetailRequestModel()
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
        [Route("topic/detail/event/hot")]
        public async Task<IActionResult> TopicDetailEventHot()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/act/event/hot",
                    OptionType = "weapi",
                    Data = new TopicDetailEventHotRequestModel()
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
        [Route("topic/sublist")]
        public async Task<IActionResult> TopicSublist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/topic/sublist",
                    OptionType = "weapi",
                    Data = new TopicSublistRequestModel()
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
