using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgramController : Controller
    {
        private readonly IProgramService _programService;
        private readonly RequestContext _context;

        public ProgramController(IProgramService programService, RequestContext context)
        {
            _programService = programService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("recommend")]
        public async Task<IActionResult> Recommend([FromBody] ProgramRecommendRequestModel requestModel)
        {
            try
            {
                var response = await _programService.Recommend(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
