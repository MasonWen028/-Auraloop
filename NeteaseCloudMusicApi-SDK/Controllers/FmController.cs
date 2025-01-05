using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class FmController : Controller
    {
        private readonly GenericService _genericService;

        public FmController(GenericService genericService)
        {
            _genericService = genericService;
        }

        /// <summary>
        /// Add new sone to trash bin
        /// </summary>
        /// <param name="id">the identifier of targeted song</param>
        /// <param name="time"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("fm/trash")]
        public async Task<IActionResult> FmTrash([FromQuery]long id, [FromQuery]long time = 25)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/radio/trash/add",
                    OptionType = "weapi",
                    Data = new FmTrashRequestModel()
                    {
                        SongId = id,
                        Time = time,
                        Alg = "RT"
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
