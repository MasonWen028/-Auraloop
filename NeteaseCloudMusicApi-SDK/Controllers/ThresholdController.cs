using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ThresholdController : Controller
    {
        private readonly GenericService _genericService;

        public ThresholdController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("threshold/detail/get")]
        public async Task<IActionResult> ThresholdDetailGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/influencer/web/apply/threshold/detail/get",
                    OptionType = "weapi",
                    Data = new ThresholdDetailGetRequestModel()
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
