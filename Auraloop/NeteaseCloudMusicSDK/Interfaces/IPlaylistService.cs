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
        Task<ApiResponse> PlaylistCatlist();

        /// <summary>
        /// Updates the cover image of a playlist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the update operation.</returns>
        Task<ApiResponse> PlaylistCoverUpdate();

        /// <summary>
        /// Creates a new playlist with the specified details.
        /// </summary>
        /// <param name="requestModel">The model containing the details for the new playlist.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the creation.</returns>
        Task<ApiResponse> PlaylistCreate(PlaylistCreateRequestModel requestModel);

        /// <summary>
        /// Deletes a playlist by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the playlist to delete.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the deletion.</returns>
        Task<ApiResponse> PlaylistDelete(string id);

        /// <summary>
        /// Updates the description of a playlist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the update operation.</returns>
        Task<ApiResponse> PlaylistDescUpdate();

        /// <summary>
        /// Retrieves detailed information about a playlist.
        /// </summary>
        /// <param name="requestModel">The model containing the request details for the playlist.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the playlist details.</returns>
        Task<ApiResponse> PlaylistDetail(PlaylistDetailRequestModel requestModel);

        /// <summary>
        /// Retrieves dynamic details for a playlist, such as play count and subscribers.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the dynamic playlist details.</returns>
        Task<ApiResponse> PlaylistDetailDynamic();

        /// <summary>
        /// Retrieves recommended playlists based on a specific playlist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the recommended playlists.</returns>
        Task<ApiResponse> PlaylistDetailRcmdGet();

        /// <summary>
        /// Retrieves high-quality tags for playlists.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the high-quality playlist tags.</returns>
        Task<ApiResponse> PlaylistHighqualityTags();

        /// <summary>
        /// Retrieves the hottest playlists.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the hottest playlists.</returns>
        Task<ApiResponse> PlaylistHot();

        /// <summary>
        /// Creates a task for importing playlist names.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the task creation.</returns>
        Task<ApiResponse> PlaylistImportNameTaskCreate();

        /// <summary>
        /// Retrieves the status of an ongoing playlist import task.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the task status.</returns>
        Task<ApiResponse> PlaylistImportTaskStatus();

        /// <summary>
        /// Retrieves playlists liked by the user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the user's liked playlists.</returns>
        Task<ApiResponse> PlaylistMylike();

        /// <summary>
        /// Updates the name of a playlist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the name update.</returns>
        Task<ApiResponse> PlaylistNameUpdate();

        /// <summary>
        /// Updates the order of playlists in the user's library.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the order update.</returns>
        Task<ApiResponse> PlaylistOrderUpdate();

        /// <summary>
        /// Updates the privacy setting of a playlist.
        /// </summary>
        /// <param name="id">The unique identifier of the playlist.</param>
        /// <param name="privacy">The privacy setting (0 for public, 1 for private). Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the privacy update.</returns>
        Task<ApiResponse> PlaylistPrivacy(long id, int privacy = 0);

        /// <summary>
        /// Subscribes or unsubscribes to a playlist.
        /// </summary>
        /// <param name="id">The unique identifier of the playlist.</param>
        /// <param name="subOpType">The operation type (subscribe or unsubscribe).</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> PlaylistSubscribe(long id, SubOpType subOpType);

        /// <summary>
        /// Retrieves the subscribers of a playlist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the subscribers of the playlist.</returns>
        Task<ApiResponse> PlaylistSubscribers();

        /// <summary>
        /// Updates the tags of a playlist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the tag update.</returns>
        Task<ApiResponse> PlaylistTagsUpdate();

        /// <summary>
        /// Adds or removes tracks from a playlist.
        /// </summary>
        /// <param name="pid">The playlist ID.</param>
        /// <param name="tracks">The track IDs to add or remove.</param>
        /// <param name="Optype">The operation type (add or remove). Default is add.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> PlaylistTracks(long pid, long[] tracks, Optype Optype = Optype.add);

        /// <summary>
        /// Adds a track to a playlist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the addition.</returns>
        Task<ApiResponse> PlaylistTrackAdd();

        /// <summary>
        /// Retrieves all tracks in a playlist with pagination options.
        /// </summary>
        /// <param name="Id">The playlist ID.</param>
        /// <param name="Limit">The maximum number of tracks to retrieve. Default is 50.</param>
        /// <param name="Offset">The offset for pagination. Default is 0.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the tracks in the playlist.</returns>
        Task<ApiResponse> PlaylistTrackAll(long Id, int Limit = 50, int Offset = 0);

        /// <summary>
        /// Removes a track from a playlist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the removal.</returns>
        Task<ApiResponse> PlaylistTrackDelete();

        /// <summary>
        /// Updates the playlist's name, tags, and description.
        /// </summary>
        /// <param name="id">The playlist ID.</param>
        /// <param name="name">The new playlist name.</param>
        /// <param name="tags">The new tags for the playlist.</param>
        /// <param name="desc">The new description for the playlist. Default is an empty string.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the update.</returns>
        Task<ApiResponse> PlaylistUpdate(long id, string name, string[] tags, string desc = "");

        /// <summary>
        /// Updates the play count of a playlist.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the update.</returns>
        Task<ApiResponse> PlaylistUpdatePlaycount();

        /// <summary>
        /// Retrieves recent videos associated with playlists.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing recent playlist videos.</returns>
        Task<ApiResponse> PlaylistVideoRecent();        
    }
}
