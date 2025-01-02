using Microsoft.AspNetCore.Mvc;
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
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("search/default")]
        public async Task<IActionResult> SearchDefault()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/search/defaultkeyword/get",
                    OptionType = "weapi",
                    Data = new SearchDefaultRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.data);
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
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("search/hot/detail")]
        public async Task<IActionResult> SearchHotDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/hotsearchlist/get",
                    OptionType = "weapi",
                    Data = new SearchHotDetailRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("search/match")]
        public async Task<IActionResult> SearchMatch()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/search/match/new",
                    OptionType = "weapi",
                    Data = new SearchMatchRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("search/multimatch")]
        public async Task<IActionResult> SearchMultimatch()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/search/suggest/multimatch",
                    OptionType = "weapi",
                    Data = new SearchMultimatchRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("search/suggest")]
        public async Task<IActionResult> SearchSuggest()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/search/suggest/",
                    OptionType = "weapi",
                    Data = new SearchSuggestRequestModel()
                    {
                        // Replace with actual data if needed
                    }
                };

                var result = await _genericService.HandleRequestAsync(apiModel);
                return Ok(result.data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
