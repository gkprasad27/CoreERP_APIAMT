using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/AccGroup")]
    public class AccGroupController : ControllerBase
    {
        private readonly IRepository<GlaccGroup> _glagRepository;
        public AccGroupController(IRepository<GlaccGroup> glagRepository)
        {
            _glagRepository = glagRepository;
        }

        [HttpPost("RegisterGlaccGroup")]
        public async Task<IActionResult> RegisterGlaccGroup([FromBody] GlaccGroup accGroup)
        {
            var result = await Task.Run(() =>
            {
                if (accGroup == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(accGroup)} cannot be null" });
                try
                {
                    //if (GLHelper.GetGLAccountGroupList().Where(x => x.GroupCode == accGroup.GroupCode).Count() > 0)
                    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Code {accGroup.GroupCode} is already exists"});

                    APIResponse apiResponse;
                    _glagRepository.Add(accGroup);
                    if (_glagRepository.SaveChanges() > 0)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = accGroup });
                    else
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });

                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetAccountGroupList")]
        public IActionResult GetAccountGroupList()
        {

            try
            {
                var glAccountGroupList = _glagRepository.GetAll();
                if (glAccountGroupList != null)
                {
                    dynamic expando = new ExpandoObject();
                    expando.GLAccountGroupList = glAccountGroupList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateAccountGroup")]
        public async Task<IActionResult> UpdateAccountGroup([FromBody] GlaccGroup accGroup)
        {
            var result = await Task.Run(() =>
            {
                if (accGroup == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(accGroup)} cannot be null" });

                try
                {
                    APIResponse apiResponse;
                    _glagRepository.Update(accGroup);
                    if (_glagRepository.SaveChanges() > 0)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = accGroup });
                    else
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpDelete("DeleteAccountGroup/{code}")]
        public async Task<IActionResult> DeleteAccountGroup(string code)
        {
            var result = await Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(code))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

                try
                {
                    APIResponse apiResponse;
                    var record = _glagRepository.GetSingleOrDefault(x => x.GroupCode.Equals(code));
                    _glagRepository.Remove(record);
                    if (_glagRepository.SaveChanges() > 0)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = record });

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "DeletionFailed." });
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