using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/GoodsReceiptNoteNumberSeries")]
    public class GoodsReceiptNoteNumberSeriesController : ControllerBase
    {
        private readonly IRepository<TblGrnnoSeries> _grnnoSeriesRepository;
        public GoodsReceiptNoteNumberSeriesController(IRepository<TblGrnnoSeries> grnnoSeriesRepository)
        {
            _grnnoSeriesRepository = grnnoSeriesRepository;
        }

        [HttpPost("RegisterGoodsReceiptNoteNumberSeries")]
        public IActionResult RegisterGoodsReceiptNoteNumberSeries([FromBody]TblGrnnoSeries series)
        {
            if (series == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _grnnoSeriesRepository.Add(series);
                if (_grnnoSeriesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = series };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGoodsReceiptNoteNumberSeriesList")]
        public IActionResult GetGoodsReceiptNoteNumberSeriesList()
        {
            try
            {
                var grnoList = _grnnoSeriesRepository.GetAll();
                if (grnoList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.grnoList = grnoList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateGoodsReceiptNoteNumberSeries")]
        public IActionResult UpdateGoodsReceiptNoteNumberSeries([FromBody] TblGrnnoSeries series)
        {
            if (series == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(series)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _grnnoSeriesRepository.Update(series);
                if (_grnnoSeriesRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = series };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteGoodsReceiptNoteNumberSeries/{code}")]
        public IActionResult DeleteGoodsReceiptNoteNumberSeriesbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _grnnoSeriesRepository.GetSingleOrDefault(x => x.Grnseries.Equals(code));
                _grnnoSeriesRepository.Remove(record);
                if (_grnnoSeriesRepository.SaveChanges() > 0)
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