using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class MlogController : Controller
    {
        private readonly GenericService _genericService;

        public MlogController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("mlog/music/rcmd")]
        public async Task<IActionResult> MlogMusicRcmd()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mlog/rcmd/feed/list",
                    OptionType = "weapi",
                    Data = new MlogMusicRcmdRequestModel()
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
        [Route("mlog/to/video")]
        public async Task<IActionResult> MlogToVideo()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mlog/video/convert/id",
                    OptionType = "weapi",
                    Data = new MlogToVideoRequestModel()
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
        [Route("mlog/url")]
        public async Task<IActionResult> MlogUrl()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mlog/detail/v1",
                    OptionType = "weapi",
                    Data = new MlogUrlRequestModel()
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
