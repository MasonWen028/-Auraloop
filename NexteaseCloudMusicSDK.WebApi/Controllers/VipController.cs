using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VipController : Controller
    {
        private readonly IVipService _vipService;
        private readonly RequestContext _context;

        public VipController(IVipService vipService, RequestContext context)
        {
            _vipService = vipService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("growthpoint")]
        public async Task<IActionResult> GrowthPoint()
        {
            try
            {
                var response = await _vipService.GrowthPoint();
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
        [HttpPost("growthpointdetails")]
        public async Task<IActionResult> GrowthPointDetails([FromBody] VipGrowthPointDetailsRequestModel requestModel)
        {
            try
            {
                var response = await _vipService.GrowthPointDetails(requestModel);
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
        [HttpPost("growthpoint")]
        public async Task<IActionResult> GrowthPointGet([FromBody] VipGrowthpointGetRequestModel requestModel)
        {
            try
            {
                var response = await _vipService.GrowthPointGet(requestModel);
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
        [HttpPost("info")]
        public async Task<IActionResult> Info([FromBody]long userId)
        {
            try
            {
                var response = await _vipService.Info(userId);
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
        [HttpPost("infov2")]
        public async Task<IActionResult> InfoV2([FromBody]long userId)
        {
            try
            {
                var response = await _vipService.InfoV2(userId);
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
        public async Task<IActionResult> Tasks()
        {
            try
            {
                var response = await _vipService.Tasks();
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
        [HttpPost("timemachine")]
        public async Task<IActionResult> TimeMachine([FromBody] VipTimeMachineRequestModel requestModel)
        {
            try
            {
                var response = await _vipService.TimeMachine(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
