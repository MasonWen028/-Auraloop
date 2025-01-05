using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class HugController : Controller
    {
        private readonly GenericService _genericService;

        public HugController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("hug/comment")]
        public async Task<IActionResult> HugComment()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v2/resource/comments/hug/listener",
                    OptionType = "weapi",
                    Data = new HugCommentRequestModel()
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
