using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class VideoService : IVideoService
    {
        private readonly NetEaseApiClient _client;

        public VideoService(NetEaseApiClient client)
        {
            _client = client;
        }


        /// <summary>
        /// Fetch the categories of videos
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> CategoryList(VideoCategoryListRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/cloudvideo/category/list", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fecth the categories of videos with model: {JsonConvert.SerializeObject(requestModel)}", ex);
            }
        }


        /// <summary>
        /// Fetch details of a video
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Detail(long id)
        {
            try
            {
                var option = new RequestOptions("/api/cloudvideo/v1/video/detail", new { id }, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch details of video with ID: {id}", ex);
            }
        }

        /// <summary>
        /// Fetch detailed information of a video
        /// </summary>
        /// <param name="vid"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> DetailInfo(long vid)
        {
            try
            {
                var option = new RequestOptions("/api/comment/commentthread/info", new { threadid = $"R_VI_62_{vid}", composeliked = true }, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch detailed information of video with ID: {vid}", ex);
            }
        }

        /// <summary>
        /// Fetch the videos under specific group ID
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Group(VideoGroupRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/videotimeline/videogroup/otherclient/get", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the videos under group ID: {requestModel.GroupId}", ex);
            }
        }

        /// <summary>
        /// Fetch group list
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> GroupList()
        {
            try
            {
                var option = new RequestOptions("/api/cloudvideo/group/list", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch group list", ex);
            }
        }

        /// <summary>
        /// Sub or unsub a video
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subscribe"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Sub(long id, bool subscribe)
        {
            string subOrNot = subscribe ? "sub" : "unsub";
            try
            {
                var option = new RequestOptions($"/api/cloudvideo/video/{subOrNot}", new { id }, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to {subOrNot} video with ID: {id}", ex);
            }
        }

        /// <summary>
        /// Fetch all video list
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> TimelineAll(VideoTimelineRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/videotimeline/otherclient/get", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch all video list", ex);
            }
        }


        /// <summary>
        /// Fetch videos recommended
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> TimelineRecommend(VideoTimelineRecommendRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/videotimeline/get", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch video list by model {JsonConvert.SerializeObject(requestModel)}", ex);
            }
        }


        /// <summary>
        /// Fetch the play url
        /// </summary>
        /// <param name="id">video id</param>
        /// <param name="resolution"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Url(long id, int resolution = 1080)
        {
            try
            {
                var option = new RequestOptions("/api/cloudvideo/playurl", new { ids = $"[{id}]", resolution });

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch play url of video with ID: {id}", ex);
            }
        }
    }
}
