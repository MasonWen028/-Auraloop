using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Request.yunbei;
using NeteaseCloudMusicSDK.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class YunbeiService : IYunbeiService
    {
        private readonly NetEaseApiClient _client;

        public YunbeiService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> CompleteTask(YunbeiTaskFinishRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/usertool/task/point/receive", requestModel, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to complete task with model: {JsonConvert.SerializeObject(requestModel)}", ex);
            }
        }

        /// <inheritdoc/>
        public Task<ApiResponse> DailySignin()
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<ApiResponse> ExpenseHistory(YunbeiExpenseRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Task<ApiResponse> GetPoints()
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public async Task<ApiResponse> Info()
        {
            try
            {
                var option = new RequestOptions("/api/v1/user/info", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch basic information", ex);
            }
        }

        ///<inheritdoc/>
        public async Task<ApiResponse> Receipt(YunbeiReceiptRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/point/receipt", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch receipt with model : {JsonConvert.SerializeObject(requestModel)}", ex);
            }
        }

        ///<inheritdoc/>
        public async Task<ApiResponse> RecommendedSongHistory(YunbeiRcmdSongHistoryRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/yunbei/rcmd/song/history/list", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch recommended songs history with model : {JsonConvert.SerializeObject(requestModel)}", ex);
            }
        }

        ///<inheritdoc/>
        public async Task<ApiResponse> RecommendedSongs(YunbeiRecommendedSongsRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/yunbei/rcmd/song/submit", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch recommended songs with model : {JsonConvert.SerializeObject(requestModel)}", ex);
            }
        }

        /// <summary>
        /// Fetch the task list
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Tasks()
        {
            try
            {
                var option = new RequestOptions("/api/usertool/task/list/all", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the task list", ex);
            }
        }


        /// <summary>
        /// Fetch the today content for current user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Today()
        {
            try
            {
                var option = new RequestOptions("/api/point/today/get", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the today content for current user", ex);
            }
        }

        /// <summary>
        /// Fetch the todo task list
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> TodoTasks()
        {
            try
            {
                var option = new RequestOptions("/api/usertool/task/todo/query", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the task list", ex);
            }
        }
    }
}
