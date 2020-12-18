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
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace CoreERP.Controllers.masters
{
    [Route("api/MemberMaster")]
    [ApiController]
    public class MemberMasterController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MemberMasterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Vehicle and member
        [HttpGet("GeMemberCode")]
        public async Task<IActionResult> GeMemberCode()
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

        [HttpGet("GetVehicles/{memberCode}")]
        public async Task<IActionResult> GetVehicles(string memberCode)
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;
                List<TblVehicle> _members = null;
                try
                {
                    if (string.IsNullOrEmpty(memberCode))
                    {
                        memberCode = "0";
                    }
                    _members = new MemberMasterHelper().GetVehicles(Convert.ToDecimal(memberCode));

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
        public async Task<IActionResult> GetMembersList([FromBody]VoucherNoSearchCriteria searchCriteria)
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

        [HttpPut("UpdateMemberMaster")]
        public async Task<IActionResult> UpdateMemberMaster([FromBody]TblMemberMaster memberMaster)
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
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
                    }

                    if (memberMaster.MemberCode == null)
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "member code can not be null/empty." });
                    }

                    var result = new MemberMasterHelper().UpdateMemberMaster(memberMaster);
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

        [HttpPut("UpdateVehicle")]
        public async Task<IActionResult> UpdateVehicle([FromBody]TblVehicle vehicle)
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;
                List<TblVehicle> _vehicles = null;
                try
                {
                    // var _member = objData["member"].ToObject<TblMemberMaster>();

                    if (vehicle == null)
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
                    }

                    if (vehicle.MemberCode == null)
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "member code can not be null/empty." });
                    }

                    var result = new MemberMasterHelper().UpdateVehicle(vehicle);
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
        #endregion
        
        #region Gift master
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;
                List<TblProduct> _products = null;
                try
                {
                    _products = new MemberMasterHelper().GetGiftProducts(_configuration);

                    if (_products == null && _products.Count() > 0)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Gift product found." });

                    dynamic expando = new ExpandoObject();
                    expando.GiftProduct = _products.Select(p=>new { id=p.ProductCode ,text=p.ProductName});
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
       
        [HttpGet("GetGifts/{memberCode}")]
        public async Task<IActionResult> GetGifts(string memberCode)
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;
                List<TblGiftMaster> _gifts = null;
                try
                {
                    TblGiftMaster gift = new TblGiftMaster();
                    gift.MemberCode = memberCode;
                    _gifts = new MemberMasterHelper().GetTblGifts(gift);

                    if (_gifts == null && _gifts.Count() > 0)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Gifts found for user"+ memberCode });

                    dynamic expando = new ExpandoObject();
                    expando.Gifts = _gifts;
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

        [HttpPost("AddGifts")]
        public async Task<IActionResult> AddGifts([FromBody] TblGiftMaster gift)
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;
                try
                {
                    TblGiftMaster _gift = new MemberMasterHelper().AddGift(gift, out errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessage });
                    }

                    dynamic expando = new ExpandoObject();
                    expando.Gift = _gift;
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

        [HttpPost("UpdateGift")]
        public async Task<IActionResult> UpdateGift([FromBody] TblGiftMaster gift)
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;
                try
                {
                    TblGiftMaster _gift = new MemberMasterHelper().UpdateGift(gift, out errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessage });
                    }

                    dynamic expando = new ExpandoObject();
                    expando.Gift = _gift;
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
        #endregion

        #region Share Transfer And Additional Share Transfer
        [HttpGet("GetShareTransfer/{memberCode}")]
        public async Task<IActionResult> GetShareTransfer(string memberCode)
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;
                List<TblShareTransfer> _members = null;
                try
                {
                    if (string.IsNullOrEmpty(memberCode))
                    {
                        memberCode = "0";
                    }
                    _members = new MemberMasterHelper().GetShareTransfer(Convert.ToDecimal(memberCode));

                    if (_members == null && _members.Count() > 0)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data found." });

                    dynamic expando = new ExpandoObject();
                    expando.ShareList = _members;
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

        [HttpGet("GetShareTransferNo")]
        public async Task<IActionResult> GetShareTransferNo()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    string errorMessage = string.Empty;
                    dynamic expando = new ExpandoObject();
                    expando.ShareTransferNoList = new MemberMasterHelper().GetShareTransferNo(out errorMessage);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetAdditionalShareTransferNo")]
        public async Task<IActionResult> GetAdditionalShareTransferNo()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    string errorMessage = string.Empty;
                    dynamic expando = new ExpandoObject();
                    expando.ShareTransferNoList = new MemberMasterHelper().GetAdditionalShareTransferNo(out errorMessage);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetShareMembersList")]
        public async Task<IActionResult> GetShareMembersList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.memberList = new MemberMasterHelper().GetShareMembersList().Select(x => new { ID = x.MemberCode, TEXT = x.MemberName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetNoOfShares/{memberCode}")]
        public async Task<IActionResult> GetNoOfShares(decimal memberCode)
        {
            var result = await Task.Run(() =>
            {
                //if (pumpNo == 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Query string parameter missing." });

                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.noOfsharesList = new MemberMasterHelper().GetNoOfShares(memberCode).NoofShares;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetToMemberName/{memberCode}")]
        public async Task<IActionResult> GetToMemberName(decimal memberCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.memberName = new MemberMasterHelper().GetNoOfShares(memberCode).MemberName;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetAdditionalShareTransfer/{memberCode}")]
        public async Task<IActionResult> GetAdditionalShareTransfer(string memberCode)
        {
            var result = await Task.Run(() =>
            {
                string errorMessage = string.Empty;
                List<TblShareTransfer> _members = null;
                try
                {
                    if (string.IsNullOrEmpty(memberCode))
                    {
                        memberCode = "0";
                    }
                    _members = new MemberMasterHelper().GetAdditionalShareTransfer(Convert.ToDecimal(memberCode));

                    if (_members == null && _members.Count() > 0)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data found." });

                    dynamic expando = new ExpandoObject();
                    expando.ShareList = _members;
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

        [HttpPost("RegisterShareTransfer/{memberCode}")]
        public async Task<IActionResult> RegisterShareTransfer(string memberCode, TblShareTransfer shareTransfer)
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

                    if (shareTransfer == null)
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No request records can not empty/null." });
                    }

                    if (shareTransfer.FromMemberCode == 0)
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Frmom Member Code can not be null/empty." });
                    }

                    var result = new MemberMasterHelper().AddShareTransfer(Convert.ToDecimal(memberCode), shareTransfer, out errorMessage);
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
        #endregion
    }
}