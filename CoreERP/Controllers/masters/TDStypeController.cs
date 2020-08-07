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
    [Route("api/TDStype")]
    public class TDStypeController : ControllerBase
    {
        private readonly IRepository<TblTdstypes> _tdstypeRepository;
        public TDStypeController(IRepository<TblTdstypes> tdstypeRepository)
        {
            _tdstypeRepository = tdstypeRepository;
        }

        [HttpPost("RegisterTDStype")]
        public IActionResult RegisterTDStype([FromBody]TblTdstypes tds)
        {
            if (tds == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (TdsTypeHelper.GetList(tds.TdsCode).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"tds Code {nameof(tds.TdsCode)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _tdstypeRepository.Add(tds);
                if (_tdstypeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = tds };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTDStypeList")]
        public IActionResult GetTDStypeList()
        {
            try
            {
                var tdsList = _tdstypeRepository.GetAll();
                if (tdsList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.tdsList = tdsList;
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

        [HttpPut("UpdateTDStype")]
        public IActionResult UpdateTDStype([FromBody] TblTdstypes code)
        {
            if (code == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _tdstypeRepository.Update(code);
                if (_tdstypeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = code };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteTDStype/{code}")]
        public IActionResult DeleteTDStypeByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _tdstypeRepository.GetSingleOrDefault(x => x.TdsCode.Equals(code));
                _tdstypeRepository.Remove(record);
                if (_tdstypeRepository.SaveChanges() > 0)
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