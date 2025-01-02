using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class DailyController : Controller
    {
        private readonly GenericService _genericService;

        public DailyController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("daily/signin")]
        public async Task<IActionResult> DailySignin()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/point/dailyTask",
                    OptionType = "weapi",
                    Data = new DailySigninRequestModel()
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
