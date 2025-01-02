using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ToplistController : Controller
    {
        private readonly GenericService _genericService;

        public ToplistController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("toplist")]
        public async Task<IActionResult> Toplist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/toplist",
                    OptionType = "weapi",
                    Data = new ToplistRequestModel()
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
        [Route("toplist/artist")]
        public async Task<IActionResult> ToplistArtist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/toplist/artist",
                    OptionType = "weapi",
                    Data = new ToplistArtistRequestModel()
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
        [Route("toplist/detail")]
        public async Task<IActionResult> ToplistDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/toplist/detail",
                    OptionType = "weapi",
                    Data = new ToplistDetailRequestModel()
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
