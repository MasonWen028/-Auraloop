using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DigitalAlbumController : Controller
    {
        private readonly IDigitalAlbumService _digitalalbumService;
        private readonly RequestContext _context;

        public DigitalAlbumController(IDigitalAlbumService digitalalbumService, RequestContext context)
        {
            _digitalalbumService = digitalalbumService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("albumdetail")]
        public async Task<IActionResult> GetAlbumDetail([FromQuery] Int64 albumId)
        {
            try
            {
                var response = await _digitalalbumService.GetAlbumDetail(albumId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("orderalbum")]
        public async Task<IActionResult> OrderAlbum([FromBody] DigitalAlbumOrderRequestModel requestModel)
        {
            try
            {
                var response = await _digitalalbumService.OrderAlbum(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("purchasedalbums")]
        public async Task<IActionResult> GetPurchasedAlbums([FromBody] PurchasedAlbumsRequestModel requestModel)
        {
            try
            {
                var response = await _digitalalbumService.GetPurchasedAlbums(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("albumsales")]
        public async Task<IActionResult> GetAlbumSales([FromBody] Int64[] albumIds)
        {
            try
            {
                var response = await _digitalalbumService.GetAlbumSales(albumIds);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
