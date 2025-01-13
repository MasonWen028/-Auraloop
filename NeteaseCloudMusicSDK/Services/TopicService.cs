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
    public class TopicService : ITopicService
    {
        private readonly NetEaseApiClient _client;

        public TopicService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Fetch details of topic
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Detail(TopicDetailRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/act/detail", requestModel, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch details of topic with ID: {requestModel.Actid}", ex);
            }
        }


        /// <summary>
        /// Fetch details of hot topic
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> DetailEventHot(TopicDetailRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/act/event/hot", requestModel, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch details of hot topic with ID: {requestModel.Actid}", ex);
            }
        }

        //TODO
        public Task<ApiResponse> Hot()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetch the topics has been favorited
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Sublist(TopicSublistRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/topic/sublist", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch favorited topics", ex);
            }
        }
    }
}
