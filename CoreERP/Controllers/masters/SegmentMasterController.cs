using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Segment")]
    public class SegmentMasterController : ControllerBase
    {
        private readonly IRepository<Segment> _segmentRepository;
        public SegmentMasterController(IRepository<Segment> segmentRepository)
        {
            _segmentRepository = segmentRepository;
        }

        [HttpGet("GetSegmentList")]
        public IActionResult GetSegmentList()
        {
            try
            {
                var segmentList = _segmentRepository.GetAll();
                if (segmentList.Count() > 0)
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
        public IActionResult RegisterSegment([FromBody] Segment segment)
        {
            if (segment == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(segment)} cannot be null" });
            try
            {
                //if (SegmentHelper.IsSegmentIDExists(segment.Id))
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"ID={segment.Id} Already Exists." });
                APIResponse apiResponse;
                _segmentRepository.Add(segment);
                if (_segmentRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = segment });
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

                APIResponse apiResponse;
                _segmentRepository.Update(segment);
                if (_segmentRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = segment });
                else
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
                var record = _segmentRepository.GetSingleOrDefault(x => x.Id.Equals(ID));
                _segmentRepository.Remove(record);
                if (_segmentRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = record });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
