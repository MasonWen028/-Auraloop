using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class AidjController : Controller
    {
        private readonly GenericService _genericService;

        public AidjController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("aidj/content/rcmd")]
        public async Task<IActionResult> AidjContentRcmd()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/aidj/content/rcmd/info",
                    OptionType = "weapi",
                    Data = new AidjContentRcmdRequestModel()
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
