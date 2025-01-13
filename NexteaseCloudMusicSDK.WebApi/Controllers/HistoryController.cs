using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : Controller
    {
        private readonly IHistoryService _historyService;
        private readonly RequestContext _context;

        public HistoryController(IHistoryService historyService, RequestContext context)
        {
            _historyService = historyService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("recommendedsongs")]
        public async Task<IActionResult> GetRecommendedSongs()
        {
            try
            {
                var response = await _historyService.GetRecommendedSongs();
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
        [HttpPost("recommendedsongsdetail")]
        public async Task<IActionResult> GetRecommendedSongsDetail([FromBody] HistoryRecommendSongsDetailRequestModel requestModel)
        {
            try
            {
                var response = await _historyService.GetRecommendedSongsDetail(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
