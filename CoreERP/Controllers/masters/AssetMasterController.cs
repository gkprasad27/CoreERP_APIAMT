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
        public async Task<IActionResult> RegisterAssetMaster([FromBody]  AssetMaster assetMaster)
        {
           
            try
            {
                APIResponse apiResponse = null;

                if (AssetHelper.GetList(assetMaster.AssetNo) != null)
                    return Ok(new APIResponse() { status=APIStatus.FAIL.ToString(),response=$"AssetNo ={assetMaster.AssetNo} Aready Exists."});

                var result = AssetHelper.RegisterAssetMaster(assetMaster);
                if (result !=null)
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
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response =ex.Message});
            }

        }

        [HttpGet("GetAssetMasterList")]
        public async Task<IActionResult> GetAssetMasterList()
        {
            try
            {
                var assetmasterList = AssetHelper.GetList();
                if (assetmasterList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assetmasterList = assetmasterList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = "No Data  Found" });
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = ex.Message });
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

        [HttpPut("UpdateAssetMaster")]
        public async Task<IActionResult> UpdateAssetMaster([FromBody]AssetMaster assetMaster)
        {
            APIResponse apiResponse = null;
            if (assetMaster == null)
                return BadRequest($"{nameof(assetMaster)} cannot be null");
            try
            {
                var result = AssetHelper.UpdateAssetMaster(assetMaster);
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
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message});
            }  
        }


        [HttpDelete("DeleteAssetMaster/{code}")]
        public async Task<IActionResult> DeleteAssetMaster(string code)
        {
      
            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response ="Request cannot be null" });

            try
            {
                APIResponse apiResponse = null;

                var result = AssetHelper.DeleteAssetMaster(code);
                if (result !=null)
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
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response =ex.Message });
            }
       }

        [HttpGet("isNoSeriesIsAuto")]
        public async Task<IActionResult> IsNoSeriesIsAuto()
        {
            try
            {
                var noSrs = AssetHelper.GetNoSeries();
                dynamic expando = new ExpandoObject();
                if (noSrs != null)
                    expando.isNoTypeAuto = noSrs.NoType.Equals("AUTO");
                else
                    expando.isNoTypeAuto = false;

                return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response=expando});
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("AutoGenerateAssetNo")]
        public async Task<IActionResult> AutoGenerateAssetNo()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.AssetNo = AssetHelper.AutoIncrementAssetNo();

                return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response=expando});
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
       
