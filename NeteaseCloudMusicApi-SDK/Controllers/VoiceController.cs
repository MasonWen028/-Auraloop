using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class VoiceController : Controller
    {
        private readonly GenericService _genericService;

        public VoiceController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("voice/delete")]
        public async Task<IActionResult> VoiceDelete()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "",
                    OptionType = "weapi",
                    Data = new VoiceDeleteRequestModel()
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
        [Route("voice/detail")]
        public async Task<IActionResult> VoiceDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/voice/workbench/voice/detail",
                    OptionType = "weapi",
                    Data = new VoiceDetailRequestModel()
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
        [Route("voice/lyric")]
        public async Task<IActionResult> VoiceLyric()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/voice/lyric/get",
                    OptionType = "weapi",
                    Data = new VoiceLyricRequestModel()
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
        [Route("voice/upload")]
        public async Task<IActionResult> VoiceUpload()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/nos/token/alloc",
                    OptionType = "weapi",
                    Data = new VoiceUploadRequestModel()
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
