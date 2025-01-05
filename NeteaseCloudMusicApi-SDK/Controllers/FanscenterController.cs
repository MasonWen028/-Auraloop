using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class FanscenterController : Controller
    {
        private readonly GenericService _genericService;

        public FanscenterController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("fanscenter/basicinfo/age/get")]
        public async Task<IActionResult> FanscenterBasicinfoAgeGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/fanscenter/basicinfo/age/get",
                    OptionType = "weapi",
                    Data = new FanscenterBasicinfoAgeGetRequestModel()
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
        [Route("fanscenter/basicinfo/gender/get")]
        public async Task<IActionResult> FanscenterBasicinfoGenderGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/fanscenter/basicinfo/gender/get",
                    OptionType = "weapi",
                    Data = new FanscenterBasicinfoGenderGetRequestModel()
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
        [Route("fanscenter/basicinfo/province/get")]
        public async Task<IActionResult> FanscenterBasicinfoProvinceGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/fanscenter/basicinfo/province/get",
                    OptionType = "weapi",
                    Data = new FanscenterBasicinfoProvinceGetRequestModel()
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
        [Route("fanscenter/overview/get")]
        public async Task<IActionResult> FanscenterOverviewGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/fanscenter/overview/get",
                    OptionType = "weapi",
                    Data = new FanscenterOverviewGetRequestModel()
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
        [Route("fanscenter/trend/list")]
        public async Task<IActionResult> FanscenterTrendList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/fanscenter/trend/list",
                    OptionType = "weapi",
                    Data = new FanscenterTrendListRequestModel()
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
