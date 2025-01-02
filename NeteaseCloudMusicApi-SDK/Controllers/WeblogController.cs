using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class WeblogController : Controller
    {
        private readonly GenericService _genericService;

        public WeblogController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("weblog")]
        public async Task<IActionResult> Weblog()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/feedback/weblog",
                    OptionType = "weapi",
                    Data = new WeblogRequestModel()
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
