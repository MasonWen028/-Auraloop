using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;
using NeteaseCloudMusicSDK.ApiClient.Models;
using NeteaseCloudMusicSDK.Models.Response;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class AudioService : IAudioService
{
    private readonly NetEaseApiClient _client;

    public AudioService(NetEaseApiClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Matches audio files to corresponding metadata or tracks in the system.
    /// </summary>
    /// <param name="requestModel">The request model containing parameters for audio matching.</param>
    /// <returns>An <see cref="ApiResponse"/> containing the match results for the audio files.</returns>
    public async Task<ApiResponse> MatchAudio(AudioMatchRequestModel requestModel)
    {
        var baseUrl = "https://interface.music.163.com/api/music/audio/match";
        var url = $"{baseUrl}?sessionId=0123456789abcdef&algorithmCode=shazam_v2&duration={requestModel.Duration}&rawdata={Uri.EscapeDataString(requestModel.AudioFingerprint)}&times=1&decrypt=1";

        try
        {
            return await _client.GetAsync(url);
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while matching audio:", ex);
          
        }
    }
}
