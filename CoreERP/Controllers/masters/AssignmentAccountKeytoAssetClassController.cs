using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/AssignmentAccountKeytoAssetClass")]
    public class AssignmentAccountKeytoAssetClassController : ControllerBase
    {
        private readonly IRepository<TblAssignAccountkeytoAsset> _assignAccountkeytoAssetRepository;
        public AssignmentAccountKeytoAssetClassController(IRepository<TblAssignAccountkeytoAsset> assignAccountkeytoAssetRepository)
        {
            _assignAccountkeytoAssetRepository = assignAccountkeytoAssetRepository;
        }
        [HttpGet("GetAssignmentAccountKeytoAssetClassList")]
        public async Task<IActionResult> GetAssignmentAccountKeytoAssetClassList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var acckeyList = _assignAccountkeytoAssetRepository.GetAll();
                    if (acckeyList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.acckeyList = acckeyList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterAssignmentAccountKeytoAssetClass")]
        public async Task<IActionResult> RegisterAssignmentAccountKeytoAssetClass([FromBody]TblAssignAccountkeytoAsset acckeytoasset)
        {
            APIResponse apiResponse;
            if (acckeytoasset == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(acckeytoasset)} cannot be null" });
            else
            {
                try
                {
                    _assignAccountkeytoAssetRepository.Add(acckeytoasset);
                    if (_assignAccountkeytoAssetRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = acckeytoasset };
                    else
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }

            }
        }

        [HttpPut("UpdateAssignmentAccountKeytoAssetClass")]
        public async Task<IActionResult> UpdateAssignmentAccountKeytoAssetClass([FromBody] TblAssignAccountkeytoAsset acckeytoasset)
        {
            APIResponse apiResponse = null;
            if (acckeytoasset == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _assignAccountkeytoAssetRepository.Update(acckeytoasset);
                if (_assignAccountkeytoAssetRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = acckeytoasset };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAssignmentAccountKeytoAssetClass/{code}")]
        public async Task<IActionResult> DeleteAssignmentAccountKeytoAssetClass(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _assignAccountkeytoAssetRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _assignAccountkeytoAssetRepository.Remove(record);
                if (_assignAccountkeytoAssetRepository.SaveChanges() > 0)
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