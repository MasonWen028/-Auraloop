using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlController : Controller
    {
        private readonly IPlService _plService;
        private readonly RequestContext _context;

        public PlController(IPlService plService, RequestContext context)
        {
            _plService = plService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            try
            {
                var response = await _plService.Count();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
