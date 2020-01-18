using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/gl/VoucherType")]
    public class VoucherTypeController : ControllerBase
    {
        [HttpPost("RegisterVoucherTypes")]
        public async Task<IActionResult> RegisterVoucherTypes([FromBody]VoucherTypes vouhertype)
        {
           if (vouhertype == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                if (GLHelper.GetVoucherTypeList(vouhertype.VoucherCode).Count > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Voucher Code ={vouhertype.VoucherCode} alredy exists." });

                VoucherTypes result = GLHelper.RegisterVoucherType(vouhertype);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }

        [HttpGet("GetVoucherTypeList")]
        public async Task<IActionResult> GetVoucherTypeList()
        {
            try
            {
                var vouchertypeList = GLHelper.GetVoucherTypeList();
                if (vouchertypeList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.GLSubCodeList = vouchertypeList;
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("gl/vt/brchlst")]
        public async Task<IActionResult> GetAllBranches()
        {
            try
            {
                return Ok(new { branches = GLHelper.GetBranches()});
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load Branches.");
            }
        }

        [HttpGet("GetCompaniesList")]
        public async Task<IActionResult> GetCompaniesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CompaniesList = GLHelper.GetCompanies().Select(x => new { ID = x.CompanyCode, TEXT = x.Name });
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetVoucherClassList")]
        public async Task<IActionResult> GetVoucherClassList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.VoucherClassList = GLHelper.GetVoucherClassList().Select(x => new { ID = x.VoucherCode, TEXT = x.Ext2 });
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateVoucherTypes")]
        public async Task<IActionResult> UpdateVoucherTypes(string code, [FromBody] VoucherTypes vouchertype)
        {
             if (vouchertype == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response ="Request cannot be null" });

            try
            {
                VoucherTypes result = GLHelper.UpdateVoucherType(vouchertype);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("gl/vt/{code}")]
        [Produces(typeof(VoucherTypes))]
        public async Task<IActionResult> DeleteVoucherTypesByID(string code)
        {
             if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                VoucherTypes result = GLHelper.DeleteVoucherType(code);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}