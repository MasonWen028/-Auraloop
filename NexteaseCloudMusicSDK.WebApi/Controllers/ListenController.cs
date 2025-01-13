using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListenController : Controller
    {
        private readonly IListenService _listenService;
        private readonly RequestContext _context;

        public ListenController(IListenService listenService, RequestContext context)
        {
            _listenService = listenService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("realtimereport")]
        public async Task<IActionResult> RealtimeReport([FromBody] ListenDataRealtimeReportRequestModel requestModel)
        {
            try
            {
                var response = await _listenService.RealtimeReport(requestModel);
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
        [HttpPost("report")]
        public async Task<IActionResult> Report([FromBody] ListenDataReportRequestModel requestModel)
        {
            try
            {
                var response = await _listenService.Report(requestModel);
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
        [HttpGet("todaysongs")]
        public async Task<IActionResult> TodaySongs()
        {
            try
            {
                var response = await _listenService.TodaySongs();
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
        [HttpGet("total")]
        public async Task<IActionResult> Total()
        {
            try
            {
                var response = await _listenService.Total();
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
        [HttpGet("yearreport")]
        public async Task<IActionResult> YearReport()
        {
            try
            {
                var response = await _listenService.YearReport();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
