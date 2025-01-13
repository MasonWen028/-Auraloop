using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Configurations;
using NeteaseCloudMusicSDK.Models.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class CommentService: ICommentService
    {
        private readonly NetEaseApiClient _client;

        public CommentService(NetEaseApiClient client)
        {
            _client = client;
        }

        RemoteServerConfig cfg = RemoteServerConfig.Instance;

        /// <inheritdoc/>
        public async Task<ApiResponse> GetAlbumComments(CommentRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/resource/comments/R_AL_3_{requestModel.Id}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get album comments with ID '{requestModel.Id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetDjComments(CommentRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/resource/comments/A_DJ_1_{requestModel.Id}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get album comments with ID '{requestModel.Id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetEventComments(CommentRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/resource/comments/A_EV_2_{requestModel.Id}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get event comments with ID '{requestModel.Id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetFloorComments(CommentFloorRequestModel requestModel)
        {
            try
            {
                requestModel.ThreadId = "A_DR_14_" + requestModel.Id;
                var options = new RequestOptions($"/api/resource/comment/floor/get", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get floor comments with ID '{requestModel.Id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetHotComments(CommentRequestModel requestModel)
        {
            try
            {
                var options = new RequestOptions($"/api/v1/resource/comments/A_PL_0_{requestModel.Id}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get album comments with ID '{requestModel.Id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetHugList(CommentHugListRequestModel requestModel)
        {
            try
            {
                requestModel.ThreadId = "R_SO_4_" + requestModel.CommentId;
                var options = new RequestOptions($"/api/v2/resource/comments/hug/list", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get hug lits  with ID '{requestModel.CommentId}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetMusicComments(CommentRequestModel requestModel)
        {
            try
            {
              
                var options = new RequestOptions($"/api/v1/resource/comments/R_SO_4_{requestModel.Id}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get music comments  with ID '{requestModel.Id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetMvComments(CommentRequestModel requestModel)
        {
            try
            {

                var options = new RequestOptions($"/api/v1/resource/comments/R_MV_5_{requestModel.Id}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get mv comments  with ID '{requestModel.Id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetNewComments(CommentNewRequestModel requestModel)
        {
            var threadId = $"{requestModel.Type.ToString().ToLower()}{requestModel.Id}";

            // Adjust SortType if it is 1
            if (requestModel.SortType == 1)
            {
                requestModel.SortType = 99; // Default to recommendation sort
            }

            // Compute cursor based on sort type
            string cursor = string.Empty;
            switch (requestModel.SortType)
            {
                case 99: // By recommendation
                    cursor = ((requestModel.PageNo - 1) * requestModel.PageSize).ToString();
                    break;
                case 2: // By popularity
                    cursor = $"normalHot#{(requestModel.PageNo - 1) * requestModel.PageSize}";
                    break;
                case 3: // By time
                    cursor = requestModel.Cursor ?? "0";
                    break;
                default:
                    break;
            }

            requestModel.ThreadId = threadId;
            requestModel.Cursor = cursor;

            try
            {
                var options = new RequestOptions($"/api/v2/resource/comments", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get new comments  with ID '{requestModel.Id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetPlaylistComments(CommentRequestModel requestModel)
        {
            try
            {

                var options = new RequestOptions($"/api/v1/resource/comments/A_PL_0_{requestModel.Id}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get playlist comments  with ID '{requestModel.Id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> GetVideoComments(CommentRequestModel requestModel)
        {
            try
            {

                var options = new RequestOptions($"/api/v1/resource/comments/R_VI_62_{requestModel.Id}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get playlist comments  with ID '{requestModel.Id}'.", ex);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiResponse> LikeComment(CommentLikeRequestModel requestModel)
        {
            try
            {

                requestModel.threadId = cfg.ResourceTypeMap[requestModel.Type.ToString()] + requestModel.Id;
                string likeOrNot = requestModel.Operation == 1 ? "like" : "unlike";
                var options = new RequestOptions($"/api/v1/comment/{likeOrNot}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get playlist comments  with ID '{requestModel.Id}'.", ex);
            }
        }

        public async Task<ApiResponse> ManageComment(CommentManageRequestModel requestModel)
        {
            try
            {
                int t = -1;
                ProcessComment(requestModel, out t);

                var options = new RequestOptions($"/api/resource/comments/{t}", requestModel, "weapi");
                return await _client.HandleRequestAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get playlist comments  with ID '{requestModel.CommentId}'.", ex);
            }
            
        }

        private void ProcessComment(CommentManageRequestModel model, out int t)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "The comment model cannot be null.");
            }

            // Validate the action type
            if (string.IsNullOrEmpty(model.Action))
            {
                throw new ArgumentException("Action type is required.");
            }

            // Process based on the action type
            switch (model.Action.ToLower())
            {
                case "add":
                    if (string.IsNullOrEmpty(model.Content))
                    {
                        throw new ArgumentException("Content is required for the 'add' action.");
                    }
                    t = 0;
                    Console.WriteLine($"Adding comment: {model.Content} to thread {model.ThreadId}");
                    break;

                case "delete":
                    if (model.CommentId == null)
                    {
                        throw new ArgumentException("CommentId is required for the 'delete' action.");
                    }
                    t = 1;
                    Console.WriteLine($"Deleting comment with ID {model.CommentId} from thread {model.ThreadId}");
                    break;

                case "reply":
                    if (string.IsNullOrEmpty(model.Content))
                    {
                        throw new ArgumentException("Content is required for the 'reply' action.");
                    }

                    if (model.CommentId == null)
                    {
                        throw new ArgumentException("CommentId is required for the 'reply' action.");
                    }
                    t = 2;
                    Console.WriteLine($"Replying to comment with ID {model.CommentId} on thread {model.ThreadId}. Content: {model.Content}");
                    break;

                default:
                    t = -1;
                    throw new ArgumentException($"Unknown action type: {model.Action}");
            }

            // Log the resource type for tracking
            Console.WriteLine($"Action performed on resource of type: {model.Type}");
        }
    }
}
