using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class EventController : Controller
    {
        private readonly GenericService _genericService;

        public EventController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("event")]
        public async Task<IActionResult> Event()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/event/get",
                    OptionType = "weapi",
                    Data = new EventRequestModel()
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
        [Route("event/del")]
        public async Task<IActionResult> EventDel()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/event/delete",
                    OptionType = "weapi",
                    Data = new EventDelRequestModel()
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
        [Route("event/forward")]
        public async Task<IActionResult> EventForward()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/event/forward",
                    OptionType = "weapi",
                    Data = new EventForwardRequestModel()
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
