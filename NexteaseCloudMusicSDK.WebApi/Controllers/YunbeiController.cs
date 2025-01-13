using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.Models.Request.yunbei;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YunbeiController : Controller
    {
        private readonly IYunbeiService _yunbeiService;
        private readonly RequestContext _context;

        public YunbeiController(IYunbeiService yunbeiService, RequestContext context)
        {
            _yunbeiService = yunbeiService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("points")]
        public async Task<IActionResult> GetPoints()
        {
            try
            {
                var response = await _yunbeiService.GetPoints();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("expensehistory")]
        public async Task<IActionResult> ExpenseHistory([FromBody] YunbeiExpenseRequestModel requestModel)
        {
            try
            {
                var response = await _yunbeiService.ExpenseHistory(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("info")]
        public async Task<IActionResult> Info()
        {
            try
            {
                var response = await _yunbeiService.Info();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("recommendedsongs")]
        public async Task<IActionResult> RecommendedSongs([FromBody] YunbeiRecommendedSongsRequestModel requestModel)
        {
            try
            {
                var response = await _yunbeiService.RecommendedSongs(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("recommendedsonghistory")]
        public async Task<IActionResult> RecommendedSongHistory([FromBody] YunbeiRcmdSongHistoryRequestModel requestModel)
        {
            try
            {
                var response = await _yunbeiService.RecommendedSongHistory(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("receipt")]
        public async Task<IActionResult> Receipt([FromBody] YunbeiReceiptRequestModel requestModel)
        {
            try
            {
                var response = await _yunbeiService.Receipt(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("dailysignin")]
        public async Task<IActionResult> DailySignin()
        {
            try
            {
                var response = await _yunbeiService.DailySignin();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("tasks")]
        public async Task<IActionResult> Tasks()
        {
            try
            {
                var response = await _yunbeiService.Tasks();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("todotasks")]
        public async Task<IActionResult> TodoTasks()
        {
            try
            {
                var response = await _yunbeiService.TodoTasks();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("completetask")]
        public async Task<IActionResult> CompleteTask([FromBody] YunbeiTaskFinishRequestModel requestModel)
        {
            try
            {
                var response = await _yunbeiService.CompleteTask(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("today")]
        public async Task<IActionResult> Today()
        {
            try
            {
                var response = await _yunbeiService.Today();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
