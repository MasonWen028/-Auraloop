using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarController : Controller
    {
        private readonly ICalendarService _calendarService;
        private readonly RequestContext _context;

        public CalendarController(ICalendarService calendarService, RequestContext context)
        {
            _calendarService = calendarService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("details")]
        public async Task<IActionResult> GetCalendarDetails([FromBody] CalendarRequestModel requestModel)
        {
            try
            {
                var response = await _calendarService.GetCalendarDetails(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
