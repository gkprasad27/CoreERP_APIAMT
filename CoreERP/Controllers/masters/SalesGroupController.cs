using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/SalesGroup")]
    public class SalesGroupController : ControllerBase
    {
        private readonly IRepository<TblSalesGroup> _sgRepository;
        public SalesGroupController(IRepository<TblSalesGroup> sgRepository)
        {
            _sgRepository = sgRepository;
        }

        [HttpPost("RegisterSalesGroup")]
        public IActionResult RegisterSalesGroup([FromBody]TblSalesGroup slgrp)
        {
            if (slgrp == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (SalesGroupHelper.GetList(slgrp.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"salesoffice Code {nameof(slgrp.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _sgRepository.Add(slgrp);
                if (_sgRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = slgrp };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetSalesGroupList")]
        public IActionResult GetSalesGroupList()
        {
            try
            {
                var salesgrplList = _sgRepository.GetAll();
                if (salesgrplList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.salesgroupList = salesgrplList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateSalesGroup")]
        public IActionResult UpdateSalesGroup([FromBody] TblSalesGroup slgrp)
        {
            if (slgrp == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(slgrp)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _sgRepository.Update(slgrp);
                if (_sgRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = slgrp };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteSalesGroup/{code}")]
        public IActionResult DeleteSalesGroupByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _sgRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _sgRepository.Remove(record);
                if (_sgRepository.SaveChanges() > 0)
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