using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class PersonalizedController : Controller
    {
        private readonly GenericService _genericService;

        public PersonalizedController(GenericService genericService)
        {
            _genericService = genericService;
        }


        /// <summary>
        /// Fetch personalized recommended playlist
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="total"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("personalized")]
        [SwaggerOperation( summary: "Fetch personalized recommended playlist")]
        public async Task<IActionResult> Personalized([FromQuery]int limit = 30, [FromQuery]bool total = true, [FromQuery]int n = 1000)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/personalized/playlist",
                    OptionType = "weapi",
                    Data = new PersonalizedRequestModel()
                    {
                        Limit = limit,
                        Total = total,
                        N = n
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
        /// Fetch recommended Radio program
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("personalized/djprogram")]
        [SwaggerOperation(summary: "Fetch recommended Radio program")]
        public async Task<IActionResult> PersonalizedDjprogram()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/personalized/djprogram",
                    OptionType = "weapi"
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
        /// Fetch recommended MV
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("personalized/mv")]
        [SwaggerOperation(summary: "Fetch recommended MV")]
        public async Task<IActionResult> PersonalizedMv()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/personalized/mv",
                    OptionType = "weapi",
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
        /// Fetch personalized new song with pagination
        /// </summary>
        /// <param name="limit">page size</param>
        /// <param name="areaId">country code, could get by interface /countries/code/list</param>
        /// <returns></returns>
        [HttpGet]
        [Route("personalized/newsong")]
        public async Task<IActionResult> PersonalizedNewsong([FromQuery]int limit = 10, [FromQuery]int areaId = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/personalized/newsong",
                    OptionType = "weapi",
                    Data = new PersonalizedNewsongRequestModel()
                    {
                        Limit = limit,
                        AreaId = areaId,
                        Type = "recommend"
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
        /// Fetch exlusive broadcast content
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("personalized/privatecontent")]
        [SwaggerOperation(summary: "Fetch exlusive broadcast content")]
        public async Task<IActionResult> PersonalizedPrivatecontent()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/personalized/privatecontent",
                    OptionType = "weapi"
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
        /// Fetch exlusive broadcast list
        /// </summary>
        /// <param name="limit">page size</param>
        /// <param name="offset">page number</param>
        /// <returns></returns>
        [HttpGet]
        [Route("personalized/privatecontent/list")]
        [SwaggerOperation(summary: "Fetch exlusive broadcast list")]
        public async Task<IActionResult> PersonalizedPrivatecontentList([FromQuery]int limit = 60, [FromQuery]int offset = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v2/privatecontent/list",
                    OptionType = "weapi",
                    Data = new PersonalizedPrivatecontentListRequestModel()
                    {
                        Limit = limit,
                        Offset = offset,
                        Total = "true"
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
