using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class InnerController : Controller
    {
        private readonly GenericService _genericService;

        public InnerController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("inner/version")]
        public async Task<IActionResult> InnerVersion()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "",
                    OptionType = "",
                    Data = new InnerVersionRequestModel()
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
