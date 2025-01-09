using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class MusicianService : IMusicianService
    {
        private readonly NetEaseApiClient _client;

        public MusicianService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Claim Cloud beans for musician
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> ClaimCloudbeans(MusicianCloudbeanClaimRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/nmusician/workbench/mission/reward/obtain/new", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to claim cloud beans.", ex);
            }
        }

        /// <summary>
        /// Fetch the cloud beans count for current musician. need login, means need cookie has field "MUSIC_U"
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> GetCloudbeanBalance()
        {
            try
            {
                var options = new RequestOptions($"/api/cloudbean/get", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch cloud beans count.", ex);
            }
        }

        /// <summary>
        /// Fetch the statistics for musician, need login
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> GetDataOverview()
        {
            try
            {
                var options = new RequestOptions($"/api/creator/musician/statistic/data/overview/get", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch cloud beans count.", ex);
            }
        }

        public Task<ApiResponse> GetNewTasks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetch current play trend for current musician
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> GetPlayTrend(MusicianPlayTrendRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/creator/musician/play/count/statistic/data/trend/get", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch play trend for current musician.", ex);
            }
        }

        /// <summary>
        /// Fetch task lists for musician
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> GetTasks()
        {
            try
            {
                var options = new RequestOptions($"/api/nmusician/workbench/mission/cycle/list", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch task list for musician.", ex);
            }
        }

        /// <summary>
        /// Daily sign in for musician
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> SignIn()
        {
            try
            {
                var options = new RequestOptions($"/api/creator/user/access", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch play trend for current musician.", ex);
            }
        }
    }
}
