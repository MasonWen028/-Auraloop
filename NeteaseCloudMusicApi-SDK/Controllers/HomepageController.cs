using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class HomepageController : Controller
    {
        private readonly GenericService _genericService;

        public HomepageController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("homepage/block/page")]
        public async Task<IActionResult> HomepageBlockPage()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/homepage/block/page",
                    OptionType = "weapi",
                    Data = new HomepageBlockPageRequestModel()
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

        [HttpPost]
        [Route("homepage/dragon/ball")]
        public async Task<IActionResult> HomepageDragonBall()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/homepage/dragon/ball/static",
                    OptionType = "weapi",
                    Data = new HomepageDragonBallRequestModel()
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
