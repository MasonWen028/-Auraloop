using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class PersonalController : Controller
    {
        private readonly GenericService _genericService;

        public PersonalController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("personal/fm")]
        public async Task<IActionResult> PersonalFm()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/radio/get",
                    OptionType = "weapi",
                    Data = new PersonalFmRequestModel()
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

        [HttpPost]
        [Route("personal/fm/mode")]
        public async Task<IActionResult> PersonalFmMode()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/radio/get",
                    OptionType = "weapi",
                    Data = new PersonalFmModeRequestModel()
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
