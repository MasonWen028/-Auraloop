using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class AvatarController : Controller
    {
        private readonly GenericService _genericService;

        public AvatarController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("avatar/upload")]
        public async Task<IActionResult> AvatarUpload()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/avatar/upload/v1",
                    OptionType = "weapi",
                    Data = new AvatarUploadRequestModel()
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
