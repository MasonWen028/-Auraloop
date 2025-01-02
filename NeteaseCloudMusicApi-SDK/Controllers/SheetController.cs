using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class SheetController : Controller
    {
        private readonly GenericService _genericService;

        public SheetController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("sheet/list")]
        public async Task<IActionResult> SheetList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/music/sheet/list/v1",
                    OptionType = "weapi",
                    Data = new SheetListRequestModel()
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

        [HttpPost]
        [Route("sheet/preview")]
        public async Task<IActionResult> SheetPreview()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/music/sheet/preview/info",
                    OptionType = "weapi",
                    Data = new SheetPreviewRequestModel()
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
