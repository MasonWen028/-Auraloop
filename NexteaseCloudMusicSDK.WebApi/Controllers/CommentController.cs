using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly RequestContext _context;

        public CommentController(ICommentService commentService, RequestContext context)
        {
            _commentService = commentService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("manage")]
        public async Task<IActionResult> ManageComment([FromBody] CommentManageRequestModel requestModel)
        {
            try
            {
                var response = await _commentService.ManageComment(requestModel);
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
        [HttpPost("albums")]
        public async Task<IActionResult> GetAlbumComments([FromBody] CommentRequestModel requestModel)
        {
            try
            {
                var response = await _commentService.GetAlbumComments(requestModel);
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
        [HttpPost("djs")]
        public async Task<IActionResult> GetDjComments([FromBody] CommentRequestModel requestModel)
        {
            try
            {
                var response = await _commentService.GetDjComments(requestModel);
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
        [HttpPost("events")]
        public async Task<IActionResult> GetEventComments([FromBody] CommentRequestModel requestModel)
        {
            try
            {
                var response = await _commentService.GetEventComments(requestModel);
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
        [HttpPost("floors")]
        public async Task<IActionResult> GetFloorComments([FromBody] CommentFloorRequestModel requestModel)
        {
            try
            {
                var response = await _commentService.GetFloorComments(requestModel);
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
        [HttpPost("hots")]
        public async Task<IActionResult> GetHotComments([FromBody] CommentRequestModel requestModel)
        {
            try
            {
                var response = await _commentService.GetHotComments(requestModel);
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
        [HttpPost("huglist")]
        public async Task<IActionResult> GetHugList([FromBody] CommentHugListRequestModel requestModel)
        {
            try
            {
                var response = await _commentService.GetHugList(requestModel);
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
        [HttpPost("like")]
        public async Task<IActionResult> LikeComment([FromBody] CommentLikeRequestModel requestModel)
        {
            try
            {
                var response = await _commentService.LikeComment(requestModel);
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
        [HttpPost("musics")]
        public async Task<IActionResult> GetMusicComments([FromBody] CommentRequestModel requestModel)
        {
            try
            {
                var response = await _commentService.GetMusicComments(requestModel);
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
        [HttpPost("mvs")]
        public async Task<IActionResult> GetMvComments([FromBody] CommentRequestModel requestModel)
        {
            try
            {
                var response = await _commentService.GetMvComments(requestModel);
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
        [HttpPost("news")]
        public async Task<IActionResult> GetNewComments([FromBody] CommentNewRequestModel requestModel)
        {
            try
            {
                var response = await _commentService.GetNewComments(requestModel);
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
        [HttpPost("playlists")]
        public async Task<IActionResult> GetPlaylistComments([FromBody] CommentRequestModel requestModel)
        {
            try
            {
                var response = await _commentService.GetPlaylistComments(requestModel);
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
        [HttpPost("videos")]
        public async Task<IActionResult> GetVideoComments([FromBody] CommentRequestModel requestModel)
        {
            try
            {
                var response = await _commentService.GetVideoComments(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
