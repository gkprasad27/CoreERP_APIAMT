using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/SegmentMaster")]
    public class SegmentMasterController : ControllerBase
    {
        
        
        [HttpGet("masters/SegmentMaster")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new
            {
           segment = SegmentHelper.GetSegmentList()

         });
    }


        [HttpPost("masters/SegmentMaster/register")]
        public async Task<IActionResult> Register([FromBody]Segment segment)
        {
             if (segment == null)
                return BadRequest($"{nameof(segment)} cannot be null");
           try
            {
        int result = SegmentHelper.RegisterSegment(segment);
        if (result > 0)
          return Ok(segment);
      }
            catch(Exception ex)
            {
               
            }
      return BadRequest("Registration Failed");
    }



        [HttpPut("masters/SegmentMaster/{code}")]
        public async Task<IActionResult> UpdateSegment(string code, [FromBody] Segment segment)
        {
            if (segment == null)
                return BadRequest($"{nameof(segment)} cannot be null");
            try
            {
                 if (segment == null)
                    return BadRequest($"{nameof(segment)} cannot be null");

                int rs = SegmentHelper.UpdateSegment(segment);
                if (rs > 0)
                    return Ok(segment);
                    
            }
            catch
            {
              throw;
            }
      return BadRequest($"{nameof(segment)} Updation Failed");             
    }


        // Delete Branch
        [HttpDelete("masters/SegmentMaster/{ID}")]
        public async Task<IActionResult> DeleteSegment(string ID)
        {
            if (ID == null)
                return BadRequest($"{nameof(ID)}can not be null");
            try
            {
        if (string.IsNullOrWhiteSpace(ID))
          return BadRequest($"{nameof(ID)} cannot be null");

        int result = SegmentHelper.DeleteSegment(ID);
        if (result > 0)
          return Ok(ID);

      }
      catch { throw; }
      return BadRequest("Deletion Failed");
    }
    }
}
