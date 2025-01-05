using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class SigninController : Controller
    {
        private readonly GenericService _genericService;

        public SigninController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("signin/progress")]
        public async Task<IActionResult> SigninProgress()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/act/modules/signin/v2/progress",
                    OptionType = "weapi",
                    Data = new SigninProgressRequestModel()
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
