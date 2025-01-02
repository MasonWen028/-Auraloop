using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class CalendarController : Controller
    {
        private readonly GenericService _genericService;

        public CalendarController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("calendar")]
        public async Task<IActionResult> Calendar()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mcalendar/detail",
                    OptionType = "weapi",
                    Data = new CalendarRequestModel()
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
