using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class StyleController : Controller
    {
        private readonly GenericService _genericService;

        public StyleController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("style/album")]
        public async Task<IActionResult> StyleAlbum()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/style-tag/home/album",
                    OptionType = "weapi",
                    Data = new StyleAlbumRequestModel()
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
        [Route("style/artist")]
        public async Task<IActionResult> StyleArtist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/style-tag/home/artist",
                    OptionType = "weapi",
                    Data = new StyleArtistRequestModel()
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
        [Route("style/detail")]
        public async Task<IActionResult> StyleDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/style-tag/home/head",
                    OptionType = "weapi",
                    Data = new StyleDetailRequestModel()
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
        [Route("style/list")]
        public async Task<IActionResult> StyleList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/tag/list/get",
                    OptionType = "weapi",
                    Data = new StyleListRequestModel()
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
        [Route("style/playlist")]
        public async Task<IActionResult> StylePlaylist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/style-tag/home/playlist",
                    OptionType = "weapi",
                    Data = new StylePlaylistRequestModel()
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
        [Route("style/preference")]
        public async Task<IActionResult> StylePreference()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/tag/my/preference/get",
                    OptionType = "weapi",
                    Data = new StylePreferenceRequestModel()
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
        [Route("style/song")]
        public async Task<IActionResult> StyleSong()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/style-tag/home/song",
                    OptionType = "weapi",
                    Data = new StyleSongRequestModel()
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
