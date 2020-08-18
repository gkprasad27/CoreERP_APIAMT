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
    [Route("api/PartnerType")]
    public class PartnerTypeController : ControllerBase
    {
        private readonly IRepository<PartnerType> _ptRepository;
        public PartnerTypeController(IRepository<PartnerType> ptRepository)
        {
            _ptRepository = ptRepository;
        }

        [HttpPost("RegisterPartnerType")]
        public IActionResult RegisterPartnerType([FromBody]PartnerType ptype)
        {
            if (ptype == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (partnertypeHelper.GetList(ptype.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Assignmentofcoatocompcode Code {nameof(ptype.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _ptRepository.Add(ptype);
                if (_ptRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ptype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPartnerTypeList")]
        public IActionResult GetPartnerTypeList()
        {
            try
            {
                var ptypeList = _ptRepository.GetAll();
                if (ptypeList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.ptypeList = ptypeList;
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

        [HttpPut("UpdatePartnerType")]
        public IActionResult UpdatePartnerType([FromBody] PartnerType ptype)
        {
            if (ptype == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(ptype)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _ptRepository.Update(ptype);
                if (_ptRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ptype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePartnerType/{code}")]
        public IActionResult DeletePartnerTypebyID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _ptRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _ptRepository.Remove(record);
                if (_ptRepository.SaveChanges() > 0)
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