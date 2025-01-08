using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeteaseCloudMusicSDK.Services
{
    public class ArtistService: IArtistService
    {
        private readonly NetEaseApiClient _client;

        /// <summary>
        /// Defines methods to interact with album-related functionalities in the Netease Cloud Music API.
        /// </summary>
        public ArtistService(NetEaseApiClient client)
        {
            _client = client;
        }

        public Task<ApiResponse> GetArtistDescription(long artistId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetArtistDetails(long artistId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetArtistFanCount(long artistId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetArtistFollowCount(long artistId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetArtistInfo(long artistId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetArtistMVs(long artistId, int limit = 50, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetArtistsByIds(string artistIds)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetArtistVideos(long artistId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetDynamicArtistDetails(long artistId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetFilteredArtists(ArtistListRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetNewMVs(int limit = 50, long beforeTimestamp = 0)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetNewSongsByArtist(long artistId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetSongsByArtist(long artistId, int limit = 50, int offset = 0, string order = "hot")
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetTopSongsByArtist(long artistId)
        {
            throw new NotImplementedException();
        }
    }
}
