using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing music sheets, including listing and previewing, in the Netease Cloud Music API.
    /// </summary>
    public interface ISheetService
    {
        /// <summary>
        /// Retrieves a list of music sheets with optional test variations.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for listing music sheets.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the list of music sheets.</returns>
        Task<ApiResponse> SheetList(SheetListRequestModel requestModel);

        /// <summary>
        /// Retrieves preview information for a specific music sheet.
        /// </summary>
        /// <param name="requestModel">The model containing parameters for the sheet preview.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the music sheet preview information.</returns>
        Task<ApiResponse> SheetPreview(SheetPreviewRequestModel requestModel);
    }
}
