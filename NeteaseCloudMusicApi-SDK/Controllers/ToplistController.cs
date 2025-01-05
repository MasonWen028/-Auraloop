using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

        /// <summary>
        /// Fetch the list of toplist
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation(
            summary: "Fetch the list of toplist",
            Tags = new string[] { "Toplist", "List" }
        )]
        [HttpGet]
        [Route("toplist")]
        public async Task<IActionResult> Toplist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/toplist",
                    OptionType = "weapi"
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
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
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Fetch the details of toplist
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation(
            summary: "Fetch the details of toplist",
            Tags = new string[] { "Toplist", "Detail" }
        )]
        [HttpGet]
        [Route("toplist/detail")]
        public async Task<IActionResult> ToplistDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/toplist/detail",
                    OptionType = "weapi"
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
