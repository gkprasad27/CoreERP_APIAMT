using System;
using System.Collections.Generic;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/PrimaryCostElementsCreation")]
    public class PrimaryCostElementsCreationController : ControllerBase
    {
        private readonly IRepository<GlaccGroup> _glaugRepository;
        private readonly IRepository<Glaccounts> _glaccountRepository;
        private readonly IRepository<TblPrimaryCostElement> _primaryCostElementRepository;
        public PrimaryCostElementsCreationController(IRepository<TblPrimaryCostElement> primaryCostElementRepository,
            IRepository<GlaccGroup> glaugRepository, IRepository<Glaccounts> glaccountRepository)
        {
            _glaugRepository = glaugRepository;
            _primaryCostElementRepository = primaryCostElementRepository;
            _glaccountRepository = glaccountRepository;
        }

        [HttpPost("UpdatePcost")]
        public IActionResult UpdatePcost([FromBody] JObject obj)
        {
            try
            {
               
                if (obj == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });
                var pcostdetails = obj["grDtl"].ToObject<List<TblPrimaryCostElement>>();
                if (!new CommonHelper().UpdatePcosts(pcostdetails))
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                dynamic expdoObj = new ExpandoObject();
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterPrimaryCostElementsCreation")]
        public IActionResult RegisterPrimaryCostElementsCreation([FromBody]TblPrimaryCostElement pcost)
        {
            if (pcost == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                var GetAccountNamelist = _glaugRepository.Where(x => x.GroupName == "Income" || x.GroupName == "Expenses").ToArray();
               foreach (var item in GetAccountNamelist)
                {
                    var glList = _glaccountRepository.Where(x => x.AccGroup == item.GroupCode || x.AccGroup == item.GroupCode).ToArray();
                    foreach(var item1 in glList)
                    {
                        TblPrimaryCostElement pcost1 = new TblPrimaryCostElement();
                        pcost1.GeneralLedger = item1.AccountNumber;
                        pcost1.Company = pcost.Company;
                        pcost1.ChartofAccount = pcost.ChartofAccount;
                        pcost1.Description = pcost.Description;
                        pcost1.Usage = pcost.Usage;
                        pcost1.Element = pcost.Element;
                        pcost1.Qty = pcost.Qty;
                        pcost1.Uom = pcost.Uom;
                        _primaryCostElementRepository.Add(pcost1);
                        _primaryCostElementRepository.SaveChanges();
                    }
                   
                }

                APIResponse apiResponse;
                if (_primaryCostElementRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = pcost };
                else
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = pcost };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPrimaryCostElementsCreationList")]
        public IActionResult GetPrimaryCostElementsCreationList()
        {
            try
            {
                var pcostList = CommonHelper.GetPrimarycostelement();
                if (pcostList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.pcostList = pcostList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatePrimaryCostElementsCreation")]
        public IActionResult UpdatePrimaryCostElementsCreation([FromBody] TblPrimaryCostElement pcost)
        {
            if (pcost == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(pcost)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _primaryCostElementRepository.Update(pcost);
                if (_primaryCostElementRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = pcost };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePrimaryCostElementsCreation/{code}")]
        public IActionResult DeletePrimaryCostElementsCreationbyId(int code)
        {
            try
            {
                if (code == 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _primaryCostElementRepository.GetSingleOrDefault(x => x.GeneralLedger.Equals(code));
                _primaryCostElementRepository.Remove(record);
                if (_primaryCostElementRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}