using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class FmController : Controller
    {
        private readonly GenericService _genericService;

        public FmController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("fm/trash")]
        public async Task<IActionResult> FmTrash()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/radio/trash/add",
                    OptionType = "weapi",
                    Data = new FmTrashRequestModel()
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
