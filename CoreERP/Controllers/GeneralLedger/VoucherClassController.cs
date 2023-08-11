using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.GeneralLedger
{
    [ApiController]
    [Route("api/VoucherClass")]
    public class VoucherClassController : ControllerBase
    {
        private readonly IRepository<Voucherclass> _vcRepository;
        public VoucherClassController(IRepository<Voucherclass> vcRepository)
        {
            _vcRepository = vcRepository;
        }

        [HttpPost("RegisterVoucherClass")]
        public IActionResult RegisterVoucherClass([FromBody] Voucherclass vcclass)
        {
            if (vcclass == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (VoucherClassHelper.GetList(vcclass.VoucherKey).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"VocherClass Code {nameof(vcclass.VoucherKey)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _vcRepository.Add(vcclass);
                if (_vcRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = vcclass };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetVoucherClassList")]
        public IActionResult GetVoucherClassList()
        {
            try
            {
                var vcclassList = _vcRepository.GetAll();
                if (_vcRepository.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.vcList = vcclassList;
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

        [HttpPut("UpdateVoucherClass")]
        public IActionResult UpdateVoucherClass([FromBody] Voucherclass vcclass)
        {
            if (vcclass == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(vcclass)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _vcRepository.Update(vcclass);
                if (_vcRepository.SaveChanges()>0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = vcclass };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteVoucherClass/{code}")]
        public IActionResult DeleteVoucherClassByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _vcRepository.GetSingleOrDefault(x => x.VoucherKey.Equals(code));
                _vcRepository.Remove(record);
                if (_vcRepository.SaveChanges() > 0)
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