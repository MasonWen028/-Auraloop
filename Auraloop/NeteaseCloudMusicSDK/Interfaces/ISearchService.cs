using System;
using System.Threading.Tasks;
using NeteaseCloudMusicSDK.Models.Response;

namespace NeteaseCloudMusicApi_SDK.Interfaces
{
    /// <summary>
    /// Defines methods for performing various search operations in the Netease Cloud Music API.
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Performs a general search across all content types.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the search results.</returns>
        Task<ApiResponse> Search();

        /// <summary>
        /// Retrieves the default search suggestion or trending search term.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the default search term or suggestion.</returns>
        Task<ApiResponse> SearchDefault();

        /// <summary>
        /// Retrieves the list of hot search terms.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the list of hot search terms.</returns>
        Task<ApiResponse> SearchHot(int type = 1111);

        /// <summary>
        /// Retrieves detailed information about hot search terms, including rankings and metadata.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing detailed hot search data.</returns>
        Task<ApiResponse> SearchHotDetail();

        /// <summary>
        /// Matches specific search keywords against the database.
        /// </summary>
        /// <param name="requestModel">The request model containing the search criteria.
        /// SearchMatchRequestModel.Songs should be the json string of and array of SearchMatchSongs 
        /// </param>
        /// <returns>An <see cref="ApiResponse"/> containing the search matches.</returns>
        Task<ApiResponse> SearchMatch(SearchMatchRequestModel requestModel);

        /// <summary>
        /// Performs a multi-match search, returning results for multiple content types.
        /// </summary>
        /// <param name="type">The type of content to prioritize in the search. Default is 1 (e.g., song).</param>
        /// <param name="keywords">The search keywords.</param>
        /// <returns>An <see cref="ApiResponse"/> containing the multi-match search results.</returns>
        Task<ApiResponse> SearchMultimatch(int type = 1, string keywords = "");

        /// <summary>
        /// Provides search suggestions based on the entered keywords.
        /// </summary>
        /// <param name="keywords">The search keywords.</param>
        /// <param name="type">The suggestion type (e.g., "mobile" or "web"). Default is "mobile".</param>
        /// <returns>An <see cref="ApiResponse"/> containing search suggestions.</returns>
        Task<ApiResponse> SearchSuggest(string keywords, string type = "mobile");
    }
}
