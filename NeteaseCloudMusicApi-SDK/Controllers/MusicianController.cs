using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class MusicianController : Controller
    {
        private readonly GenericService _genericService;

        public MusicianController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("musician/cloudbean")]
        public async Task<IActionResult> MusicianCloudbean()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloudbean/get",
                    OptionType = "weapi",
                    Data = new MusicianCloudbeanRequestModel()
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
        [Route("musician/cloudbean/obtain")]
        public async Task<IActionResult> MusicianCloudbeanObtain()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/nmusician/workbench/mission/reward/obtain/new",
                    OptionType = "weapi",
                    Data = new MusicianCloudbeanObtainRequestModel()
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
        [Route("musician/data/overview")]
        public async Task<IActionResult> MusicianDataOverview()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/creator/musician/statistic/data/overview/get",
                    OptionType = "weapi",
                    Data = new MusicianDataOverviewRequestModel()
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
        [Route("musician/play/trend")]
        public async Task<IActionResult> MusicianPlayTrend()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/creator/musician/play/count/statistic/data/trend/get",
                    OptionType = "weapi",
                    Data = new MusicianPlayTrendRequestModel()
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
        [Route("musician/sign")]
        public async Task<IActionResult> MusicianSign()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/creator/user/access",
                    OptionType = "weapi",
                    Data = new MusicianSignRequestModel()
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
        [Route("musician/tasks")]
        public async Task<IActionResult> MusicianTasks()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/nmusician/workbench/mission/cycle/list",
                    OptionType = "weapi",
                    Data = new MusicianTasksRequestModel()
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
        [Route("musician/tasks/new")]
        public async Task<IActionResult> MusicianTasksNew()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/nmusician/workbench/mission/stage/list ",
                    OptionType = "weapi",
                    Data = new MusicianTasksNewRequestModel()
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
