using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Language")]
    public class LanguageController : Controller
    {
        private readonly IRepository<TblLanguage> _languageRepository;
        public LanguageController(IRepository<TblLanguage> languageRepository)
        {
            _languageRepository = languageRepository;
        }

        [HttpPost("RegisterLanguage")]
        public IActionResult RegisterLanguage([FromBody] TblLanguage language)
        {
            if (language == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(language)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                //if (LanguageHelper.GetList(language.LanguageCode).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"language Code {nameof(language.LanguageCode)} is already exists ,Please Use Different Code " });
                _languageRepository.Add(language);
                if (_languageRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = language };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Recored Added Failed." };
                
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
                var languageList = _languageRepository.GetAll(); //LanguageHelper.GetList();
                if (languageList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.languageList = languageList;
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

        [HttpPut("UpdateLanguage")]
        public IActionResult UpdateLanguage([FromBody] TblLanguage language)
        {
            if (language == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(language)} cannot be null" });

            try
            {   
                APIResponse apiResponse;
                _languageRepository.Update(language);
                if (_languageRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = language };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
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
                APIResponse apiResponse;
                if (code == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });
                var record = _languageRepository.GetSingleOrDefault( x => x.LanguageCode.Equals(code));
                _languageRepository.Remove(record);
                if(_languageRepository.SaveChanges() > 0)                
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