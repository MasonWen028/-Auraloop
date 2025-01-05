using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class CaptchaController : Controller
    {
        private readonly GenericService _genericService;

        public CaptchaController(GenericService genericService)
        {
            _genericService = genericService;
        }

        /// <summary>
        /// Sends a CAPTCHA to the user's phone via SMS.
        /// </summary>
        /// <param name="Phone">The user's phone number (in long format).</param>
        /// <param name="Ctcode">The country code for the phone number (default is 86 for China).</param>
        /// <returns>The result of the API call, indicating the success or failure of the CAPTCHA request.</returns>
        /// <remarks>
        /// This endpoint triggers an SMS containing a CAPTCHA code to the user's phone. 
        /// It uses a generic service to send the request to the specified API endpoint. 
        /// The country code parameter is optional and defaults to 86 if not provided.
        /// </remarks>
        /// <response code="200">Successfully sent the CAPTCHA.</response>
        /// <response code="500">An error occurred while processing the request.</response>
        [HttpGet]
        [Route("captcha/sent")]
        [SwaggerOperation(
            Summary = "Send CAPTCHA via SMS",
            Description = "Sends a CAPTCHA code to the user's phone number using the provided country code."
        )]
        [SwaggerResponse(200, "Successfully sent the CAPTCHA.", typeof(object))]
        [SwaggerResponse(500, "Internal server error.")]
        public async Task<IActionResult> CaptchaSent([FromQuery]long Phone, [FromQuery]int Ctcode = 86)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/sms/captcha/sent",
                    OptionType = "weapi",
                    Data = new CaptchaSentRequestModel()
                    {
                        Cellphone = Phone.ToString(),
                        Ctcode = Ctcode.ToString()
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Verifies the CAPTCHA code sent to the user's phone number.
        /// </summary>
        /// <param name="Phone">The user's phone number in long format. This is the number where the CAPTCHA was sent.</param>
        /// <param name="Captcha">The CAPTCHA code entered by the user for verification.</param>
        /// <param name="Ctcode">The country code for the user's phone number (default is 86, representing China).</param>
        /// <returns>
        /// An HTTP 200 response with the result of the verification process, 
        /// or an HTTP 500 response in case of an internal server error.
        /// </returns>
        /// <remarks>
        /// This action validates the CAPTCHA code entered by the user by sending a verification request
        /// to the API endpoint "/api/sms/captcha/verify". It uses a generic service to handle the API request
        /// and provides the verification result in the response.
        /// </remarks>
        [HttpGet]
        [Route("captcha/verify")]
        [SwaggerOperation(
            Summary = "Verify CAPTCHA via SMS",
            Description = "Verifies the CAPTCHA code entered by the user for the given phone number and country code."
        )]
        [SwaggerResponse(200, "Successfully verified the CAPTCHA.", typeof(object))]
        [SwaggerResponse(500, "Internal server error.")]
        public async Task<IActionResult> CaptchaVerify([FromQuery]long Phone, [FromQuery]int Captcha, [FromQuery]int Ctcode = 86)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/sms/captcha/verify",
                    OptionType = "weapi",
                    Data = new CaptchaVerifyRequestModel()
                    {
                        Cellphone = Phone.ToString(),
                        Captcha = Captcha.ToString(),
                        Ctcode = Ctcode.ToString()
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
