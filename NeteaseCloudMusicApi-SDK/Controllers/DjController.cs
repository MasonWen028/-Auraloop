using Microsoft.AspNetCore.Mvc;
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
                return Ok(result.data);
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
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("dj/category/recommend")]
        public async Task<IActionResult> DjCategoryRecommend()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/home/category/recommend",
                    OptionType = "weapi",
                    Data = new DjCategoryRecommendRequestModel()
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

        [HttpPost]
        [Route("dj/catelist")]
        public async Task<IActionResult> DjCatelist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/category/get",
                    OptionType = "weapi",
                    Data = new DjCatelistRequestModel()
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

        [HttpPost]
        [Route("dj/detail")]
        public async Task<IActionResult> DjDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/v2/get",
                    OptionType = "weapi",
                    Data = new DjDetailRequestModel()
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
                return Ok(result.data);
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
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("dj/personalize/recommend")]
        public async Task<IActionResult> DjPersonalizeRecommend()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/personalize/rcmd",
                    OptionType = "weapi",
                    Data = new DjPersonalizeRecommendRequestModel()
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

        [HttpPost]
        [Route("dj/program")]
        public async Task<IActionResult> DjProgram()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/dj/program/byradio",
                    OptionType = "weapi",
                    Data = new DjProgramRequestModel()
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

        [HttpPost]
        [Route("dj/program/detail")]
        public async Task<IActionResult> DjProgramDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/dj/program/detail",
                    OptionType = "weapi",
                    Data = new DjProgramDetailRequestModel()
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
                return Ok(result.data);
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
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("dj/radio/hot")]
        public async Task<IActionResult> DjRadioHot()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/hot",
                    OptionType = "weapi",
                    Data = new DjRadioHotRequestModel()
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

        [HttpPost]
        [Route("dj/recommend")]
        public async Task<IActionResult> DjRecommend()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/recommend/v1",
                    OptionType = "weapi",
                    Data = new DjRecommendRequestModel()
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

        [HttpPost]
        [Route("dj/recommend/type")]
        public async Task<IActionResult> DjRecommendType()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/recommend",
                    OptionType = "weapi",
                    Data = new DjRecommendTypeRequestModel()
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

        [HttpPost]
        [Route("dj/sub")]
        public async Task<IActionResult> DjSub()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/${query.t}",
                    OptionType = "weapi",
                    Data = new DjSubRequestModel()
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

        [HttpPost]
        [Route("dj/sublist")]
        public async Task<IActionResult> DjSublist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/get/subed",
                    OptionType = "weapi",
                    Data = new DjSublistRequestModel()
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
                return Ok(result.data);
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
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("dj/toplist")]
        public async Task<IActionResult> DjToplist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/toplist",
                    OptionType = "weapi",
                    Data = new DjToplistRequestModel()
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
                return Ok(result.data);
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
                return Ok(result.data);
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
                return Ok(result.data);
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
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
