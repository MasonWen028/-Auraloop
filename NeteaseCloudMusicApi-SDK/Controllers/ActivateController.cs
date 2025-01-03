using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ActivateController : Controller
    {
        private readonly GenericService _genericService;

        public ActivateController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("activate/init/profile")]
        public async Task<IActionResult> ActivateInitProfile([FromBody] ActivateInitProfileRequestModel requestModel)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/activate/initProfile",
                    OptionType = "weapi",
                    Data = requestModel
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
