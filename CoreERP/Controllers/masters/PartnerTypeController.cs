using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{

    [ApiController]
    [Route("api/PartnerType")]
    public class PartnerTypeController : ControllerBase
    {

        [HttpPost("masters/partnerType/insertpartnerType")]
        public async Task<IActionResult> Register([FromBody]PartnerType partnerType)
        {
            if (partnerType == null)
                return BadRequest($"{nameof(partnerType)} can not be null");
            try
            {
                int result = PartnerTypeHelper.RegistePartnerType(partnerType);
                if(result > 0)
                return Ok(partnerType);

            }
            catch
            {             
            }

            return BadRequest("Registration Failed");
        }



        [HttpGet("masters/partnerType")]
        public async Task<IActionResult> GetAllPartnerTypes()
        {            
            return Ok(
                new {
                   partnerType= PartnerTypeHelper.GetPartnerTypeList()
                    
                });
        }

        [HttpPut("masters/partnerType/{code}")]
        public async Task<IActionResult> UpdatePartnerType(string code, [FromBody] PartnerType partnerType)
        {
            try {
                if (partnerType == null)
                    return BadRequest($"{nameof(partnerType)} cannot be null");

                int rs = PartnerTypeHelper.UpdatePartnerType(partnerType);
                if (rs > 0)
                    return Ok(partnerType);
             
            }
            catch { throw; }
            return BadRequest($"{nameof(partnerType)} Updation Failed");
        }


        [HttpDelete("masters/PartnerType/{code}")]
        public async Task<IActionResult> DeletePartnerTypeByID(string code)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                    return BadRequest($"{nameof(code)} cannot be null");

                int result =PartnerTypeHelper.DeletePartnerType(code);
                if(result > 0)
                        return Ok(code);
            }
            catch { }
            return BadRequest("Deletion Failed");
        }
    }
}
