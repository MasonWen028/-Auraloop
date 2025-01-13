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
        /// Check the status of qr code key
        /// </summary>
        /// <param name="qrCode"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<ApiResponse> CheckQrCodeStatus(string qrCode);
    }
}
