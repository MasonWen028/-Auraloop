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
    public class SearchService : ISearchService
    {
        private readonly NetEaseApiClient _client;

        public SearchService(NetEaseApiClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Search by keywords
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Search(SearchInputModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/search/get", requestModel);
                if (requestModel.Type == SearchTypes.Audio)
                {
                    option = new RequestOptions("/api/search/voice/get", new SearchAudioRequestModel
                    {
                        Keyword = requestModel.Keywords,
                        Limit = requestModel.Limit,
                        Offset = requestModel.Offset,
                    });
                }
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {

                throw new Exception($"Failed to search by keyword: {requestModel.Keywords}", ex);
            }
        }

        /// <summary>
        /// Fetch all suggested search keywords
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> SearchDefault()
        {
            try
            {
                var option = new RequestOptions("/api/search/defaultkeyword/get");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch all suggested search keywords", ex);
            }
        }

        /// <summary>
        /// Fetch the hot topics
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> SearchHot(int type = 1111)
        {
            try
            {
                var option = new RequestOptions("/api/search/hot", new { type });
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch the hot topics", ex);
            }
        }

        /// <summary>
        /// Fetch the list of hot topics
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> SearchHotDetail()
        {
            try
            {
                var option = new RequestOptions("/api/hotsearchlist/get", null, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch the hot topic list", ex);
            }
        }

        /// <summary>
        /// Match local music with cloud music
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> SearchMatch(SearchMatchRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/search/match/new", requestModel);
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed match local music with cloud music", ex);
            }
        }

        /// <summary>
        /// Search by multiple type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="keywords"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> SearchMultimatch(int type = 1, string keywords = "")
        {
            try
            {
                var option = new RequestOptions("/api/search/suggest/multimatch", new { type, s = keywords }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed match local music with cloud music", ex);
            }
        }

        /// <summary>
        /// Fetch suggested searching keywords
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> SearchSuggest(string keywords, string type = "mobile")
        {
            try
            {
                var option = new RequestOptions("/api/search/suggest/" + type, new { s = keywords }, "weapi");
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed match local music with cloud music", ex);
            }
        }
    }
}
