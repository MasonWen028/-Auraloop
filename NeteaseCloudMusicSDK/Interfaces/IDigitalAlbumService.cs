using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing digital albums in the Netease Cloud Music API.
    /// </summary>
    public interface IDigitalAlbumService
    {
        /// <summary>
        /// Retrieves detailed information about a specific digital album.
        /// </summary>
        /// <param name="albumId">The unique identifier of the digital album.</param>
        /// <returns>An <see cref="ApiResponse"/> containing detailed information about the digital album.</returns>
        Task<ApiResponse> GetAlbumDetail(long albumId);

        /// <summary>
        /// Places an order for a specific digital album.
        /// </summary>
        /// <param name="requestModel">The model containing details for the album order.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the ordering process.</returns>
        Task<ApiResponse> OrderAlbum(DigitalAlbumOrderRequestModel requestModel);

        /// <summary>
        /// Retrieves a list of digital albums purchased by the user.
        /// </summary>
        /// <param name="requestModel">The model containing pagination parameters.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of purchased digital albums.</returns>
        Task<ApiResponse> GetPurchasedAlbums(PurchasedAlbumsRequestModel requestModel);

        /// <summary>
        /// Retrieves sales data for digital albums.
        /// </summary>
        /// <param name="albumIds">An array of album IDs for which sales data is to be fetched.</param>
        /// <returns>An <see cref="ApiResponse"/> containing sales statistics and information for digital albums.</returns>
        Task<ApiResponse> GetAlbumSales(long[] albumIds);
    }
}
