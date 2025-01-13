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
    public class VoiceService : IVoiceService
    {
        private readonly NetEaseApiClient _client;


        public VoiceService(NetEaseApiClient client)
        {
            _client = client;
        }


        /// <summary>
        /// Remove voices by id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Delete(long[] ids)
        {
            try
            {
                var option = new RequestOptions("/api/content/voice/delete", new { ids });

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to remove voice by ids: {JsonConvert.SerializeObject(ids)}", ex);
            }
        }


        /// <summary>
        /// Fetch details of a voice
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Detail(long id)
        {
            try
            {
                var option = new RequestOptions("/api/voice/workbench/voice/detail", new { id });

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch details of a voice with ID: {id}", ex);
            }
        }

        /// <summary>
        /// Fetch voice list by list Id
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> List(VoiceListRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/voice/workbench/voices/by/voicelist", requestModel);

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch voice list with list ID: {requestModel.VoiceListId}", ex);
            }
        }


        /// <summary>
        /// Fetch the details of voice list by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> ListDetail(long id)
        {
            try
            {
                var option = new RequestOptions("/api/voice/workbench/voicelist/detail", new { id });

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch details of voice list with ID: {id}", ex);
            }
        }


        /// <summary>
        /// Search voice list
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> ListSearch(VoiceListSearchModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/voice/workbench/voicelist/search", requestModel);

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to search voice list with model: {JsonConvert.SerializeObject(requestModel)}", ex);
            }
        }


        /// <summary>
        /// Fetch lyric of a voice by its id
        /// </summary>
        /// <param name="programId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ApiResponse> Lyric(long programId)
        {
            try
            {
                var option = new RequestOptions("/api/voice/lyric/get", new { programId });

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch lyric of a voice with ID: {programId}", ex);
            }
        }

        public Task<ApiResponse> Search(VoiceListSearchRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetch the trans information of voicelist
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<ApiResponse> Trans(VoicelistTransRequestModel requestModel)
        {
            try
            {
                var option = new RequestOptions("/api/voice/workbench/radio/program/trans", requestModel);

                return await _client.HandleRequestAsync(option);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to fetch the trans information of voice list with model: {JsonConvert.SerializeObject(requestModel)}", ex);
            }
        }


        //TODO
        public Task<ApiResponse> Upload(VoiceUploadRequestModel requestModel)
        {
            throw new NotImplementedException();
        }
    }
}
