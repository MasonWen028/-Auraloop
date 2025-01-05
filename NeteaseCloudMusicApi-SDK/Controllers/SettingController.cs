using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class SettingController : Controller
    {
        private readonly GenericService _genericService;

        public SettingController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("setting")]
        public async Task<IActionResult> Setting()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/setting",
                    OptionType = "weapi",
                    Data = new SettingRequestModel()
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
