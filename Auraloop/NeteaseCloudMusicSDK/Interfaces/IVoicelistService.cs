using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    public interface IVoicelistService
    {
        Task<ApiResponse> VoicelistDetail();
        Task<ApiResponse> VoicelistList();
        Task<ApiResponse> VoicelistListSearch();
        Task<ApiResponse> VoicelistSearch();
        Task<ApiResponse> VoicelistTrans();
    }
}