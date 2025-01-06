using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    public interface IMusicService
    {
        /// <summary>
        /// Retrieves information required to initialize or start the music listening experience for the first time.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing details necessary for starting music playback.</returns>
        Task<ApiResponse> StartMusicListening();      


    }
}