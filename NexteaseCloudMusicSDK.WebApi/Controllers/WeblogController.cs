using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeblogController : Controller
    {
        private readonly IWeblogService _weblogService;
        private readonly RequestContext _context;

        public WeblogController(IWeblogService weblogService, RequestContext context)
        {
            _weblogService = weblogService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> Weblog([FromBody] Object data)
        {
            try
            {
                var response = await _weblogService.Weblog(data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
