using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
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

        /// <summary>
        /// Fetch chorus time of a song
        /// </summary>
        /// <param name="id">song id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("song/chorus")]
        [SwaggerOperation(summary: " Fetch chorus time of a song")]
        public async Task<IActionResult> SongChorus([FromQuery]long id)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/chorus",
                    OptionType = "weapi",
                    Data = new SongChorusRequestModel()
                    {
                        Ids = $"[{id}]"
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
        /// Fetch Song details
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("song/detail")]
        [SwaggerOperation(summary: "Fetch Song details")]
        public async Task<IActionResult> SongDetail([FromQuery] long[] ids)
        {
            try
            {
                var sondRequestData = new { c = JsonConvert.SerializeObject(ids) };

                var songApiModel = new ApiModel()
                {
                    ApiEndpoint = "/api/v3/song/detail",
                    Data = sondRequestData,
                    OptionType = "weapi"
                };
                var songRes = await _genericService.HandleRequestAsync(songApiModel);

                return Ok(songRes.body);
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
                return Ok(result.body);
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
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }


        /// <summary>
        /// Fetch the download url of targeted song through client.
        /// </summary>
        /// <param name="id">the identifier of targeted song</param>
        /// <param name="level"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("song/download/url/v1")]
        [SwaggerOperation(summary: "Fetch the download url of targeted song through client.")]
        public async Task<IActionResult> SongDownloadUrlV1([FromQuery]long id, [FromQuery]string level = "h")
        {
            try
            {
                SongLevel songLevel = (SongLevel)Enum.Parse(typeof(SongLevel), level);
                var (levelName, levalChnName) = SongLevelData.Levels.GetValueOrDefault(songLevel, ("exhigh", "º´∏ﬂ“Ù÷ "));

                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/enhance/download/url/v1",
                    OptionType = "weapi",
                    Data = new SongDownloadUrlV1RequestModel()
                    {
                        Id = id,
                        ImmerseType = "C51",
                        Level = levelName
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
        /// Fetch the dynamic cover for targeted song
        /// </summary>
        /// <param name="id">song id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("song/dynamic/cover")]
        [SwaggerOperation(summary: "Fetch the dynamic cover for targeted song")]
        public async Task<IActionResult> SongDynamicCover([FromQuery]long id)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/songplay/dynamic-cover",
                    OptionType = "weapi",
                    Data = new SongDynamicCoverRequestModel()
                    {
                        SongId = id
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
                return Ok(result.body);
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
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Fetch sound quality of targeted song
        /// </summary>
        /// <param name="id">the identifier of target</param>
        /// <returns></returns>
        [HttpGet]
        [Route("song/music/detail")]
        [SwaggerOperation(summary: "Fetch sound quality of targeted song")]
        public async Task<IActionResult> SongMusicDetail([FromQuery]long id)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/music/detail/get",
                    OptionType = "weapi",
                    Data = new SongMusicDetailRequestModel()
                    {
                        SongId = id
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
                return Ok(result.body);
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
                return Ok(result.body);
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
                return Ok(result.body);
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
                return Ok(result.body);
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
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        /// <summary>
        /// Fetch song uri
        /// </summary>
        /// <param name="id">song Id</param>
        /// <param name="level">quality level: standard, exhigh, lossless, hires, jyeffect, sky, jymaster</param>
        /// <returns></returns>
        [HttpGet]
        [Route("song/url/v1")]
        [SwaggerOperation(summary: "Fetch song uri")]
        public async Task<IActionResult> SongUrlV1([FromQuery]long id, [FromQuery]string level)
        {
            try
            {                             
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/enhance/player/url/v1",
                    OptionType = "weapi",
                    Data = new SongUrlV1RequestModel()
                    {
                        EncodeType = "flac",
                        Ids = $"[{id}]",
                        Level = level.ToString(),
                        ImmerseType = level == SongLevelForUrl.sky.ToString() ? "c51" : ""
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
                return Ok(result.body);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
