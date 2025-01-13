using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing playlists in the Netease Cloud Music API.
    /// </summary>
    public interface IPlaylistService
    {
        /// <summary>
        /// Retrieves all available playlist categories.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the playlist categories.</returns>
        Task<ApiResponse> Catlist();

        /// <summary>
        /// Updates the cover image of a playlist.
        /// </summary>
        /// <param name="requestModel">The model containing the playlist ID and image file for the cover update.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the update operation.</returns>
        Task<ApiResponse> CoverUpdate(PlaylistCoverUpdateRequestModel requestModel);


        /// <summary>
        /// Creates a new playlist with the specified details.
        /// </summary>
        /// <param name="requestModel">The model containing the details for the new playlist.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the creation.</returns>
        Task<ApiResponse> Create(PlaylistCreateRequestModel requestModel);

        /// <summary>
        /// Deletes a playlist by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the playlist to delete.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the deletion.</returns>
        Task<ApiResponse> Delete(string id);

        /// <summary>
        /// Updates the description of a playlist.
        /// </summary>
        /// <param name="requestModel">The model containing the playlist ID and the new description.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the update operation.</returns>
        Task<ApiResponse> DescUpdate(PlaylistDescUpdateRequestModel requestModel);

        /// <summary>
        /// Retrieves detailed information about a playlist.
        /// </summary>
        /// <param name="requestModel">The model containing the request details for the playlist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the playlist details.</returns>
        Task<ApiResponse> tDetail(PlaylistDetailRequestModel requestModel);

        /// <summary>
        /// Retrieves dynamic details for a playlist, such as play count and subscribers.
        /// </summary>
        /// <param name="id">The unique identifier of the playlist.</param>
        /// <param name="subscriberLimit">The maximum number of subscriber details to retrieve. Default is 8.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the dynamic playlist details.</returns>
        Task<ApiResponse> DetailDynamic(long id, int subscriberLimit = 8);

        /// <summary>
        /// Retrieves recommended playlists based on a specific playlist.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching recommended playlists.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the recommended playlists.</returns>
        Task<ApiResponse> DetailRcmdGet(PlaylistDetailRcmdRequestModel requestModel);

        /// <summary>
        /// Retrieves high-quality tags for playlists.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the high-quality playlist tags.</returns>
        Task<ApiResponse> HighqualityTags();

        /// <summary>
        /// Retrieves the hottest playlists.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the hottest playlists.</returns>
        Task<ApiResponse> Hot();

        /// <summary>
        /// Creates a task for importing playlist names.
        /// </summary>
        /// <param name="requestModel">The model containing the playlist import details.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the task creation.</returns>
        Task<ApiResponse> ImportNameTaskCreate(PlaylistImportNameTaskRequestModel requestModel);

        /// <summary>
        /// Retrieves the status of an ongoing playlist import task.
        /// </summary>
        /// <param name="id">The unique identifier of the task.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the task status.</returns>
        Task<ApiResponse> PlaylistImportTaskStatus(long id);

        /// <summary>
        /// Retrieves playlists liked by the user.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching liked playlists.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the user's liked playlists.</returns>
        Task<ApiResponse> MyLike(PlaylistMyLikeRequestModel requestModel);

        /// <summary>
        /// Updates the name of a playlist.
        /// </summary>
        /// <param name="requestModel">The model containing the playlist ID and the new name.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the name update.</returns>
        Task<ApiResponse> NameUpdate(PlaylistNameUpdateRequestModel requestModel);

        /// <summary>
        /// Updates the order of playlists in the user's library.
        /// </summary>
        /// <param name="requestModel">The model containing the IDs of playlists in the desired order.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the order update.</returns>
        Task<ApiResponse> OrderUpdate(PlaylistOrderUpdateRequestModel requestModel);

        /// <summary>
        /// Updates the privacy setting of a playlist.
        /// </summary>
        /// <param name="requestModel">The model containing the playlist ID and the desired privacy setting.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the privacy update.</returns>
        Task<ApiResponse> Privacy(PlaylistPrivacyRequestModel requestModel);

        /// <summary>
        /// Subscribes or unsubscribes to a playlist.
        /// </summary>
        /// <param name="requestModel">The model containing the playlist ID and subscription operation.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> Subscribe(PlaylistSubscribeRequestModel requestModel);

        /// <summary>
        /// Retrieves the subscribers of a playlist.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching playlist subscribers.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the subscribers of the playlist.</returns>
        Task<ApiResponse> Subscribers(PlaylistSubscribersRequestModel requestModel);

        /// <summary>
        /// Updates the tags of a playlist.
        /// </summary>
        /// <param name="requestModel">The model containing the playlist ID and the new tags.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the tag update.</returns>
        Task<ApiResponse> TagsUpdate(PlaylistTagsUpdateRequestModel requestModel);

        /// <summary>
        /// Adds or removes tracks from a playlist.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for adding or removing tracks.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> TracksManipulate(PlaylistTracksManipulateRequestModel requestModel);

        /// <summary>
        /// Adds tracks to a playlist.
        /// </summary>
        /// <param name="requestModel">The model containing the playlist ID and tracks to add.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the addition.</returns>
        Task<ApiResponse> TrackAdd(PlaylistTrackAddRequestModel requestModel);

        /// <summary>
        /// Retrieves all tracks in a playlist with pagination options.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for fetching all tracks in the playlist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the tracks in the playlist.</returns>
        Task<ApiResponse> TrackAll(PlaylistTrackAllRequestModel requestModel);

        /// <summary>
        /// Removes a track from a playlist.
        /// </summary>
        /// <param name="requestModel">The model containing the playlist ID and tracks to remove.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the removal.</returns>
        Task<ApiResponse> TrackDelete(PlaylistTrackAddRequestModel requestModel);

        /// <summary>
        /// Updates the playlist's name, tags, and description.
        /// </summary>
        /// <param name="requestModel">The model containing the playlist ID, new name, tags, and description.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the update.</returns>
        Task<ApiResponse> Update(PlaylistUpdateRequestModel requestModel);

        /// <summary>
        /// Updates the play count of a playlist.
        /// </summary>
        /// <param name="id">The unique identifier of the playlist.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the update.</returns>
        Task<ApiResponse> UpdatePlaycount(long id);

        /// <summary>
        /// Retrieves recent videos associated with playlists.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing recent playlist videos.</returns>
        Task<ApiResponse> VideoRecent();
    }
}
