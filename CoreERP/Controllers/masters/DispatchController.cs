using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Dispatch")]
    public class DispatchController : Controller
    {
        private readonly IRepository<TblDispatch> _dispatchRepository;
        public DispatchController(IRepository<TblDispatch> DispatchRepository)
        {
            _dispatchRepository = DispatchRepository;
        }

        [HttpPost("RegisterDispatch")]
        public IActionResult RegisterDispatch([FromBody] TblDispatch dispatch)
        {
            if (dispatch == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(dispatch)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                //if (LanguageHelper.GetList(language.LanguageCode).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"language Code {nameof(language.LanguageCode)} is already exists ,Please Use Different Code " });
                _dispatchRepository.Add(dispatch);
                if (_dispatchRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = dispatch };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Recored Added Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetDispatchList")]
        public IActionResult GetDispatchList()
        {
            try
            {
                var DispatchList = _dispatchRepository.GetAll(); //LanguageHelper.GetList();
                if (DispatchList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.DispatchList = DispatchList;
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

        [HttpPut("UpdateDispatch")]
        public IActionResult UpdateDispatch([FromBody] TblDispatch dispatch)
        {
            if (dispatch == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(dispatch)} cannot be null" });

            try
            {   
                APIResponse apiResponse;
                _dispatchRepository.Update(dispatch);
                if (_dispatchRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = dispatch };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteDispatch/{code}")]
        public IActionResult DeleteDispatch(int code)
        {
            try
            {
                APIResponse apiResponse;
                if (code == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });
                var record = _dispatchRepository.GetSingleOrDefault( x => x.ID.Equals(code));
                _dispatchRepository.Remove(record);
                if(_dispatchRepository.SaveChanges() > 0)                
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