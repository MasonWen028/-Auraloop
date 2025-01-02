using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class PersonalizedController : Controller
    {
        private readonly GenericService _genericService;

        public PersonalizedController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("personalized")]
        public async Task<IActionResult> Personalized()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/personalized/playlist",
                    OptionType = "weapi",
                    Data = new PersonalizedRequestModel()
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
        [Route("personalized/djprogram")]
        public async Task<IActionResult> PersonalizedDjprogram()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/personalized/djprogram",
                    OptionType = "weapi",
                    Data = new PersonalizedDjprogramRequestModel()
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
        [Route("personalized/mv")]
        public async Task<IActionResult> PersonalizedMv()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/personalized/mv",
                    OptionType = "weapi",
                    Data = new PersonalizedMvRequestModel()
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
        [Route("personalized/newsong")]
        public async Task<IActionResult> PersonalizedNewsong()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/personalized/newsong",
                    OptionType = "weapi",
                    Data = new PersonalizedNewsongRequestModel()
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
        [Route("personalized/privatecontent")]
        public async Task<IActionResult> PersonalizedPrivatecontent()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/personalized/privatecontent",
                    OptionType = "weapi",
                    Data = new PersonalizedPrivatecontentRequestModel()
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
        [Route("personalized/privatecontent/list")]
        public async Task<IActionResult> PersonalizedPrivatecontentList()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v2/privatecontent/list",
                    OptionType = "weapi",
                    Data = new PersonalizedPrivatecontentListRequestModel()
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
