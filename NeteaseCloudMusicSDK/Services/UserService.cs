using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Extensions;
using NeteaseCloudMusicSDK.Models.Response;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class UserService : IUserService
    {
        private readonly NetEaseApiClient _client;

        public UserService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Account()
        {
            try
            {
                var options = new RequestOptions($"/api/nuser/account/get", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get account info.", ex);
            }
        }

        /// <inheritdoc/>
        public Task<ApiResponse> ActivateInitProfile(ActivateInitProfileRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Audio(long userId)
        {
            try
            {
                var options = new RequestOptions($"/api/djradio/get/byuser", new { userId = userId }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get radio list create by user.", ex);
            }
        }
        /// <inheritdoc/>
        public async Task<ApiResponse> AvatarUpload(byte[] imageData, string fileName)
        {
            if (imageData == null || imageData.Length == 0)
            {
                throw new ArgumentException("Image data cannot be null or empty.");
            }
            try
            {
                string docId = await UploadFileAsync(imageData, fileName);

                // Step 3: set the uploaded img as avatar result
                var options = new RequestOptions($"/api/user/avatar/upload/v1", new { imgid = docId }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to upload avatar.", ex);
            }
        }

        private async Task<string> UploadFileAsync(byte[] imageData, string fileName)
        {
            // Step 1: Get key and token
            var tokenRequestData = new
            {
                bucket = "yyimgs",
                ext = "jpg",
                filename = fileName,
                local = false,
                nos_product = 0,
                return_body = "{\"code\":200,\"size\":\"$(ObjectSize)\"}",
                type = "other"
            };

            var tokenOption = new RequestOptions(
                "/api/nos/token/alloc",
                tokenRequestData);


            var tokenResponse = await _client.HandleRequestAsync(tokenOption);

            if (!tokenResponse.IsSuccess)
            {
                throw new Exception("Failed to allocate token for image upload.");
            }

            var result = tokenResponse.Data;


            // Step 2: Upload the image
            using (var imageContent = new ByteArrayContent(imageData))
            {
                var resultJobj = JObject.Parse(result.ToString());
                var token = resultJobj["token"].ToString();
                var objectKey = resultJobj["objectKey"].ToString();
                var docId = resultJobj["docId"].ToString();
                imageContent.Headers.Add("x-nos-token", token);
                imageContent.Headers.Add("Content-Type", "image/jpeg");

                var uploadUrl = $"https://nosup-hz1.127.net/yyimgs/{objectKey}?offset=0&complete=true&version=1.0";
                var uploadResponse = await _client.PostAsync(uploadUrl, imageContent);

                if (!uploadResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to upload image.");
                }

                return docId;
            }
        }

        public async Task<ApiResponse> Binding(long userId)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/user/bindings/{userId}", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get binding state of current user.", ex);
            }
        }
        /// <inheritdoc>
        public async Task<ApiResponse> BindingCellphone(BindingCellphoneRequestModel requestModel)
        {
            try
            {
                if (string.IsNullOrEmpty(requestModel.Password))
                {
                    requestModel.Password = requestModel.Password.CalculateMd5();
                }
                var options = new RequestOptions($"/api/user/bindingCellphone", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to bind phone number +{requestModel.CountryCode + requestModel.Phone} to current user.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> CellphoneExistenceCheck(CellphoneExistenceCheckRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/cellphone/existence/check", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to check phone number +{requestModel.CountryCode + requestModel.Cellphone} existence.", ex);
            }
        }

        /// <inheritdoc />
        public async Task<ApiResponse> Cloud(int limit = 30, int offset = 0)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/cloud/get", new { limit = limit, offet = offset }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the files from cloud disk.", ex);
            }
        }

        /// <inheritdoc />
        public async Task<ApiResponse> CloudDelete(long songId)
        {
            try
            {
                var options = new RequestOptions($"/api/cloud/del", new { songIds = new long[] { songId } }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to remove songs from cloud disk", ex);
            }
        }

        /// <inheritdoc />
        public async Task<ApiResponse> CloudDetail(long[] songIds)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/cloud/get/byids", new { songIds = songIds }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch songs detail", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> CommentHistory(UserCommentHistoryRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/comment/user/comment/history", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch comment history for current user", ex);
            }
        }

        //TODO not implement
        public Task<ApiResponse> DailySignin(int type)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Detail(long userId)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/user/detail/{userId}", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch user details", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Event(UserEventRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/event/get/{requestModel.UserId}", new {
                    limit = requestModel.Limit,
                    lastTime = requestModel.LastTime,
                    total = requestModel.Total,
                    getCounts = requestModel.GetCounts
                }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch user details", ex);
            }
        }

        //TODO return illegal request
        /// <inheritdoc/>
        public async Task<ApiResponse> Follow(long userId, bool follow)
        {
            if (userId <= 0)
                throw new ArgumentException("Invalid user ID.");

            string action = follow ? "follow" : "delfollow";

            try
            {
                string endpoint = $"/api/user/{action}/{userId}";

                var options = new RequestOptions(endpoint, null, "weapi");

                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to {action} user with ID {userId}.", ex);
            }
        }

        public async Task<ApiResponse> Followeds(UserFollowedsRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/user/getfolloweds/{requestModel.UserId}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the list followed by user", ex);
            }
        }

        //TODO 
        public async Task<ApiResponse> FollowMixed(UserFollowMixedRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/user/follow/users/mixed/get/v2", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch user followmixed", ex);
            }
        }

        /// <inheritdoc />
        public async Task<ApiResponse> Follows(UserFollowsRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/user/getfollows/{requestModel.UserId}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch user followers", ex);
            }
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

        //TODO get userids by nicknames
        public Task<ApiResponse> GetUserIds(string[] nicknames)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task<ApiResponse> Level()
        {
            try
            {
                var options = new RequestOptions($"/api/user/level", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get subscribed artists.", ex);
            }
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
                var options = new RequestOptions($"/api/artist/{subOrNot}", new
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

        /// <inheritdoc />
        public async Task<ApiResponse> Medal(long userId)
        {
            try
            {
                var options = new RequestOptions($"/api/medal/user/page", new { uid = userId }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get subscribed artists.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> MutualFollow(long friendId)
        {
            try
            {
                var options = new RequestOptions($"/api/user/mutualfollow/get", new { friendid = friendId });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get subscribed artists.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> NicknameCheck(string nickname)
        {
            try
            {
                var options = new RequestOptions($"/api/nickname/duplicated", new { nickname = nickname });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get subscribed artists.", ex);
            }
        }

        /// <inheritdoc />
        public async Task<ApiResponse> Playlist(UserPlaylistRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/user/playlist", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get subscribed artists.", ex);
            }
        }

        /// <inheritdoc />
        public async Task<ApiResponse> Radio(UserRadiosRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/dj/program/${requestModel.Uid}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get subscribed artists.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Rebind(UserReplacePhoneRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/user/replaceCellphone", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to rebind the cellphone to this user.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Record(long userId, int type = 0)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/play/record", new { uid = userId, type = type }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to rebind the cellphone to this user.", ex);
            }
        }

        /// <inheritdoc />
        public async Task<ApiResponse> ResourceLike(ResourceLikeRequestModel requestModel)
        {
            if (requestModel == null)
            {
                throw new ArgumentNullException(nameof(requestModel), "Request model cannot be null.");
            }

            // Map the type if necessary (simulate resourceTypeMap)
            var resourceTypeMap = new System.Collections.Generic.Dictionary<string, string>
        {
            { "song", "R_SO_4_" },
            { "playlist", "A_PL_0_" },
            { "video", "R_VI_62_" },
            { "event", "A_EV_2_" }
        };

            if (!resourceTypeMap.TryGetValue(requestModel.Type, out string mappedType))
            {
                throw new ArgumentException($"Unsupported resource type: {requestModel.Type}");
            }

            // Construct the threadId
            string threadId = mappedType + requestModel.Id;

            if (mappedType == "A_EV_2_" && !string.IsNullOrEmpty(requestModel.ThreadId))
            {
                threadId = requestModel.ThreadId; // Override for specific type
            }


            var action = requestModel.Like ? "like" : "unlike";

            try
            {
                var options = new RequestOptions($"/api/resource/{action}", new { threadId = threadId }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to rebind the cellphone to this user.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Scrobble(ScrobbleRequestModel requestModel)
        {
            if (requestModel == null)
            {
                throw new ArgumentNullException(nameof(requestModel), "Request model cannot be null.");
            }

            
            try
            {
                var logs = new List<object>
                {
                    new
                    {
                        action = "play",
                        json = new
                        {
                            download = 0,
                            end = "playend",
                            id = requestModel.Id,
                            sourceId = requestModel.SourceId,
                            time = requestModel.Time,
                            type = "song",
                            wifi = 0,
                            source = "list",
                            mainsite = 1,
                            content = string.Empty
                        }
                    }
                };

                var options = new RequestOptions($"/api/feedback/weblog", new { logs = logs }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to rebind the cellphone to this user.", ex);
            }

        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Setting()
        {
            try
            {
                var options = new RequestOptions($"/api/user/setting", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to current setting of this user.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> SocialStatus(long userId)
        {
            try
            {
                var options = new RequestOptions($"/api/social/user/status", new { visitorId = userId });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch social state of current user.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> SocialStatusEdit(UserSocialStatusEditRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/social/user/status/edit", new { content = requestModel });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to edit social state of current user.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> SocialStatusRcmd()
        {
            try
            {
                var options = new RequestOptions($"/api/social/user/status/rcmd");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch users who has same social state.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> SocialStatusSupport()
        {
            try
            {
                var options = new RequestOptions($"/api/social/user/status/support");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch states which could be set by users.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Subcount()
        {
            try
            {
                var options = new RequestOptions($"/api/subcount", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch states which could be set by users.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> Update(UserUpdateRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/user/profile/update", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update user details.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetUserFavoritedSongs(long userId)
        {
            try
            {
                var options = new RequestOptions($"/api/song/like/get", new { uid = userId });
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fecth user favorited songs.", ex);
            }
        }
    }
}
