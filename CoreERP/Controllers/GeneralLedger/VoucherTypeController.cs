using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/VoucherType")]
    public class VoucherTypeController : ControllerBase
    {
       /* [HttpPost("gl/vt/register")]
        public async Task<IActionResult> Register([FromBody]VoucherTypes vouhertype)
        {
            try
            {
                int result = GLHelper.RegisterVoucherType(vouhertype);
                if (result > 0)
                    return Ok(vouhertype);
            }
            catch
            { }
            return BadRequest("Registration Failed");

        }



        [HttpGet("gl/vt")]
        public async Task<IActionResult> GetAllAccountSubGroup()
        {
            //return Json(new
            //{
            //    vouchertype = _unitOfWork.VoucherTypes.GetAll(),
            //    company =CompanyHelper.GetDistinctCompanyNames(this._unitOfWork),

            //});
            return Ok(
               new
               {
                   vouchertype = GLHelper.GetVoucherTypeList()
               });
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

        [HttpGet("gl/vt/getCompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                return Ok(new { companies = GLHelper.GetCompanies() });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load Companies.");
            }
        }

        [HttpGet("gl/vt/getVoucherClass")]
        public async Task<IActionResult> GetVoucherClass()
        {
            try
            {
                return Ok(new { voucherClass = GLHelper.GetVoucherClassList() });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load Voucher Class.");
            }
        }

        [HttpPut("gl/vt/{code}")]
        public async Task<IActionResult> UpdateVoucherTypes(string code, [FromBody] VoucherTypes vouchertype)
        {
            if (vouchertype == null)
                return BadRequest($"{nameof(vouchertype)} cannot be null");
            try
            {
                int result = GLHelper.UpdateVoucherType(vouchertype);
                if (result > 0)
                    return Ok(vouchertype);
            }
            catch { }

            return BadRequest("Updation Failed");
        }


        [HttpDelete("gl/vt/{code}")]
        [Produces(typeof(VoucherTypes))]
        public async Task<IActionResult> DeleteVoucherTypesByID(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                int result = GLHelper.DeleteVoucherType(code);
                if (result > 0)
                    return Ok(code);
            }
            catch { }

            return BadRequest("Delete Operation Failed");

        }*/
    }
}