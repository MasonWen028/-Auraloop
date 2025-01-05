using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ApiController : Controller
    {
        private readonly GenericService _genericService;

        public ApiController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("api")]
        public async Task<IActionResult> Api()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "",
                    OptionType = "weapi",
                    Data = new ApiRequestModel()
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
