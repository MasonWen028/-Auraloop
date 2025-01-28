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
    public class SongService : ISongService
    {
        private readonly NetEaseApiClient _client;

        public SongService(NetEaseApiClient client)
        {
            _client = client;
        }


        /// <summary>
        /// Fetch the chorus time of a song
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Chorus(long id)
        {
            try
            {
                var option = new RequestOptions("/api/song/chorus", new { ids = $"[{id}]" });
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch chorus time with ID: {id}", ex);
            }
        }

        /// <summary>
        /// Fetch details of a song
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Detail(SongDetailRequestModel requestModel)
        {
            try
            {
                List<object> clist = new List<object>();
                for (int i = 0; i < requestModel.Ids.Length; i++)
                {
                    clist.Add(new { id = requestModel.Ids[i] });
                }
                string c = JsonConvert.SerializeObject(clist);

                var option = new RequestOptions("/api/v3/song/detail", new { c }, "weapi");

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch details of song with ID: {requestModel.Ids}", ex);
            }
        }

        /// <summary>
        /// Fetch the download record
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Downlist(PaginatedRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/member/song/downlist", requestModel);

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch download record", ex);
            }
        }

        /// <summary>
        /// Fetch download url for certain song by certain bitrate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bitrate"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> DownloadUrl(long id, int bitrate = 999000)
        {
            try
            {
                var option = new RequestOptions("/api/song/enhance/download/url", new { id, bitrate });
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch download url with ID: {id}", ex);
            }
        }

        /// <summary>
        /// Fetch download url
        /// </summary>
        /// <param name="id"> song id</param>
        /// <param name="level"> standard, exhigh, lossless, hires, jyeffect, sky, jymaster</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> DownloadUrlV1(long id, string level = "exhigh")
        {
            try
            {
                var option = new RequestOptions("/api/song/enhance/download/url/v1", new { id, immerseType = "c51", level });
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch download url with ID: {id}", ex);
            }
        }


        /// <summary>
        /// Fetch the dynamic cover of a song
        /// </summary>
        /// <param name="id">song id</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> DynamicCover(long id)
        {
            try
            {
                var option = new RequestOptions("/api/songplay/dynamic-cover", new { songId = id });

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the dynamic cover of song with ID: {id}", ex);
            }
        }

        /// <summary>
        /// Check out songs liked or not
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApiResponse> LikeCheck(long[] ids)
        {
            try
            {
                var option = new RequestOptions("/api/song/like/check", new { trackIds = ids });

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to check out songs like or not with IDs: {JsonConvert.SerializeObject(ids)}", ex);
            }
        }

        /// <summary>
        /// Fecth the download history by month
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Monthdownlist(PaginatedRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/member/song/monthdownlist", requestModel);

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the download history", ex);
            }
        }

        /// <summary>
        /// Fetch the quality details of song
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> MusicDetail(long id)
        {
            try
            {
                var option = new RequestOptions("/api/song/music/detail/get", new { songId = id });
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the quality details of song with ID: {id}", ex);
            }
        }

        /// <summary>
        /// Modify the order of songs in a playlist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> OrderUpdate(SongOrderUpdateRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/playlist/manipulate/tracks", requestModel);
                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update the order of songs in a playlist {requestModel.PlaylistId}, song id {requestModel.TrackIds}", ex);
            }
        }


        /// <summary>
        /// Fetch the url of song for playing
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Url(SongUrlRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/song/enhance/player/url", new { ids = new long[] { requestModel.id }, br = requestModel.br });

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the url of song with ID: {JsonConvert.SerializeObject(requestModel.id)}", ex);
            }
        }

        /// <summary>
        /// Fetch the url of song for playing
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> UrlV1(SongUrlV1RequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/song/enhance/player/url", requestModel);

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the url of song with ID: {JsonConvert.SerializeObject(requestModel.Ids)}", ex);
            }
        }

        /// <summary>
        /// Fetch the basic information of current song
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> WikiSummary(long id)
        {
            try
            {
                var option = new RequestOptions("/api/song/play/about/block/page", new { songId = id });

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the basic information of song with ID: {id}", ex);
            }
        }
    }
}
