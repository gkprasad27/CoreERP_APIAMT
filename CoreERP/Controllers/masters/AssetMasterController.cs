using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/AssetMaster")]
    public class AssetMasterController : ControllerBase
    {
       
        [HttpPost("masters/assetmaster/register")]
        public async Task<IActionResult> Register([FromBody]  AssetMaster assetMaster)//
        {
            try
            {
                int result = AssetHelper.RegisterAssetMaster(assetMaster);
                if (result > 0)
                    return Ok(assetMaster);

                return BadRequest(" Registration Operation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest(" Registration Operation Failed");
            }

        }



        [HttpGet("masters/assetmaster")]
        public async Task<IActionResult> GetAll()
        {

            return Ok( new {

                assetmasterlist=AssetHelper.GetList()
                //glAssetAccts=_unitOfWork.GLAccounts.GetAll().Where(x=>x.Nactureofaccount == "FIXEDASSETS"),
                //noSeriesAssetRcd =(from nos in _unitOfWork.NoSeries.GetAll()
                //                   join pt  in _unitOfWork.PartnerType.GetAll()
                //                   on nos.PartnerType equals pt.Code
                //                   where pt.AccountType == "FIXEDASSETS"
                //                   select nos),
                ////branch =BrancheHelper.GetBranches(),
                //company =CompaniesHelper.GetListOfCompanies()
            });
        }

        

        [HttpPut("masters/assetmaster/{code}")]
        public async Task<IActionResult> Update(string code, [FromBody]AssetMaster assetMaster)
        {
            if (assetMaster == null)
                return BadRequest($"{nameof(assetMaster)} cannot be null");
            try
            {
                int rs = AssetHelper.UpdateAssetMaster(assetMaster);
                if (rs > 0)
                    return Ok(assetMaster);

                return BadRequest($"{nameof(assetMaster)} Updation Failed");
            }
            catch(Exception ex)
            {
             return BadRequest($"{nameof(assetMaster)} Updation Failed");
            }  
        }


        [HttpDelete("masters/assetmaster/{code}")]
        public async Task<IActionResult> Delete(string code)
        {
           // Division division = null;
            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                int result = AssetHelper.DeleteAssetMaster(code);
                if (result > 0)
                    return Ok(code);

                return BadRequest("Delete Operation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest("Delete Operation Failed");
            }
       }


    }
}
       
