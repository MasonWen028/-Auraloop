using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class StarpickController : Controller
    {
        private readonly GenericService _genericService;

        public StarpickController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("starpick/comments/summary")]
        public async Task<IActionResult> StarpickCommentsSummary()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/homepage/block/page",
                    OptionType = "weapi",
                    Data = new StarpickCommentsSummaryRequestModel()
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
