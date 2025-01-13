using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FansCenterController : Controller
    {
        private readonly IFansCenterService _fanscenterService;
        private readonly RequestContext _context;

        public FansCenterController(IFansCenterService fanscenterService, RequestContext context)
        {
            _fanscenterService = fanscenterService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("agedistribution")]
        public async Task<IActionResult> GetAgeDistribution()
        {
            try
            {
                var response = await _fanscenterService.GetAgeDistribution();
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
        [HttpGet("genderdistribution")]
        public async Task<IActionResult> GetGenderDistribution()
        {
            try
            {
                var response = await _fanscenterService.GetGenderDistribution();
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
        [HttpGet("provincedistribution")]
        public async Task<IActionResult> GetProvinceDistribution()
        {
            try
            {
                var response = await _fanscenterService.GetProvinceDistribution();
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
        [HttpGet("overview")]
        public async Task<IActionResult> GetOverview()
        {
            try
            {
                var response = await _fanscenterService.GetOverview();
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
        [HttpPost("trendlist")]
        public async Task<IActionResult> GetTrendList([FromBody] FansCenterTrendRequestModel requestModel)
        {
            try
            {
                var response = await _fanscenterService.GetTrendList(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
