using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class MsgController : Controller
    {
        private readonly GenericService _genericService;

        public MsgController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("msg/comments")]
        public async Task<IActionResult> MsgComments()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/user/comments/${query.uid}",
                    OptionType = "weapi",
                    Data = new MsgCommentsRequestModel()
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
        [Route("msg/forwards")]
        public async Task<IActionResult> MsgForwards()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/forwards/get",
                    OptionType = "weapi",
                    Data = new MsgForwardsRequestModel()
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
        [Route("msg/notices")]
        public async Task<IActionResult> MsgNotices()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/msg/notices",
                    OptionType = "weapi",
                    Data = new MsgNoticesRequestModel()
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
        [Route("msg/private")]
        public async Task<IActionResult> MsgPrivate()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/msg/private/users",
                    OptionType = "weapi",
                    Data = new MsgPrivateRequestModel()
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
        [Route("msg/private/history")]
        public async Task<IActionResult> MsgPrivateHistory()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/msg/private/history",
                    OptionType = "weapi",
                    Data = new MsgPrivateHistoryRequestModel()
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
        [Route("msg/recentcontact")]
        public async Task<IActionResult> MsgRecentcontact()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/msg/recentcontact/get",
                    OptionType = "weapi",
                    Data = new MsgRecentcontactRequestModel()
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
