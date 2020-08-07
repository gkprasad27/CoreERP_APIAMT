using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/TaxTypes")]
    public class TaxTypesController : ControllerBase
    {
        private readonly IRepository<TblTaxtypes> _ttRepository;
        public TaxTypesController(IRepository<TblTaxtypes> ttRepository)
        {
            _ttRepository = ttRepository;
        }

        [HttpPost("RegisterTaxTypes")]
        public IActionResult RegisterTaxTypes([FromBody] TblTaxtypes taxtype)
        {
            if (taxtype == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                //if (GLHelper.GetTblTaxtypesList(taxtype.TaxKey).Count > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Tax Code ={taxtype.TaxKey} alredy exists." });

                APIResponse apiResponse;
                _ttRepository.Add(taxtype);
                if (_ttRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = taxtype });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTaxTypesList")]
        public IActionResult GetTaxTypesList()
        {
            try
            {
                var taxtypesList = _ttRepository.GetAll();
                if (taxtypesList.Count() > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.TaxtypesList = taxtypesList;
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

        [HttpPut("UpdateTaxTypes")]
        public IActionResult UpdateTaxTypes([FromBody] TblTaxtypes taxtypes)
        {
            if (taxtypes == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(taxtypes)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _ttRepository.Update(taxtypes);
                if (_ttRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = taxtypes });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteTaxTypes/{code}")]
        public IActionResult DeleteTaxTypes(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                var record = _ttRepository.GetSingleOrDefault(x => x.TaxKey.Equals(code));
                _ttRepository.Remove(record);
                if (_ttRepository.SaveChanges() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = record });
                else
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}

