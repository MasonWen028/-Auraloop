using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MsgController : Controller
    {
        private readonly IMsgService _msgService;
        private readonly RequestContext _context;

        public MsgController(IMsgService msgService, RequestContext context)
        {
            _msgService = msgService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("comments")]
        public async Task<IActionResult> Comments([FromBody] MsgCommentsRequestModel requestModel)
        {
            try
            {
                var response = await _msgService.Comments(requestModel);
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
        [HttpPost("forwards")]
        public async Task<IActionResult> Forwards([FromBody] MsgForwardsRequestModel requestModel)
        {
            try
            {
                var response = await _msgService.Forwards(requestModel);
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
        [HttpPost("notices")]
        public async Task<IActionResult> Notices([FromBody] MsgNoticesRequestModel requestModel)
        {
            try
            {
                var response = await _msgService.Notices(requestModel);
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
        [HttpPost("privatemessages")]
        public async Task<IActionResult> PrivateMessages([FromBody] MsgPrivateRequestModel requestModel)
        {
            try
            {
                var response = await _msgService.PrivateMessages(requestModel);
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
        [HttpPost("privatehistory")]
        public async Task<IActionResult> PrivateHistory([FromBody] MsgPrivateHistoryRequestModel requestModel)
        {
            try
            {
                var response = await _msgService.PrivateHistory(requestModel);
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
        [HttpGet("recentcontacts")]
        public async Task<IActionResult> RecentContacts()
        {
            try
            {
                var response = await _msgService.RecentContacts();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
