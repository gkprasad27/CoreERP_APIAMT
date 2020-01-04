using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/AsignmentAcctoAccClass")]
    public class AsignmentAcctoAccClassController : ControllerBase
    {
        [HttpPost("generalledger/asigAccAccclass/register")]
        public async Task<IActionResult> Register([FromBody]AsignmentAcctoAccClass asignmentAcctoAccClass)
        {
            try
            {
                int result = GLHelper.RegisterAccToAccClass(asignmentAcctoAccClass);
                if (result > 0)
                    return Ok(asignmentAcctoAccClass);

                return BadRequest(" Registration Operation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest(" Registration Operation Failed");
            }

        }

        [HttpGet("generalledger/asigAccAccclass")]
        public async Task<IActionResult> GetAll()
        {
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
            return Ok(
               new
               {
                   asigAcctoAccclass = GLHelper.GetAsignAccToAccClas(),
                   //        glaccoutns=(from glacc  in   (from gacc in _unitOfWork.GLAccounts.GetAll() where gacc.Nactureofaccount !=null select gacc)
                   //                    where glacc.Nactureofaccount == NatureOfAccounts.PURCHASES.ToString() ||
                   //                          glacc.Nactureofaccount == NatureOfAccounts.SALES.ToString()  || 
                   //                          glacc.Nactureofaccount == NatureOfAccounts.INVENTORY.ToString()
                   //                    select glacc),      GetInvPurchaseSalesGLAcc()
               });
        }

        [HttpGet("generalledger/asigAccAccclass/getMatTranTypes")]
        public async Task<IActionResult> GetMatTranTypes()
        {
            try
            {
                return Ok(new { mattranstype = GLHelper.GetMatTranTypesList()});
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load MatTranTypes.");
            }
        }

        [HttpGet("generalledger/asigAccAccclass/getInvPurchaseSalesGLAcc")]
        public async Task<IActionResult> GetInvPurchaseSalesGLAcc()
        {
            try
            {
                return Ok(new { glaccounts = GLHelper.GetInvPurchaseSalesGLAcc() });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load GL Accounts.");
            }
        }

        [HttpGet("generalledger/asigAccAccclass/getAccountingClass")]
        public async Task<IActionResult> GetAccountingClass()
        {
            try
            {
                return Ok(new { accountingclass = GLHelper.GetAccountingClass() });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load Accounting Class.");
            }
        }

        [HttpPut("generalledger/asigAccAccclass/{code}")]
        public async Task<IActionResult> UpdateTaxIntegration(string code, [FromBody] AsignmentAcctoAccClass asignmentAcctoAccClass)
        {
            if (asignmentAcctoAccClass == null)
                return BadRequest($"{nameof(asignmentAcctoAccClass)} cannot be null");

            if (!string.IsNullOrWhiteSpace(asignmentAcctoAccClass.Code) && code != asignmentAcctoAccClass.Code)
                return BadRequest("Conflicting role id in parameter and model data");

            try
            {
                int result = GLHelper.UpdateAccToAccClass(asignmentAcctoAccClass);
                if (result > 0)
                    return Ok(asignmentAcctoAccClass);
            }
            catch { }

            return BadRequest("Updation Failed");
        }


        [HttpDelete("generalledger/asigAccAccclass/{code}")]
        public async Task<IActionResult> DeleteTaxIntegrationByID(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                int result = GLHelper.DeleteAccToAccClass(code);
                if (result > 0)
                    return Ok(code);
            }
            catch { }

            return BadRequest("Delete Operation Failed");

        }


        [HttpGet("generalledger/asigAccAccclass/acclst")]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                //var result = (from acc in _unitOfWork.GLAccounts.GetAll()
                //              where acc.Nactureofaccount == "Purchases" || acc.Nactureofaccount == "Sales" || acc.Nactureofaccount == " "
                //              select acc).ToList();
                var result = GLHelper.GetGLAccountsList()
                                    .Where(acc => acc.Nactureofaccount.Equals("Purchases", StringComparison.OrdinalIgnoreCase)
                                               || acc.Nactureofaccount.Equals("Sales", StringComparison.OrdinalIgnoreCase) || acc.Nactureofaccount == " ").ToList();

                return Ok(result);
            }
            catch
            {
                return NoContent();
            }

        }


        [HttpGet("generalledger/asigAccAccclass/accinglst")]
        public async Task<IActionResult> GetAccounting()
        {
            try
            {
                return Ok(new { GLAccgroup = GLHelper.GetGLAccountGroupList() });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load Branches.");
            }

        }

    }
}