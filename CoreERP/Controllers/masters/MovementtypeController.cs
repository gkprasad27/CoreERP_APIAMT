using System;
using System.Collections.Generic;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Movementtype")]
    public class MovementtypeController : ControllerBase
    {

        private readonly IRepository<TblMovementType> _movementTypeRepository;
        public MovementtypeController(IRepository<TblMovementType> movementTypeRepository)
        {
            _movementTypeRepository = movementTypeRepository;
        }

        [HttpPost("RegisterMovementtype")]
        public IActionResult RegisterMovementtype([FromBody]TblMovementType moment)
        {
            if (moment == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _movementTypeRepository.Add(moment);
                if (_movementTypeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = moment };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMovementtypeList")]
        public IActionResult GetMovementtypeList()
        {
            try
            {
                var movementList = _movementTypeRepository.GetAll();
                if (movementList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.movementList = movementList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateMovementtype")]
        public IActionResult UpdateMovementtype([FromBody] TblMovementType moment)
        {
            if (moment == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(moment)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _movementTypeRepository.Update(moment);
                if (_movementTypeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = moment };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMovementtype/{code}")]
        public IActionResult DeleteMovementtypebyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _movementTypeRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _movementTypeRepository.Remove(record);
                if (_movementTypeRepository.SaveChanges() > 0)
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