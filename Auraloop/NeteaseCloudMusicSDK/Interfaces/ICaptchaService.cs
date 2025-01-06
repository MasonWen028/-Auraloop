using System;
using System.Numerics;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for handling captcha-related operations in the Netease Cloud Music API.
    /// </summary>
    public interface ICaptchaService
    {
        /// <summary>
        /// Sends a captcha code to the specified phone number.
        /// </summary>
        /// <param name="Phone">The phone number to which the captcha will be sent.</param>
        /// <param name="Ctcode">The country code for the phone number. Default is 86 (China).</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the operation.</returns>
        Task<ApiResponse> CaptchaSent(long Phone, int Ctcode = 86);

        /// <summary>
        /// Verifies the captcha code for a specified phone number.
        /// </summary>
        /// <param name="Phone">The phone number associated with the captcha.</param>
        /// <param name="Captcha">The captcha code entered by the user.</param>
        /// <param name="Ctcode">The country code for the phone number. Default is 86 (China).</param>
        /// <returns>An <see cref="ApiResponse"/> indicating whether the captcha verification was successful.</returns>
        Task<ApiResponse> CaptchaVerify(long Phone, int Captcha, int Ctcode = 86);
    }
}
