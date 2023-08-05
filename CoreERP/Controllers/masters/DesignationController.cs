using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Designation")]
    public class DesignationController : ControllerBase
    {

        private readonly IRepository<TblDesignation> _designationRepository;

        public DesignationController(IRepository<TblDesignation> designationRepository)
        {
            _designationRepository = designationRepository;
        }

        [HttpPost("RegisterDesignation")]
        public IActionResult RegisterDesignation([FromBody] TblDesignation designation)
        {
            if (designation == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(designation)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _designationRepository.Add(designation);
                if (_designationRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = designation };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetDesignationsList")]
        public IActionResult GetDesignationsList()
        {
            try
            {
                var designationList = CommonHelper.GetDesignation();
                if (designationList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.designationsList = designationList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateDesignation")]
        public IActionResult UpdateDesignation([FromBody] TblDesignation designation)
        {

            if (designation == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(designation)} cannot be null" });
            try
            {
                APIResponse apiResponse;

                _designationRepository.Update(designation);
                if (_designationRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = designation };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteDesignation/{code}")]
        public IActionResult DeleteDesignation(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)}can not be null" });

                APIResponse apiResponse;
                var record = _designationRepository.GetSingleOrDefault(x => x.DesignationName.Equals(code));
                _designationRepository.Remove(record);
                if (_designationRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}