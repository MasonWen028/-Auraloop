using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ScrobbleController : Controller
    {
        private readonly GenericService _genericService;

        public ScrobbleController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("scrobble")]
        public async Task<IActionResult> Scrobble()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/feedback/weblog",
                    OptionType = "weapi",
                    Data = new ScrobbleRequestModel()
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
