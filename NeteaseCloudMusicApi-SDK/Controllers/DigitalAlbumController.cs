using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class DigitalAlbumController : Controller
    {
        private readonly GenericService _genericService;

        public DigitalAlbumController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("digitalalbum/detail")]
        public async Task<IActionResult> DigitalalbumDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/vipmall/albumproduct/detail",
                    OptionType = "weapi",
                    Data = new DigitalAlbumDetailRequestModel()
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
        [Route("digitalalbum/ordering")]
        public async Task<IActionResult> DigitalalbumOrdering()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/ordering/web/digital",
                    OptionType = "weapi",
                    Data = new DigitalAlbumOrderingRequestModel()
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
        [Route("digitalalbum/purchased")]
        public async Task<IActionResult> DigitalalbumPurchased()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/digitalAlbum/purchased",
                    OptionType = "weapi",
                    Data = new DigitalAlbumPurchasedRequestModel()
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
        [Route("digitalalbum/sales")]
        public async Task<IActionResult> DigitalalbumSales()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/vipmall/albumproduct/album/query/sales",
                    OptionType = "weapi",
                    Data = new DigitalAlbumSalesRequestModel()
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
