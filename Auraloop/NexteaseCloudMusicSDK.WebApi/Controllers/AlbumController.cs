using Microsoft.AspNetCore.Mvc;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.Models.Request;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        /// <summary>
        /// Retrieves album information by its ID.
        /// </summary>
        [HttpGet("get")]
        public async Task<IActionResult> GetAlbum([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(new { Error = "The album ID is required." });

            try
            {
                var response = await _albumService.GetAlbum(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves detailed information about an album by its ID.
        /// </summary>
        [HttpGet("detail")]
        public async Task<IActionResult> AlbumDetail([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(new { Error = "The album ID is required." });

            try
            {
                var response = await _albumService.AlbumDetail(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves dynamic details about an album by its ID.
        /// </summary>
        [HttpGet("detail/dynamic")]
        public async Task<IActionResult> AlbumDetailDynamic([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(new { Error = "The album ID is required." });

            try
            {
                var response = await _albumService.AlbumDetailDynamic(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves a list of albums with filtering and pagination options.
        /// </summary>
        [HttpPost("list")]
        public async Task<IActionResult> AlbumList([FromBody] AlbumListRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "The request model is required." });

            try
            {
                var response = await _albumService.AlbumList(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves a list of albums by style with pagination options.
        /// </summary>
        [HttpPost("list/style")]
        public async Task<IActionResult> AlbumListStyle([FromBody] AlbumListRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "The request model is required." });

            try
            {
                var response = await _albumService.AlbumListStyle(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves newly released albums with pagination options.
        /// </summary>
        [HttpPost("new")]
        public async Task<IActionResult> AlbumNew([FromBody] AlbumNewRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "The request model is required." });

            try
            {
                var response = await _albumService.AlbumNew(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves the newest albums without pagination.
        /// </summary>
        [HttpGet("newest")]
        public async Task<IActionResult> AlbumNewest()
        {
            try
            {
                var response = await _albumService.AlbumNewest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves privilege information for a specific album by its ID.
        /// </summary>
        [HttpGet("privilege")]
        public async Task<IActionResult> AlbumPrivilege([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(new { Error = "The album ID is required." });

            try
            {
                var response = await _albumService.AlbumPrivilege(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves sales information for album songs based on album type, sales type, and year.
        /// </summary>
        [HttpPost("sales")]
        public async Task<IActionResult> AlbumSongsaleboard([FromBody] AlbumSongsaleboardRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "The request model is required." });

            try
            {
                var response = await _albumService.AlbumSongsaleboard(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Subscribes or unsubscribes to an album.
        /// </summary>
        [HttpPost("subscribe")]
        public async Task<IActionResult> AlbumSub([FromQuery] int t, [FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(new { Error = "The album ID is required." });

            if (t != 0 && t != 1)
                return BadRequest(new { Error = "The 't' parameter must be 0 (unsubscribe) or 1 (subscribe)." });

            try
            {
                var response = await _albumService.AlbumSub(t, id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves a list of subscribed albums with pagination options.
        /// </summary>
        [HttpPost("subscribed")]
        public async Task<IActionResult> AlbumSublist([FromBody] AlbumSublistRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "The request model is required." });

            try
            {
                var response = await _albumService.AlbumSublist(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
