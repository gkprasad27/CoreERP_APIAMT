using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/CreationOfCostUnits")]
    public class CreationOfCostUnitsController : ControllerBase
    {
        private readonly IRepository<TblCostingnumberAssigntoObject> _assignmentrepository;
        private readonly IRepository<TblCostingObjectTypes> _costingObjectTypesrepository;
        private readonly IRepository<TblCostingNumberSeries> _numberRangerepository;
        private readonly IRepository<TblCostingUnitsCreation> _costingUnitsCreationRepository;
        public CreationOfCostUnitsController(IRepository<TblCostingUnitsCreation> costingUnitsCreationRepository,
             IRepository<TblCostingnumberAssigntoObject> assignmentepository,
            IRepository<TblCostingObjectTypes> costingObjectTypesrepository,
          IRepository<TblCostingNumberSeries> numberRangerepository)
        {
            _costingUnitsCreationRepository = costingUnitsCreationRepository;
            _costingObjectTypesrepository = costingObjectTypesrepository;
            _assignmentrepository = assignmentepository;
            _numberRangerepository = numberRangerepository;
        }

        [HttpGet("GetObjectNumber/{code}")]
        public IActionResult GetObjectNumber(string code)
        {
            try
            {
                int i = Convert.ToInt32(_assignmentrepository.Where(x => x.ObjectType == code).SingleOrDefault().PresentNumber);
                var Getaccnolist = _assignmentrepository.Where(x => x.ObjectType == code).FirstOrDefault();
                var numrnglist = _numberRangerepository.Where(x => x.NumberObject == Getaccnolist.NumberSeries.ToString()).FirstOrDefault();
                if (i == 0 && Getaccnolist.ObjectType == code)
                {
                    var x = numrnglist.FromInterval;

                    if (Enumerable.Range(Convert.ToInt32(numrnglist.FromInterval), Convert.ToInt32(numrnglist.ToInterval)).Contains(Convert.ToInt32(x)))
                    {
                        if (x >= Convert.ToInt32(numrnglist.FromInterval) && x <= Convert.ToInt32(numrnglist.ToInterval))
                        {
                            var objectno = x + 1;
                            if (objectno != null)
                            {
                                dynamic expdoObj = new ExpandoObject();
                                expdoObj.objectno = objectno;
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
                        var objectno = i + 1;
                        if (objectno != null)
                        {
                            dynamic expdoObj = new ExpandoObject();
                            expdoObj.objectno = objectno;
                            return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                        }
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
                }

                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data.." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
            return Ok();

        }

        [HttpPost("RegisterCreationOfCostUnits")]
        public IActionResult RegisterCreationOfCostUnits([FromBody]TblCostingUnitsCreation costunits)
        {
            if (costunits == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                var result = new CommonHelper().updateobjectcode(costunits);
                _costingUnitsCreationRepository.Add(costunits);
                if (_costingUnitsCreationRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costunits };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCreationOfCostUnitsList")]
        public IActionResult GetCreationOfCostUnitsList()
        {
            try
            {
                var costunitList = CommonHelper.GetCostingUnitsCreation();
                if (costunitList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.costunitList = costunitList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateCreationOfCostUnits")]
        public IActionResult UpdateCreationOfCostUnits([FromBody] TblCostingUnitsCreation costunits)
        {
            if (costunits == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(costunits)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _costingUnitsCreationRepository.Update(costunits);
                if (_costingUnitsCreationRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = costunits };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteCreationOfCostUnits/{code}")]
        public IActionResult DeleteCreationOfCostUnitsbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _costingUnitsCreationRepository.GetSingleOrDefault(x => x.ObjectNumber.Equals(code));
                _costingUnitsCreationRepository.Remove(record);
                if (_costingUnitsCreationRepository.SaveChanges() > 0)
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