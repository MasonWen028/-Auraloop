using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for managing musician-related features in the Netease Cloud Music API.
    /// </summary>
    public interface IMusicianService
    {
        /// <summary>
        /// Retrieves the musician's current Cloudbean balance.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the Cloudbean balance information.</returns>
        Task<ApiResponse> MusicianCloudbean();

        /// <summary>
        /// Claims obtainable Cloudbeans for the musician.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the Cloudbean claim operation.</returns>
        Task<ApiResponse> MusicianCloudbeanObtain();

        /// <summary>
        /// Provides an overview of the musician's data, including statistics and performance metrics.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing data overview information.</returns>
        Task<ApiResponse> MusicianDataOverview();

        /// <summary>
        /// Retrieves the play trend data for the musician's tracks over time.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing play trend analytics.</returns>
        Task<ApiResponse> MusicianPlayTrend();

        /// <summary>
        /// Signs the musician into the platform's daily or periodic tasks.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> indicating the success or failure of the sign-in operation.</returns>
        Task<ApiResponse> MusicianSign();

        /// <summary>
        /// Retrieves the list of tasks available for the musician to complete.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of available tasks.</returns>
        Task<ApiResponse> MusicianTasks();

        /// <summary>
        /// Retrieves the list of newly added tasks available for the musician.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of new tasks.</returns>
        Task<ApiResponse> MusicianTasksNew();
    }
}
