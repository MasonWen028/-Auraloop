using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckController : Controller
    {
        private readonly ICheckService _checkService;
        private readonly RequestContext _context;

        public CheckController(ICheckService checkService, RequestContext context)
        {
            _checkService = checkService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("music")]
        public async Task<IActionResult> CheckMusic([FromBody] CheckMusicRequestModel requestModel)
        {
            try
            {
                var response = await _checkService.CheckMusic(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
