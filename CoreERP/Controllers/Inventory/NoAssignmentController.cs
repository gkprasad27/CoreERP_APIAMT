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
using System.Dynamic;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Inventory/NoAssignment")]
    public class NoAssignmentController : ControllerBase
    {
        [HttpPost("RegisterNoAssignment")]
        public async Task<IActionResult> RegisterNoAssignment([FromBody]NoAssignment noAssignment)
        {
            try
            {
                if(NoAssignmentHelper.GetNoAssignmentList(noAssignment.Code).Count > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $" code={noAssignment.Code} Already exists." });

                NoAssignment result = NoAssignmentHelper.RegisterNoAssignment(noAssignment);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = noAssignment });
                
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response =ex.Message });
            }

        }

        [HttpGet("GetNoAssignmentList")]
        public async Task<IActionResult> GetNoAssignmentList()
        {
            try
            {
                var noAssignmentList = NoAssignmentHelper.GetNoAssignmentList();
                if (noAssignmentList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.NoAssignmentList = noAssignmentList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAllCompanies")]
        [Produces(typeof(List<NoAssignment>))]
        public async Task<IActionResult> GetAllCompanies()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = CompaniesHelper.GetListOfCompanies() });
        }

        [HttpPut("UpdateNoAssignment")]
        [Produces(typeof(NoAssignment))]
        public async Task<IActionResult> UpdateNoAssignment([FromBody] NoAssignment noAssignments)
        {
            if (noAssignments == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(noAssignments)} cannot be null" });

          
            try
            {
                NoAssignment result = NoAssignmentHelper.UpdateNoAssignment(noAssignments);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response ="Updation Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response =ex.Message });
            }
        }


        [HttpDelete("DeleteNoAssignment/{code}")]
        [Produces(typeof(NoAssignment))]
        public async Task<IActionResult> DeleteNoAssignment(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                NoAssignment result = NoAssignmentHelper.DeleteNoAssignment(code);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = code });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("GetCompanysList")]
        public async Task<IActionResult> GetCompanysList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CompanysList = CompaniesHelper.GetListOfCompanies();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response =expando });
            } catch (Exception ex)
            {
                return Ok(new APIResponse() { status=APIStatus.FAIL.ToString(),response=ex.Message});
            }
        }

        [HttpGet("GetMaterialGroupList")]
        public async Task<IActionResult> GetMaterialGroupList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.MaterialGroupList = MaterialGroupHelper.GetMaterialGroupList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpGet("GetAllMaterialGroups")]
        //[Produces(typeof(List<NoAssignment>))]
        //public async Task<IActionResult> GetAllMaterialGroups()
        //{
        //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = MaterialGroupHelper.GetMaterialGroupList() });
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.MaterialGroupList = MaterialGroupHelper.GetMaterialGroupList();
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}
    }
}