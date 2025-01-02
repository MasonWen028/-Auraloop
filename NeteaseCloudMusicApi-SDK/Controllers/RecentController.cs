using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class RecentController : Controller
    {
        private readonly GenericService _genericService;

        public RecentController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("recent/listen/list")]
        public async Task<IActionResult> RecentListenList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/pc/recent/listen/list",
                    OptionType = "weapi",
                    Data = new RecentListenListRequestModel()
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
