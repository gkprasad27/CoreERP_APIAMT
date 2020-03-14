using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/masters/TaxStructure")]
    public class TaxStructureController : ControllerBase
    {
        [HttpPost("RegisterTaxStructure")]
        public async Task<IActionResult> RegisterTaxStructure([FromBody]TblTaxStructure taxstructure)
        {
            APIResponse apiResponse = null;
            if (taxstructure == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //var taxstructurelist = new TaxgroupHelpers().GetList(taxstructure.TaxGroupCode);
                //if (taxstructurelist.Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"productpacking Code {nameof(taxstructurelist)} is already exists ,Please Use Different Code " });

                var result = new TaxstructureHelpers().Register(taxstructure);
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                }

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("GetTaxStructureList")]
        public async Task<IActionResult> GetTaxStructureList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                var TaxStructureList = new TaxstructureHelpers().GetList();
                expando.TaxStructureList = TaxStructureList;
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }



        [HttpPut("UpdateTaxStructure")]
        public async Task<IActionResult> UpdateTaxStructure([FromBody] TblTaxStructure taxstructure)
        {
            APIResponse apiResponse = null;
            if (taxstructure == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(taxstructure)} cannot be null" });

            try
            {
                var rs = new TaxstructureHelpers().Update(taxstructure);
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteTaxStructure/{code}")]
        public async Task<IActionResult> DeleteTaxStructure(string code)
        {
            APIResponse apiResponse = null;
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = new TaxstructureHelpers().Delete(code);
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTaxGroups")]
        [Produces(typeof(List<TblTaxGroup>))]
        public async Task<IActionResult> GetTaxGroups()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.TaxGroupsList = new TaxstructureHelpers().GetTaxGroups().Select(taxgrp => new { ID = taxgrp.TaxGroupCode, TEXT = taxgrp.TaxGroupName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPurchaseAccountss")]
        [Produces(typeof(List<TblAccountLedger>))]
        public async Task<IActionResult> GetPurchaseAccountss()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.PSGroupsList =new  TaxstructureHelpers().GetPurchaseAccountss().Select(taxgrp => new { ID = taxgrp.LedgerCode, TEXT = taxgrp.LedgerName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}