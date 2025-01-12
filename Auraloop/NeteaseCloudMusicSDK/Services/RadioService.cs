using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class RadioService : IRadioService
    {
        private readonly NetEaseApiClient _client;

        public RadioService(NetEaseApiClient client)
        {
            _client = client;
        }


        /// <summary>
        /// Fetch the banner of Radio
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Banner()
        {
            try
            {
                var option = new RequestOptions("/api/djradio/banner/get", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch the banner of radios", ex);
            }
        }

        /// <summary>
        /// Fetch the categories of none hot radio
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> CategoryExcludeHot()
        {
            try
            {
                var option = new RequestOptions("/api/djradio/category/excludehot", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch the categories of none hot radios", ex);
            }
        }

        /// <summary>
        /// Fetch the category list for radios
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> CategoryList()
        {
            try
            {
                var option = new RequestOptions("/api/djradio/category/get", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch the categories of none hot radios", ex);
            }
        }

        /// <summary>
        /// Fetch the recommended categories of raiod
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> CategoryRecommend()
        {
            try
            {
                var option = new RequestOptions("/api/djradio/category/recommend", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch the recommended categories of raiod", ex);
            }
        }

        /// <summary>
        /// Fetch the details of Radio
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Detail(long rid)
        {
            try
            {
                var option = new RequestOptions("/api/djradio/v2/get", new { id = rid }, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch the details of Radio", ex);
            }
        }


        /// <summary>
        /// Fetch the ranking list for Radios
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> GetRadioRankings(RadioRankingRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/expert/worksdata/works/top/get", requestModel);

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch the ranking list for Radios", ex);
            }
        }


        /// <summary>
        /// Fetch hot list of raidos
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Hot(RadioHotRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/djradio/hot/v1", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch the hot list for Radios", ex);
            }
        }


        /// <summary>
        /// Fetch hot list of target categoried radios
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> HotStations(RadioHotStationsRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/djradio/hot", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to hot list of target categoried radios", ex);
            }
        }


        //TODO 
        public Task<ApiResponse> Like(RadioLikeRequestModel requestModel)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Fetch the list of Pay-per-view radio station required
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> PayGift(RadioPayGiftRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/djradio/home/paygift/list", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch the list of Pay-per-view radio station required", ex);
            }
        }

        /// <summary>
        /// Fetch the recommended radio list
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> PersonalizedRecommend(int limit = 6)
        {
            try
            {
                var option = new RequestOptions("/api/djradio/personalize/rcmd", new { limit }, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch the recommended radio list", ex);
            }
        }

        /// <summary>
        /// Fetch the details of propgram with ID: {id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> ProgramDetail(long id)
        {
            try
            {
                var option = new RequestOptions("/api/djradio/personalize/rcmd", new { id }, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the details of propgram with ID: {id}", ex);
            }
        }


        /// <summary>
        /// Fetch the list of program of radio with ID: {requestModel.RadioId}
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Programs(RadioProgramsRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/dj/program/byradio", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the list of program of radio with ID: {requestModel.RadioId}", ex);
            }
        }

        /// <summary>
        /// Fetch the ranked list of program of Radio
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> ProgramToplist(RadioProgramToplistRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/program/toplist/v1", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed  the ranked list of program of Radio", ex);
            }
        }

        /// <summary>
        /// Fetch the ranked program list for radio in past 24 hours 
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> ProgramToplistByHour(int limit = 100)
        {
            try
            {
                var option = new RequestOptions("/api/djprogram/toplist/hours", new { limit }, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed the ranked program list for radio in past 24 hours ", ex);
            }
        }

        /// <summary>
        /// Fetch the essential selected radio list
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Recommend()
        {
            try
            {
                var option = new RequestOptions("/api/djradio/recommend/v1", null, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed fetch the essential selected radio list", ex);
            }
        }

        /// <summary>
        /// Fetch radio list by category/type
        /// </summary>
        /// <param name="cateId">有声书 10001
        ///    知识技能 453050
        ///商业财经 453051
        ///人文历史 11
        ///外语世界 13
        ///亲子宝贝 14
        ///创作|翻唱 2001
        ///音乐故事 2
        ///3D|电子 10002
        ///相声曲艺 8
        ///情感调频 3
        ///美文读物 6
        ///脱口秀 5
        ///广播剧 7
        ///二次元 3001
        ///明星做主播 1
        ///娱乐|影视 4
        ///科技科学 453052
        ///校园|教育 4001
        ///旅途|城市 12</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> RecommendByType(long cateId)
        {
            try
            {
                var option = new RequestOptions("/api/djradio/recommend", new { cateId }, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed fetch the essential selected radio list", ex);
            }
        }

        /// <summary>
        /// Fetch the user list who subscribed radio with Id: {requestModel.RadioId}
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Subscribers(RadioSubscribersRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/djradio/subscriber", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed fetch the user list who subscribed radio with Id: {requestModel.RadioId}", ex);
            }
        }

        /// <summary>
        /// Sub or Unsub a radio
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Subscription(RadioSubscriptionRequestModel requestModel)
        {
            string subOrNot = requestModel.SubscriptionType == 1 ? "sub" : "unsub";
            try
            {
                var option = new RequestOptions("/api/djradio/" + subOrNot, new { id = requestModel.RadioId }, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed {subOrNot} radio with Id: {requestModel.RadioId}", ex);
            }
        }

        /// <summary>
        /// Fetch the list of subscribed radio, need login.
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Subscriptions(RadioSubscriptionsRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/djradio/get/subed", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed fetch the list of subscribed radio", ex);
            }
        }

        /// <summary>
        /// Fetch the list of radio prefered today
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> TodayPreferred(int page = 0)
        {
            try
            {
                var option = new RequestOptions("/api/djradio/home/today/perfered", new { page }, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed fetch the list of radio prefered today", ex);
            }
        }

        /// <summary>
        /// Fecth the top list of new / hot radio
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Toplist(RadioToplistRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/djradio/toplist", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed fetch the list of radio prefered today", ex);
            }
        }

        /// <summary>
        /// Throw a song in a list into trash bin, means nerver gonna listen to it again.
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> TrashSong(RadioTrashSongRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/radio/trash/add", requestModel, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed throw a song in a list into trash bin", ex);
            }
        }
    }
}
