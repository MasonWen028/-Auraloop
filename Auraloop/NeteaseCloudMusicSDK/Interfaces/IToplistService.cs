
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    public interface IToplistService
    {
        Task<ApiResponse> Toplist();
        Task<ApiResponse> ToplistArtist();
        Task<ApiResponse> ToplistDetail();
    }
}