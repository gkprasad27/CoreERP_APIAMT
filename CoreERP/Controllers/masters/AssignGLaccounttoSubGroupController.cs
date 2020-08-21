using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly IRepository<AssignmentSubaccounttoGl> _assignmentSubaccounttoGLRepository;
        public AssignGLaccounttoSubGroupController(IRepository<TblAccountGroup> glaugRepository,
            IRepository<AssignmentSubaccounttoGl> assignmentSubaccounttoGLRepository)
        {
            _glaugRepository = glaugRepository;
            _assignmentSubaccounttoGLRepository = assignmentSubaccounttoGLRepository;
        }
        [HttpGet("GetAssignGLaccounttoSubGroupList")]
        public async Task<IActionResult> GetAssignGLaccounttoSubGroupList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var assignacckeyList = CommonHelper.GetAssignmentsubaccounttoGL();
                    if (assignacckeyList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.assignacckeyList = assignacckeyList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for assignacckeyList." });
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
            
            APIResponse apiResponse;
            
            if (obj == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"request cannot be null" });
            else
            {
                try
                {

                    List<AssignmentSubaccounttoGl> assnacckey = null;
                    assnacckey = obj["GLS"].ToObject<IList<AssignmentSubaccounttoGl>>().ToList();

                    _assignmentSubaccounttoGLRepository.AddRange(assnacckey);
                    if (_assignmentSubaccounttoGLRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assnacckey };
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

        [HttpPut("UpdateAssignGLaccounttoSubGroup")]
        public async Task<IActionResult> UpdateAssignGLaccounttoSubGroup([FromBody] AssignmentSubaccounttoGl assnacckey)
        {
            APIResponse apiResponse = null;
            if (assnacckey == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _assignmentSubaccounttoGLRepository.Update(assnacckey);
                if (_assignmentSubaccounttoGLRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assnacckey };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

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
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _assignmentSubaccounttoGLRepository.Where(x => x.Code==code).SingleOrDefault();
                _assignmentSubaccounttoGLRepository.Remove(record);
                if (_assignmentSubaccounttoGLRepository.SaveChanges() > 0)
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


        [HttpGet("GetGLUnderSubGroupList/{undersubgroup}")]
        public IActionResult GetGLUnderSubGroupList(string undersubgroup)
        {
            try
            {
                try
                {
                    var GetAccountNamelist = _glaugRepository.Where(x => x.Nature == undersubgroup&&x.IsDefault==1);
                    if (GetAccountNamelist.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.GetAccountNamelist = GetAccountNamelist;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for SubGroupList." });
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
                    var structkeyList = _glaugRepository.GetAll().Select(x=>x.StructureKey).Distinct();                
                    if (structkeyList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.structkeyList = structkeyList.ToArray();
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for assignacckeyList." });
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