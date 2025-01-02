using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class BatchController : Controller
    {
        private readonly GenericService _genericService;

        public BatchController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("batch")]
        public async Task<IActionResult> Batch()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/batch",
                    OptionType = "weapi",
                    Data = new BatchRequestModel()
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
