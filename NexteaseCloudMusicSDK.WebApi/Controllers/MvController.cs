using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MvController : Controller
    {
        private readonly IMvService _mvService;
        private readonly RequestContext _context;

        public MvController(IMvService mvService, RequestContext context)
        {
            _mvService = mvService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("all")]
        public async Task<IActionResult> GetAll([FromBody] MvAllRequestModel requestModel)
        {
            try
            {
                var response = await _mvService.GetAll(requestModel);
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
        [HttpGet("detail")]
        public async Task<IActionResult> Detail([FromQuery] Int64 mvid)
        {
            try
            {
                var response = await _mvService.Detail(mvid);
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
        [HttpGet("detailinfo")]
        public async Task<IActionResult> DetailInfo([FromQuery] Int64 mvid)
        {
            try
            {
                var response = await _mvService.DetailInfo(mvid);
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
        [HttpGet("exclusivercmd")]
        public async Task<IActionResult> ExclusiveRcmd([FromQuery] Int32 limit, Int32 offset)
        {
            try
            {
                var response = await _mvService.ExclusiveRcmd(limit, offset);
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
        [HttpPost("first")]
        public async Task<IActionResult> First([FromBody] MvFirstRequestModel requestModel)
        {
            try
            {
                var response = await _mvService.First(requestModel);
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
        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] MvSubscribeRequestModel requestModel)
        {
            try
            {
                var response = await _mvService.Subscribe(requestModel);
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
        [HttpGet("sublist")]
        public async Task<IActionResult> Sublist([FromQuery] Int32 limit, Int32 offset)
        {
            try
            {
                var response = await _mvService.Sublist(limit, offset);
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
        [HttpPost("url")]
        public async Task<IActionResult> Url([FromBody] MvUrlRequestModel requestModel)
        {
            try
            {
                var response = await _mvService.Url(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
