using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class MsgService : IMsgService
    {
        private readonly NetEaseApiClient _client;

        public MsgService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// unknown interface TODO 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Comments(MsgCommentsRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/user/comments/{requestModel.UserId}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album subscription list.", ex);
            }
        }

        /// <summary>
        /// Fetch the messages forwarded
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Forwards(MsgForwardsRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/forwards/get", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album subscription list.", ex);
            }
        }

        /// <summary>
        /// Fetch notices send to current user
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Notices(MsgNoticesRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/msg/notices", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album subscription list.", ex);
            }
        }

        /// <summary>
        /// Fetch the private message history
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> PrivateHistory(MsgPrivateHistoryRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/msg/private/history", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album subscription list.", ex);
            }
        }


        /// <summary>
        /// Fetch private messages
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> PrivateMessages(MsgPrivateRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/msg/private/users", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album subscription list.", ex);
            }
        }

        /// <summary>
        /// Fetch contact recent in touch
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> RecentContacts()
        {
            try
            {
                var options = new RequestOptions($"/api/msg/recentcontact/get", null, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get album subscription list.", ex);
            }
        }
    }
}
