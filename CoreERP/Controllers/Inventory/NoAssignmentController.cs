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
        public IActionResult RegisterNoAssignment([FromBody]NoAssignment noAssignment)
        {
            try
            {
                if (NoAssignmentHelper.GetNoAssignmentList(noAssignment.Code).Count > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $" code={noAssignment.Code} Already exists." });

                NoAssignment result = NoAssignmentHelper.RegisterNoAssignment(noAssignment);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }

        [HttpPut("UpdateNoAssignment")]
        [Produces(typeof(NoAssignment))]
        public IActionResult UpdateNoAssignment([FromBody] NoAssignment noAssignments)
        {
            if (noAssignments == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(noAssignments)} cannot be null" });


            try
            {
                NoAssignment result = NoAssignmentHelper.UpdateNoAssignment(noAssignments);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteNoAssignment/{code}")]
        [Produces(typeof(NoAssignment))]
        public IActionResult DeleteNoAssignment(string code)
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

        [HttpGet("GetNoAssignmentList")]
        public IActionResult GetNoAssignmentList()
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

        [HttpGet("GetCompanysList")]
        public IActionResult GetCompanysList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CompanysList = CompaniesHelper.GetListOfCompanies().Select(comp => new { ID = comp.CompanyCode, TEXT = comp.Name });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMaterialGroupList")]
        public IActionResult GetMaterialGroupList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.MaterialGroupList = MaterialGroupHelper.GetMaterialGroupList().Select(matgrp => new { ID = matgrp.Code, TEXT = matgrp.GroupName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetNumberTypes")]
        public IActionResult GetNumberTypes()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.NumberTypesList = NoAssignmentHelper.GetNumberTypes().Select(notype => new { ID = notype.ToString(), TEXT = notype.ToString() });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}