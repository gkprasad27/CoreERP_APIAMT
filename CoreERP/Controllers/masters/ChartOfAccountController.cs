using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/ChartOfAccount")]
    public class ChartOfAccountController : ControllerBase
    {
        private readonly IRepository<TblChartAccount> _caRepository;
        public ChartOfAccountController(IRepository<TblChartAccount> caRepository)
        {
            _caRepository = caRepository;
        }

        [HttpPost("RegisterChartOfAccount")]
        public IActionResult RegisterChartOfAccount([FromBody]TblChartAccount coa)
        {
            if (coa == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (ChartofaccountHelper.GetList(coa.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Chartofaccount Code {nameof(coa.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _caRepository.Add(coa);
                if (_caRepository.SaveChanges() > 0)
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

        [HttpGet("GetChartOfAccountList")]
        public IActionResult GetChartOfAccountList()
        {
            try
            {
                var coaList = _caRepository.GetAll();
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

        [HttpPut("UpdateChartOfAccount")]
        public IActionResult UpdateChartOfAccount([FromBody] TblChartAccount coa)
        {
            if (coa == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(coa)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _caRepository.Update(coa);
                if (_caRepository.SaveChanges() > 0)
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

        [HttpDelete("DeleteChartOfAccount/{code}")]
        public IActionResult DeleteChartOfAccountID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _caRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _caRepository.Remove(record);
                if (_caRepository.SaveChanges() > 0)
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