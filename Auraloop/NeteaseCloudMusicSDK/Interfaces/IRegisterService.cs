using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for user registration in the Netease Cloud Music API.
    /// </summary>
    public interface IRegisterService
    {
        /// <summary>
        /// Registers an anonymous user account for temporary use.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the anonymous registration.</returns>
        Task<ApiResponse> RegisterAnonymous();

        /// <summary>
        /// Registers a user account using a cellphone number.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the cellphone registration.</returns>
        Task<ApiResponse> RegisterCellphone();
    }
}
