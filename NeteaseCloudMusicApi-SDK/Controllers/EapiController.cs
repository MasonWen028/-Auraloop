using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class EapiController : Controller
    {
        private readonly GenericService _genericService;

        public EapiController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("eapi/decrypt")]
        public async Task<IActionResult> EapiDecrypt()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "",
                    OptionType = "",
                    Data = new EapiDecryptRequestModel()
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
