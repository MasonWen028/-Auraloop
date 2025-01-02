using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class LikelistController : Controller
    {
        private readonly GenericService _genericService;

        public LikelistController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("likelist")]
        public async Task<IActionResult> Likelist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/like/get",
                    OptionType = "weapi",
                    Data = new LikelistRequestModel()
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
