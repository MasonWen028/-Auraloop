using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class UserService: IUserService
    {
        private readonly NetEaseApiClient _client;

        public UserService(NetEaseApiClient client)
        {
            _client = client;
        }

        public Task<ApiResponse> Account()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> ActivateInitProfile(ActivateInitProfileRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Audio(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> AvatarUpload(byte[] imageData)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Binding(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> BindingCellphone(BindingCellphoneRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> CellphoneExistenceCheck(CellphoneExistenceCheckRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Cloud(int limit = 30, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> CloudDelete(long songId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> CloudDetail(long[] songIds)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> CommentHistory(UserCommentHistoryRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DailySignin(int type)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Detail(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Event(UserEventRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Follow(long userId, bool follow)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Followeds(long userId, int limit = 30, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> FollowMixed(UserFollowMixedRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Follows(long userId, int limit = 30, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetCreatorAuthInfo()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetSubscribedArtists(ArtistSublistRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/artist/sublist", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get subscribed artists.", ex);
            }
        }

        public Task<ApiResponse> GetUserIds(string[] nicknames)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Level()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> ManageArtistSubscription(long artistId, bool subscribe)
        {
            string subOrNot = subscribe ? "sub" : "unsub";

            if (artistId <= 0)
            {
                throw new ArgumentException($"{subOrNot} failed, artist id can not lower than 1");
            }

            try
            {
                var options = new RequestOptions($"/api/artist/${subOrNot}", new
                {
                    artistId = artistId,
                    artistIds = $"[{artistId}]"
                });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to {subOrNot} artist with ID '{artistId}'.", ex);
            }
        }

        public Task<ApiResponse> Medal(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> MutualFollow(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> NicknameCheck(string nickname)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Playlist(long userId, int limit = 30, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Radio(long userId, int limit = 30, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Rebind(UserReplacePhoneRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Record(long userId, int type = 0)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> ResourceLike(ResourceLikeRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Scrobble(ScrobbleRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Setting()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> SocialStatus(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> SocialStatusEdit(UserSocialStatusEditRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> SocialStatusRcmd()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> SocialStatusSupport()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Subcount()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Update(UserUpdateRequestModel requestModel)
        {
            throw new NotImplementedException();
        }
    }
}
