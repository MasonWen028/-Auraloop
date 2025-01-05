using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class DailyController : Controller
    {
        private readonly GenericService _genericService;

        public DailyController(GenericService genericService)
        {
            _genericService = genericService;
        }


        /// <summary>
        /// User daily check-in, if type == 0, get 3 points, type == 1 2 point
        /// </summary>
        /// <param name="type">0 for android, 1 for web</param>
        /// <returns></returns>
        [HttpPost]
        [Route("daily/signin")]

        [SwaggerOperation(summary: "User daily check-in")]
        public async Task<IActionResult> DailySignin([FromQuery]int type)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/point/dailyTask",
                    OptionType = "weapi",
                    Data = new DailySigninRequestModel()
                    {
                        Type = type
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
