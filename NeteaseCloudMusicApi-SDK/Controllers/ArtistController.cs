using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class ArtistController : Controller
    {
        private readonly GenericService _genericService;

        public ArtistController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("artist/album")]
        public async Task<IActionResult> ArtistAlbum()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/albums/${query.id}",
                    OptionType = "weapi",
                    Data = new ArtistAlbumRequestModel()
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
        [Route("artist/desc")]
        public async Task<IActionResult> ArtistDesc()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/introduction",
                    OptionType = "weapi",
                    Data = new ArtistDescRequestModel()
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
        [Route("artist/detail")]
        public async Task<IActionResult> ArtistDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/head/info/get",
                    OptionType = "weapi",
                    Data = new ArtistDetailRequestModel()
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
        [Route("artist/detail/dynamic")]
        public async Task<IActionResult> ArtistDetailDynamic()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/detail/dynamic",
                    OptionType = "weapi",
                    Data = new ArtistDetailDynamicRequestModel()
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
        [Route("artist/fans")]
        public async Task<IActionResult> ArtistFans()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/fans/get",
                    OptionType = "weapi",
                    Data = new ArtistFansRequestModel()
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
        [Route("artist/follow/count")]
        public async Task<IActionResult> ArtistFollowCount()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/follow/count/get",
                    OptionType = "weapi",
                    Data = new ArtistFollowCountRequestModel()
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
        [Route("artist/list")]
        public async Task<IActionResult> ArtistList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/artist/list",
                    OptionType = "weapi",
                    Data = new ArtistListRequestModel()
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
        [Route("artist/mv")]
        public async Task<IActionResult> ArtistMv()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/mvs",
                    OptionType = "weapi",
                    Data = new ArtistMvRequestModel()
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
        [Route("artist/new/mv")]
        public async Task<IActionResult> ArtistNewMv()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/sub/artist/new/works/mv/list",
                    OptionType = "weapi",
                    Data = new ArtistNewMvRequestModel()
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
        [Route("artist/new/song")]
        public async Task<IActionResult> ArtistNewSong()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/sub/artist/new/works/song/list",
                    OptionType = "weapi",
                    Data = new ArtistNewSongRequestModel()
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
        [Route("artist/songs")]
        public async Task<IActionResult> ArtistSongs()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/artist/songs",
                    OptionType = "weapi",
                    Data = new ArtistSongsRequestModel()
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
        [Route("artist/sub")]
        public async Task<IActionResult> ArtistSub()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/${query.t}",
                    OptionType = "weapi",
                    Data = new ArtistSubRequestModel()
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
        [Route("artist/sublist")]
        public async Task<IActionResult> ArtistSublist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/sublist",
                    OptionType = "weapi",
                    Data = new ArtistSublistRequestModel()
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
        [Route("artist/top/song")]
        public async Task<IActionResult> ArtistTopSong()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/artist/top/song",
                    OptionType = "weapi",
                    Data = new ArtistTopSongRequestModel()
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
        [Route("artist/video")]
        public async Task<IActionResult> ArtistVideo()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mlog/artist/video",
                    OptionType = "weapi",
                    Data = new ArtistVideoRequestModel()
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
