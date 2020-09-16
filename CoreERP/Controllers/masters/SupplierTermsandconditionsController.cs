using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/SupplierTermsandconditions")]
    public class SupplierTermsandconditionsController : ControllerBase
    {
        private readonly IRepository<TblSupplierTermsAndConditons> _supplierTermsAndConditonsRepository;
        public SupplierTermsandconditionsController(IRepository<TblSupplierTermsAndConditons> supplierTermsAndConditonsRepository)
        {
            _supplierTermsAndConditonsRepository = supplierTermsAndConditonsRepository;
        }

        [HttpPost("RegisterSupplierTermsandconditions")]
        public IActionResult RegisterSupplierTermsandconditions([FromBody]TblSupplierTermsAndConditons suppliers)
        {
            if (suppliers == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _supplierTermsAndConditonsRepository.Add(suppliers);
                if (_supplierTermsAndConditonsRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = suppliers };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetSupplierTermsandconditionsList")]
        public IActionResult GetSupplierTermsandconditionsList()
        {
            try
            {
                var suppliersList = _supplierTermsAndConditonsRepository.GetAll();
                if (suppliersList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.suppliersList = suppliersList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateSupplierTermsandconditions")]
        public IActionResult UpdateSupplierTermsandconditions([FromBody] TblSupplierTermsAndConditons suppliers)
        {
            if (suppliers == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(suppliers)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _supplierTermsAndConditonsRepository.Update(suppliers);
                if (_supplierTermsAndConditonsRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = suppliers };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteSupplierTermsandconditions/{code}")]
        public IActionResult DeleteSupplierTermsandconditionsbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _supplierTermsAndConditonsRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _supplierTermsAndConditonsRepository.Remove(record);
                if (_supplierTermsAndConditonsRepository.SaveChanges() > 0)
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