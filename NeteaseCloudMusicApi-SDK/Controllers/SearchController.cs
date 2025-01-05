using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class SearchController : Controller
    {
        private readonly GenericService _genericService;

        public SearchController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/search/voice/get",
                    OptionType = "weapi",
                    Data = new SearchRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Search data by default method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("search/default")]
        [SwaggerOperation(summary: "Search data by default method")]
        public async Task<IActionResult> SearchDefault()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/search/defaultkeyword/get",
                    OptionType = "weapi"
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("search/hot")]
        public async Task<IActionResult> SearchHot()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/search/hot",
                    OptionType = "weapi",
                    Data = new SearchHotRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Fetch hot stuff
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("search/hot/detail")]
        [SwaggerOperation(summary: " Fetch hot stuff")]
        public async Task<IActionResult> SearchHotDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/hotsearchlist/get",
                    OptionType = "weapi",
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Match local song info with the cloud tracks, a bit like checking before uploading
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("search/match")]
        [SwaggerOperation(summary: "Match local song info with the cloud tracks")]
        public async Task<IActionResult> SearchMatch([FromQuery] SearchMatchRequestModel requestModel)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/search/match/new",
                    OptionType = "weapi",
                    Data = requestModel
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Search data by multimatch
        /// </summary>
        /// <param name="type">search type</param>
        /// <param name="s">keywords</param>
        /// <returns></returns>
        [HttpGet]
        [Route("search/multimatch")]
        public async Task<IActionResult> SearchMultimatch([FromQuery]int type = 1, [FromQuery]string keywords = "")
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/search/suggest/multimatch",
                    OptionType = "weapi",
                    Data = new SearchMultimatchRequestModel()
                    {
                        Type = type,
                        S = keywords
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        
        /// <summary>
        /// Fetch suggestion search keywords
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("search/suggest")]
        [SwaggerOperation(summary: "Fetch suggestion search keywords")]
        public async Task<IActionResult> SearchSuggest([FromQuery]string? keywords, [FromQuery]string type = "mobile")
        {
            try
            {
                string end = type == "mobile" ? "keyword" : "web";
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/search/suggest/" + type,
                    OptionType = "weapi",
                    Data = new SearchSuggestRequestModel()
                    {
                        S = keywords ?? ""
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
