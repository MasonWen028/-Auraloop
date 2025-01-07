using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing QR code-based verification in the Netease Cloud Music API.
    /// </summary>
    public interface IVerifyService
    {
        /// <summary>
        /// Generates a QR code for user verification.
        /// </summary>
        /// <param name="requestModel">The model containing parameters required to generate the QR code.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the QR code, its URL, and a base64-encoded image.</returns>
        Task<ApiResponse> GetQrCode(VerifyGetQrRequestModel requestModel);

        /// <summary>
        /// Checks the status of a previously generated QR code.
        /// </summary>
        /// <param name="qrCode">The QR code to check the status for.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the status of the QR code.</returns>
        Task<ApiResponse> CheckQrCodeStatus(string qrCode);
    }
}
