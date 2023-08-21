using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/MaterialMaster")]
    public class MaterialMasterController : ControllerBase
    {
        private readonly IRepository<TblMaterialNoAssignment> _assignmentrepository;
        private readonly IRepository<TblMaterialTypes> _materialtyperepository;
        private readonly IRepository<TblMaterialNoSeries> _numberRangerepository;
        private readonly IRepository<TblMaterialMaster> _materialMasterRepository;
        public MaterialMasterController(IRepository<TblMaterialMaster> materialMasterRepository,
            IRepository<TblMaterialNoAssignment> assignmentepository, IRepository<TblMaterialTypes> materialtyperepository,
          IRepository<TblMaterialNoSeries> numberRangerepository)
        {
            _materialMasterRepository = materialMasterRepository;
            _materialtyperepository = materialtyperepository;
            _assignmentrepository = assignmentepository;
            _numberRangerepository = numberRangerepository;
        }


        [HttpGet("GetMaterialNumber/{code}")]
        public IActionResult GetMaterialNumber(string code)
        {
            try
            {
                int i = Convert.ToInt32(_numberRangerepository.Where(x => x.Code == code).SingleOrDefault()?.CurrentNumber);
                var Getaccnolist = _assignmentrepository.Where(x => x.MaterialType == code).FirstOrDefault();
                if (Getaccnolist != null)
                {
                    var numrnglist = _numberRangerepository.Where(x => x.Code == Getaccnolist.NumberRange.ToString()).FirstOrDefault();

                    if (i == 0 && Getaccnolist.MaterialType == code)
                    {
                        var x = numrnglist.FromInterval;

                        if (Enumerable.Range(Convert.ToInt32(numrnglist.FromInterval), Convert.ToInt32(numrnglist.ToInterval)).Contains(Convert.ToInt32(x)))
                        {
                            if (x >= Convert.ToInt32(numrnglist.FromInterval) && x <= Convert.ToInt32(numrnglist.ToInterval))
                            {
                                var materialnum = x + 1;
                                if (materialnum != null)
                                {
                                    dynamic expdoObj = new ExpandoObject();
                                    expdoObj.materialnum = materialnum;
                                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                                }
                            }
                            else
                                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
                        }
                    }
                    else
                    if (Enumerable.Range(Convert.ToInt32(numrnglist.FromInterval), Convert.ToInt32(numrnglist.ToInterval)).Contains(i))
                    {
                        if (i >= Convert.ToInt32(numrnglist.FromInterval) && i <= Convert.ToInt32(numrnglist.ToInterval))
                        {
                            var materialnum = i + 1;
                            if (materialnum != null)
                            {
                                dynamic expdoObj = new ExpandoObject();
                                expdoObj.materialnum = materialnum;
                                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                            }
                        }
                        else
                            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
                    }

                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data.." });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Not Configured Material Number. Continue with Enter Manual Number." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
            return Ok();

        }

        [HttpPost("RegisterMaterialMaster")]
        public IActionResult RegisterMaterialMaster([FromBody] TblMaterialMaster mmaster)
        {
            if (mmaster == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                var result = new CommonHelper().updatemmaterielcode(mmaster);
                _materialMasterRepository.Add(mmaster);
                if (_materialMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mmaster };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMaterialMasterList")]
        public IActionResult GetMaterialMasterList()
        {
            try
            {
                var mmasterList = CommonHelper.GetMaterialMaster();
                if (mmasterList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.mmasterList = mmasterList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateMaterialMaster")]
        public IActionResult UpdateMaterialMaster([FromBody] TblMaterialMaster mmaster)
        {
            if (mmaster == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(mmaster)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _materialMasterRepository.Update(mmaster);
                if (_materialMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mmaster };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMaterialMaster/{code}")]
        public IActionResult DeleteMaterialMasterbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _materialMasterRepository.GetSingleOrDefault(x => x.MaterialCode.Equals(code));
                _materialMasterRepository.Remove(record);
                if (_materialMasterRepository.SaveChanges() > 0)
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