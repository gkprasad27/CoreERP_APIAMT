using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.transactionsHelpers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.Transactions
{
    [ApiController]
    [Route("api/transactions/MeterReading")]
    public class MeterReadingController : Controller
    {
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.BranchesList = new MeterReadingHelper().GetBranchesList().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetPump/{branchCode}")]
        public async Task<IActionResult> GetPump(string branchCode)
        {
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(branchCode))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.PumpList = new MeterReadingHelper().GetPumpList(branchCode).Select(x => new { ID = x.PumpNo, TEXT = x.PumpNo });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetMeterReadingList/{branchCode}/{role}")]
        public async Task<IActionResult> GetMeterReadingList(string branchCode,int role)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var meterRreadingList = new MeterReadingHelper().GetMeterReadingList(branchCode,role);
                    if (meterRreadingList.Count > 0)
                    {
                        dynamic expando = new ExpandoObject();
                        expando.MeterReadingList = meterRreadingList;
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPut("UpdateMeterReading")]
        public async Task<IActionResult> UpdateMeterReading([FromBody] TblMeterReading meterreading)
        {
            var result = await Task.Run(() =>
            {

                if (meterreading == null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(meterreading)} cannot be null" });
                try
                {
                    APIResponse apiResponse = null;

                    TblMeterReading result = new MeterReadingHelper().Update(meterreading);
                    if (result != null)
                    {
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                    }
                    else
                    {
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                    }
                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpDelete("DeleteMeterReading/{code}")]
        public async Task<IActionResult> DeleteMeterReading(int code)
        {
            var result = await Task.Run(() =>
            {
                APIResponse apiResponse = null;
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)}can not be null" });

                try
                {
                    var result = new MeterReadingHelper().Delete(code);
                    if (result != null)
                    {
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                    }
                    else
                    {
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                    }
                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }
        [HttpGet("GetShift/{userId}")]
        public async Task<IActionResult> GetShift(decimal userId)
        {
            var result = await Task.Run(() =>
            {
                if (userId == 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.ShiftList = new MeterReadingHelper().GetShift(userId).LastOrDefault();
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }
        [HttpPost("RegisterMeterReading")]
        public async Task<IActionResult> RegisterMeterReading([FromBody]TblMeterReading meterreading)
        {
            var result = await Task.Run(() =>
            {
                if (meterreading == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(meterreading)} cannot be null" });
                try
                {
                    var reponse = new MeterReadingHelper().Register(meterreading);
                    if (reponse != null)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = reponse });

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("GetOBFromPump/{branchCode}/{pumpNo}")]
        public async Task<IActionResult> GetOBFromPump(string branchCode,decimal pumpNo)
        {
            var result = await Task.Run(() =>
            {
                if (pumpNo==0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.OBList = new MeterReadingHelper().GetOBFromPump(branchCode,pumpNo).FirstOrDefault();
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

    }
}