
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    public interface IVideoService
    {
        Task<ApiResponse> VideoCategoryList();
        Task<ApiResponse> VideoDetail(long id);
        Task<ApiResponse> VideoDetailInfo(long vid);
        Task<ApiResponse> VideoGroup();
        Task<ApiResponse> VideoGroupList();
        Task<ApiResponse> VideoSub();
        Task<ApiResponse> VideoTimelineAll();
        Task<ApiResponse> VideoTimelineRecommend();
        Task<ApiResponse> VideoUrl(long id, int r = 1080);
    }
}