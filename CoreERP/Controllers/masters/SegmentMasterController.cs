using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using CoreERP.DataAccess;
using System.Dynamic;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/masters/Segment")]
    public class SegmentMasterController : ControllerBase
    {


        [HttpGet("GetSegmentList")]
        public IActionResult GetSegmentList()
        {
            try
            {
                var segmentList = SegmentHelper.GetSegmentList();
                if (segmentList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.segmentList = segmentList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterSegment")]
        public IActionResult RegisterSegment([FromBody]Segment segment)
        {
            if (segment == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(segment)} cannot be null" });
            try
            {
                if (SegmentHelper.IsSegmentIDExists(segment.Id))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"ID={segment.Id} Already Exists." });

                var result = SegmentHelper.RegisterSegment(segment);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpPut("UpdateSegment")]
        public IActionResult UpdateSegment([FromBody] Segment segment)
        {
            if (segment == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(segment)} cannot be null" });
            try
            {
                if (segment == null)
                    return BadRequest($"{nameof(segment)} cannot be null");

                var result = SegmentHelper.UpdateSegment(segment);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteSegment/{ID}")]
        public IActionResult DeleteSegment(string ID)
        {
            if (ID == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(ID)}can not be null" });
            try
            {
                var result = SegmentHelper.DeleteSegment(Convert.ToInt32(ID));
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
