using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class PlController : Controller
    {
        private readonly GenericService _genericService;

        public PlController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("pl/count")]
        public async Task<IActionResult> PlCount()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/pl/count",
                    OptionType = "weapi",
                    Data = new PlCountRequestModel()
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
