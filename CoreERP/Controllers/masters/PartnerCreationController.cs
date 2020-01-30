using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/masters/PartnerCreation")]
    public class PartnerCreationController : ControllerBase
    {
        //
        [HttpPost("RegisterCreation")]
        public async Task<IActionResult> RegisterCreation([FromBody]PartnerCreation partnercreation)
        {
            try
            {
                var result = PartnerCreationHelper.RegisterPartnerCreation(partnercreation);
                if (result !=null)
                    return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response= result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPartnerCreationList")]
        public async Task<IActionResult> GetPartnerCreationList()
        {

            try
            {
                var partnerCreationList = PartnerCreationHelper.GetList();
                if (partnerCreationList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.partnerCreationList = partnerCreationList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatePartnerCreation")]
        [Produces(typeof(PartnerCreation))]
        public async Task<IActionResult> UpdatePartnerCreation([FromBody] PartnerCreation partnercreation)
        {
            if (partnercreation == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(partnercreation)} cannot be null" });


            try
            {
                var rs = PartnerCreationHelper.UpdatePartnerCreation(partnercreation);
                if (rs != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = rs });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }            
        }


        [HttpDelete("DeletePartnerCreation/{code}")]
        public async Task<IActionResult> DeletePartnerCreation(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                var result = PartnerCreationHelper.DeletePartnerCreation(code);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBalanceTypes")]
        public async Task<IActionResult> GetBalanceTypes()
        {
            try
            {
                var balanceTypeList = PartnerCreationHelper.GetBalanceType();
                if (balanceTypeList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.partnerCreationList = balanceTypeList.Select(n => new { ID = n, Text = n }); ;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Blance Type not configured." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetNatureList")]
        public async Task<IActionResult> GetNatureList()
        {
            try
            {
                var natureList = PartnerCreationHelper.GetNatureList();
                if (natureList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.partnerCreationList = natureList.Select(n=>new {ID=n,Text=n });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Nature Value not configured." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
       
        [HttpGet("GetGlAccounts")]
        public async Task<IActionResult> GetGlAccounts()
        {
            try
            {
                var glAccountList = PartnerCreationHelper.GetGlaccounts();
                if (glAccountList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.glAccountList = glAccountList.Select(n => new { ID = n.Glcode, Text = n.GlaccountName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "NO Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPartnerTypes")]
        public async Task<IActionResult> GetPartnerTypes()
        {
            try
            {
                var partnerTypeList = PartnerCreationHelper.GetPartnerTypes();
                if (partnerTypeList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.partnerTypeList = partnerTypeList.Select(n => new { ID = n.Code, Text = n.Description });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            try
            {
                var branchesList = PartnerCreationHelper.GetBranches();
                if (branchesList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.branchesList = branchesList.Select(n => new { ID = n.BranchCode, Text = n.Name });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCompaniesList")]
        public async Task<IActionResult> GetCompaniesList()
        {
            try
            {
                var companiesList = PartnerCreationHelper.GetCompanies();
                if (companiesList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.companiesList = companiesList.Select(n => new { ID = n.CompanyCode, Text = n.Name });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
