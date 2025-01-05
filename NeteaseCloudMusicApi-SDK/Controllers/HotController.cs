using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class HotController : Controller
    {
        private readonly GenericService _genericService;

        public HotController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("hot/topic")]
        public async Task<IActionResult> HotTopic()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/act/hot",
                    OptionType = "weapi",
                    Data = new HotTopicRequestModel()
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
