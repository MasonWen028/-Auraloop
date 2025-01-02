using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class NicknameController : Controller
    {
        private readonly GenericService _genericService;

        public NicknameController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("nickname/check")]
        public async Task<IActionResult> NicknameCheck()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/nickname/duplicated",
                    OptionType = "weapi",
                    Data = new NicknameCheckRequestModel()
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
