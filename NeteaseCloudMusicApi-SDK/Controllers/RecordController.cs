using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class RecordController : Controller
    {
        private readonly GenericService _genericService;

        public RecordController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("record/recent/album")]
        public async Task<IActionResult> RecordRecentAlbum()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/play-record/album/list",
                    OptionType = "weapi",
                    Data = new RecordRecentAlbumRequestModel()
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
        [Route("record/recent/dj")]
        public async Task<IActionResult> RecordRecentDj()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/play-record/djradio/list",
                    OptionType = "weapi",
                    Data = new RecordRecentDjRequestModel()
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
        [Route("record/recent/playlist")]
        public async Task<IActionResult> RecordRecentPlaylist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/play-record/playlist/list",
                    OptionType = "weapi",
                    Data = new RecordRecentPlaylistRequestModel()
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
        [Route("record/recent/song")]
        public async Task<IActionResult> RecordRecentSong()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/play-record/song/list",
                    OptionType = "weapi",
                    Data = new RecordRecentSongRequestModel()
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
        [Route("record/recent/video")]
        public async Task<IActionResult> RecordRecentVideo()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/play-record/newvideo/list",
                    OptionType = "weapi",
                    Data = new RecordRecentVideoRequestModel()
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
        [Route("record/recent/voice")]
        public async Task<IActionResult> RecordRecentVoice()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/play-record/voice/list",
                    OptionType = "weapi",
                    Data = new RecordRecentVoiceRequestModel()
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
