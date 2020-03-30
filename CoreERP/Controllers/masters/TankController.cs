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
    [Route("api/masters/Tank")]
    public class TankController : ControllerBase
    {
        [HttpPost("RegisterTank")]
        public async Task<IActionResult> RegisterTank([FromBody]TblTanks tanks)
        {
            var result = await Task.Run(() =>
            {
                APIResponse apiResponse = null;
                if (tanks == null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

                try
                {
                    var tanklist = new TankHelpers().GetList(tanks.TankNo);
                    if (tanklist.Count() > 0)
                    {
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"tank Code {nameof(tanklist)} is already exists ,Please Use Different Code " });
                    }
                    var result = new TankHelpers().Register(tanks);
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


        [HttpGet("GetTankList")]
        public async Task<IActionResult> GetTankList()
        {
            var result = await Task.Run(() =>
            {
                var tankList = new TankHelpers().GetList();
                if (tankList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.tankList = tankList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
            });
            return result;
        }



        [HttpPut("UpdateTank")]
        public async Task<IActionResult> UpdateTank([FromBody] TblTanks tanks)
        {
            var result = await Task.Run(() =>
            {
                APIResponse apiResponse = null;
                if (tanks == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(tanks)} cannot be null" });

                try
                {
                    var rs = new TankHelpers().Update(tanks);
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
            });
            return result;
        }


        [HttpDelete("DeleteTank/{code}")]
        public async Task<IActionResult> DeleteTank(string code)
        {
            var result = await Task.Run(() =>
            {
                APIResponse apiResponse = null;
                try
                {
                    if (code == null)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                    var rs = new TankHelpers().Delete(code);
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
            });
            return result;
        }

        //[HttpGet("GetBranches")]
        //[Produces(typeof(List<Branches>))]
        //public async Task<IActionResult> GetBranches()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.BranchesList = new TankHelpers().GetBranches().Select(pro => new { ID = pro.BranchCode, TEXT = pro.Address1 });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("Getbranchcode/{branchname}")]
        //public async Task<IActionResult> Getbranchcode(string branchname)
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.branchcode = new TankHelpers().Getbranchcodes(branchname).Select(bc => new { Name = bc.Address1, Id = bc.BranchCode });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}
    }
}