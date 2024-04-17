using CoreERP.DataAccess;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/AttendanceProcess")]
    public class AttendanceProcessController : Controller
    {
        private readonly IRepository<TblAttendanceDetails> _attendanceProcessRepositoryRepository;
        public AttendanceProcessController(IRepository<TblAttendanceDetails> AttendanceProcessRepository)
        {
            _attendanceProcessRepositoryRepository = AttendanceProcessRepository;
        }

        [HttpPost("RegisterAttendanceProcess")]
        public IActionResult RegisterAttendanceProcess([FromBody] TblAttendanceDetails capa)
        {
            if (capa == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(capa)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _attendanceProcessRepositoryRepository.Add(capa);
                if (_attendanceProcessRepositoryRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = capa };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Recored Added Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAttendanceDetails")]
        public IActionResult GetAttendanceDetails()
        {
            try
            {
                var CapaList = CommonHelper.GetAttendanceDetails();

                if (CapaList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.Attendance = CapaList;
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

        [HttpGet("GetAttendanceDetails/{EmpCode}")]
        public IActionResult GetAttendanceDetails(string EmpCode)
        {
            try
            {
                var CapaList = CommonHelper.GetAttendanceDetails(EmpCode);

                if (CapaList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.CapaDetailList = CapaList;
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

        [HttpPut("UpdateAttendanceProcess")]
        public IActionResult UpdateAttendanceProcess([FromBody] TblAttendanceDetails tad)
        {
            if (tad == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(tad)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _attendanceProcessRepositoryRepository.Update(tad);
                if (_attendanceProcessRepositoryRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = tad };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAttendanceProcess/{code}")]
        public IActionResult DeleteAttendanceProcess(int code)
        {
            try
            {
                APIResponse apiResponse;
                if (code == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });
                var record = _attendanceProcessRepositoryRepository.GetSingleOrDefault(x => x.ID.Equals(code));
                _attendanceProcessRepositoryRepository.Remove(record);
                if (_attendanceProcessRepositoryRepository.SaveChanges() > 0)
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