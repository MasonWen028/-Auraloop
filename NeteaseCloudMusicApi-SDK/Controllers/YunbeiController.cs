using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class YunbeiController : Controller
    {
        private readonly GenericService _genericService;

        public YunbeiController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("yunbei")]
        public async Task<IActionResult> Yunbei()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/point/signed/get",
                    OptionType = "weapi",
                    Data = new YunbeiRequestModel()
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
        [Route("yunbei/expense")]
        public async Task<IActionResult> YunbeiExpense()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/point/expense",
                    OptionType = "weapi",
                    Data = new YunbeiExpenseRequestModel()
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
        [Route("yunbei/info")]
        public async Task<IActionResult> YunbeiInfo()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/user/info",
                    OptionType = "weapi",
                    Data = new YunbeiInfoRequestModel()
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
        [Route("yunbei/rcmd/song")]
        public async Task<IActionResult> YunbeiRcmdSong()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/yunbei/rcmd/song/submit",
                    OptionType = "weapi",
                    Data = new YunbeiRcmdSongRequestModel()
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
        [Route("yunbei/rcmd/song/history")]
        public async Task<IActionResult> YunbeiRcmdSongHistory()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/yunbei/rcmd/song/history/list",
                    OptionType = "weapi",
                    Data = new YunbeiRcmdSongHistoryRequestModel()
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
        [Route("yunbei/receipt")]
        public async Task<IActionResult> YunbeiReceipt()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/point/receipt",
                    OptionType = "weapi",
                    Data = new YunbeiReceiptRequestModel()
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
        [Route("yunbei/sign")]
        public async Task<IActionResult> YunbeiSign()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/pointmall/user/sign",
                    OptionType = "weapi",
                    Data = new YunbeiSignRequestModel()
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
        [Route("yunbei/tasks")]
        public async Task<IActionResult> YunbeiTasks()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/usertool/task/list/all",
                    OptionType = "weapi",
                    Data = new YunbeiTasksRequestModel()
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
        [Route("yunbei/tasks/todo")]
        public async Task<IActionResult> YunbeiTasksTodo()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/usertool/task/todo/query",
                    OptionType = "weapi",
                    Data = new YunbeiTasksTodoRequestModel()
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
        [Route("yunbei/task/finish")]
        public async Task<IActionResult> YunbeiTaskFinish()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/usertool/task/point/receive",
                    OptionType = "weapi",
                    Data = new YunbeiTaskFinishRequestModel()
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
        [Route("yunbei/today")]
        public async Task<IActionResult> YunbeiToday()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/point/today/get",
                    OptionType = "weapi",
                    Data = new YunbeiTodayRequestModel()
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
