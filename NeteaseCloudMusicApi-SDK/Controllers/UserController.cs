using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace NeteaseCloudMusicApi_SDK.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly GenericService _genericService;

        public UserController(GenericService genericService)
        {
            _genericService = genericService;
        }

        [HttpPost]
        [Route("user/account")]
        public async Task<IActionResult> UserAccount()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/nuser/account/get",
                    OptionType = "weapi",
                    Data = new UserAccountRequestModel()
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
        [Route("user/audio")]
        public async Task<IActionResult> UserAudio()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/djradio/get/byuser",
                    OptionType = "weapi",
                    Data = new UserAudioRequestModel()
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
        [Route("user/binding")]
        public async Task<IActionResult> UserBinding()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/user/bindings/${query.uid}",
                    OptionType = "weapi",
                    Data = new UserBindingRequestModel()
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
        [Route("user/bindingcellphone")]
        public async Task<IActionResult> UserBindingcellphone()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/bindingCellphone",
                    OptionType = "weapi",
                    Data = new UserBindingcellphoneRequestModel()
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
        [Route("user/cloud")]
        public async Task<IActionResult> UserCloud([FromQuery]int limit = 30, [FromQuery]int offset = 0)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/cloud/get",
                    OptionType = "weapi",
                    Data = new UserCloudRequestModel()
                    {
                       Limit = limit,
                       Offset = offset
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
        [Route("user/cloud/del")]
        public async Task<IActionResult> UserCloudDel([FromQuery]long id)
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/cloud/del",
                    OptionType = "weapi",
                    Data = new UserCloudDelRequestModel()
                    {
                        SongIds = new long[] { id}
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
        [Route("user/cloud/detail")]
        public async Task<IActionResult> UserCloudDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/cloud/get/byids",
                    OptionType = "weapi",
                    Data = new UserCloudDetailRequestModel()
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
        [Route("user/comment/history")]
        public async Task<IActionResult> UserCommentHistory()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/comment/user/comment/history",
                    OptionType = "weapi",
                    Data = new UserCommentHistoryRequestModel()
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
        [Route("user/detail")]
        public async Task<IActionResult> UserDetail()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/user/detail/${query.uid}",
                    OptionType = "weapi",
                    Data = new UserDetailRequestModel()
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
        [Route("user/dj")]
        public async Task<IActionResult> UserDj()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/dj/program/${query.uid}",
                    OptionType = "weapi",
                    Data = new UserDjRequestModel()
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
        [Route("user/event")]
        public async Task<IActionResult> UserEvent()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/event/get/${query.uid}",
                    OptionType = "weapi",
                    Data = new UserEventRequestModel()
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
        [Route("user/followeds")]
        public async Task<IActionResult> UserFolloweds()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/getfolloweds/${query.uid}",
                    OptionType = "weapi",
                    Data = new UserFollowedsRequestModel()
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
        [Route("user/follows")]
        public async Task<IActionResult> UserFollows()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/getfollows/${query.uid}",
                    OptionType = "weapi",
                    Data = new UserFollowsRequestModel()
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
        [Route("user/follow/mixed")]
        public async Task<IActionResult> UserFollowMixed()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/follow/users/mixed/get/v2",
                    OptionType = "weapi",
                    Data = new UserFollowMixedRequestModel()
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
        [Route("user/level")]
        public async Task<IActionResult> UserLevel()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/level",
                    OptionType = "weapi",
                    Data = new UserLevelRequestModel()
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
        [Route("user/medal")]
        public async Task<IActionResult> UserMedal()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/medal/user/page",
                    OptionType = "weapi",
                    Data = new UserMedalRequestModel()
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
        [Route("user/mutualfollow/get")]
        public async Task<IActionResult> UserMutualfollowGet()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/mutualfollow/get",
                    OptionType = "weapi",
                    Data = new UserMutualfollowGetRequestModel()
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
        [Route("user/playlist")]
        public async Task<IActionResult> UserPlaylist()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/playlist",
                    OptionType = "weapi",
                    Data = new UserPlaylistRequestModel()
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
        [Route("user/record")]
        public async Task<IActionResult> UserRecord()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/v1/play/record",
                    OptionType = "weapi",
                    Data = new UserRecordRequestModel()
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
        [Route("user/replacephone")]
        public async Task<IActionResult> UserReplacephone()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/replaceCellphone",
                    OptionType = "weapi",
                    Data = new UserReplacephoneRequestModel()
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
        [Route("user/social/status")]
        public async Task<IActionResult> UserSocialStatus()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/social/user/status",
                    OptionType = "weapi",
                    Data = new UserSocialStatusRequestModel()
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
        [Route("user/social/status/edit")]
        public async Task<IActionResult> UserSocialStatusEdit()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/social/user/status/edit",
                    OptionType = "weapi",
                    Data = new UserSocialStatusEditRequestModel()
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
        [Route("user/social/status/rcmd")]
        public async Task<IActionResult> UserSocialStatusRcmd()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/social/user/status/rcmd",
                    OptionType = "weapi",
                    Data = new UserSocialStatusRcmdRequestModel()
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
        [Route("user/social/status/support")]
        public async Task<IActionResult> UserSocialStatusSupport()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/social/user/status/support",
                    OptionType = "weapi",
                    Data = new UserSocialStatusSupportRequestModel()
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
        [Route("user/subcount")]
        public async Task<IActionResult> UserSubcount()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/subcount",
                    OptionType = "weapi",
                    Data = new UserSubcountRequestModel()
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
        [Route("user/update")]
        public async Task<IActionResult> UserUpdate()
        {
            try
            {
                var apiModel = new ApiModel
                {
                    ApiEndpoint = "/api/user/profile/update",
                    OptionType = "weapi",
                    Data = new UserUpdateRequestModel()
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
