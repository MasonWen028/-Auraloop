using Microsoft.AspNetCore.Mvc;
using NeteaseCloudMusicApi_SDK.Interfaces;
using NeteaseCloudMusicSDK.ApiClient.Models;

namespace NeteaseCloudMusicSDK.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        /// <summary>
        /// Retrieves detailed information about an artist.
        /// </summary>
        [HttpGet("details")]
        public async Task<IActionResult> GetArtistDetails([FromQuery] long artistId)
        {
            if (artistId <= 0)
                return BadRequest(new { Error = "Invalid artist ID." });

            try
            {
                var response = await _artistService.GetArtistDetails(artistId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves the description of an artist.
        /// </summary>
        [HttpGet("description")]
        public async Task<IActionResult> GetArtistDescription([FromQuery] long artistId)
        {
            if (artistId <= 0)
                return BadRequest(new { Error = "Invalid artist ID." });

            try
            {
                var response = await _artistService.GetArtistDescription(artistId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves the fan count of an artist.
        /// </summary>
        [HttpGet("fans/count")]
        public async Task<IActionResult> GetArtistFansCount([FromQuery] long artistId)
        {
            if (artistId <= 0)
                return BadRequest(new { Error = "Invalid artist ID." });

            try
            {
                var response = await _artistService.GetArtistFansCount(artistId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves music videos (MVs) by an artist.
        /// </summary>
        [HttpPost("mvs")]
        public async Task<IActionResult> GetArtistMVs([FromBody] ArtistMvRequestModel requestModel)
        {
            if (requestModel.ArtistId <= 0)
                return BadRequest(new { Error = "Invalid artist ID." });

            try
            {
                var response = await _artistService.GetArtistMVs(requestModel.ArtistId, requestModel.Limit, requestModel.Offset);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves filtered artists based on the provided criteria.
        /// </summary>
        [HttpPost("filtered")]
        public async Task<IActionResult> GetFilteredArtists([FromBody] ArtistListRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "The request model is required." });

            try
            {
                var response = await _artistService.GetFilteredArtists(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves dynamic details about an artist.
        /// </summary>
        [HttpGet("dynamic")]
        public async Task<IActionResult> GetDynamicArtistDetails([FromQuery] long artistId)
        {
            if (artistId <= 0)
                return BadRequest(new { Error = "Invalid artist ID." });

            try
            {
                var response = await _artistService.GetDynamicArtistDetails(artistId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves the top songs of an artist.
        /// </summary>
        [HttpGet("top/songs")]
        public async Task<IActionResult> GetTopSongsByArtist([FromQuery] long artistId)
        {
            if (artistId <= 0)
                return BadRequest(new { Error = "Invalid artist ID." });

            try
            {
                var response = await _artistService.GetTopSongsByArtist(artistId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves videos associated with an artist.
        /// </summary>
        [HttpPost("videos")]
        public async Task<IActionResult> GetArtistVideos([FromBody] ArtistVideoRequestModel requestModel)
        {
            if (requestModel.ArtistId <= 0)
                return BadRequest(new { Error = "Invalid artist ID." });

            try
            {
                var response = await _artistService.GetArtistVideos(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves new songs by an artist.
        /// </summary>
        [HttpPost("songs/new")]
        public async Task<IActionResult> GetNewSongsByArtist([FromBody] ArtistNewSongRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "The request model is required." });

            try
            {
                var response = await _artistService.GetNewSongsByArtist(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves new MVs by an artist.
        /// </summary>
        [HttpPost("mvs/new")]
        public async Task<IActionResult> GetNewMVs([FromBody] ArtistNewMvRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "The request model is required." });

            try
            {
                var response = await _artistService.GetNewMVs(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves a list of songs by an artist with sorting and pagination options.
        /// </summary>
        [HttpPost("songs")]
        public async Task<IActionResult> GetSongsByArtist([FromBody] ArtistSongsRequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest(new { Error = "The request model is required." });

            if (requestModel.ArtistId <= 0)
                return BadRequest(new { Error = "Invalid artist ID." });

            try
            {
                var response = await _artistService.GetSongsByArtist(requestModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
