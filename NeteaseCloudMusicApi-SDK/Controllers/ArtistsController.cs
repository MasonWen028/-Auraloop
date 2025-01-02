using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ArtistsController : Controller
    {
        private readonly GenericService _genericService;

        public ArtistsController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("artists")]
        public async Task<IActionResult> Artists()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/artist/${query.id}",
                    OptionType = "weapi",
                    Data = new ArtistsRequestModel()
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
