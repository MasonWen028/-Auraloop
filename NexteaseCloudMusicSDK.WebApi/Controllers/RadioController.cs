using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RadioController : Controller
    {
        private readonly IRadioService _radioService;
        private readonly RequestContext _context;

        public RadioController(IRadioService radioService, RequestContext context)
        {
            _radioService = radioService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet("banner")]
        public async Task<IActionResult> Banner()
        {
            try
            {
                var response = await _radioService.Banner();
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
        [HttpGet("categoryexcludehot")]
        public async Task<IActionResult> CategoryExcludeHot()
        {
            try
            {
                var response = await _radioService.CategoryExcludeHot();
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
        [HttpGet("categoryrecommend")]
        public async Task<IActionResult> CategoryRecommend()
        {
            try
            {
                var response = await _radioService.CategoryRecommend();
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
        [HttpGet("categorylist")]
        public async Task<IActionResult> CategoryList()
        {
            try
            {
                var response = await _radioService.CategoryList();
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
        [HttpGet("detail")]
        public async Task<IActionResult> Detail([FromQuery] Int64 rid)
        {
            try
            {
                var response = await _radioService.Detail(rid);
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
        [HttpPost("hot")]
        public async Task<IActionResult> Hot([FromBody] RadioHotRequestModel requestModel)
        {
            try
            {
                var response = await _radioService.Hot(requestModel);
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
        [HttpPost("paygift")]
        public async Task<IActionResult> PayGift([FromBody] RadioPayGiftRequestModel requestModel)
        {
            try
            {
                var response = await _radioService.PayGift(requestModel);
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
        [HttpGet("personalizedrecommend")]
        public async Task<IActionResult> PersonalizedRecommend([FromQuery] Int32 limit)
        {
            try
            {
                var response = await _radioService.PersonalizedRecommend(limit);
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
        [HttpPost("programs")]
        public async Task<IActionResult> Programs([FromBody] RadioProgramsRequestModel requestModel)
        {
            try
            {
                var response = await _radioService.Programs(requestModel);
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
        [HttpGet("programdetail")]
        public async Task<IActionResult> ProgramDetail([FromQuery] Int64 id)
        {
            try
            {
                var response = await _radioService.ProgramDetail(id);
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
        [HttpPost("programtoplist")]
        public async Task<IActionResult> ProgramToplist([FromBody] RadioProgramToplistRequestModel requestModel)
        {
            try
            {
                var response = await _radioService.ProgramToplist(requestModel);
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
        [HttpGet("programtoplistbyhour")]
        public async Task<IActionResult> ProgramToplistByHour([FromQuery] Int32 limit)
        {
            try
            {
                var response = await _radioService.ProgramToplistByHour(limit);
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
        [HttpPost("hotstations")]
        public async Task<IActionResult> HotStations([FromBody] RadioHotStationsRequestModel requestModel)
        {
            try
            {
                var response = await _radioService.HotStations(requestModel);
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
        [HttpGet("recommend")]
        public async Task<IActionResult> Recommend()
        {
            try
            {
                var response = await _radioService.Recommend();
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
        [HttpGet("recommendbytype")]
        public async Task<IActionResult> RecommendByType([FromQuery] Int64 cateId)
        {
            try
            {
                var response = await _radioService.RecommendByType(cateId);
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
        [HttpPost("subscription")]
        public async Task<IActionResult> Subscription([FromBody] RadioSubscriptionRequestModel requestModel)
        {
            try
            {
                var response = await _radioService.Subscription(requestModel);
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
        [HttpPost("subscriptions")]
        public async Task<IActionResult> Subscriptions([FromBody] RadioSubscriptionsRequestModel requestModel)
        {
            try
            {
                var response = await _radioService.Subscriptions(requestModel);
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
        [HttpPost("subscribers")]
        public async Task<IActionResult> Subscribers([FromBody] RadioSubscribersRequestModel requestModel)
        {
            try
            {
                var response = await _radioService.Subscribers(requestModel);
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
        [HttpGet("todaypreferred")]
        public async Task<IActionResult> TodayPreferred([FromQuery] Int32 page)
        {
            try
            {
                var response = await _radioService.TodayPreferred(page);
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
        [HttpPost("toplist")]
        public async Task<IActionResult> Toplist([FromBody] RadioToplistRequestModel requestModel)
        {
            try
            {
                var response = await _radioService.Toplist(requestModel);
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
        [HttpPost("trashsong")]
        public async Task<IActionResult> TrashSong([FromBody] RadioTrashSongRequestModel requestModel)
        {
            try
            {
                var response = await _radioService.TrashSong(requestModel);
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
        [HttpPost("like")]
        public async Task<IActionResult> Like([FromBody] RadioLikeRequestModel requestModel)
        {
            try
            {
                var response = await _radioService.Like(requestModel);
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
        [HttpPost("rankings")]
        public async Task<IActionResult> GetRadioRankings([FromBody] RadioRankingRequestModel requestModel)
        {
            try
            {
                var response = await _radioService.GetRadioRankings(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
