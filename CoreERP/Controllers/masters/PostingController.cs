using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Posting")]
    public class PostingController : ControllerBase
    {
        private readonly IRepository<TblPosting> _postingRepository;
        public PostingController(IRepository<TblPosting> postingRepository)
        {
            _postingRepository = postingRepository;
        }

        [HttpPost("RegisterPosting")]
        public IActionResult RegisterPosting([FromBody]TblPosting post)
        {
            if (post == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (postingHelper.GetList(post.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Posting Code {nameof(post.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _postingRepository.Add(post);
                if (_postingRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = post };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPostingList")]
        public IActionResult GetPostingList()
        {
            try
            {
                var postingList = CommonHelper.GetPosting();
                if (postingList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.psList = postingList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatePosting")]
        public IActionResult UpdatePosting([FromBody] TblPosting post)
        {
            if (post == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(post)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _postingRepository.Update(post);
                if (_postingRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = post };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePosting/{code}")]
        public IActionResult DeletePostingByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _postingRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _postingRepository.Remove(record);
                if (_postingRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}