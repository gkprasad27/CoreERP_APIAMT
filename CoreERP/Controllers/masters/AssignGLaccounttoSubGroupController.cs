using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/AssignGLaccounttoSubGroup")]

    public class AssignGLaccounttoSubGroupController : ControllerBase
    {
        private readonly IRepository<TblAccountGroup> _glaugRepository;
        private readonly IRepository<TblFinanceialStatement> _financeialStatementRepository;
        private readonly IRepository<AssignmentSubaccounttoGl> _assignmentSubaccounttoGlRepository;

        public AssignGLaccounttoSubGroupController(IRepository<TblAccountGroup> glaugRepository, IRepository<AssignmentSubaccounttoGl> assignmentSubaccounttoGlRepository, IRepository<TblFinanceialStatement> financeialStatementRepository)
        {
            _glaugRepository = glaugRepository;
            _assignmentSubaccounttoGlRepository = assignmentSubaccounttoGlRepository;
            _financeialStatementRepository = financeialStatementRepository;
        }

        [HttpGet("GetAssignGLaccounttoSubGroupList")]
        public async Task<IActionResult> GetAssignGLaccounttoSubGroupList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var assignacckeyList = CommonHelper.GetAssignmentsubaccounttoGl();
                    if (!assignacckeyList.Any())
                        return Ok(new APIResponse
                        { status = APIStatus.FAIL.ToString(), response = "No Data Found for assignacckeyList." });
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assignacckeyList = assignacckeyList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterAssignGLaccounttoSubGroup")]
        public async Task<IActionResult> RegisterAssignGLaccounttoSubGroup([FromBody] JObject obj)
        {
            if (obj == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"request cannot be null" });
            try
            {

                List<AssignmentSubaccounttoGl> assnacckey;
                assnacckey = obj["GLS"].ToObject<IList<AssignmentSubaccounttoGl>>().ToList();

                _assignmentSubaccounttoGlRepository.AddRange(assnacckey);
                APIResponse apiResponse;
                if (_assignmentSubaccounttoGlRepository.SaveChanges() <= 0)
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                else
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assnacckey };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateAssignGLaccounttoSubGroup")]
        public async Task<IActionResult> UpdateAssignGLaccounttoSubGroup([FromBody] JObject obj)
        {
            if (obj == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                List<AssignmentSubaccounttoGl> assnacckey;
                assnacckey = obj["GLS"].ToObject<IList<AssignmentSubaccounttoGl>>().ToList();

                _assignmentSubaccounttoGlRepository.UpdateRange(assnacckey);
                APIResponse apiResponse;
                if (_assignmentSubaccounttoGlRepository.SaveChanges() <= 0)
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                else
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assnacckey };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAssignGLaccounttoSubGroup/{code}")]
        public async Task<IActionResult> DeleteAssignGLaccounttoSubGroup(int code)
        {
            try
            {
                var record = _assignmentSubaccounttoGlRepository.Where(x => x.ID == code).SingleOrDefault();
                _assignmentSubaccounttoGlRepository.Remove(record);
                APIResponse apiResponse;
                if (_assignmentSubaccounttoGlRepository.SaveChanges() <= 0)
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                else
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("GetGLUnderSubGroupList/{undersubgroup}")]
        public IActionResult GetGlUnderSubGroupList(string undersubgroup)
        {
            try
            {
                try
                {
                    var getAccountNamelist = _glaugRepository.Where(x => x.Nature == undersubgroup && x.IsDefault == 1);
                    if (!getAccountNamelist.Any())
                        return Ok(new APIResponse
                        { status = APIStatus.FAIL.ToString(), response = "No Data Found for SubGroupList." });
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.GetAccountNamelist = getAccountNamelist;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetStructurekeyList")]
        public async Task<IActionResult> GetStructurekeyList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var structkeyList = _financeialStatementRepository.GetAll();
                    if (!structkeyList.Any())
                        return Ok(new APIResponse
                        { status = APIStatus.FAIL.ToString(), response = "No Data Found for assignacckeyList." });
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.structkeyList = structkeyList.ToArray();
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

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