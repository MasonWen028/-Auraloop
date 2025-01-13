using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly RequestContext _context;

        public LoginController(ILoginService loginService, RequestContext context)
        {
            _loginService = loginService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel requestModel)
        {
            try
            {
                var response = await _loginService.Login(requestModel);
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
        [HttpPost("cellphone")]
        public async Task<IActionResult> LoginCellphone([FromBody] LoginCellphoneRequestModel requestModel)
        {
            try
            {
                var response = await _loginService.LoginCellphone(requestModel);
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
        [HttpGet("qrcheck")]
        public async Task<IActionResult> LoginQrCheck([FromQuery] String key)
        {
            try
            {
                var response = await _loginService.LoginQrCheck(key);
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
        [HttpGet("generateqrurl")]
        public async Task<IActionResult> GenerateQrUrl([FromQuery] String key, Boolean qrimg)
        {
            try
            {
                var response = await _loginService.GenerateQrUrl(key, qrimg);
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
        [HttpGet("qrkey")]
        public async Task<IActionResult> LoginQrKey()
        {
            try
            {
                var response = await _loginService.LoginQrKey();
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
        [HttpGet("refresh")]
        public async Task<IActionResult> LoginRefresh()
        {
            try
            {
                var response = await _loginService.LoginRefresh();
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
        [HttpGet("status")]
        public async Task<IActionResult> LoginStatus()
        {
            try
            {
                var response = await _loginService.LoginStatus();
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
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var response = await _loginService.Logout();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
