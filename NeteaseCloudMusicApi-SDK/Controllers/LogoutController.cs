using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class LogoutController : Controller
    {
        private readonly GenericService _genericService;

        public LogoutController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/logout",
                    OptionType = "weapi",
                    Data = new LogoutRequestModel()
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
