using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class GetController : Controller
    {
        private readonly GenericService _genericService;

        public GetController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("get/userids")]
        public async Task<IActionResult> GetUserids()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/getUserIds",
                    OptionType = "weapi",
                    Data = new GetUseridsRequestModel()
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
