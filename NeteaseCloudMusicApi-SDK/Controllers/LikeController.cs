using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class LikeController : Controller
    {
        private readonly GenericService _genericService;

        public LikeController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("like")]
        public async Task<IActionResult> Like()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/radio/like",
                    OptionType = "weapi",
                    Data = new LikeRequestModel()
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
