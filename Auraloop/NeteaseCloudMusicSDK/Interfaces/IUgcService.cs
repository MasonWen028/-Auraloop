
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    public interface IUgcService
    {
        Task<ApiResponse> UgcAlbumGet();
        Task<ApiResponse> UgcArtistGet();
        Task<ApiResponse> UgcArtistSearch(string keyword, int limit = 10);
        Task<ApiResponse> UgcDetail();
        Task<ApiResponse> UgcMvGet();
        Task<ApiResponse> UgcSongGet();
        Task<ApiResponse> UgcUserDevote();
    }
}