using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class VerifyController : Controller
    {
        private readonly GenericService _genericService;

        public VerifyController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("verify/getqr")]
        public async Task<IActionResult> VerifyGetqr()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/frontrisk/verify/getqrcode",
                    OptionType = "weapi",
                    Data = new VerifyGetQrRequestModel()
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
        [Route("verify/qrcodestatus")]
        public async Task<IActionResult> VerifyQrcodestatus()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/frontrisk/verify/qrcodestatus",
                    OptionType = "weapi",
                    Data = new VerifyQrcodestatusRequestModel()
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
