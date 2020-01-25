using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/gl/AsignmentAcctoAccClass")]
    public class AsignmentAcctoAccClassController : ControllerBase
    {
        [HttpPost("RegisterAsigAcctoAccClass")]
        public async Task<IActionResult> RegisterAsigAcctoAccClass([FromBody]AsignmentAcctoAccClass asignmentAcctoAccClass)
        {
            try
            {
                AsignmentAcctoAccClass result = GLHelper.RegisterAccToAccClass(asignmentAcctoAccClass);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAsigAcctoAccclassList")]
        public async Task<IActionResult> GetAsigAcctoAccclassList()
        {
            try
            {
                var asigAcctoAccclass = GLHelper.GetAsignAccToAccClas();
                if (asigAcctoAccclass.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.AsigAcctoAccclassList = asigAcctoAccclass;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

            //return Json(
            //    new
            //    {
            //        asigAcctoAccclass=_unitOfWork.AsignmentAcctoAccClass.GetAll(),
            //        glaccoutns=(from glacc  in   (from gacc in _unitOfWork.GLAccounts.GetAll() where gacc.Nactureofaccount !=null select gacc)
            //                    where glacc.Nactureofaccount == NatureOfAccounts.PURCHASES.ToString() ||
            //                          glacc.Nactureofaccount == NatureOfAccounts.SALES.ToString()  || 
            //                          glacc.Nactureofaccount == NatureOfAccounts.INVENTORY.ToString()
            //                    select glacc),
            //        accountingCLass = _unitOfWork.AccountingClass.GetAll(),
            //        maerialTransType =_unitOfWork.Mat_Tran_Types.GetAll(),
            //    });
        }
        
        [HttpGet("GetMatTranTypes")]
        public async Task<IActionResult> GetMatTranTypes()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.mattranstype = GLHelper.GetMatTranTypesList().Select(mat=> new { ID= mat.Code,TEXT=mat.Description});
                return Ok(new APIResponse{ status=APIStatus.PASS.ToString(),response= expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

      

        [HttpGet("GetAccountingClass")]
        public async Task<IActionResult> GetAccountingClass()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.AccountingclassList = GLHelper.GetAccountingClass().Select(acc=> new { ID=acc.Code,TEXT=acc.Description});
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateAccToAccClass")]
        public async Task<IActionResult> UpdateAccToAccClass([FromBody] AsignmentAcctoAccClass asignmentAcctoAccClass)
        {
            if (asignmentAcctoAccClass == null)
                return Ok(new APIResponse() {status=APIStatus.FAIL.ToString(),response= $"{nameof(asignmentAcctoAccClass)} cannot be null" });
            try
            {
                AsignmentAcctoAccClass result = GLHelper.UpdateAccToAccClass(asignmentAcctoAccClass);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response ="Updation Failed." });
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAccToAccClass")]
        public async Task<IActionResult> DeleteAccToAccClass(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                AsignmentAcctoAccClass result = GLHelper.DeleteAccToAccClass(code);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGLAccountGroupList")]
        public async Task<IActionResult> GetGLAccountGroupList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GLAccgroup = GLHelper.GetGLAccountGroupList().Select(glgrp=>new { ID=glgrp.GroupCode,TEXT=glgrp.GroupName});
                return Ok(new APIResponse(){status=APIStatus.PASS.ToString(),response=expando  });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetSalesGlAccounts")]
        public async Task<IActionResult> GetSalesGlAccounts()
        {

            try
            {
                dynamic expando = new ExpandoObject();
                expando.GLSalesAccounts = GLHelper.GetGLAccountsList(NATURESOFACCOUNTS.SALES).Select(x => new { ID = x.Glcode, TEXT = x.GlaccountName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPurchaseGlAccounts")]
        public async Task<IActionResult> GetPurchaseGlAccounts()
        {

            try
            {
                dynamic expando = new ExpandoObject();
                expando.GLPurchaseAccounts = GLHelper.GetGLAccountsList(NATURESOFACCOUNTS.PURCHASES).Select(x => new { ID = x.Glcode, TEXT = x.GlaccountName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetInventoryGlAccounts")]
        public async Task<IActionResult> GetInventoryGlAccounts()
        {

            try
            {
                dynamic expando = new ExpandoObject();
                expando.GLInventoryAccounts = GLHelper.GetGLAccountsList(NATURESOFACCOUNTS.INVENTORY).Select(x => new { ID = x.Glcode, TEXT = x.GlaccountName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpGet("GetGLAccountsList")]
        //public async Task<IActionResult> GetGLAccountsList()
        //{
        //    try
        //    {
        //        //var result = (from acc in _unitOfWork.GLAccounts.GetAll()
        //        //              where acc.Nactureofaccount == "Purchases" || acc.Nactureofaccount == "Sales" || acc.Nactureofaccount == " "
        //        //              select acc).ToList();

        //        dynamic expdo = new ExpandoObject();
        //        expdo.GLAccountsList = GLHelper.GetGLAccountsList()
        //                                .Where(acc => acc.Nactureofaccount.Equals("Purchases", StringComparison.OrdinalIgnoreCase)
        //                                           || acc.Nactureofaccount.Equals("Sales", StringComparison.OrdinalIgnoreCase) || acc.Nactureofaccount == " ").ToList();

        //            return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response= expdo });
        //    }
        //    catch(Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }

        //}
    }
}