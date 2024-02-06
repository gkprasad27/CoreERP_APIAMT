using System;
using System.Collections.Generic;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.DataAccess;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/QCParamConfig")]
    public class QCParamConfigController : ControllerBase
    {
        private readonly IRepository<TblQCParamConfig> _qcparamRepository;
        public QCParamConfigController(IRepository<TblQCParamConfig> qcparamRepository)
        {
            _qcparamRepository = qcparamRepository;
        }

        [HttpPost("RegisterQCParam")]
        public IActionResult RegisterQCParam([FromBody] TblQCParamConfig citem)
        {
            if (citem == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _qcparamRepository.Add(citem);
                if (_qcparamRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = citem };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetQCParamsList")]
        public async Task<IActionResult> GetQCParamsList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var citemList = _qcparamRepository.GetAll();
                    if (citemList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.QCPList = citemList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }

                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }
        public List<tblQCResults> GetQCResult(string materialcode, string tagname,string type)
        {
            using var repo = new Repository<tblQCResults>();
            //var MaterialCodes = repo.TblMaterialMaster.ToList();

           return repo.tblQCResults.Where(cd => cd.MaterialCode == materialcode && cd.TagName == tagname && cd.Type == type).ToList();
            
        }
        [HttpGet("GetCommitmentItemList/{materialcode}/{tagname}/{type}")]
        public async Task<IActionResult> GetCommitmentItemList(string materialcode, string tagname, string Type)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expdoObj = new ExpandoObject();
                    var tagsData = GetQCResult(materialcode, tagname, Type).Select(x => new { id = x.Id, description = x.Parameter , type =x.Type,result=x.Result});
                    int count=tagsData.Count();
                    if (count==0)
                    {
                        var tagsData1 = _qcparamRepository.Where(x => x.Type.Equals(Type));
                        expdoObj.citemList = tagsData1;
                    }
                    else
                        expdoObj.citemList = tagsData;

                    //var citemList = _commitmentItemRepository.Where(x => x.Type.Equals(Type));
                    //if (citemList.Any())
                    //{
                    //    dynamic expdoObj = new ExpandoObject();
                    //    expdoObj.citemList = citemList;
                    //    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    //}

                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }
        [HttpGet("GetCommitmentItemList/{type}")]
        public async Task<IActionResult> GetCommitmentItemList(string Type)
        {
            var result = await Task.Run(() =>
            {
                try
                {

                    var citemList = _qcparamRepository.Where(x => x.Type.Equals(Type)).OrderBy(z=>z.SortOrder);
                    if (citemList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.citemList = citemList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }

                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPut("UpdateQCParams")]
        public IActionResult UpdateQCParams([FromBody] TblQCParamConfig citem)
        {
            if (citem == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(citem)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _qcparamRepository.Update(citem);
                if (_qcparamRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = citem };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteQCParam/{code}")]
        public IActionResult DeleteQCParam(int code)
        {
            try
            {
                if (code ==0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _qcparamRepository.GetSingleOrDefault(x => x.ID.Equals(code));
                _qcparamRepository.Remove(record);
                if (_qcparamRepository.SaveChanges() > 0)
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