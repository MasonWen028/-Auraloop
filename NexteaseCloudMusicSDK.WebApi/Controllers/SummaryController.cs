using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SummaryController : Controller
    {
        private readonly ISummaryService _summaryService;
        private readonly RequestContext _context;

        public SummaryController(ISummaryService summaryService, RequestContext context)
        {
            _summaryService = summaryService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("annual")]
        public async Task<IActionResult> SummaryAnnual([FromBody] SummaryAnnualRequestModel requestModel)
        {
            try
            {
                var response = await _summaryService.SummaryAnnual(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
