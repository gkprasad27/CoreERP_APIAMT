using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers
{

    [ApiController]
    [Route("api/Division")]
    public class DivisionController : ControllerBase
    {
        private readonly IRepository<Divisions> _divisionRepository;
        public DivisionController(IRepository<Divisions> divisionpcRepository)
        {
            _divisionRepository = divisionpcRepository;
        }

        [HttpPost("RegisterDivision")]
        public IActionResult RegisterDivision([FromBody]Divisions division)
        {
            if (division == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (DivisionHelper.GetList(division.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Division Code {nameof(division.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _divisionRepository.Add(division);
                if (_divisionRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = division };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetDivisionsList")]
        public IActionResult GetDivisionsList()
        {
            try
            {
                var divisionsList = CommonHelper.GetDivisions();
                if (divisionsList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.divisionsList = divisionsList;
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

        [HttpPut("UpdateDivision")]
        public IActionResult UpdateDivision([FromBody] Divisions division)
        {
            if (division == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(division)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _divisionRepository.Update(division);
                if (_divisionRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = division };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteDivision/{code}")]
        public IActionResult DeleteDivisionByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _divisionRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _divisionRepository.Remove(record);
                if (_divisionRepository.SaveChanges() > 0)
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
