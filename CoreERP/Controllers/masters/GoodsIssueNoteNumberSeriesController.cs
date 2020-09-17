using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/GoodsIssueNoteNumberSeries")]
    public class GoodsIssueNoteNumberSeriesController : ControllerBase
    {
        private readonly IRepository<TblGinnoSeries> _ginnoSeriesRepository;
        public GoodsIssueNoteNumberSeriesController(IRepository<TblGinnoSeries> ginnoSeriesRepository)
        {
            _ginnoSeriesRepository = ginnoSeriesRepository;
        }

        [HttpPost("RegisterGoodsIssueNoteNumberSeries")]
        public IActionResult RegisterGoodsIssueNoteNumberSeries([FromBody]TblGinnoSeries series)
        {
            if (series == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _ginnoSeriesRepository.Add(series);
                if (_ginnoSeriesRepository.SaveChanges() > 0)
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

        [HttpGet("GetGoodsIssueNoteNumberSeriesList")]
        public IActionResult GetGoodsIssueNoteNumberSeriesList()
        {
            try
            {
                var issuenoList = _ginnoSeriesRepository.GetAll();
                if (issuenoList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.issuenoList = issuenoList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateGoodsIssueNoteNumberSeries")]
        public IActionResult UpdateGoodsIssueNoteNumberSeries([FromBody] TblGinnoSeries series)
        {
            if (series == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(series)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _ginnoSeriesRepository.Update(series);
                if (_ginnoSeriesRepository.SaveChanges() > 0)
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

        [HttpDelete("DeleteGoodsIssueNoteNumberSeries/{code}")]
        public IActionResult DeleteGoodsIssueNoteNumberSeriesbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _ginnoSeriesRepository.GetSingleOrDefault(x => x.Ginseries.Equals(code));
                _ginnoSeriesRepository.Remove(record);
                if (_ginnoSeriesRepository.SaveChanges() > 0)
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