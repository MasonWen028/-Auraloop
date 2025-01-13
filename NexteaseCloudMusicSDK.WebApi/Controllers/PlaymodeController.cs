using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaymodeController : Controller
    {
        private readonly IPlaymodeService _playmodeService;
        private readonly RequestContext _context;

        public PlaymodeController(IPlaymodeService playmodeService, RequestContext context)
        {
            _playmodeService = playmodeService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("intelligencelist")]
        public async Task<IActionResult> IntelligenceList([FromBody] PlaymodeIntelligenceListRequestModel requestModel)
        {
            try
            {
                var response = await _playmodeService.IntelligenceList(requestModel);
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
        [HttpPost("songvector")]
        public async Task<IActionResult> SongVector([FromBody] PlaymodeSongVectorRequestModel requestModel)
        {
            try
            {
                var response = await _playmodeService.SongVector(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
