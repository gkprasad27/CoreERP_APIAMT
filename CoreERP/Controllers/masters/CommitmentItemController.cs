using System;
using System.Collections.Generic;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.DataAccess;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/CommitmentItem")]
    public class CommitmentItemController : ControllerBase
    {
        private readonly IRepository<TblCommitmentItem> _commitmentItemRepository;
        public CommitmentItemController(IRepository<TblCommitmentItem> commitmentItemRepository)
        {
            _commitmentItemRepository = commitmentItemRepository;
        }

        [HttpPost("RegisterCommitmentItem")]
        public IActionResult RegisterCommitmentItem([FromBody] TblCommitmentItem citem)
        {
            if (citem == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _commitmentItemRepository.Add(citem);
                if (_commitmentItemRepository.SaveChanges() > 0)
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

        [HttpGet("GetCommitmentItemList")]
        public async Task<IActionResult> GetCommitmentItemList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var citemList = _commitmentItemRepository.GetAll();
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
                    var tagsData = GetQCResult(materialcode, tagname, Type).Select(x => new { code = x.Id, description = x.Parameter , type =x.Type,result=x.Result}); ;
                    if (tagsData == null )
                    {
                        var tagsData1 = _commitmentItemRepository.Where(x => x.Type.Equals(Type));
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

                    var citemList = _commitmentItemRepository.Where(x => x.Type.Equals(Type)).OrderBy(z=>z.SortOrder);
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

        [HttpPut("UpdateCommitmentItem")]
        public IActionResult UpdateCommitmentItem([FromBody] TblCommitmentItem citem)
        {
            if (citem == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(citem)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _commitmentItemRepository.Update(citem);
                if (_commitmentItemRepository.SaveChanges() > 0)
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

        [HttpDelete("DeleteCommitmentItem/{code}")]
        public IActionResult DeleteCommitmentItembyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _commitmentItemRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _commitmentItemRepository.Remove(record);
                if (_commitmentItemRepository.SaveChanges() > 0)
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