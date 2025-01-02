using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class CreatorController : Controller
    {
        private readonly GenericService _genericService;

        public CreatorController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("creator/authinfo/get")]
        public async Task<IActionResult> CreatorAuthinfoGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/creator/authinfo/get",
                    OptionType = "weapi",
                    Data = new CreatorAuthinfoGetRequestModel()
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
