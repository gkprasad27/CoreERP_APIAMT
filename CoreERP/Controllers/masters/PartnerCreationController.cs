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
    [Route("api/PartnerCreation")]
    public class PartnerCreationController : ControllerBase
    {

        [HttpPost("masters/partnercreation/insertpartnerType")]
        public async Task<IActionResult> Register([FromBody]PartnerCreation partnercreation)
        {
            try
            {
                int result = PartnerCreationHelper.RegisterPartnerCreation(partnercreation);
                if (result > 0)
                    return Ok(partnercreation);

                return BadRequest(" Registration Operation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest(" Registration Operation Failed");
            }

        }



        [HttpGet("masters/partnercreation")]
        public async Task<IActionResult> GetAllData()
        {
            // return Ok(_unitOfWork.PartnerCreation.GetAll());
            //return Json(new {
            //    company=_unitOfWork.Companys.GetAll(),
            //    branches=_unitOfWork.Branches.GetAll(),
            //    partnertype =_unitOfWork.PartnerType.GetAll(),
            //    partnercreation=_unitOfWork.PartnerCreation.GetAll().OrderBy(x=> int.Parse(x.Code)),
            //    glaccount = (from glacc in ( from  glaccount1 in _unitOfWork.GLAccounts.GetAll()
            //                                where  glaccount1.Nactureofaccount != null
            //                               select  glaccount1)
            //                  where glacc.Nactureofaccount.ToUpper() == NatureOfAccounts.TRADECUSTOMER.ToString().ToUpper() ||
            //                        glacc.Nactureofaccount.ToUpper() == NatureOfAccounts.TRADEVENDORS.ToString().ToUpper()
            //                  select glacc)

            //});
            return Ok(new
            {

                partnerCreaetionList = PartnerCreationHelper.GetList()

            });
        }

        [HttpPut("masters/partnercreation/{code}")]
        [Produces(typeof(PartnerCreation))]
        public async Task<IActionResult> Updatepartnercreation(string code, [FromBody] PartnerCreation partnercreation)
        {
            if (partnercreation == null)
                return BadRequest($"{nameof(partnercreation)} cannot be null");

            if (!string.IsNullOrWhiteSpace(partnercreation.Code) && code != partnercreation.Code)
                return BadRequest("Conflicting role id in parameter and model data");


            try
            {
                int rs = PartnerCreationHelper.UpdatePartnerCreation(partnercreation);
                if (rs > 0)
                    return Ok(partnercreation);

                return BadRequest($"{nameof(partnercreation)} Updation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest($"{nameof(partnercreation)} Updation Failed");
            }
        }


        [HttpDelete("masters/partnercreation/{code}")]
        [Produces(typeof(PartnerCreation))]
        public async Task<IActionResult> DeletepartnercreationByID(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");
            try
            {
                int result = PartnerCreationHelper.DeletePartnerCreation(code);
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
