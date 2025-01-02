using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class TopController : Controller
    {
        private readonly GenericService _genericService;

        public TopController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("top/album")]
        public async Task<IActionResult> TopAlbum()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/discovery/new/albums/area",
                    OptionType = "weapi",
                    Data = new TopAlbumRequestModel()
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
        [Route("top/artists")]
        public async Task<IActionResult> TopArtists()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/top",
                    OptionType = "weapi",
                    Data = new TopArtistsRequestModel()
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
        [Route("top/list")]
        public async Task<IActionResult> TopList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/v4/detail",
                    OptionType = "weapi",
                    Data = new TopListRequestModel()
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
        [Route("top/mv")]
        public async Task<IActionResult> TopMv()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mv/toplist",
                    OptionType = "weapi",
                    Data = new TopMvRequestModel()
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
        [Route("top/playlist")]
        public async Task<IActionResult> TopPlaylist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/list",
                    OptionType = "weapi",
                    Data = new TopPlaylistRequestModel()
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
        [Route("top/playlist/highquality")]
        public async Task<IActionResult> TopPlaylistHighquality()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/playlist/highquality/list",
                    OptionType = "weapi",
                    Data = new TopPlaylistHighqualityRequestModel()
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
        [Route("top/song")]
        public async Task<IActionResult> TopSong()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/discovery/new/songs",
                    OptionType = "weapi",
                    Data = new TopSongRequestModel()
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
