using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListenTogetherController : Controller
    {
        private readonly IListenTogetherService _listentogetherService;
        private readonly RequestContext _context;

        public ListenTogetherController(IListenTogetherService listentogetherService, RequestContext context)
        {
            _listentogetherService = listentogetherService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("acceptinvitation")]
        public async Task<IActionResult> AcceptInvitation([FromBody] ListenTogetherAcceptRequestModel requestModel)
        {
            try
            {
                var response = await _listentogetherService.AcceptInvitation(requestModel);
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
        [HttpGet("endsession")]
        public async Task<IActionResult> EndSession([FromQuery] Int64 roomId)
        {
            try
            {
                var response = await _listentogetherService.EndSession(roomId);
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
        [HttpPost("sendheartbeat")]
        public async Task<IActionResult> SendHeartbeat([FromBody] ListenTogetherHeartbeatRequestModel requestModel)
        {
            try
            {
                var response = await _listentogetherService.SendHeartbeat(requestModel);
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
        [HttpPost("sendplaycommand")]
        public async Task<IActionResult> SendPlayCommand([FromBody] ListenTogetherPlayCommandRequestModel requestModel)
        {
            try
            {
                var response = await _listentogetherService.SendPlayCommand(requestModel);
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
        [HttpGet("checkroomstatus")]
        public async Task<IActionResult> CheckRoomStatus([FromQuery] Int64 roomId)
        {
            try
            {
                var response = await _listentogetherService.CheckRoomStatus(roomId);
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
        [HttpGet("createroom")]
        public async Task<IActionResult> CreateRoom()
        {
            try
            {
                var response = await _listentogetherService.CreateRoom();
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
        [HttpGet("sessionstatus")]
        public async Task<IActionResult> GetSessionStatus()
        {
            try
            {
                var response = await _listentogetherService.GetSessionStatus();
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
        [HttpPost("synccommandlist")]
        public async Task<IActionResult> SyncCommandList([FromBody] ListenTogetherSyncCommandRequestModel requestModel)
        {
            try
            {
                var response = await _listentogetherService.SyncCommandList(requestModel);
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
        [HttpGet("syncplaylist")]
        public async Task<IActionResult> GetSyncPlaylist([FromQuery] Int64 roomId)
        {
            try
            {
                var response = await _listentogetherService.GetSyncPlaylist(roomId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
