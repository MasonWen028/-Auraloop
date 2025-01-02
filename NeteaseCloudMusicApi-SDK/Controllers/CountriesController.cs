using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly GenericService _genericService;

        public CountriesController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("countries/code/list")]
        public async Task<IActionResult> CountriesCodeList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/lbs/countries/v1",
                    OptionType = "weapi",
                    Data = new CountriesCodeListRequestModel()
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
