using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

        /// <summary>
        /// Retrieves a list of country codes from the external API.
        /// </summary>
        /// <remarks>
        /// This endpoint fetches country code data by forwarding a request to an external API (`/api/lbs/countries/v1`) 
        /// using a generic service. The data is returned as-is in the response body.
        /// </remarks>
        /// <returns>
        /// An HTTP 200 response containing the list of country codes from the external API, 
        /// or an HTTP 500 response in case of an internal server error.
        /// </returns>

        [HttpGet]
        [HttpGet]
        [Route("countries/code/list")]
                [SwaggerOperation(
            Summary = "Retrieve country code list",
            Description = "Fetches a list of country codes by making a request to the external API endpoint `/api/lbs/countries/v1`."
        )]
        [SwaggerResponse(200, "Successfully retrieved the list of country codes.", typeof(object))]
        [SwaggerResponse(500, "Internal server error.")]
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
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
