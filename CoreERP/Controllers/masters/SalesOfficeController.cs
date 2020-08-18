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
    [Route("api/SalesOffice")]
    public class SalesOfficeController : ControllerBase
    {
        private readonly IRepository<TblSalesOffice> _soRepository;
        public SalesOfficeController(IRepository<TblSalesOffice> soRepository)
        {
            _soRepository = soRepository;
        }

        [HttpPost("RegisterSalesOffice")]
        public IActionResult RegisterSalesOffice([FromBody]TblSalesOffice slofc)
        {
            if (slofc == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (SalesOfficeHelper.GetList(slofc.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"salesoffice Code {nameof(slofc.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _soRepository.Add(slofc);
                if (_soRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = slofc };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetSalesOfficeList")]
        public IActionResult GetSalesOfficeList()
        {
            try
            {
                var salesofclList = _soRepository.GetAll();
                if (salesofclList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.salesList = salesofclList;
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

        [HttpPut("UpdateSalesOffice")]
        public IActionResult UpdateSalesOffice([FromBody] TblSalesOffice slofc)
        {
            if (slofc == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(slofc)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _soRepository.Update(slofc);
                if (_soRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = slofc };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteSalesOffice/{code}")]
        public IActionResult DeleteSalesOfficeByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _soRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _soRepository.Remove(record);
                if (_soRepository.SaveChanges() > 0)
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