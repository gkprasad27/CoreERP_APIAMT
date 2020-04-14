using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CoreERP.Controllers.masters
{
    [Route("api/MemberMaster")]
    [ApiController]
    public class MemberMasterController : ControllerBase
    {
        [HttpGet("GeMemberCode")]
        public async Task<IActionResult> GeneratePurchaseReturnInvNo()
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;

                try
                {
                    var _memberCode = new MemberMasterHelper().GenerateMemberCode();
                    if (_memberCode != null)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessage });

                    dynamic expando = new ExpandoObject();
                    expando.MemberCode = _memberCode;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    string message = string.Empty;

                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }
                    else
                    {
                        message = ex.Message;
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
                }
            });
            return result;
        }

        [HttpGet("GetTitles")]
        public async Task<IActionResult> GetTitles()
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;

                try
                {
                    var _tilesList = new MemberMasterHelper().GetTitles();
                    if (_tilesList == null || _tilesList.Count() == 0)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No tile record found." });

                    dynamic expando = new ExpandoObject();
                    expando.TileNameList = _tilesList.Select(t=> new { ID=t.TitleName,TEXT=t.TitleName});
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    string message = string.Empty;

                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }
                    else
                    {
                        message = ex.Message;
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
                }
            });
            return result;
        }

        [HttpGet("GetVehicles/{memberId}")]
        public async Task<IActionResult> GetVehicles(string memberId)
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;
                List<TblVehicle> _members = null;
                try
                {
                    if (string.IsNullOrEmpty(memberId))
                    {
                        memberId = "0";
                    }
                    _members = new MemberMasterHelper().GetVehicles(Convert.ToDecimal(memberId));

                    if (_members == null && _members.Count() > 0)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data found." });

                    dynamic expando = new ExpandoObject();
                    expando.VechicleList = _members;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    string message = string.Empty;

                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }
                    else
                    {
                        message = ex.Message;
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
                }
            });
            return result;
        }

        [HttpGet("GetStates")]
        public async Task<IActionResult> GetStates()
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;
               
                try
                {
                   var _stateList = new MemberMasterHelper().GetStateWiseGsts(null);

                    if (_stateList == null && _stateList.Count()== 0)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No States Data found." });

                    dynamic expando = new ExpandoObject();
                    expando.StateList = _stateList.Select(x => new { ID = x.StateCode, TEXT = x.StateName, IsDefualtSelected = (x.IsDefault == 1) });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    string message = string.Empty;

                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }
                    else
                    {
                        message = ex.Message;
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
                }
            });
            return result;
        }

        [HttpGet("GetPassbookStatuses")]
        public async Task<IActionResult> GetPassbookStatuses()
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;

                try
                {
                    var _passbookStatuses = new MemberMasterHelper().GetPassbookStatuses();

                    if (_passbookStatuses == null && _passbookStatuses.Count() == 0)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No passbook statuses found." });

                    dynamic expando = new ExpandoObject();
                    expando.PassbookStatuses = _passbookStatuses.Select(x => new { ID = x.PassbookStatusName, TEXT = x.PassbookStatusName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    string message = string.Empty;

                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }
                    else
                    {
                        message = ex.Message;
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
                }
            });
            return result;
        }

        [HttpGet("GetRelations")]
        public async Task<IActionResult> GetRelations()
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;

                try
                {
                    var _relations = new MemberMasterHelper().GetRelations();

                    if (_relations == null && _relations.Count() == 0)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No relations Data found." });

                    dynamic expando = new ExpandoObject();
                    expando.PassbookStatuses = _relations.Select(x => new { ID = x.RelationName, TEXT = x.RelationName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    string message = string.Empty;

                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }
                    else
                    {
                        message = ex.Message;
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
                }
            });
            return result;
        }

        [HttpGet("GetVehicleTypes")]
        public async Task<IActionResult> GetVehicleTypes()
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;

                try
                {
                    var _VehicleTypes = new MemberMasterHelper().GetVehicleTypes();

                    if (_VehicleTypes == null && _VehicleTypes.Count() == 0)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No vechile types found." });

                    dynamic expando = new ExpandoObject();
                    expando.VehicleTypes = _VehicleTypes.Select(x => new { ID = x.VehicleTypeId, TEXT = x.VehicleTypeName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    string message = string.Empty;

                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }
                    else
                    {
                        message = ex.Message;
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
                }
            });
            return result;
        }

        [HttpPost("GetMembersList")]
        public async Task<IActionResult> GetMembersList([FromBody]SearchCriteria searchCriteria)
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;

                try
                {
                    var _membersList = new MemberMasterHelper().GetMemberMasters(searchCriteria);

                    if (_membersList == null && _membersList.Count() == 0)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No members found." });

                    dynamic expando = new ExpandoObject();
                    expando.MembersList = _membersList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    string message = string.Empty;

                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }
                    else
                    {
                        message = ex.Message;
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
                }
            });
            return result;
        }

        [HttpPost("RegisterMemberMaster")]
        public async Task<IActionResult> RegisterMemberMaster([FromBody]TblMemberMaster memberMaster)
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;
                List<TblVehicle> _vehicles = null;
                try
                {
                   // var _member = objData["member"].ToObject<TblMemberMaster>();

                    if (memberMaster == null)
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No request records can not empty/null." });
                    }
                   
                    if (memberMaster.MemberCode == null)
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "member code can not be null/empty." });
                    }

                    var result = new MemberMasterHelper().AddMemberMaster(memberMaster, null,out errorMessage);
                    if(result == null)
                    {
                        if (string.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "Registration Failed.";
                        }

                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessage });
                    }

                    dynamic expando = new ExpandoObject();
                    expando.Member = result;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    string message = string.Empty;

                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }
                    else
                    {
                        message = ex.Message;
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
                }
            });
            return result;
        }

        [HttpPost("RegisterMemberMaster/{memberCode}")]
        public async Task<IActionResult> RegisterMemberMaster(string memberCode,TblVehicle vehicle)
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;
               
                try
                {
                    if (string.IsNullOrEmpty(memberCode))
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "member Code query string can not be null/empty." });
                    }

                    if (vehicle == null)
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No request records can not empty/null." });
                    }

                    if (vehicle.VehicleRegNo == null)
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "vehicle no can not be null/empty." });
                    }

                    var result = new MemberMasterHelper().AddVehicles(Convert.ToDecimal(memberCode), vehicle, out errorMessage);
                    if (result == null)
                    {
                        if (string.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "Registration Failed.";
                        }

                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessage });
                    }

                    dynamic expando = new ExpandoObject();
                    expando.Member = result;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    string message = string.Empty;

                    if (ex.InnerException != null)
                    {
                        message = ex.InnerException.Message;
                    }
                    else
                    {
                        message = ex.Message;
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
                }
            });
            return result;
        }

    }
}