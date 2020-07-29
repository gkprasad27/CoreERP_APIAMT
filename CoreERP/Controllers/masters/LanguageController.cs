using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Language")]
    public class LanguageController : ControllerBase
    {
        [HttpPost("RegisterLanguage")]
        public IActionResult RegisterLanguage([FromBody]TblLanguage language)
        {
            if (language == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (LanguageHelper.GetList(language.LanguageCode).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"language Code {nameof(language.LanguageCode)} is already exists ,Please Use Different Code " });

                var result = LanguageHelper.Register(language);
                APIResponse apiResponse;
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                }

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetLanguageList")]
        public IActionResult GetLanguageList()
        {
            try
            {
                var languageList = LanguageHelper.GetList();
                if (languageList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.languageList = languageList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateLanguage")]
        public IActionResult UpdateLanguage([FromBody] TblLanguage language)
        {
            if (language == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(language)} cannot be null" });

            try
            {
                var rs = LanguageHelper.Update(language);
                APIResponse apiResponse;
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteLanguage/{code}")]
        public IActionResult DeleteLanguageByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = LanguageHelper.Delete(code);
                APIResponse apiResponse;
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}