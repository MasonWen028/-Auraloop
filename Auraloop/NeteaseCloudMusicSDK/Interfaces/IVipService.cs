using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    public interface IVipService
    {
        Task<ApiResponse> VipGrowthpoint();
        Task<ApiResponse> VipGrowthpointDetails();
        Task<ApiResponse> VipGrowthpointGet();
        Task<ApiResponse> VipInfo();
        Task<ApiResponse> VipInfoV2();
        Task<ApiResponse> VipTasks();
        Task<ApiResponse> VipTimemachine();
    }
}