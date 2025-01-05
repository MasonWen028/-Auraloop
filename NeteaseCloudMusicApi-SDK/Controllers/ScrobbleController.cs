using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ScrobbleController : Controller
    {
        private readonly GenericService _genericService;

        public ScrobbleController(GenericService genericService)
        {
            _genericService = genericService;
        }

        /// <summary>
        /// Song listening check-in
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="sourceid">song id</param>
        /// <param name="time">check-in time</param>
        /// <returns></returns>
        [HttpGet]
        [Route("scrobble")]
        [SwaggerOperation(summary: "Song listening check-in")]
        public async Task<IActionResult> Scrobble([FromQuery]long id, [FromQuery]long? sourceid, [FromQuery]long? time)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/feedback/weblog",
                    OptionType = "weapi",
                    Data = new
                    {
                        logs = "[" + JsonConvert.SerializeObject(new {
                            action = "play",
                            json = new
                                    {
                                    download = 0,
                              end = "playend",
                              id = id,
                              sourceId = sourceid,
                              time = time,
                              type = "song",
                                wifi = 0,
                              source = "list",
                              mainsite = 1,
                              content = "",
                            }
                        }) + "]"
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
