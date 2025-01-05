using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class BannerController : Controller
    {
        private readonly GenericService _genericService;

        public BannerController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("banner")]
        public async Task<IActionResult> Banner()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v2/banner/get",
                    OptionType = "weapi",
                    Data = new BannerRequestModel()
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
