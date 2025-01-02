using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class UgcController : Controller
    {
        private readonly GenericService _genericService;

        public UgcController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("ugc/album/get")]
        public async Task<IActionResult> UgcAlbumGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/album/get",
                    OptionType = "weapi",
                    Data = new UgcAlbumGetRequestModel()
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
        [Route("ugc/artist/get")]
        public async Task<IActionResult> UgcArtistGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/artist/get",
                    OptionType = "weapi",
                    Data = new UgcArtistGetRequestModel()
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
        [Route("ugc/artist/search")]
        public async Task<IActionResult> UgcArtistSearch()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/artist/search",
                    OptionType = "weapi",
                    Data = new UgcArtistSearchRequestModel()
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
        [Route("ugc/detail")]
        public async Task<IActionResult> UgcDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/detail",
                    OptionType = "weapi",
                    Data = new UgcDetailRequestModel()
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
        [Route("ugc/mv/get")]
        public async Task<IActionResult> UgcMvGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/mv/get",
                    OptionType = "weapi",
                    Data = new UgcMvGetRequestModel()
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
        [Route("ugc/song/get")]
        public async Task<IActionResult> UgcSongGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/song/get",
                    OptionType = "weapi",
                    Data = new UgcSongGetRequestModel()
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
        [Route("ugc/user/devote")]
        public async Task<IActionResult> UgcUserDevote()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/rep/ugc/user/devote",
                    OptionType = "weapi",
                    Data = new UgcUserDevoteRequestModel()
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
