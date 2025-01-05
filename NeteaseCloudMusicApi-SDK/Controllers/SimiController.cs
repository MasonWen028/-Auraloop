using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class SimiController : Controller
    {
        private readonly GenericService _genericService;

        public SimiController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("simi/artist")]
        public async Task<IActionResult> SimiArtist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/discovery/simiArtist",
                    OptionType = "weapi",
                    Data = new SimiArtistRequestModel()
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
        [Route("simi/mv")]
        public async Task<IActionResult> SimiMv()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/discovery/simiMV",
                    OptionType = "weapi",
                    Data = new SimiMvRequestModel()
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
        [Route("simi/playlist")]
        public async Task<IActionResult> SimiPlaylist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/discovery/simiPlaylist",
                    OptionType = "weapi",
                    Data = new SimiPlaylistRequestModel()
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
        [Route("simi/song")]
        public async Task<IActionResult> SimiSong()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/discovery/simiSong",
                    OptionType = "weapi",
                    Data = new SimiSongRequestModel()
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
        [Route("simi/user")]
        public async Task<IActionResult> SimiUser()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/discovery/simiUser",
                    OptionType = "weapi",
                    Data = new SimiUserRequestModel()
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
