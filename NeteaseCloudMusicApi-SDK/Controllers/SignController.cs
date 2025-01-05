using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class SignController : Controller
    {
        private readonly GenericService _genericService;

        public SignController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("sign/happy/info")]
        public async Task<IActionResult> SignHappyInfo()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/sign/happy/info",
                    OptionType = "weapi",
                    Data = new SignHappyInfoRequestModel()
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
