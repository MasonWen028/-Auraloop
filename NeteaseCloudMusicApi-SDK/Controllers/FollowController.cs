using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class FollowController : Controller
    {
        private readonly GenericService _genericService;

        public FollowController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("follow")]
        public async Task<IActionResult> Follow()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/${query.t}/${query.id}",
                    OptionType = "weapi",
                    Data = new FollowRequestModel()
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
