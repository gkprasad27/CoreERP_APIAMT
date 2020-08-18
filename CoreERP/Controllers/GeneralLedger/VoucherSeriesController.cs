using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.GeneralLedger
{
    [ApiController]
    [Route("api/VoucherSeries")]
    public class VoucherSeriesController : ControllerBase
    {
        private readonly IRepository<TblVoucherSeries> _vsRepository;
        public VoucherSeriesController(IRepository<TblVoucherSeries> vsRepository)
        {
            _vsRepository = vsRepository;
        }

        [HttpPost("RegisterVoucherSeries")]
        public IActionResult RegisterVoucherSeries([FromBody]TblVoucherSeries vcseries)
        {
            if (vcseries == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (VoucherSeriesHelper.GetList(vcseries.VoucherSeriesKey).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Vocherseries Code {nameof(vcseries.VoucherSeriesKey)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _vsRepository.Add(vcseries);
                if (_vsRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = vcseries };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetVoucherSeriesList")]
        public IActionResult GetVoucherSeriesList()
        {
            try
            {
                var vcseriesList = _vsRepository.GetAll();
                if (vcseriesList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.vseriesList = vcseriesList;
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

        [HttpPut("UpdateVoucherSeries")]
        public IActionResult UpdateVoucherSeries([FromBody] TblVoucherSeries vcseries)
        {
            if (vcseries == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(vcseries)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _vsRepository.Update(vcseries);
                if (_vsRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = vcseries };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteVoucherSeries/{code}")]
        public IActionResult DeleteVoucherSeriesByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _vsRepository.GetSingleOrDefault(x => x.VoucherSeriesKey.Equals(code));
                _vsRepository.Remove(record);
                if (_vsRepository.SaveChanges() > 0)
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