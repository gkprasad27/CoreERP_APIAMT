using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.GeneralLedger
{
    [ApiController]
    [Route("api/AssignTaxacctoTaxcode")]
    public class AssignTaxacctoTaxcodeController : ControllerBase
    {
        private readonly IRepository<TblAssignTaxacctoTaxcode> _assitrateRepository;
        public AssignTaxacctoTaxcodeController(IRepository<TblAssignTaxacctoTaxcode> assitrateRepository)
        {
            _assitrateRepository = assitrateRepository;
        }

        [HttpPost("RegisterAssignTaxacctoTaxcode")]
        public IActionResult RegisterAssignTaxacctoTaxcode([FromBody]TblAssignTaxacctoTaxcode taxcode)
        {
            if (taxcode == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (AssignTaxacctoTaxcodeHelper.GetList(taxcode.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Ledger Code {nameof(taxcode.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _assitrateRepository.Add(taxcode);
                if (_assitrateRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = taxcode };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAssignTaxacctoTaxcodeList")]
        public IActionResult GetAssignTaxacctoTaxcodeList()
        {
            try
            {
                var taxcodeList = CommonHelper.GetTaxaccountsTaxcodes();
                if (taxcodeList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.taxcodesList = taxcodeList;
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

        [HttpPut("UpdateAssignTaxacctoTaxcode")]
        public IActionResult UpdateAssignTaxacctoTaxcode([FromBody] TblAssignTaxacctoTaxcode taxcode)
        {
            if (taxcode == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(taxcode)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _assitrateRepository.Update(taxcode);
                if (_assitrateRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = taxcode };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletAssignTaxacctoTaxcode/{code}")]
        public IActionResult DeletAssignTaxacctoTaxcodeByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _assitrateRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _assitrateRepository.Remove(record);
                if (_assitrateRepository.SaveChanges() > 0)
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