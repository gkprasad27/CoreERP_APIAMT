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
    [Route("api/OpenLedger")]
    public class OpenLedgerController : ControllerBase
    {
        [HttpPost("RegisterOpenLedger")]
        public IActionResult RegisterOpenLedger([FromBody]TblOpenLedger opnldgr)
        {
            if (opnldgr == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                //if (GLHelper.GetList(opnldgr.LedgerKey).Count > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Ledger Code ={opnldgr.LedgerKey} alredy exists." });

                TblOpenLedger result = GLHelper.Register(opnldgr);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetOpenLedgerList")]
        public IActionResult GetOpenLedgerList()
        {
            try
            {
                var openledgerList = GLHelper.GetList();
                //if (openledgerList.Count > 0)
                //{
                    dynamic expando = new ExpandoObject();
                    expando.OpenLedgerList = openledgerList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                //}

                //return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }


        [HttpPut("UpdateOpenLedgerList")]
        public IActionResult UpdateOpenLedgerList([FromBody] TblOpenLedger ledger)
        {
            if (ledger == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(ledger)} cannot be null" });

            try
            {
                TblOpenLedger result = GLHelper.Update(ledger);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteOpenLedgerList/{code}")]
        public IActionResult DeleteOpenLedgerList(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                TblOpenLedger result = GLHelper.DeleteOpenLedger(code);
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