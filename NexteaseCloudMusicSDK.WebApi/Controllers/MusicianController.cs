using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicianController : Controller
    {
        private readonly IMusicianService _musicianService;
        private readonly RequestContext _context;

        public MusicianController(IMusicianService musicianService, RequestContext context)
        {
            _musicianService = musicianService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("cloudbeanbalance")]
        public async Task<IActionResult> GetCloudbeanBalance()
        {
            try
            {
                var response = await _musicianService.GetCloudbeanBalance();
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
        [HttpPost("claimcloudbeans")]
        public async Task<IActionResult> ClaimCloudbeans([FromBody] MusicianCloudbeanClaimRequestModel requestModel)
        {
            try
            {
                var response = await _musicianService.ClaimCloudbeans(requestModel);
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
        [HttpGet("dataoverview")]
        public async Task<IActionResult> GetDataOverview()
        {
            try
            {
                var response = await _musicianService.GetDataOverview();
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
        [HttpPost("playtrend")]
        public async Task<IActionResult> GetPlayTrend([FromBody] MusicianPlayTrendRequestModel requestModel)
        {
            try
            {
                var response = await _musicianService.GetPlayTrend(requestModel);
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
        [HttpGet("signin")]
        public async Task<IActionResult> SignIn()
        {
            try
            {
                var response = await _musicianService.SignIn();
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
        [HttpGet("tasks")]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                var response = await _musicianService.GetTasks();
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
        [HttpGet("newtasks")]
        public async Task<IActionResult> GetNewTasks()
        {
            try
            {
                var response = await _musicianService.GetNewTasks();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
