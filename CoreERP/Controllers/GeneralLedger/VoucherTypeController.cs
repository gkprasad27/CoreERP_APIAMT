using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/VoucherType")]
    public class VoucherTypeController : ControllerBase
    {
        private readonly IRepository<TblCompany> _companyRepository;
        private readonly IRepository<Branches> _branchRepository;
        private readonly IRepository<TblVoucherType> _vtRepository;
        public VoucherTypeController(IRepository<TblVoucherType> vtRepository, IRepository<TblCompany> companyRepository,IRepository<Branches>branchRepository)
        {
            _vtRepository = vtRepository;
            _companyRepository = companyRepository;
            _branchRepository = branchRepository;
        }

        [HttpGet("GetBranchesList")]
        public IActionResult GetBranchesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.BranchesList = _branchRepository.GetAll().Select(b => new { ID = b.BranchCode, TEXT = b.Name });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCompaniesList")]
        public IActionResult GetCompaniesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CompaniesList = _companyRepository.GetAll().Select(x => new { ID = x.CompanyCode, TEXT = x.CompanyName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetVoucherTypeList")]
        public IActionResult GetVoucherTypeList()
        {
            try
            {
                var vouchertypeList = CommonHelper.GetVoucherType();
                if (vouchertypeList.Count() > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.GLSubCodeList = vouchertypeList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterVoucherTypes")]
        public IActionResult RegisterVoucherTypes([FromBody] TblVoucherType vouhertype)
        {
            if (vouhertype == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                //if (GLHelper.GetVoucherTypeList(vouhertype.VoucherTypeId).Count > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Voucher Code ={vouhertype.VoucherTypeId} alredy exists." });

                APIResponse apiResponse;
                _vtRepository.Add(vouhertype);
                if (_vtRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = vouhertype });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }

        [HttpPut("UpdateVoucherTypes")]
        public IActionResult UpdateVoucherTypes([FromBody] TblVoucherType vouchertype)
        {
            if (vouchertype == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "Request cannot be null" });

            try
            {
                APIResponse apiResponse;
                _vtRepository.Update(vouchertype);
                if (_vtRepository.SaveChanges()>0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = vouchertype });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteVoucherTypes/{code}")]
        [Produces(typeof(VoucherTypes))]
        public IActionResult DeleteVoucherTypes(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                var record = _vtRepository.GetSingleOrDefault(x => x.VoucherTypeId.Equals(code));
                _vtRepository.Remove(record);
                if (_vtRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = record });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}