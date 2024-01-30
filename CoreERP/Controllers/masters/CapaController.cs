using CoreERP.DataAccess;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Capa")]
    public class CapaController : Controller
    {
        private readonly IRepository<TblCAPA> _capaRepository;
        public CapaController(IRepository<TblCAPA> CapaRepository)
        {
            _capaRepository = CapaRepository;
        }

        [HttpPost("Registercapa")]
        public IActionResult RegisterDispatch([FromBody] TblCAPA capa)
        {
            if (capa == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(capa)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _capaRepository.Add(capa);
                if (_capaRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = capa };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Recored Added Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCapaList")]
        public IActionResult GetCapaList()
        {
            try
            {
                var CapaList = CommonHelper.GetCapaList();

                if (CapaList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.CapaList = CapaList;
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

        [HttpPut("UpdateCapa")]
        public IActionResult UpdateCapa([FromBody] TblCAPA capa)
        {
            if (capa == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(capa)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _capaRepository.Update(capa);
                if (_capaRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = capa };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("Deletecapa/{code}")]
        public IActionResult Deletecapa(int code)
        {
            try
            {
                APIResponse apiResponse;
                if (code == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });
                var record = _capaRepository.GetSingleOrDefault(x => x.ID.Equals(code));
                _capaRepository.Remove(record);
                if (_capaRepository.SaveChanges() > 0)
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