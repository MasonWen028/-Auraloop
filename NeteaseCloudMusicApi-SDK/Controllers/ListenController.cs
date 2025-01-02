using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ListenController : Controller
    {
        private readonly GenericService _genericService;

        public ListenController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("listen/data/realtime/report")]
        public async Task<IActionResult> ListenDataRealtimeReport()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/content/activity/listen/data/realtime/report",
                    OptionType = "weapi",
                    Data = new ListenDataRealtimeReportRequestModel()
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
        [Route("listen/data/report")]
        public async Task<IActionResult> ListenDataReport()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/content/activity/listen/data/report",
                    OptionType = "weapi",
                    Data = new ListenDataReportRequestModel()
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
        [Route("listen/data/today/song")]
        public async Task<IActionResult> ListenDataTodaySong()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/content/activity/listen/data/today/song/play/rank",
                    OptionType = "weapi",
                    Data = new ListenDataTodaySongRequestModel()
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
        [Route("listen/data/total")]
        public async Task<IActionResult> ListenDataTotal()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/content/activity/listen/data/total",
                    OptionType = "weapi",
                    Data = new ListenDataTotalRequestModel()
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
        [Route("listen/data/year/report")]
        public async Task<IActionResult> ListenDataYearReport()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/content/activity/listen/data/year/report",
                    OptionType = "weapi",
                    Data = new ListenDataYearReportRequestModel()
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
