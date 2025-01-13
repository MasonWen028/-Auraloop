using Microsoft.AspNetCore.Mvc;
using NeteaseCloudMusicSDK.Services;
using NeteaseCloudMusicSDK.Models.Request;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.Extensions;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("account")]
        public async Task<IActionResult> GetAccount()
        {
            try
            {
                var response = await _userService.Account();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetUserDetail([FromQuery] long userId)
        {
            if (userId <= 0)
                return BadRequest(new { Error = "Invalid user ID." });

            try
            {
                var response = await _userService.Detail(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UserUpdateRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "Request model is required." });

            try
            {
                var response = await _userService.Update(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("cellphone/check")]
        public async Task<IActionResult> CheckCellphone([FromBody] CellphoneExistenceCheckRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "Request model is required." });

            try
            {
                var response = await _userService.CellphoneExistenceCheck(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("playlist")]
        public async Task<IActionResult> GetUserPlaylist([FromQuery] long userId)
        {
            if (userId <= 0)
                return BadRequest(new { Error = "Invalid user ID." });

            try
            {
                var response = await _userService.Playlist(new UserPlaylistRequestModel { Uid = userId });
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("avatar/upload")]
        public async Task<IActionResult> UploadAvatar([FromBody]AvatarUploadRequestModel requestModel)
        {
            if (requestModel == null || requestModel.ImageData == null || requestModel.ImageData.Length == 0)
                return BadRequest(new { Error = "Image data is required." });

            try
            {
                var imageData = requestModel.ImageData.ReadFileBytes();
                var fileName = requestModel.ImageData.FileName;
                var response = await _userService.AvatarUpload(imageData, fileName);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("social/status")]
        public async Task<IActionResult> GetSocialStatus([FromQuery] long userId)
        {
            if (userId <= 0)
                return BadRequest(new { Error = "Invalid user ID." });

            try
            {
                var response = await _userService.SocialStatus(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("social/status/edit")]
        public async Task<IActionResult> EditSocialStatus([FromBody] UserSocialStatusEditRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "Request model is required." });

            try
            {
                var response = await _userService.SocialStatusEdit(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("level")]
        public async Task<IActionResult> GetUserLevel()
        {
            try
            {
                var response = await _userService.Level();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("event")]
        public async Task<IActionResult> GetUserEvent([FromBody] UserEventRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "Request model is required." });

            try
            {
                var response = await _userService.Event(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("follow")]
        public async Task<IActionResult> FollowUser([FromQuery] long userId, [FromQuery] bool follow)
        {
            if (userId <= 0)
                return BadRequest(new { Error = "Invalid user ID." });

            try
            {
                var response = await _userService.Follow(userId, follow);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("followers")]
        public async Task<IActionResult> GetUserFollowers([FromQuery] long userId)
        {
            if (userId <= 0)
                return BadRequest(new { Error = "Invalid user ID." });

            try
            {
                var response = await _userService.Follows(new UserFollowsRequestModel { UserId = userId });
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("audio")]
        public async Task<IActionResult> GetUserAudio([FromQuery] long userId)
        {
            if (userId <= 0)
                return BadRequest(new { Error = "Invalid user ID." });

            try
            {
                var response = await _userService.Audio(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("binding")]
        public async Task<IActionResult> GetUserBinding([FromQuery] long userId)
        {
            if (userId <= 0)
                return BadRequest(new { Error = "Invalid user ID." });

            try
            {
                var response = await _userService.Binding(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("binding/cellphone")]
        public async Task<IActionResult> BindCellphone([FromBody] BindingCellphoneRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "Request model is required." });

            try
            {
                var response = await _userService.BindingCellphone(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("cloud")]
        public async Task<IActionResult> GetUserCloudData([FromQuery] int limit = 30, [FromQuery] int offset = 0)
        {
            try
            {
                var response = await _userService.Cloud(limit, offset);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpDelete("cloud/song")]
        public async Task<IActionResult> DeleteCloudSong([FromQuery] long songId)
        {
            if (songId <= 0)
                return BadRequest(new { Error = "Invalid song ID." });

            try
            {
                var response = await _userService.CloudDelete(songId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("cloud/detail")]
        public async Task<IActionResult> GetCloudSongDetails([FromBody] long[] songIds)
        {
            if (songIds == null || songIds.Length == 0)
                return BadRequest(new { Error = "Song IDs are required." });

            try
            {
                var response = await _userService.CloudDetail(songIds);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("comment/history")]
        public async Task<IActionResult> GetCommentHistory([FromBody] UserCommentHistoryRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "Request model is required." });

            try
            {
                var response = await _userService.CommentHistory(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("medal")]
        public async Task<IActionResult> GetUserMedals([FromQuery] long userId)
        {
            if (userId <= 0)
                return BadRequest(new { Error = "Invalid user ID." });

            try
            {
                var response = await _userService.Medal(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("mutualfollow")]
        public async Task<IActionResult> CheckMutualFollow([FromQuery] long friendId)
        {
            if (friendId <= 0)
                return BadRequest(new { Error = "Invalid friend ID." });

            try
            {
                var response = await _userService.MutualFollow(friendId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("follow/mixed")]
        public async Task<IActionResult> GetFollowMixed([FromBody] UserFollowMixedRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "Request model is required." });

            try
            {
                var response = await _userService.FollowMixed(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("followeds")]
        public async Task<IActionResult> GetFolloweds([FromBody] UserFollowedsRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "Request model is required." });

            try
            {
                var response = await _userService.Followeds(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("record")]
        public async Task<IActionResult> GetUserRecord([FromQuery] long userId, [FromQuery] int type = 0)
        {
            if (userId <= 0)
                return BadRequest(new { Error = "Invalid user ID." });

            try
            {
                var response = await _userService.Record(userId, type);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("rebind/phone")]
        public async Task<IActionResult> RebindPhone([FromBody] UserReplacePhoneRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "Request model is required." });

            try
            {
                var response = await _userService.Rebind(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("social/status/recommendations")]
        public async Task<IActionResult> GetSocialStatusRecommendations()
        {
            try
            {
                var response = await _userService.SocialStatusRcmd();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("social/status/support")]
        public async Task<IActionResult> GetSupportedSocialStatuses()
        {
            try
            {
                var response = await _userService.SocialStatusSupport();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("subcount")]
        public async Task<IActionResult> GetUserSubcount()
        {
            try
            {
                var response = await _userService.Subcount();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("activate/profile")]
        public async Task<IActionResult> ActivateProfile([FromBody] ActivateInitProfileRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "Request model is required." });

            try
            {
                var response = await _userService.ActivateInitProfile(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("daily/signin")]
        public async Task<IActionResult> DailySignIn([FromQuery] int type)
        {
            if (type < 0 || type > 1)
                return BadRequest(new { Error = "Invalid sign-in type." });

            try
            {
                var response = await _userService.DailySignin(type);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("user/ids")]
        public async Task<IActionResult> GetUserIds([FromBody] string[] nicknames)
        {
            if (nicknames == null || nicknames.Length == 0)
                return BadRequest(new { Error = "Nicknames are required." });

            try
            {
                var response = await _userService.GetUserIds(nicknames);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("nickname/check")]
        public async Task<IActionResult> CheckNickname([FromQuery] string nickname)
        {
            if (string.IsNullOrWhiteSpace(nickname))
                return BadRequest(new { Error = "Nickname is required." });

            try
            {
                var response = await _userService.NicknameCheck(nickname);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("settings")]
        public async Task<IActionResult> GetUserSettings()
        {
            try
            {
                var response = await _userService.Setting();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("resource/like")]
        public async Task<IActionResult> LikeResource([FromBody] ResourceLikeRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "Request model is required." });

            try
            {
                var response = await _userService.ResourceLike(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("creator/auth-info")]
        public async Task<IActionResult> GetCreatorAuthInfo()
        {
            try
            {
                var response = await _userService.GetCreatorAuthInfo();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("artist/manage-subscription")]
        public async Task<IActionResult> ManageArtistSubscription([FromQuery] long artistId, [FromQuery] bool subscribe)
        {
            if (artistId <= 0)
                return BadRequest(new { Error = "Invalid artist ID." });

            try
            {
                var response = await _userService.ManageArtistSubscription(artistId, subscribe);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost("artist/subscribed")]
        public async Task<IActionResult> GetSubscribedArtists([FromBody] ArtistSublistRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "Request model is required." });

            try
            {
                var response = await _userService.GetSubscribedArtists(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

    }
}
