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
    public class MvService : IMvService
    {
        private readonly NetEaseApiClient _client;

        public MvService(NetEaseApiClient client)
        {
            _client = client;
        }


        /// <summary>
        /// Fetch mv details by MV ID
        /// </summary>
        /// <param name="mvid"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Detail(long mvid)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/mv/detail", new { id = mvid }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch mv detail.", ex);
            }
        }

        /// <summary>
        /// Fetch the comment and like count
        /// </summary>
        /// <param name="mvid"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> DetailInfo(long mvid)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/mv/detail", new { threadid = "R_MV_5_" + mvid, composeliked = true }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch mv detail.", ex);
            }
        }

        /// <summary>
        /// Fetch the recommended list by Netease
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> ExclusiveRcmd(int limit = 30, int offset = 0)
        {
            try
            {
                var options = new RequestOptions($"/api/mv/exclusive/rcmd", new { limit , offset});
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch mv detail.", ex);
            }
        }

        /// <summary>
        /// Fetch latest mv
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> First(MvFirstRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/mv/first", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch latest mv.", ex);
            }
        }

        /// <summary>
        /// Fetch all MVs by pagination
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> GetAll(MvAllRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/mv/all", requestModel);
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch all MVs.", ex);
            }
        }

        /// <summary>
        /// Fetch all favorited MVs by pagination
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Sublist(int limit = 50, int offset = 0)
        {
            try
            {
                var options = new RequestOptions($"/api/mv/all", new { limit, offset, total = true }, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch all favorited MVs.", ex);
            }
        }

        /// <summary>
        /// Sub or Unsub a MV
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Subscribe(MvSubscribeRequestModel requestModel)
        {
            string likeOrNot = requestModel.Operation == 1 ? "sub" : "ubsub";
            try
            {
                var options = new RequestOptions($"/api/mv/all", new { mvId = requestModel.MvId, mvIds = $"[{requestModel.MvId}]"}, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to {likeOrNot} MVs.", ex);
            }
        }

        /// <summary>
        /// Fetch url for mv
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> Url(MvUrlRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/song/enhance/play/mv/url", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch url for MV with ID: {requestModel.Id}.", ex);
            }
        }
    }
}
