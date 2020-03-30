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
    [Route("api/masters/Unit")]
    public class UnitController : ControllerBase
    {
        [HttpPost("RegisterUnit")]
        public async Task<IActionResult> RegisterUnit([FromBody]TblUnit unit)
        {
            var result = await Task.Run(() =>
            {
                APIResponse apiResponse = null;
                if (unit == null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

                try
                {
                    var unitlist = new UnitHelpers().GetList(unit.UnitName);
                    if (unitlist.Count() > 0)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"unit Code {nameof(unitlist)} is already exists ,Please Use Different Code " });

                    var result = new UnitHelpers().Register(unit);
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
            });
            return result;
        }


        [HttpGet("GetUnitList")]
        public async Task<IActionResult> GetUnitList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var unitList = new UnitHelpers().GetList();
                    if (unitList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.unitList = unitList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                    {
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
                //try
                //{
                //    dynamic expando = new ExpandoObject();
                //    var unitList = new UnitHelpers().GetList();
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                //}
                //catch (Exception ex)
                //{
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                //}
            });
            return result;
        }



        [HttpPut("UpdateUnit")]
        public IActionResult UpdateUnit([FromBody] TblUnit unit)
        {
            APIResponse apiResponse = null;
            if (unit == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(unit)} cannot be null" });

            try
            {
                var rs = new UnitHelpers().Update(unit);
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


        [HttpDelete("DeleteUnit/{code}")]
        public IActionResult DeleteUnit(string code)
        {
            APIResponse apiResponse = null;
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = new UnitHelpers().Delete(code);
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
    }
}