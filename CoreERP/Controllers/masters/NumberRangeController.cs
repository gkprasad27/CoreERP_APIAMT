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
    [Route("api/NumberRange")]
    public class NumberRangeController : ControllerBase
    {
        private readonly IRepository<TblNumberRange> _bnoRepository;
        public NumberRangeController(IRepository<TblNumberRange> bnoRepository)
        {
            _bnoRepository = bnoRepository;
        }

        [HttpPost("RegisterNumberRange")]
        public IActionResult RegisterNumberRange([FromBody]TblNumberRange numrange)
        {
            if (numrange == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (NumberrangeHelper.GetList(numrange.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Numberrange Code {nameof(numrange.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _bnoRepository.Add(numrange);
                if (_bnoRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = numrange };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetNumberRangeList")]
        public IActionResult GetNumberRangeList()
        {
            try
            {
                var nrrList = _bnoRepository.GetAll();
                if (nrrList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.nrrList = nrrList;
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

        [HttpPut("UpdateNumberRange")]
        public IActionResult UpdateNumberRange([FromBody] TblNumberRange numrange)
        {
            if (numrange == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(numrange)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _bnoRepository.Update(numrange);
                if (_bnoRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = numrange };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteNumberRange/{code}")]
        public IActionResult DeleteNumberRangebyID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _bnoRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _bnoRepository.Remove(record);
                if (_bnoRepository.SaveChanges() > 0)
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