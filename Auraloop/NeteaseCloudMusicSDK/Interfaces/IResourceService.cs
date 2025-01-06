using NeteaseCloudMusicSDK.Models.Response;
using System.Threading.Tasks;

/// <summary>
/// Defines methods for managing resources, such as liking or unliking content, in the Netease Cloud Music API.
/// </summary>
public interface IResourceService
{
    /// <summary>
    /// Likes or unlikes a specific resource, such as a song, playlist, or video.
    /// </summary>
    /// <param name="requestModel">The model containing the resource details and operation type.</param>
    /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
    Task<ApiResponse> ResourceLike(ResourceLikeRequestModel requestModel);
}
