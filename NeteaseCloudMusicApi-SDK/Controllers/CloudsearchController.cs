using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

        /// <summary>
        /// Seach data
        /// </summary>
        /// <param name="keywords">Searching keywords</param>
        /// <param name="limit">page size</param>
        /// <param name="offset">page no</param>
        /// <param name="type">Searching type</param>
        /// <returns></returns>
        [HttpGet]
        [Route("cloudsearch")]
        [SwaggerOperation(summary: "Seach data")]
        public async Task<IActionResult> Cloudsearch([FromQuery]string keywords, [FromQuery]int limit = 50, [FromQuery]int offset = 0, [FromQuery]SearchTypes type = SearchTypes.All)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloudsearch/pc",
                    OptionType = "weapi",
                    Data = new CloudsearchRequestModel()
                    {
                        S = keywords,
                        Limit = limit,
                        Offset = offset,
                        Total = true,
                        Type = type
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
    }
}
