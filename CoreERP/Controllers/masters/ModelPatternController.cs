using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/ModelPattern")]
    public class ModelPatternController : ControllerBase
    {
        private readonly IRepository<TblModelPattern> _modelPatternRepository;
        public ModelPatternController(IRepository<TblModelPattern> modelPatternRepository)
        {
            _modelPatternRepository = modelPatternRepository;
        }

        [HttpPost("RegisterModelPattern")]
        public IActionResult RegisterModelPattern([FromBody]TblModelPattern mpattern)
        {
            if (mpattern == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _modelPatternRepository.Add(mpattern);
                if (_modelPatternRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mpattern };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetModelPatternList")]
        public IActionResult GetModelPatternList()
        {
            try
            {
                var mpatternList = _modelPatternRepository.GetAll();
                if (mpatternList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.mpatternList = mpatternList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateModelPattern")]
        public IActionResult UpdateModelPattern([FromBody] TblModelPattern mpattern)
        {
            if (mpattern == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(mpattern)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _modelPatternRepository.Update(mpattern);
                if (_modelPatternRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mpattern };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteModelPattern/{code}")]
        public IActionResult DeleteModelPatternbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _modelPatternRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _modelPatternRepository.Remove(record);
                if (_modelPatternRepository.SaveChanges() > 0)
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