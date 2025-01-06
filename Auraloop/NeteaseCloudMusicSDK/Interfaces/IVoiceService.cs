using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    public interface IVoiceService
    {
        Task<ApiResponse> VoiceDelete();
        Task<ApiResponse> VoiceDetail();
        Task<ApiResponse> VoiceLyric();
        Task<ApiResponse> VoiceUpload();
    }
}