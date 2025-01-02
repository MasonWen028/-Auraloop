using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class SendController : Controller
    {
        private readonly GenericService _genericService;

        public SendController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("send/album")]
        public async Task<IActionResult> SendAlbum()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/msg/private/send",
                    OptionType = "weapi",
                    Data = new SendAlbumRequestModel()
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
        [Route("send/playlist")]
        public async Task<IActionResult> SendPlaylist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/msg/private/send",
                    OptionType = "weapi",
                    Data = new SendPlaylistRequestModel()
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
        [Route("send/song")]
        public async Task<IActionResult> SendSong()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/msg/private/send",
                    OptionType = "weapi",
                    Data = new SendSongRequestModel()
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
        [Route("send/text")]
        public async Task<IActionResult> SendText()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/msg/private/send",
                    OptionType = "weapi",
                    Data = new SendTextRequestModel()
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
