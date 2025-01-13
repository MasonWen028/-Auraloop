using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BatchController : Controller
    {
        private readonly IBatchService _batchService;
        private readonly RequestContext _context;

        public BatchController(IBatchService batchService, RequestContext context)
        {
            _batchService = batchService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> Batch([FromBody] BatchRequestModel requestModel)
        {
            try
            {
                var response = await _batchService.Batch(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
