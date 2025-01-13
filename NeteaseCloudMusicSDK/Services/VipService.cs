using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class VipService : IVipService
    {
        private readonly NetEaseApiClient _client;

        public VipService(NetEaseApiClient client)
        {
            _client = client;
        }


        /// <summary>
        /// Fetch curren VIP point 
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse> GrowthPoint()
        {
            try
            {
                var option = new RequestOptions("/api/vipnewcenter/app/level/growhpoint/basic", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the VIP point", ex);
            }
        }

        /// <summary>
        /// Fetch the record of claiming VIP point
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> GrowthPointDetails(VipGrowthPointDetailsRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/vipnewcenter/app/level/growth/details", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the record of claiming VIP points with model: {JsonConvert.SerializeObject(requestModel)}", ex);
            }
        }

        /// <summary>
        /// Claim the point of VIP
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> GrowthPointGet(VipGrowthpointGetRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/vipnewcenter/app/level/task/reward/get", requestModel, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to claim VIP point", ex);
            }
        }

        /// <summary>
        /// Fetch information of VIP user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Info(long? userId = null)
        {
            try
            {

                var option = new RequestOptions("/api/music-vip-membership/front/vip/info", new { userId = userId.HasValue? userId.ToString() : "" } ,"weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch information of VIP user with ID: {userId}", ex);
            }
        }

        /// <summary>
        ///  Fetch information of VIP user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> InfoV2(long? userId = null)
        {
            try
            {

                var option = new RequestOptions("/api/music-vip-membership/client/vip/info", new { userId = userId.HasValue ? userId.ToString() : "" }, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch information of VIP user with ID: {userId}", ex);
            }
        }

        /// <summary>
        /// Fetch task list for VIP
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Tasks()
        {
            try
            {
                var option = new RequestOptions("/api/vipnewcenter/app/level/task/list", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch task list for VIP", ex);
            }
        }


        /// <summary>
        /// Fetch the week flow of time machine
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> TimeMachine(VipTimeMachineRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/vipmusic/newrecord/weekflow", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the week flow of time machine with model : {JsonConvert.SerializeObject(requestModel)}", ex);
            }
        }
    }
}
