using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class AlbumController : Controller
    {
        private readonly GenericService _genericService;

        public AlbumController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("album")]
        public async Task<IActionResult> Album()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/album/${query.id}",
                    OptionType = "weapi",
                    Data = new AlbumRequestModel()
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
        [Route("album/detail")]
        public async Task<IActionResult> AlbumDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/vipmall/albumproduct/detail",
                    OptionType = "weapi",
                    Data = new AlbumDetailRequestModel()
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
        [Route("album/detail/dynamic")]
        public async Task<IActionResult> AlbumDetailDynamic()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/album/detail/dynamic",
                    OptionType = "weapi",
                    Data = new AlbumDetailDynamicRequestModel()
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
        [Route("album/list")]
        public async Task<IActionResult> AlbumList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/vipmall/albumproduct/list",
                    OptionType = "weapi",
                    Data = new AlbumListRequestModel()
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
        [Route("album/list/style")]
        public async Task<IActionResult> AlbumListStyle()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/vipmall/appalbum/album/style",
                    OptionType = "weapi",
                    Data = new AlbumListStyleRequestModel()
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
        [Route("album/new")]
        public async Task<IActionResult> AlbumNew()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/album/new",
                    OptionType = "weapi",
                    Data = new AlbumNewRequestModel()
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
        [Route("album/newest")]
        public async Task<IActionResult> AlbumNewest()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/discovery/newAlbum",
                    OptionType = "weapi",
                    Data = new AlbumNewestRequestModel()
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
        [Route("album/privilege")]
        public async Task<IActionResult> AlbumPrivilege()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/album/privilege",
                    OptionType = "weapi",
                    Data = new AlbumPrivilegeRequestModel()
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
        [Route("album/songsaleboard")]
        public async Task<IActionResult> AlbumSongsaleboard()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/feealbum/songsaleboard/${type}/type",
                    OptionType = "weapi",
                    Data = new AlbumSongsaleboardRequestModel()
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
        [Route("album/sub")]
        public async Task<IActionResult> AlbumSub()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/album/${query.t}",
                    OptionType = "weapi",
                    Data = new AlbumSubRequestModel()
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
        [Route("album/sublist")]
        public async Task<IActionResult> AlbumSublist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/album/sublist",
                    OptionType = "weapi",
                    Data = new AlbumSublistRequestModel()
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
