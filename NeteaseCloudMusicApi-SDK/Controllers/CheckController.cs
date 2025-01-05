using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class CheckController : Controller
    {
        private readonly GenericService _genericService;

        public CheckController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("check/music")]
        public async Task<IActionResult> CheckMusic()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/enhance/player/url",
                    OptionType = "weapi",
                    Data = new CheckMusicRequestModel()
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
