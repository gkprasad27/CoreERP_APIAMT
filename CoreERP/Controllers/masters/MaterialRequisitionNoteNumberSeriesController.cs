using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/MaterialRequisitionNoteNumberSeries")]
    public class MaterialRequisitionNoteNumberSeriesController : ControllerBase
    {
        private readonly IRepository<TblMrnnoSeries> _materialNoSeriesRepository;
        public MaterialRequisitionNoteNumberSeriesController(IRepository<TblMrnnoSeries> materialNoSeriesRepository)
        {
            _materialNoSeriesRepository = materialNoSeriesRepository;
        }

        [HttpPost("RegisterMaterialRequisitionNoteNumberSeries")]
        public IActionResult RegisterMaterialRequisitionNoteNumberSeries([FromBody]TblMrnnoSeries noseries)
        {
            if (noseries == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _materialNoSeriesRepository.Add(noseries);
                if (_materialNoSeriesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = noseries };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMaterialRequisitionNoteNumberSeriesList")]
        public IActionResult GetMaterialRequisitionNoteNumberSeriesList()
        {
            try
            {
                var mseriesnoList = _materialNoSeriesRepository.GetAll();
                if (mseriesnoList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.mseriesnoList = mseriesnoList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateMaterialRequisitionNoteNumberSeries")]
        public IActionResult UpdateMaterialRequisitionNoteNumberSeries([FromBody] TblMrnnoSeries noseries)
        {
            if (noseries == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(noseries)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _materialNoSeriesRepository.Update(noseries);
                if (_materialNoSeriesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = noseries };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMaterialRequisitionNoteNumberSeries/{code}")]
        public IActionResult DeleteMaterialRequisitionNoteNumberSeriesbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _materialNoSeriesRepository.GetSingleOrDefault(x => x.Mrnseries.Equals(code));
                _materialNoSeriesRepository.Remove(record);
                if (_materialNoSeriesRepository.SaveChanges() > 0)
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