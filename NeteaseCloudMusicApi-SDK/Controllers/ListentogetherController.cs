using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ListentogetherController : Controller
    {
        private readonly GenericService _genericService;

        public ListentogetherController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("listentogether/accept")]
        public async Task<IActionResult> ListentogetherAccept()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/listen/together/play/invitation/accept",
                    OptionType = "weapi",
                    Data = new ListentogetherAcceptRequestModel()
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
        [Route("listentogether/end")]
        public async Task<IActionResult> ListentogetherEnd()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/listen/together/end/v2",
                    OptionType = "weapi",
                    Data = new ListentogetherEndRequestModel()
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
        [Route("listentogether/heatbeat")]
        public async Task<IActionResult> ListentogetherHeatbeat()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/listen/together/heartbeat",
                    OptionType = "weapi",
                    Data = new ListentogetherHeatbeatRequestModel()
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
        [Route("listentogether/play/command")]
        public async Task<IActionResult> ListentogetherPlayCommand()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/listen/together/play/command/report",
                    OptionType = "weapi",
                    Data = new ListentogetherPlayCommandRequestModel()
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
        [Route("listentogether/room/check")]
        public async Task<IActionResult> ListentogetherRoomCheck()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/listen/together/room/check",
                    OptionType = "weapi",
                    Data = new ListentogetherRoomCheckRequestModel()
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
        [Route("listentogether/room/create")]
        public async Task<IActionResult> ListentogetherRoomCreate()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/listen/together/room/create",
                    OptionType = "weapi",
                    Data = new ListentogetherRoomCreateRequestModel()
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
        [Route("listentogether/status")]
        public async Task<IActionResult> ListentogetherStatus()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/listen/together/status/get",
                    OptionType = "weapi",
                    Data = new ListentogetherStatusRequestModel()
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
        [Route("listentogether/sync/list/command")]
        public async Task<IActionResult> ListentogetherSyncListCommand()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/listen/together/sync/list/command/report",
                    OptionType = "weapi",
                    Data = new ListentogetherSyncListCommandRequestModel()
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
        [Route("listentogether/sync/playlist/get")]
        public async Task<IActionResult> ListentogetherSyncPlaylistGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/listen/together/sync/playlist/get",
                    OptionType = "weapi",
                    Data = new ListentogetherSyncPlaylistGetRequestModel()
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
