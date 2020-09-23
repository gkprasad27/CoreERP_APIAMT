using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/CostingKeyFigures")]
    public class CostingKeyFiguresController : ControllerBase
    {

        private readonly IRepository<TblCostingKeyFigures> _costingKeyFiguresRepository;
        public CostingKeyFiguresController(IRepository<TblCostingKeyFigures> costingKeyFiguresRepository)
        {
            _costingKeyFiguresRepository = costingKeyFiguresRepository;
        }

        [HttpPost("RegisterCostingKeyFigures")]
        public IActionResult RegisterCostingKeyFigures([FromBody]TblCostingKeyFigures costfigures)
        {
            if (costfigures == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _costingKeyFiguresRepository.Add(costfigures);
                if (_costingKeyFiguresRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costfigures };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCostingKeyFiguresList")]
        public IActionResult GetCostingKeyFiguresList()
        {
            try
            {
                var costfiguresList = CommonHelper.GetCostingKeyFigures();
                if (costfiguresList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.costfiguresList = costfiguresList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateCostingKeyFigures")]
        public IActionResult UpdateCostingKeyFigures([FromBody] TblCostingKeyFigures costfigures)
        {
            if (costfigures == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(costfigures)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _costingKeyFiguresRepository.Update(costfigures);
                if (_costingKeyFiguresRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costfigures };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteCostingKeyFigures/{code}")]
        public IActionResult DeleteCostingKeyFiguresbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _costingKeyFiguresRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _costingKeyFiguresRepository.Remove(record);
                if (_costingKeyFiguresRepository.SaveChanges() > 0)
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