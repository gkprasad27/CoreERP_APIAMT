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
    [Route("api/masters/Pump")]
    public class PumpController : ControllerBase
    {
        [HttpPost("RegisterPump")]
        public async Task<IActionResult> RegisterPump([FromBody]TblPumps pumps)
        {
            APIResponse apiResponse = null;
            if (pumps == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                var result = new PumpHelpers().Register(pumps);
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


        [HttpGet("GetPumpList")]
        public async Task<IActionResult> GetPumpList()
        {
            try
            {
                var pumplist = new PumpHelpers().GetList();
                if (pumplist.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.pumplist = pumplist;
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
        }



        [HttpPut("UpdatePump")]
        public async Task<IActionResult> UpdatePump([FromBody] TblPumps pumps)
        {
            APIResponse apiResponse = null;
            if (pumps == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(pumps)} cannot be null" });

            try
            {
                var rs = new PumpHelpers().Update(pumps);
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


        [HttpDelete("DeletePump/{code}")]
        public async Task<IActionResult> DeletePump(string code)
        {
            APIResponse apiResponse = null;
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = new PumpHelpers().Delete(code);
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

        [HttpGet("GetProductGroups")]
        [Produces(typeof(List<MaterialGroup>))]
        public async Task<IActionResult> GetProductGroups()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.ProductGroupsList = new PumpHelpers().GetProductGroups().Select(pro => new { ID = pro.Code, TEXT = pro.GroupName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBranches")]
        [Produces(typeof(List<Branches>))]
        public async Task<IActionResult> GetBranches()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.BranchesList = new PumpHelpers().GetBranches().Select(pro => new { ID = pro.BranchCode, TEXT = pro.BranchName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBranchcodes/{branchname}")]
        public async Task<IActionResult> GetBranchcodes(string branchname)
        {
            try
            {
                if (branchname!=null)
                {
                    dynamic expdoObj = new ExpandoObject();
                   // expdoObj.branchcode = new PumpHelpers().GetBranchcodes(branchname).BranchCode;
                    expdoObj.branchcode = new PumpHelpers().GetBranchcodes(branchname).Select(bc => new { Name = bc.TankNo, Id = bc.BranchCode });
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
        }

        [HttpGet("GetProductGroupsNames/{code}")]
        public async Task<IActionResult> GetProductGroupsNames(string code)
        {
            try
            {
                dynamic expdoObj = new ExpandoObject();
                expdoObj.ProductGroupsName = new PumpHelpers().GetProductGroupsNames(code).Select(pg => new { Name = pg.GroupName, Id = pg.Code });
                //expando.ProductGroupsName = new PumpHelpers().GetProductGroupsNames(code).ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}