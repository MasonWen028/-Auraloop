using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for scrobbling songs (tracking song play history) in the Netease Cloud Music API.
    /// </summary>
    public interface IScrobbleService
    {
        /// <summary>
        /// Tracks a song play (scrobble) with details about the playback.
        /// </summary>
        /// <param name="requestModel">The model containing details about the song and playback context.</param>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the scrobble operation.</returns>
        Task<ApiResponse> Scrobble(ScrobbleRequestModel requestModel);
    }

}