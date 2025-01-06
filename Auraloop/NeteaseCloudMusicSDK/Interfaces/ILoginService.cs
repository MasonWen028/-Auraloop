using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing login and authentication in the Netease Cloud Music API.
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Logs in using default credentials or session cookies.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the login attempt.</returns>
        Task<ApiResponse> Login();

        /// <summary>
        /// Logs in using a cellphone number and verification details.
        /// </summary>
        /// <param name="requestModel">The request model containing the cellphone number and password or verification code.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the login attempt.</returns>
        Task<ApiResponse> LoginCellphone(LoginCellphoneRequestModel requestModel);

        /// <summary>
        /// Checks the status of a QR code login attempt.
        /// </summary>
        /// <param name="key">The unique key associated with the QR code.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating whether the QR code login is successful, pending, or failed.</returns>
        Task<ApiResponse> LoginQrCheck(string key);

        /// <summary>
        /// Generates a QR code URL for login purposes.
        /// </summary>
        /// <param name="key">The unique key associated with the QR code.</param>
        /// <param name="qrimg">If true, includes the QR image in the response. Default is false.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the QR code URL or image.</returns>
        Task<ApiResponse> GenerateQrUrl(string key, bool qrimg = false);

        /// <summary>
        /// Generates a unique key for QR code login.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the generated QR code key.</returns>
        Task<ApiResponse> LoginQrKey();

        /// <summary>
        /// Refreshes the current login session to extend its validity.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the session refresh.</returns>
        Task<ApiResponse> LoginRefresh();

        /// <summary>
        /// Retrieves the status of the current login session.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the login session status, such as active or expired.</returns>
        Task<ApiResponse> LoginStatus();


        /// <summary>
        /// Logs out the current user and terminates the session.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the logout operation.</returns>
        Task<ApiResponse> Logout();
    }
}
