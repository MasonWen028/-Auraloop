using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class SongController : Controller
    {
        private readonly GenericService _genericService;

        public SongController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("song/chorus")]
        public async Task<IActionResult> SongChorus()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/chorus",
                    OptionType = "weapi",
                    Data = new SongChorusRequestModel()
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
        [Route("song/detail")]
        public async Task<IActionResult> SongDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v3/song/detail",
                    OptionType = "weapi",
                    Data = new SongDetailRequestModel()
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
        [Route("song/downlist")]
        public async Task<IActionResult> SongDownlist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/member/song/downlist",
                    OptionType = "weapi",
                    Data = new SongDownlistRequestModel()
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
        [Route("song/download/url")]
        public async Task<IActionResult> SongDownloadUrl()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/enhance/download/url",
                    OptionType = "weapi",
                    Data = new SongDownloadUrlRequestModel()
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
        [Route("song/download/url/v1")]
        public async Task<IActionResult> SongDownloadUrlV1()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/enhance/download/url/v1",
                    OptionType = "weapi",
                    Data = new SongDownloadUrlV1RequestModel()
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
        [Route("song/dynamic/cover")]
        public async Task<IActionResult> SongDynamicCover()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/songplay/dynamic-cover",
                    OptionType = "weapi",
                    Data = new SongDynamicCoverRequestModel()
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
        [Route("song/like/check")]
        public async Task<IActionResult> SongLikeCheck()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/like/check",
                    OptionType = "weapi",
                    Data = new SongLikeCheckRequestModel()
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
        [Route("song/monthdownlist")]
        public async Task<IActionResult> SongMonthdownlist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/member/song/monthdownlist",
                    OptionType = "weapi",
                    Data = new SongMonthdownlistRequestModel()
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
        [Route("song/music/detail")]
        public async Task<IActionResult> SongMusicDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/music/detail/get",
                    OptionType = "weapi",
                    Data = new SongMusicDetailRequestModel()
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
        [Route("song/order/update")]
        public async Task<IActionResult> SongOrderUpdate()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/manipulate/tracks",
                    OptionType = "weapi",
                    Data = new SongOrderUpdateRequestModel()
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
        [Route("song/purchased")]
        public async Task<IActionResult> SongPurchased()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/single/mybought/song/list",
                    OptionType = "weapi",
                    Data = new SongPurchasedRequestModel()
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
        [Route("song/red/count")]
        public async Task<IActionResult> SongRedCount()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/red/count",
                    OptionType = "weapi",
                    Data = new SongRedCountRequestModel()
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
        [Route("song/singledownlist")]
        public async Task<IActionResult> SongSingledownlist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/member/song/singledownlist",
                    OptionType = "weapi",
                    Data = new SongSingledownlistRequestModel()
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
        [Route("song/url")]
        public async Task<IActionResult> SongUrl()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/enhance/player/url",
                    OptionType = "weapi",
                    Data = new SongUrlRequestModel()
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
        [Route("song/url/v1")]
        public async Task<IActionResult> SongUrlV1()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/enhance/player/url/v1",
                    OptionType = "weapi",
                    Data = new SongUrlV1RequestModel()
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
        [Route("song/wiki/summary")]
        public async Task<IActionResult> SongWikiSummary()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/play/about/block/page",
                    OptionType = "weapi",
                    Data = new SongWikiSummaryRequestModel()
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
