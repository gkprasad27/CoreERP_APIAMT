using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;


namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Formulas")]
    public class FormulasController : ControllerBase
    {

        private readonly IRepository<TblFormula> _formulaRepository;
        public FormulasController(IRepository<TblFormula> formulaRepository)
        {
            _formulaRepository = formulaRepository;
        }

        [HttpPost("RegisterFormulas")]
        public IActionResult RegisterFormulas([FromBody]TblFormula formula)
        {
            if (formula == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _formulaRepository.Add(formula);
                if (_formulaRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = formula };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetFormulasList")]
        public IActionResult GetFormulasList()
        {
            try
            {
                var formulaList = _formulaRepository.GetAll();
                if (formulaList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.formulaList = formulaList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateFormulas")]
        public IActionResult UpdateFormulas([FromBody] TblFormula formula)
        {
            if (formula == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(formula)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _formulaRepository.Update(formula);
                if (_formulaRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = formula };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteFormulas/{code}")]
        public IActionResult DeleteFormulasbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _formulaRepository.GetSingleOrDefault(x => x.FormulaKey.Equals(code));
                _formulaRepository.Remove(record);
                if (_formulaRepository.SaveChanges() > 0)
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