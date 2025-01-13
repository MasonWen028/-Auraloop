using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountriesService _countriesService;
        private readonly RequestContext _context;

        public CountriesController(ICountriesService countriesService, RequestContext context)
        {
            _countriesService = countriesService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("codelist")]
        public async Task<IActionResult> CountriesCodeList()
        {
            try
            {
                var response = await _countriesService.CountriesCodeList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
