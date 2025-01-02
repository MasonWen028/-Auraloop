using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class CellphoneController : Controller
    {
        private readonly GenericService _genericService;

        public CellphoneController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("cellphone/existence/check")]
        public async Task<IActionResult> CellphoneExistenceCheck()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cellphone/existence/check",
                    OptionType = "weapi",
                    Data = new CellphoneExistenceCheckRequestModel()
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
