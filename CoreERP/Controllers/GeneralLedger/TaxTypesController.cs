using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/TaxTypes")]
    public class TaxTypesController : ControllerBase
    {
        [HttpPost("RegisterTaxTypes")]
        public IActionResult RegisterTaxTypes([FromBody]TblTaxtypes taxtype)
        {
            if (taxtype == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                if (GLHelper.GetTblTaxtypesList(taxtype.TaxKey).Count > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Tax Code ={taxtype.TaxKey} alredy exists." });

                TblTaxtypes result = GLHelper.RegisterTblTaxtypes(taxtype);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTaxTypesList")]
        public IActionResult GetTaxTypesList()
        {
            try
            {
                var taxtypesList = GLHelper.GetTblTaxtypesList();
                if (taxtypesList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.TaxtypesList = taxtypesList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
            
        }
       

        [HttpPut("UpdateTaxTypes")]
        public IActionResult UpdateTaxTypes([FromBody] TblTaxtypes taxtypes)
        {
            if (taxtypes == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(taxtypes)} cannot be null" });

            try
            {
                TblTaxtypes result = GLHelper.UpdateTblTaxtypes(taxtypes);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteTaxTypes/{code}")]
        public IActionResult DeleteTaxTypes(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                TblTaxtypes result = GLHelper.DeleteTblTaxtypes(code);
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

