using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ShareController : Controller
    {
        private readonly GenericService _genericService;

        public ShareController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("share/resource")]
        public async Task<IActionResult> ShareResource()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/share/friends/resource",
                    OptionType = "weapi",
                    Data = new ShareResourceRequestModel()
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
