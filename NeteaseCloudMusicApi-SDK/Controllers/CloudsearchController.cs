using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class CloudsearchController : Controller
    {
        private readonly GenericService _genericService;

        public CloudsearchController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("cloudsearch")]
        public async Task<IActionResult> Cloudsearch()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloudsearch/pc",
                    OptionType = "weapi",
                    Data = new CloudsearchRequestModel()
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
