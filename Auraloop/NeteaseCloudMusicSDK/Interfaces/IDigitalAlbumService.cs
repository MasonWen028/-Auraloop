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
        /// <returns>An <see cref="ApiResponse"/> containing detailed information about the digital album.</returns>
        Task<ApiResponse> DigitalalbumDetail();

        /// <summary>
        /// Places an order for a specific digital album.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the ordering process.</returns>
        Task<ApiResponse> DigitalalbumOrdering();

        /// <summary>
        /// Retrieves a list of digital albums purchased by the user.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of purchased digital albums.</returns>
        Task<ApiResponse> DigitalalbumPurchased();

        /// <summary>
        /// Retrieves sales data for digital albums.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing sales statistics and information for digital albums.</returns>
        Task<ApiResponse> DigitalalbumSales();
    }
}
