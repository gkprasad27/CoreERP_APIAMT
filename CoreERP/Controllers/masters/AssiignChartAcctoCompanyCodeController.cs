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
    [Route("api/AssiignChartAcctoCompanyCode")]
    public class AssiignChartAcctoCompanyCodeController : ControllerBase
    {
        private readonly IRepository<TblAssignchartaccttoCompanycode> _acaRepository;
        public AssiignChartAcctoCompanyCodeController(IRepository<TblAssignchartaccttoCompanycode> acaRepository)
        {
            _acaRepository = acaRepository;
        }

        [HttpPost("RegisterAssiignChartAcctoCompanyCode")]
        public IActionResult RegisterAssiignChartAcctoCompanyCode([FromBody]TblAssignchartaccttoCompanycode coa)
        {
            if (coa == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (AssignmentofcoatocompcodeHelper.GetList(coa.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Assignmentofcoatocompcode Code {nameof(coa.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _acaRepository.Add(coa);
                if (_acaRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = coa };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAssiignChartAcctoCompanyCodeList")]
        public IActionResult GetAssiignChartAcctoCompanyCodeList()
        {
            try
            {
                var coaList = CommonHelper.GetChartofAccounttoCompany();
                if (coaList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.coaList = coaList;
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

        [HttpPut("UpdateAssiignChartAcctoCompanyCode")]
        public IActionResult UpdateAssiignChartAcctoCompanyCode([FromBody] TblAssignchartaccttoCompanycode coa)
        {
            if (coa == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(coa)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _acaRepository.Update(coa);
                if (_acaRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = coa };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAssiignChartAcctoCompanyCode/{code}")]
        public IActionResult DeleteAssiignChartAcctoCompanyCodebyID(int code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _acaRepository.Where(x => x.Code==code).FirstOrDefault();
                _acaRepository.Remove(record);
                if (_acaRepository.SaveChanges() > 0)
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