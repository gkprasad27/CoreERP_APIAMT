using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreERP.BussinessLogic.InventoryHelpers;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using CoreERP.DataAccess;

namespace CoreERP.Controllers
{
    [Authorize]
    [Route("api/Inventory/NoAssignment")]
    public class NoAssignmentController : ControllerBase
    {
        [HttpPost("RegisterNoAssignment")]
        public async Task<IActionResult> RegisterNoAssignment([FromBody]NoAssignment noAssignment)
        {
            try
            {
                int result = NoAssignmentHelper.RegisterNoAssignment(noAssignment);
                if (result > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = noAssignment });
                else
                    return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }

        }



        [HttpGet("GetAllNoAssignments")]
        [Produces(typeof(List<NoAssignment>))]
        public async Task<IActionResult> GetAllNoAssignments()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = NoAssignmentHelper.GetNoAssignmentList() });
        }

        [HttpGet("GetAllCompanies")]
        [Produces(typeof(List<NoAssignment>))]
        public async Task<IActionResult> GetAllCompanies()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = CompaniesHelper.GetListOfCompanies() });
        }

        [HttpGet("GetAllMaterialGroups")]
        [Produces(typeof(List<NoAssignment>))]
        public async Task<IActionResult> GetAllMaterialGroups()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = MaterialGroupHelper.GetMaterialGroupList() });
        }

        [HttpPut("UpdateNoAssignment/{code}")]
        [Produces(typeof(NoAssignment))]
        public async Task<IActionResult> UpdateNoAssignment(string code, [FromBody] NoAssignment noAssignments)
        {
            if (noAssignments == null)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(noAssignments)} cannot be null" });

            if (!string.IsNullOrWhiteSpace(noAssignments.Code) && code != noAssignments.Code)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Conflicting role id in parameter and model data" });


            try
            {
                int rs = NoAssignmentHelper.UpdateNoAssignment(noAssignments);
                if (rs > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = noAssignments });
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(noAssignments)} Updation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(noAssignments)} Updation Failed" });
            }
        }


        [HttpDelete("DeleteNoAssignment/{code}")]
        [Produces(typeof(NoAssignment))]
        public async Task<IActionResult> DeleteNoAssignment(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                int result = NoAssignmentHelper.DeleteNoAssignment(code);
                if (result > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = code });
                else
                    return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Delete Operation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Delete Operation Failed" });
            }


        }



        [HttpGet("GetAllCompanys")]
        [Produces(typeof(List<Companies>))]
        public async Task<IActionResult> GetAllCompanys()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = CompaniesHelper.GetListOfCompanies() });
        }

        [HttpGet("GetAllMaterialGroup")]
        [Produces(typeof(List<MaterialGroup>))]
        public async Task<IActionResult> GetAllMaterialGroup()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = MaterialGroupHelper.GetMaterialGroupList() });
        }

    }
}