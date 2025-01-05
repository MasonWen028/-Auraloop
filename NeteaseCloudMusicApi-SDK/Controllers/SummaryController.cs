using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class SummaryController : Controller
    {
        private readonly GenericService _genericService;

        public SummaryController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("summary/annual")]
        public async Task<IActionResult> SummaryAnnual()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/activity/summary/annual/${query.year}/${key}",
                    OptionType = "weapi",
                    Data = new SummaryAnnualRequestModel()
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
