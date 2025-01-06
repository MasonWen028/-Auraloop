using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for handling cellphone-related operations in the Netease Cloud Music API.
    /// </summary>
    public interface ICellphoneService
    {
        /// <summary>
        /// Checks the existence of a cellphone number in the system.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating whether the cellphone number exists in the system.</returns>
        Task<ApiResponse> CellphoneExistenceCheck();
    }
}
