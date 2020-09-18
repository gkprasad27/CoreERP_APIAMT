using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;
namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/BinsCreation")]
    public class BinsCreationController : ControllerBase
    {

        private readonly IRepository<TblBinsCreation> _binsCreationRepository;
        public BinsCreationController(IRepository<TblBinsCreation> binsCreationRepository)
        {
            _binsCreationRepository = binsCreationRepository;
        }

        [HttpPost("RegisterBinsCreation")]
        public IActionResult RegisterBinsCreation([FromBody]TblBinsCreation bincreation)
        {
            if (bincreation == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _binsCreationRepository.Add(bincreation);
                if (_binsCreationRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = bincreation };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBinsCreationList")]
        public IActionResult GetBinsCreationList()
        {
            try
            {
                var bcList = _binsCreationRepository.GetAll();
                if (bcList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.bcList = bcList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateBinsCreation")]
        public IActionResult UpdateBinsCreation([FromBody] TblBinsCreation bincreation)
        {
            if (bincreation == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(bincreation)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _binsCreationRepository.Update(bincreation);
                if (_binsCreationRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = bincreation };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteBinsCreation/{code}")]
        public IActionResult DeleteBinsCreationbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _binsCreationRepository.GetSingleOrDefault(x => x.BinNumber.Equals(code));
                _binsCreationRepository.Remove(record);
                if (_binsCreationRepository.SaveChanges() > 0)
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