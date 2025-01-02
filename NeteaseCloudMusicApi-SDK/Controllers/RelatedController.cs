using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class RelatedController : Controller
    {
        private readonly GenericService _genericService;

        public RelatedController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("related/allvideo")]
        public async Task<IActionResult> RelatedAllvideo()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloudvideo/v1/allvideo/rcmd",
                    OptionType = "weapi",
                    Data = new RelatedAllvideoRequestModel()
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
        [Route("related/playlist")]
        public async Task<IActionResult> RelatedPlaylist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "https://music.163.com/playlist?id=${query.id}",
                    OptionType = "",
                    Data = new RelatedPlaylistRequestModel()
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
