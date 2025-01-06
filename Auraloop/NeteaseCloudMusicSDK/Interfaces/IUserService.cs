
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse> UserAccount();
        Task<ApiResponse> UserAudio();
        Task<ApiResponse> UserBinding();
        Task<ApiResponse> UserBindingcellphone();
        Task<ApiResponse> UserCloud(int limit = 30, int offset = 0);
        Task<ApiResponse> UserCloudDel(long id);
        Task<ApiResponse> UserCloudDetail();
        Task<ApiResponse> UserCommentHistory();
        Task<ApiResponse> UserDetail(long uid);
        Task<ApiResponse> UserDj();
        Task<ApiResponse> UserEvent();
        Task<ApiResponse> UserFolloweds();
        Task<ApiResponse> UserFollows();
        Task<ApiResponse> UserFollowMixed();
        Task<ApiResponse> UserLevel();
        Task<ApiResponse> UserMedal();
        Task<ApiResponse> UserMutualfollowGet();
        Task<ApiResponse> UserPlaylist(long uid, int limit, int offset = 0);
        Task<ApiResponse> UserRecord();
        Task<ApiResponse> UserReplacephone();
        Task<ApiResponse> UserSocialStatus();
        Task<ApiResponse> UserSocialStatusEdit();
        Task<ApiResponse> UserSocialStatusRcmd();
        Task<ApiResponse> UserSocialStatusSupport();
        Task<ApiResponse> UserSubcount();
        Task<ApiResponse> UserUpdate();
        Task<ApiResponse> ActivateInitProfile(ActivateInitProfileRequestModel requestModel);

        Task<ApiResponse> AvatarUpload();

        /// <summary>
        /// Performs a daily sign-in action for the user, based on the specified sign-in type.
        /// </summary>
        /// <param name="type">
        /// The type of sign-in action:
        /// <list type="bullet">
        /// <item><description>1 for mobile app sign-in.</description></item>
        /// <item><description>0 for website sign-in.</description></item>
        /// </list>
        /// </param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the sign-in action.</returns>
        Task<ApiResponse> DailySignin(int type);

        Task<ApiResponse> Follow();

        Task<ApiResponse> GetUserids(string[] nicknames);

        /// <summary>
        /// Checks the availability of a specified nickname for a user.
        /// </summary>
        /// <param name="nickname">The nickname to check for availability.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating whether the nickname is available or already taken.</returns>
        Task<ApiResponse> NicknameCheck(string nickname);

        /// <summary>
        /// Changes the phone number bound to the user's account.
        /// </summary>
        /// <param name="phone">The new phone number to be bound to the account.</param>
        /// <param name="captcha">The verification code sent to the new phone number.</param>
        /// <param name="oldcaptcha">The verification code sent to the currently bound phone number.</param>
        /// <param name="ctcode">The country code of the phone number. Default is "86" (China).</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the phone number binding update.</returns>
        Task<ApiResponse> Rebind(string phone, string captcha, string oldcaptcha, string ctcode = "86");

        Task<ApiResponse> Setting();

    }
}