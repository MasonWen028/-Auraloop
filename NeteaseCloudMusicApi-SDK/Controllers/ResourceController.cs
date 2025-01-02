using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ResourceController : Controller
    {
        private readonly GenericService _genericService;

        public ResourceController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("resource/like")]
        public async Task<IActionResult> ResourceLike()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/resource/${query.t}",
                    OptionType = "weapi",
                    Data = new ResourceLikeRequestModel()
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
