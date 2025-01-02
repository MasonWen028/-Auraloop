using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class RebindController : Controller
    {
        private readonly GenericService _genericService;

        public RebindController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("rebind")]
        public async Task<IActionResult> Rebind()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/replaceCellphone",
                    OptionType = "weapi",
                    Data = new RebindRequestModel()
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
