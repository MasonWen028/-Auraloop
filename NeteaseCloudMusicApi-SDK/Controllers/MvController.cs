using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class MvController : Controller
    {
        private readonly GenericService _genericService;

        public MvController(GenericService genericService)
        {
            _genericService = genericService;
        }

        /// <summary>
        /// Fetch all MVs
        /// </summary>
        /// <param name="area">area of it</param>
        /// <param name="type">type of it</param>
        /// <param name="order">order method</param>
        /// <param name="limit">page size</param>
        /// <param name="offset">page no</param>
        /// <returns></returns>
        [HttpGet]
        [Route("mv/all")]
        [SwaggerOperation(summary: "Fetch all MVs")]
        public async Task<IActionResult> MvAll([FromQuery]string? area = "全部", [FromQuery]string? type = "全部", [FromQuery]string? order = "上升最快", [FromQuery]int limit = 30, [FromQuery]int offset = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mv/all",
                    OptionType = "weapi",
                    Data = new MvAllRequestModel()
                    {
                        Tags = JsonConvert.SerializeObject(new {
                            地区 = area,
                            类型 = type,
                            排序 = order
                        }),
                        Limit = limit,
                        Offset = offset,
                        Total = true
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
        /// Fetch detailed information of MV
        /// </summary>
        /// <param name="mvid">mv id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("mv/detail")]
        [SwaggerOperation(summary: "Fetch detailed information of MV")]
        public async Task<IActionResult> MvDetail([FromQuery]long mvid)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/mv/detail",
                    OptionType = "weapi",
                    Data = new MvDetailRequestModel()
                    {
                        Id = mvid
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
        /// Fetch count of like, forward and comment
        /// </summary>
        /// <param name="mvid">MV id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("mv/detail/info")]
        [SwaggerOperation("Fetch count of like, forward and comment")]
        public async Task<IActionResult> MvDetailInfo([FromQuery]long mvid)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/comment/commentthread/info",
                    OptionType = "weapi",
                    Data = new MvDetailInfoRequestModel()
                    {
                        Threadid = $"R_MV_5_{mvid}"
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

        [HttpPost]
        [Route("mv/exclusive/rcmd")]
        public async Task<IActionResult> MvExclusiveRcmd()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mv/exclusive/rcmd",
                    OptionType = "weapi",
                    Data = new MvExclusiveRcmdRequestModel()
                    {
                        // Replace with actual data if needed
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

        [HttpPost]
        [Route("mv/first")]
        public async Task<IActionResult> MvFirst()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mv/first",
                    OptionType = "weapi",
                    Data = new MvFirstRequestModel()
                    {
                        // Replace with actual data if needed
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

        [HttpPost]
        [Route("mv/sub")]
        public async Task<IActionResult> MvSub()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mv/${query.t}",
                    OptionType = "weapi",
                    Data = new MvSubRequestModel()
                    {
                        // Replace with actual data if needed
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
        /// Fecth MVs subscribed by user with pagination
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("mv/sublist")]
        [SwaggerOperation(summary: " Fecth MVs subscribed by user")]
        public async Task<IActionResult> MvSublist([FromQuery] int limit = 50, [FromQuery] int offset = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloudvideo/allvideo/sublist",
                    OptionType = "weapi",
                    Data = new MvSublistRequestModel()
                    {
                        Limit = limit,
                        Offset = offset,
                        Total = true
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
        /// Fecth MV url
        /// </summary>
        /// <param name="id">mv url</param>
        /// <param name="r">resolution</param>
        /// <returns></returns>
        [HttpGet]
        [Route("mv/url")]
        [SwaggerOperation(summary: "Fecth MV url")]
        public async Task<IActionResult> MvUrl([FromQuery]long id, [FromQuery]int r = 1080)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/enhance/play/mv/url",
                    OptionType = "weapi",
                    Data = new MvUrlRequestModel()
                    {
                        Id = id,
                        R = r
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
