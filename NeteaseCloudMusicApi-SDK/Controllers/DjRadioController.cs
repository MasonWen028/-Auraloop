using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class DjRadioController : Controller
    {
        private readonly GenericService _genericService;

        public DjRadioController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("djradio/top")]
        public async Task<IActionResult> DjradioTop()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "",
                    OptionType = "weapi",
                    Data = new DjRadioTopRequestModel()
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
