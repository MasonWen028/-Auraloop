
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing user data and operations in the Netease Cloud Music API.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves the user's account details.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the user's account details.</returns>
        Task<ApiResponse> Account();

        /// <summary>
        /// Retrieves the radio stations created by the user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the user's radio stations.</returns>
        Task<ApiResponse> Audio(long userId);

        /// <summary>
        /// Retrieves the user's account bindings, such as linked email or phone.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the user's account bindings.</returns>
        Task<ApiResponse> Binding(long userId);

        /// <summary>
        /// Binds a phone number to the user's account.
        /// </summary>
        /// <param name="requestModel">The model containing the phone binding details.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> BindingCellphone(BindingCellphoneRequestModel requestModel);

        /// <summary>
        /// Retrieves the user's cloud data, including uploaded songs.
        /// </summary>
        /// <param name="limit">The maximum number of items to retrieve. Default is 30.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the user's cloud data.</returns>
        Task<ApiResponse> Cloud(int limit = 30, int offset = 0);

        /// <summary>
        /// Deletes a song from the user's cloud data.
        /// </summary>
        /// <param name="songId">The unique identifier of the song to delete.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the deletion.</returns>
        Task<ApiResponse> CloudDelete(long songId);

        /// <summary>
        /// Retrieves detailed information about songs in the user's cloud data.
        /// </summary>
        /// <param name="songIds">An array of song IDs for which to retrieve details.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the cloud song details.</returns>
        Task<ApiResponse> CloudDetail(long[] songIds);

        /// <summary>
        /// Retrieves the user's comment history with filtering options.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for filtering comment history.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the user's comment history.</returns>
        Task<ApiResponse> CommentHistory(UserCommentHistoryRequestModel requestModel);

        /// <summary>
        /// Retrieves detailed information about a specific user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the user's details.</returns>
        Task<ApiResponse> Detail(long userId);

        /// <summary>
        /// Retrieves the user's radio programs.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the user's radio programs.</returns>
        Task<ApiResponse> Radio(UserRadiosRequestModel requestModel);
        /// <summary>
        /// Retrieves the user's event feed with filtering and pagination.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for filtering and pagination.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the user's events.</returns>
        Task<ApiResponse> Event(UserEventRequestModel requestModel);

        /// <summary>
        /// Retrieves the list of users or artists followed by the current account.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for filtering followed users or artists.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of followed users or artists.</returns>
        Task<ApiResponse> FollowMixed(UserFollowMixedRequestModel requestModel);

        /// <summary>
        /// Retrieves the followers (fans) of a specified user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of followers.</returns>
        Task<ApiResponse> Followeds(UserFollowedsRequestModel requestModel);

        /// <summary>
        /// Retrieves the users followed by a specified user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of followed users.</returns>
        Task<ApiResponse> Follows(UserFollowsRequestModel requestModel);

        /// <summary>
        /// Retrieves the level details of the current user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the user's level details.</returns>
        Task<ApiResponse> Level();

        /// <summary>
        /// Retrieves the user's medals.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the user's medals.</returns>
        Task<ApiResponse> Medal(long userId);

        /// <summary>
        /// Checks whether the specified user is mutually following the current user.
        /// </summary>
        /// <param name="friendId">The unique identifier of the user to check.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating whether the users are mutually following each other.</returns>
        Task<ApiResponse> MutualFollow(long friendId);

        /// <summary>
        /// Retrieves the user's playlists with pagination.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="limit">The maximum number of results to retrieve. Default is 30.</param>
        /// <param name="offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the user's playlists.</returns>
        Task<ApiResponse> Playlist(UserPlaylistRequestModel requestModel);

        /// <summary>
        /// Retrieves the user's listening records.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <param name="type">The type of records to retrieve (1 for recent week, 0 for all time). Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the user's listening records.</returns>
        Task<ApiResponse> Record(long userId, int type = 0);

        /// <summary>
        /// Changes the phone number bound to the user's account.
        /// </summary>
        /// <param name="phone">The new phone number to be bound to the account.</param>
        /// <param name="captcha">The verification code sent to the new phone number.</param>
        /// <param name="oldcaptcha">The verification code sent to the currently bound phone number.</param>
        /// <param name="ctcode">The country code of the phone number. Default is "86" (China).</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the phone number binding update.</returns>
        Task<ApiResponse> Rebind(UserReplacePhoneRequestModel requestModel);

        /// <summary>
        /// Retrieves the current user's social status.
        /// </summary>
        /// <param name="userId">The unique identifier of the visitor or user.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the user's social status.</returns>
        Task<ApiResponse> SocialStatus(long userId);

        /// <summary>
        /// Edits the current user's social status.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for editing the user's social status.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> SocialStatusEdit(UserSocialStatusEditRequestModel requestModel);

        /// <summary>
        /// Retrieves users with the same social status as the current user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing users with the same social status.</returns>
        Task<ApiResponse> SocialStatusRcmd();

        /// <summary>
        /// Retrieves the supported social statuses that the user can set.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the supported social statuses.</returns>
        Task<ApiResponse> SocialStatusSupport();

        /// <summary>
        /// Retrieves the user's collection count, including playlists, MVs, and albums.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the collection counts.</returns>
        Task<ApiResponse> Subcount();

        /// <summary>
        /// Updates the user's profile information.
        /// </summary>
        /// <param name="requestModel">The model containing the user's updated profile details.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the update.</returns>
        Task<ApiResponse> Update(UserUpdateRequestModel requestModel);

        /// <summary>
        /// Uploads a new avatar for the user.
        /// </summary>
        /// <param name="imageData">The image data for the avatar.</param>
        /// // <param name="fileName">The image name for the avatar.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the upload result.</returns>
        Task<ApiResponse> AvatarUpload(byte[] imageData, string fileName);

        /// <summary>
        /// Activates the user's profile by initializing their nickname.
        /// </summary>
        /// <param name="requestModel">The model containing the user's initial profile details.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the initialization.</returns>
        Task<ApiResponse> ActivateInitProfile(ActivateInitProfileRequestModel requestModel);

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

        /// <summary>
        /// Follows a user or artist based on their unique identifier.
        /// </summary>
        /// <param name="userId">The unique identifier of the user or artist to follow.</param>
        /// <param name="follow">A boolean indicating whether to follow (true) or unfollow (false) the user.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the follow action.</returns>
        Task<ApiResponse> Follow(long userId, bool follow);

        /// <summary>
        /// Retrieves user IDs based on an array of nicknames.
        /// </summary>
        /// <param name="nicknames">An array of nicknames to search for.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the user IDs corresponding to the nicknames.</returns>
        Task<ApiResponse> GetUserIds(string[] nicknames);

        /// <summary>
        /// Checks the availability of a specified nickname for a user.
        /// </summary>
        /// <param name="nickname">The nickname to check for availability.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating whether the nickname is available or already taken.</returns>
        Task<ApiResponse> NicknameCheck(string nickname);

        /// <summary>
        /// Retrieves the user's settings, such as preferences or notifications.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the user's settings.</returns>
        Task<ApiResponse> Setting();


        /// <summary>
        /// Likes or unlikes a specific resource, such as a song, playlist, or video.
        /// </summary>
        /// <param name="requestModel">The model containing the resource details and operation type.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> ResourceLike(ResourceLikeRequestModel requestModel);


        /// <summary>
        /// Tracks a song play (scrobble) with details about the playback.
        /// </summary>
        /// <param name="requestModel">The model containing details about the song and playback context.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the scrobble operation.</returns>
        Task<ApiResponse> Scrobble(ScrobbleRequestModel requestModel);


        /// <summary>
        /// Retrieves authentication and related details for a creator user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the creator's authentication information.</returns>
        Task<ApiResponse> GetCreatorAuthInfo();

        /// <summary>
        /// Checks the existence of a cellphone number in the system.
        /// </summary>
        /// <param name="requestModel">The request model containing the cellphone number and country code.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating whether the cellphone number exists in the system.</returns>
        Task<ApiResponse> CellphoneExistenceCheck(CellphoneExistenceCheckRequestModel requestModel);

        /// <summary>
        /// Subscribes or unsubscribes to an artist.
        /// </summary>
        /// <param name="artistId">The unique identifier of the artist.</param>
        /// <param name="subscribe">Indicates whether to subscribe (true) or unsubscribe (false).</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the action.</returns>
        Task<ApiResponse> ManageArtistSubscription(long artistId, bool subscribe);

        /// <summary>
        /// Retrieves a list of subscribed artists for the user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of subscribed artists.</returns>
        Task<ApiResponse> GetSubscribedArtists(ArtistSublistRequestModel requestModel);

        /// <summary>
        /// Retrieves a list of favorited songs for the user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ApiResponse> GetUserFavoritedSongs(long userId);
    }
}