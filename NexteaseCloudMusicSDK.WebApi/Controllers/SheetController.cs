using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SheetController : Controller
    {
        private readonly ISheetService _sheetService;
        private readonly RequestContext _context;

        public SheetController(ISheetService sheetService, RequestContext context)
        {
            _sheetService = sheetService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("list")]
        public async Task<IActionResult> List([FromBody] SheetListRequestModel requestModel)
        {
            try
            {
                var response = await _sheetService.List(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("preview")]
        public async Task<IActionResult> Preview([FromBody] SheetPreviewRequestModel requestModel)
        {
            try
            {
                var response = await _sheetService.Preview(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
