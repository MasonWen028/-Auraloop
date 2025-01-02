using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ProgramController : Controller
    {
        private readonly GenericService _genericService;

        public ProgramController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("program/recommend")]
        public async Task<IActionResult> ProgramRecommend()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/program/recommend/v1",
                    OptionType = "weapi",
                    Data = new ProgramRecommendRequestModel()
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
