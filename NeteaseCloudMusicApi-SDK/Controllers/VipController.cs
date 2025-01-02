using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class VipController : Controller
    {
        private readonly GenericService _genericService;

        public VipController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("vip/growthpoint")]
        public async Task<IActionResult> VipGrowthpoint()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/vipnewcenter/app/level/growhpoint/basic",
                    OptionType = "weapi",
                    Data = new VipGrowthpointRequestModel()
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
        [Route("vip/growthpoint/details")]
        public async Task<IActionResult> VipGrowthpointDetails()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/vipnewcenter/app/level/growth/details",
                    OptionType = "weapi",
                    Data = new VipGrowthpointDetailsRequestModel()
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
        [Route("vip/growthpoint/get")]
        public async Task<IActionResult> VipGrowthpointGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/vipnewcenter/app/level/task/reward/get",
                    OptionType = "weapi",
                    Data = new VipGrowthpointGetRequestModel()
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
        [Route("vip/info")]
        public async Task<IActionResult> VipInfo()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/music-vip-membership/front/vip/info",
                    OptionType = "weapi",
                    Data = new VipInfoRequestModel()
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
        [Route("vip/info/v2")]
        public async Task<IActionResult> VipInfoV2()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/music-vip-membership/client/vip/info",
                    OptionType = "weapi",
                    Data = new VipInfoV2RequestModel()
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
        [Route("vip/tasks")]
        public async Task<IActionResult> VipTasks()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/vipnewcenter/app/level/task/list",
                    OptionType = "weapi",
                    Data = new VipTasksRequestModel()
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
        [Route("vip/timemachine")]
        public async Task<IActionResult> VipTimemachine()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/vipmusic/newrecord/weekflow",
                    OptionType = "weapi",
                    Data = new VipTimemachineRequestModel()
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
