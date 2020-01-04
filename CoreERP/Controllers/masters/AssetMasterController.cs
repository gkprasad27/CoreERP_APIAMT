using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/masters/AssetMaster")]
    public class AssetMasterController : ControllerBase
    {
       
        [HttpPost("RegisterAssetMaster")]
        public async Task<IActionResult> RegisterAssetMaster([FromBody]  AssetMaster assetMaster)//
        {
            APIResponse apiResponse = null;
            try
            {
                int result = AssetHelper.RegisterAssetMaster(assetMaster);
                if (result > 0)
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
                return BadRequest(" Registration Operation Failed");
            }

        }



        [HttpGet("GetAssetMasterList")]
        public async Task<IActionResult> GetAssetMasterList()
        {
            try
            {
                var assetmasterList = AssetHelper.GetList();
                dynamic expdoObj = new ExpandoObject();
                expdoObj.assetmasterList = assetmasterList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch
            {
                return BadRequest("No Data  Found");
            }
            //return Ok( new {

            //    assetmasterlist=AssetHelper.GetList()
            //    //glAssetAccts=_unitOfWork.GLAccounts.GetAll().Where(x=>x.Nactureofaccount == "FIXEDASSETS"),
            //    //noSeriesAssetRcd =(from nos in _unitOfWork.NoSeries.GetAll()
            //    //                   join pt  in _unitOfWork.PartnerType.GetAll()
            //    //                   on nos.PartnerType equals pt.Code
            //    //                   where pt.AccountType == "FIXEDASSETS"
            //    //                   select nos),
            //    ////branch =BrancheHelper.GetBranches(),
            //    //company =CompaniesHelper.GetListOfCompanies()
            //});
        }

        

        [HttpPut("UpdateAssetMaster/{code}")]
        public async Task<IActionResult> UpdateAssetMaster(string code, [FromBody]AssetMaster assetMaster)
        {
            APIResponse apiResponse = null;
            if (assetMaster == null)
                return BadRequest($"{nameof(assetMaster)} cannot be null");
            try
            {
                int rs = AssetHelper.UpdateAssetMaster(assetMaster);
                if (rs > 0)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);

            }
            catch(Exception ex)
            {
             return BadRequest($"{nameof(assetMaster)} Updation Failed");
            }  
        }


        [HttpDelete("DeleteAssetMaster/{code}")]
        public async Task<IActionResult> DeleteAssetMaster(string code)
        {
            APIResponse apiResponse = null;
            // Division division = null;
            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                int result = AssetHelper.DeleteAssetMaster(code);
                if (result > 0)
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
                return BadRequest("Delete Operation Failed");
            }
       }


    }
}
       
