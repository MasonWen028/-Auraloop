
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    public interface ITopService
    {
        Task<ApiResponse> TopAlbum();
        Task<ApiResponse> TopArtists(MusicRegion areaId = MusicRegion.All, int limit = 100, int offset = 0);
        Task<ApiResponse> TopList();
        Task<ApiResponse> TopMv();
        Task<ApiResponse> TopPlaylist(TopPlaylistHighqualityRequestModel requestModel);
        Task<ApiResponse> TopPlaylistHighquality(TopPlaylistHighqualityRequestModel requestModel);
        Task<ApiResponse> TopSong();
        Task<ApiResponse> ToplistArtist();
        Task<ApiResponse> ToplistDetail();
    }
}