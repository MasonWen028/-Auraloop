using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class LikelistController : Controller
    {
        private readonly GenericService _genericService;

        public LikelistController(GenericService genericService)
        {
            _genericService = genericService;
        }

        /// <summary>
        /// Fetch Songs liked by user without order
        /// </summary>
        /// <param name="uid">user id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("likelist")]
        [SwaggerOperation("Fetch Songs liked by user")]
        public async Task<IActionResult> Likelist([FromQuery]long uid)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/like/get",
                    OptionType = "weapi",
                    Data = new LikelistRequestModel()
                    {
                        Uid = uid
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
