using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class VoicelistController : Controller
    {
        private readonly GenericService _genericService;

        public VoicelistController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("voicelist/detail")]
        public async Task<IActionResult> VoicelistDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/voice/workbench/voicelist/detail",
                    OptionType = "weapi",
                    Data = new VoicelistDetailRequestModel()
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
        [Route("voicelist/list")]
        public async Task<IActionResult> VoicelistList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/voice/workbench/voices/by/voicelist",
                    OptionType = "weapi",
                    Data = new VoicelistListRequestModel()
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
        [Route("voicelist/list/search")]
        public async Task<IActionResult> VoicelistListSearch()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "",
                    OptionType = "weapi",
                    Data = new VoicelistListSearchRequestModel()
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
        [Route("voicelist/search")]
        public async Task<IActionResult> VoicelistSearch()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/voice/workbench/voicelist/search",
                    OptionType = "weapi",
                    Data = new VoicelistSearchRequestModel()
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
        [Route("voicelist/trans")]
        public async Task<IActionResult> VoicelistTrans()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/voice/workbench/radio/program/trans",
                    OptionType = "weapi",
                    Data = new VoicelistTransRequestModel()
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
