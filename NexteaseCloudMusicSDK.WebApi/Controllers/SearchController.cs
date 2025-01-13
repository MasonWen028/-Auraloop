using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly RequestContext _context;

        public SearchController(ISearchService searchService, RequestContext context)
        {
            _searchService = searchService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> Search([FromBody] SearchInputModel requestModel)
        {
            try
            {
                var response = await _searchService.Search(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("default")]
        public async Task<IActionResult> SearchDefault()
        {
            try
            {
                var response = await _searchService.SearchDefault();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("hot")]
        public async Task<IActionResult> SearchHot([FromQuery] Int32 type)
        {
            try
            {
                var response = await _searchService.SearchHot(type);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("hotdetail")]
        public async Task<IActionResult> SearchHotDetail()
        {
            try
            {
                var response = await _searchService.SearchHotDetail();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("match")]
        public async Task<IActionResult> SearchMatch([FromBody] SearchMatchRequestModel requestModel)
        {
            try
            {
                var response = await _searchService.SearchMatch(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("multimatch")]
        public async Task<IActionResult> SearchMultimatch([FromQuery] Int32 type, String keywords)
        {
            try
            {
                var response = await _searchService.SearchMultimatch(type, keywords);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("suggest")]
        public async Task<IActionResult> SearchSuggest([FromQuery] String keywords, String type)
        {
            try
            {
                var response = await _searchService.SearchSuggest(keywords, type);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
