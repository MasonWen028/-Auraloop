using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShareController : Controller
    {
        private readonly IShareService _shareService;
        private readonly RequestContext _context;

        public ShareController(IShareService shareService, RequestContext context)
        {
            _shareService = shareService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("resource")]
        public async Task<IActionResult> Resource([FromBody] ShareResourceRequestModel requestModel)
        {
            try
            {
                var response = await _shareService.Resource(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
