using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class LogoutController : Controller
    {
        private readonly GenericService _genericService;

        public LogoutController(GenericService genericService)
        {
            _genericService = genericService;
        }

        /// <summary>
        /// Logs the user out of the system.
        /// </summary>
        /// <remarks>
        /// This endpoint forwards a logout request to an external API (`/api/logout`) using a generic service.
        /// It ensures that the user is logged out securely and any related session data is cleared.
        /// </remarks>
        /// <returns>
        /// An HTTP 200 response with the result of the logout operation from the external API, 
        /// or an HTTP 500 response if an internal server error occurs.
        /// </returns>
        [HttpGet]
        [Route("logout")]
        [SwaggerOperation(
            Summary = "Log out the user",
            Description = "Sends a logout request to the external API endpoint `/api/logout` to securely log out the user."
        )]
        [SwaggerResponse(200, "Successfully logged out.", typeof(object))]
        [SwaggerResponse(500, "Internal server error.")]

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/logout",
                    OptionType = "weapi",
                    Data = new LogoutRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
