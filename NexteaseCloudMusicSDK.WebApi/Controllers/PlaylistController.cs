using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistService _playlistService;
        private readonly RequestContext _context;

        public PlaylistController(IPlaylistService playlistService, RequestContext context)
        {
            _playlistService = playlistService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("catlist")]
        public async Task<IActionResult> Catlist()
        {
            try
            {
                var response = await _playlistService.Catlist();
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
        [HttpPost("coverupdate")]
        public async Task<IActionResult> CoverUpdate([FromBody] PlaylistCoverUpdateRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.CoverUpdate(requestModel);
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
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PlaylistCreateRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.Create(requestModel);
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
        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery] String id)
        {
            try
            {
                var response = await _playlistService.Delete(id);
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
        [HttpPost("descupdate")]
        public async Task<IActionResult> DescUpdate([FromBody] PlaylistDescUpdateRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.DescUpdate(requestModel);
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
        [HttpPost("detail")]
        public async Task<IActionResult> Detail([FromBody] PlaylistDetailRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.Detail(requestModel);
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
        [HttpGet("detaildynamic")]
        public async Task<IActionResult> DetailDynamic([FromQuery] Int64 id, Int32 subscriberLimit)
        {
            try
            {
                var response = await _playlistService.DetailDynamic(id, subscriberLimit);
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
        [HttpPost("detailrcmd")]
        public async Task<IActionResult> DetailRcmdGet([FromBody] PlaylistDetailRcmdRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.DetailRcmdGet(requestModel);
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
        [HttpGet("highqualitytags")]
        public async Task<IActionResult> HighqualityTags()
        {
            try
            {
                var response = await _playlistService.HighqualityTags();
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
        [HttpGet("hot")]
        public async Task<IActionResult> Hot()
        {
            try
            {
                var response = await _playlistService.Hot();
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
        [HttpPost("importnametaskcreate")]
        public async Task<IActionResult> ImportNameTaskCreate([FromBody] PlaylistImportNameTaskRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.ImportNameTaskCreate(requestModel);
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
        [HttpGet("importtaskstatus")]
        public async Task<IActionResult> PlaylistImportTaskStatus([FromQuery] Int64 id)
        {
            try
            {
                var response = await _playlistService.PlaylistImportTaskStatus(id);
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
        [HttpPost("mylike")]
        public async Task<IActionResult> MyLike([FromBody] PlaylistMyLikeRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.MyLike(requestModel);
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
        [HttpPost("nameupdate")]
        public async Task<IActionResult> NameUpdate([FromBody] PlaylistNameUpdateRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.NameUpdate(requestModel);
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
        [HttpPost("orderupdate")]
        public async Task<IActionResult> OrderUpdate([FromBody] PlaylistOrderUpdateRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.OrderUpdate(requestModel);
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
        [HttpPost("privacy")]
        public async Task<IActionResult> Privacy([FromBody] PlaylistPrivacyRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.Privacy(requestModel);
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
        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] PlaylistSubscribeRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.Subscribe(requestModel);
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
        [HttpPost("subscribers")]
        public async Task<IActionResult> Subscribers([FromBody] PlaylistSubscribersRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.Subscribers(requestModel);
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
        [HttpPost("tagsupdate")]
        public async Task<IActionResult> TagsUpdate([FromBody] PlaylistTagsUpdateRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.TagsUpdate(requestModel);
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
        [HttpPost("tracksmanipulate")]
        public async Task<IActionResult> TracksManipulate([FromBody] PlaylistTracksManipulateRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.TracksManipulate(requestModel);
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
        [HttpPost("trackadd")]
        public async Task<IActionResult> TrackAdd([FromBody] PlaylistTrackAddRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.TrackAdd(requestModel);
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
        [HttpPost("trackall")]
        public async Task<IActionResult> TrackAll([FromBody] PlaylistTrackAllRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.TrackAll(requestModel);
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
        [HttpPost("trackdelete")]
        public async Task<IActionResult> TrackDelete([FromBody] PlaylistTrackAddRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.TrackDelete(requestModel);
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
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] PlaylistUpdateRequestModel requestModel)
        {
            try
            {
                var response = await _playlistService.Update(requestModel);
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
        [HttpGet("updateplaycount")]
        public async Task<IActionResult> UpdatePlaycount([FromQuery] Int64 id)
        {
            try
            {
                var response = await _playlistService.UpdatePlaycount(id);
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
        [HttpGet("videorecent")]
        public async Task<IActionResult> VideoRecent()
        {
            try
            {
                var response = await _playlistService.VideoRecent();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
