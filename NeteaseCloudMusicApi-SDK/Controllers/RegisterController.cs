using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly GenericService _genericService;

        public RegisterController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("register/anonimous")]
        public async Task<IActionResult> RegisterAnonimous()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "${deviceId} ${cloudmusic_dll_encode_id(deviceId)}",
                    OptionType = "weapi",
                    Data = new RegisterAnonimousRequestModel()
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
        [Route("register/cellphone")]
        public async Task<IActionResult> RegisterCellphone()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/register/cellphone",
                    OptionType = "weapi",
                    Data = new RegisterCellphoneRequestModel()
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
