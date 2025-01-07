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
        /// <param name="username">
        /// step 1: get a random deviceId, like "AA9955F5FE37BA7EAF48F8EF0C9966B28293CC8D6415CCD93549"
        /// step 2: encode it by CryptoUtils.CloudMusicDllEncodeId(deviceId);
        /// step 3: var strToBase64 = deviceId + encoded deviceid(from step 2)
        /// step 4: convert strToBase64 to base64,username = strToBase64
        /// </param>
        /// <returns></returns>
        Task<ApiResponse> RegisterAnonymous(string username);

        /// <summary>
        /// Registers a user account using a cellphone number.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the cellphone registration.</returns>
        Task<ApiResponse> RegisterCellphone(RegisterCellphoneRequestModel requestModel);
    }
}
