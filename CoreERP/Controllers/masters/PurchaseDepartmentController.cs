using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/PurchaseDepartment")]
    public class PurchaseDepartmentController : ControllerBase
    {
        private readonly IRepository<TblPurchaseDepartment> _pdRepository;
        public PurchaseDepartmentController(IRepository<TblPurchaseDepartment> pdRepository)
        {
            _pdRepository = pdRepository;
        }

        [HttpPost("RegisterPurchaseDepartment")]
        public IActionResult RegisterPurchaseDepartment([FromBody]TblPurchaseDepartment prdept)
        {
            if (prdept == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (PurchaseDepartmentHelper.GetList(prdept.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"salesoffice Code {nameof(prdept.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _pdRepository.Add(prdept);
                if (_pdRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = prdept };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPurchaseDepartment")]
        public IActionResult GetPurchaseDepartment()
        {
            try
            {
                var prdeptList = _pdRepository.GetAll();
                if (prdeptList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.prdeptList = prdeptList;
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

        [HttpPut("UpdatePurchaseDepartment")]
        public IActionResult UpdatePurchaseDepartment([FromBody] TblPurchaseDepartment prdept)
        {
            if (prdept == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(prdept)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _pdRepository.Update(prdept);
                if (_pdRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = prdept };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePurchaseDepartment/{code}")]
        public IActionResult DeletePurchaseDepartmentByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _pdRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _pdRepository.Remove(record);
                if (_pdRepository.SaveChanges() > 0)
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