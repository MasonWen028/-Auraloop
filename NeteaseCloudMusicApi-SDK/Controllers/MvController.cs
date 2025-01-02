using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class MvController : Controller
    {
        private readonly GenericService _genericService;

        public MvController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("mv/all")]
        public async Task<IActionResult> MvAll()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mv/all",
                    OptionType = "weapi",
                    Data = new MvAllRequestModel()
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
        [Route("mv/detail")]
        public async Task<IActionResult> MvDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/mv/detail",
                    OptionType = "weapi",
                    Data = new MvDetailRequestModel()
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
        [Route("mv/detail/info")]
        public async Task<IActionResult> MvDetailInfo()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "R_MV_5_${query.mvid}",
                    OptionType = "weapi",
                    Data = new MvDetailInfoRequestModel()
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
        [Route("mv/exclusive/rcmd")]
        public async Task<IActionResult> MvExclusiveRcmd()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mv/exclusive/rcmd",
                    OptionType = "weapi",
                    Data = new MvExclusiveRcmdRequestModel()
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
        [Route("mv/first")]
        public async Task<IActionResult> MvFirst()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mv/first",
                    OptionType = "weapi",
                    Data = new MvFirstRequestModel()
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
        [Route("mv/sub")]
        public async Task<IActionResult> MvSub()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/mv/${query.t}",
                    OptionType = "weapi",
                    Data = new MvSubRequestModel()
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
        [Route("mv/sublist")]
        public async Task<IActionResult> MvSublist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloudvideo/allvideo/sublist",
                    OptionType = "weapi",
                    Data = new MvSublistRequestModel()
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
        [Route("mv/url")]
        public async Task<IActionResult> MvUrl()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/song/enhance/play/mv/url",
                    OptionType = "weapi",
                    Data = new MvUrlRequestModel()
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
