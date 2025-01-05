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

        /// <summary>
        /// Fetch personalized dj list
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("aidj/content/rcmd")]
        public async Task<IActionResult> AidjContentRcmd([FromBody]ExtInfo requestModel)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/aidj/content/rcmd/info",
                    OptionType = "weapi"
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
