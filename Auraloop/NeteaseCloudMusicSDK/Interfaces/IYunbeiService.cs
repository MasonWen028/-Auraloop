using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    public interface IYunbeiService
    {
        Task<ApiResponse> Yunbei();
        Task<ApiResponse> YunbeiExpense();
        Task<ApiResponse> YunbeiInfo();
        Task<ApiResponse> YunbeiRcmdSong();
        Task<ApiResponse> YunbeiRcmdSongHistory();
        Task<ApiResponse> YunbeiReceipt();
        Task<ApiResponse> YunbeiSign();
        Task<ApiResponse> YunbeiTasks();
        Task<ApiResponse> YunbeiTasksTodo();
        Task<ApiResponse> YunbeiTaskFinish();
        Task<ApiResponse> YunbeiToday();
    }
}