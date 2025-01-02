using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class MusicController : Controller
    {
        private readonly GenericService _genericService;

        public MusicController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("music/first/listen/info")]
        public async Task<IActionResult> MusicFirstListenInfo()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/content/activity/music/first/listen/info",
                    OptionType = "weapi",
                    Data = new MusicFirstListenInfoRequestModel()
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
