using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/State")]
    public class StateController : ControllerBase
    {
        private readonly IRepository<States> _stateRepository;
        public StateController(IRepository<States> stateRepository)
        {
            _stateRepository = stateRepository;
        }

        [HttpPost("RegisterState")]
        public IActionResult RegisterState([FromBody] States state)
        {
            if (state == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (StateHelper.GetList(state.StateCode).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"state Code {nameof(state.StateCode)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _stateRepository.Add(state);
                if (_stateRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = state };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                if (Convert.ToString(ex.HResult) == "-2146233088")

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = state.StateCode + " " + "Already exists" });

                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetStateList")]
        public IActionResult GetStateList()
        {
            try
            {
                var stateList = CommonHelper.GetStates();
                if (stateList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.stateList = stateList;
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

        [HttpPut("UpdateState")]
        public IActionResult UpdateState([FromBody] States state)
        {
            if (state == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(state)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _stateRepository.Update(state);
                if (_stateRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = state };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteState/{code}")]
        public IActionResult DeleteStateByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _stateRepository.GetSingleOrDefault(x => x.StateCode.Equals(code));
                _stateRepository.Remove(record);
                if (_stateRepository.SaveChanges() > 0)
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

        [HttpGet("GetStatesList/{code}")]
        public async Task<IActionResult> GetStatesList(string code)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.StatesList = _stateRepository.Where(x => x.CountryCode == code).Select(x => new { ID = x.StateCode, TEXT = x.StateName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

    }
}