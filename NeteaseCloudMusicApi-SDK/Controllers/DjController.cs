using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class DjController : Controller
    {
        private readonly GenericService _genericService;

        public DjController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("dj/banner")]
        public async Task<IActionResult> DjBanner()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/banner/get",
                    OptionType = "weapi",
                    Data = new DjBannerRequestModel()
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
        [Route("dj/category/excludehot")]
        public async Task<IActionResult> DjCategoryExcludehot()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/category/excludehot",
                    OptionType = "weapi",
                    Data = new DjCategoryExcludehotRequestModel()
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
        /// Fetch recommended category
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation(
            summary: "Fetch recommended category"
        )]
        [HttpGet]
        [Route("dj/category/recommend")]
        public async Task<IActionResult> DjCategoryRecommend()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/home/category/recommend",
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
        /// Fetch catelist of dj
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("dj/catelist")]
        [SwaggerOperation(
            summary: "Fetch the catelist of dj",
            description: "Fetch the catelist of dj"
        )]
        public async Task<IActionResult> DjCatelist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/category/get",
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
        /// Fetch detailed information of dj corresponding to the dj id
        /// </summary>
        /// <param name="rid">the identifier of dj</param>
        /// <returns></returns>
        [HttpGet]
        [Route("dj/detail")]
        [SwaggerOperation(
            summary: " Fetch detailed information of dj corresponding to the dj id"
         )]
        public async Task<IActionResult> DjDetail([FromQuery]long rid)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/v2/get",
                    OptionType = "weapi",
                    Data = new DjDetailRequestModel()
                    {
                        Id = rid
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
        [Route("dj/hot")]
        public async Task<IActionResult> DjHot()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/hot/v1",
                    OptionType = "weapi",
                    Data = new DjHotRequestModel()
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
        [Route("dj/paygift")]
        public async Task<IActionResult> DjPaygift()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/home/paygift/list",
                    OptionType = "weapi",
                    Data = new DjPaygiftRequestModel()
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
        /// Fetch the personalized recommendation of dj list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("dj/personalize/recommend")]
        public async Task<IActionResult> DjPersonalizeRecommend()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/personalize/rcmd",
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
        /// Fetch all programs of dj by id, limit, and offset
        /// </summary>
        /// <param name="rid">the identifier of dj</param>
        /// <param name="limit">size</param>
        /// <param name="offset">start position</param>
        /// <returns></returns>
        [HttpGet]
        [Route("dj/program")]
        [SwaggerOperation(
            summary: "Fetch all programs of dj by id, limit, and offset"
        )]
        public async Task<IActionResult> DjProgram([FromQuery]long rid, [FromQuery]int limit = 50, [FromQuery]int offset = 0, [FromQuery]bool asc = false)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/dj/program/byradio",
                    OptionType = "weapi",
                    Data = new DjProgramRequestModel()
                    {
                        RadioId = rid,
                        Asc = asc,
                        Limit = limit,
                        Offset = offset
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
        /// Fetch the detailed information of targeted dj
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("dj/program/detail")]
        [SwaggerOperation(
            summary: "Fetch the detailed information of targeted dj"
        )]
        public async Task<IActionResult> DjProgramDetail([FromQuery]long id)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/dj/program/detail",
                    OptionType = "weapi",
                    Data = new DjProgramDetailRequestModel()
                    {
                        Id = id
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
        [Route("dj/program/toplist")]
        public async Task<IActionResult> DjProgramToplist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/program/toplist/v1",
                    OptionType = "weapi",
                    Data = new DjProgramToplistRequestModel()
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
        [Route("dj/program/toplist/hours")]
        public async Task<IActionResult> DjProgramToplistHours()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djprogram/toplist/hours",
                    OptionType = "weapi",
                    Data = new DjProgramToplistHoursRequestModel()
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
        /// Fetch the top dj lists by category
        /// </summary>
        /// <param name="cateId">the identifier of targeted category</param>
        /// <param name="limit">size</param>
        /// <param name="offset">start position</param>
        /// <returns></returns>
        [HttpGet]
        [Route("dj/radio/hot")]
        [SwaggerOperation(
            summary: "Fetch the top dj lists by category"
        )]
        public async Task<IActionResult> DjRadioHot([FromQuery]long cateId, [FromQuery]int limit = 50, [FromQuery]int offset = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/hot",
                    OptionType = "weapi",
                    Data = new DjRadioHotRequestModel()
                    {
                        CateId = cateId,
                        Limit = limit,
                        Offset = offset
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
        /// Fetch recommended dj list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("dj/recommend")]
        [SwaggerOperation(
            summary: "Fetch recommended dj list"
        )]
        public async Task<IActionResult> DjRecommend()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/recommend/v1",
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
        /// Fetch the type corresponding to the dj by cateId
        /// </summary>
        /// <param name="cateId">the identifier of category</param>
        /// <returns></returns>
        [HttpGet]
        [Route("dj/recommend/type")]
        [SwaggerOperation(
            summary: "Fetch the type corresponding to the dj by cateId"
        )]
        public async Task<IActionResult> DjRecommendType([FromQuery]long cateId)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/recommend",
                    OptionType = "weapi",
                    Data = new DjRecommendTypeRequestModel()
                    {
                        CateId = cateId
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
        /// subscribe or unsubscribe dj
        /// </summary>
        /// <param name="rid">the idenfifier of dj</param>
        /// <param name="subOpType">1 for subscribe, 0 for unsubscribe</param>
        /// <returns></returns>
        [HttpGet]
        [Route("dj/sub")]
        [SwaggerOperation(
            summary: "subscribe or unsubscribe dj"
        )]
        public async Task<IActionResult> DjSub([FromQuery]long rid, [FromQuery]SubOpType subOpType = SubOpType.subscribe)
        {
            try
            {
                string subOptype = subOpType == SubOpType.subscribe ? "sub" : "unsub";
                var apiModel = new ApiModel
                {
                    ApiEndpoint = $"/api/djradio/{subOptype}",
                    OptionType = "weapi",
                    Data = new DjSubRequestModel()
                    {
                        Id = rid
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
        /// Fetch broadcasts subscribed by user with pagination
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("dj/sublist")]
        [SwaggerOperation(summary: "Fetch broadcasts subscribed by user")]
        public async Task<IActionResult> DjSublist([FromQuery] int limit = 50, [FromQuery] int offset = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/get/subed",
                    OptionType = "weapi",
                    Data = new DjSublistRequestModel()
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

        [HttpPost]
        [Route("dj/subscriber")]
        public async Task<IActionResult> DjSubscriber()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/subscriber",
                    OptionType = "weapi",
                    Data = new DjSubscriberRequestModel()
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
        [Route("dj/today/perfered")]
        public async Task<IActionResult> DjTodayPerfered()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/home/today/perfered",
                    OptionType = "weapi",
                    Data = new DjTodayPerferedRequestModel()
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
        /// Fetch new/hot DJ list
        /// </summary>
        /// <param name="listType">new / hot</param>
        /// <param name="limit">size of data</param>
        /// <param name="offset">starting position</param>
        /// <returns></returns>
        [HttpGet]
        [Route("dj/toplist")]
        [SwaggerOperation(
            summary: "Fetch new/hot DJ list"
        )]
        public async Task<IActionResult> DjToplist([FromQuery]ListType listType, [FromQuery]int limit = 20, [FromQuery]int offset = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/toplist",
                    OptionType = "weapi",
                    Data = new DjToplistRequestModel()
                    {
                        Limit = limit,
                        Offset = offset,
                        Type = listType.ToString()
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
        [Route("dj/toplist/hours")]
        public async Task<IActionResult> DjToplistHours()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/dj/toplist/hours",
                    OptionType = "weapi",
                    Data = new DjToplistHoursRequestModel()
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
        [Route("dj/toplist/newcomer")]
        public async Task<IActionResult> DjToplistNewcomer()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/dj/toplist/newcomer",
                    OptionType = "weapi",
                    Data = new DjToplistNewcomerRequestModel()
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
        [Route("dj/toplist/pay")]
        public async Task<IActionResult> DjToplistPay()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/toplist/pay",
                    OptionType = "weapi",
                    Data = new DjToplistPayRequestModel()
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
        [Route("dj/toplist/popular")]
        public async Task<IActionResult> DjToplistPopular()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/dj/toplist/popular",
                    OptionType = "weapi",
                    Data = new DjToplistPopularRequestModel()
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
    }
}
