using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonalizedController : Controller
    {
        private readonly IPersonalizedService _personalizedService;
        private readonly RequestContext _context;

        public PersonalizedController(IPersonalizedService personalizedService, RequestContext context)
        {
            _personalizedService = personalizedService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("recommendations")]
        public async Task<IActionResult> GetRecommendations([FromBody] PersonalizedRequestModel requestModel)
        {
            try
            {
                var response = await _personalizedService.GetRecommendations(requestModel);
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
        [HttpGet("djprogram")]
        public async Task<IActionResult> Djprogram()
        {
            try
            {
                var response = await _personalizedService.Djprogram();
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
        [HttpGet("mv")]
        public async Task<IActionResult> Mv()
        {
            try
            {
                var response = await _personalizedService.Mv();
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
        [HttpPost("newsong")]
        public async Task<IActionResult> Newsong([FromBody] PersonalizedNewsongRequestModel requestModel)
        {
            try
            {
                var response = await _personalizedService.Newsong(requestModel);
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
        [HttpGet("privatecontent")]
        public async Task<IActionResult> Privatecontent()
        {
            try
            {
                var response = await _personalizedService.Privatecontent();
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
        [HttpPost("privatecontentlist")]
        public async Task<IActionResult> PrivatecontentList([FromBody] PersonalizedPrivatecontentListRequestModel requestModel)
        {
            try
            {
                var response = await _personalizedService.PrivatecontentList(requestModel);
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
        [HttpGet("personalfm")]
        public async Task<IActionResult> PersonalFm()
        {
            try
            {
                var response = await _personalizedService.PersonalFm();
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
        [HttpPost("personalfmmode")]
        public async Task<IActionResult> PersonalFmMode([FromBody] PersonalFmModeRequestModel requestModel)
        {
            try
            {
                var response = await _personalizedService.PersonalFmMode(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
