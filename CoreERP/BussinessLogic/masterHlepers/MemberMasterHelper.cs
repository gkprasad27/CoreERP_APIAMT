using CoreERP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.Models;
using CoreERP.Helpers.SharedModels;
using Microsoft.Extensions.Configuration;
using CoreERP.BussinessLogic.Common;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class MemberMasterHelper
    {
        public decimal? GenerateMemberCode()
        {
            try
            {
                decimal? memberCode = null;
                using (Repository<TblMemberMaster> _repo = new Repository<TblMemberMaster>())
                {
                    if (_repo.TblMemberMaster.Count() > 0)
                    {
                        memberCode = _repo.TblMemberMaster.Max(x => x.MemberCode);
                    }
                    else
                    {
                        memberCode = 0;
                    }
                }

                return memberCode + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblMemberMaster> GetMemberMasters(VoucherNoSearchCriteria searchCriteria)
        {
            try
            {
                searchCriteria.FromDate = searchCriteria.FromDate ?? DateTime.Today;
                searchCriteria.ToDate = searchCriteria.ToDate ?? DateTime.Today;
                if (string.IsNullOrEmpty(searchCriteria.InvoiceNo))
                    searchCriteria.InvoiceNo = null;
                if (string.IsNullOrEmpty(searchCriteria.Name))
                    searchCriteria.Name = null;
                if (string.IsNullOrEmpty(searchCriteria.Vehicle))
                    searchCriteria.Vehicle = null;
                using Repository<TblMemberMaster> _repo = new Repository<TblMemberMaster>();
                List<TblMemberMaster> _membermasterList = null;
                {
                    if (searchCriteria.Vehicle != null)
                    {
                        _membermasterList = (from MM in _repo.TblMemberMaster join v in _repo.TblVehicle on MM.MemberCode equals v.MemberCode
                                            where (MM.MemberCode.ToString().Contains((searchCriteria.InvoiceNo == null ? MM.MemberCode.ToString() : searchCriteria.InvoiceNo))
                                             && v.IsValid==1  && MM.MemberName.ToLower().Contains((searchCriteria.Name ?? MM.MemberName).ToLower()) && v.VehicleRegNo.ToLower().Contains((searchCriteria.Vehicle ?? v.VehicleRegNo).ToLower()))
                                         select MM).ToList();
                                                        //_membermasterList = (from MM in _repo.TblMemberMaster
                        //                     join Vehicle in _repo.TblVehicle on MM.MemberCode equals Vehicle.MemberCode
                        //                     where (MM.MemberCode.ToString().Contains((searchCriteria.InvoiceNo == null ? MM.MemberCode.ToString() : searchCriteria.InvoiceNo))
                        //                  && MM.MemberName.ToLower().Contains((searchCriteria.Name ?? MM.MemberName).ToLower()) && Vehicle.VehicleRegNo.ToString()
                        //                  .Contains((searchCriteria.Vehicle == null ? Vehicle.VehicleRegNo.ToString() : searchCriteria.Vehicle)))
                        //                     select MM).ToList();

                    }

                    else
                    {
                        _membermasterList= _repo.TblMemberMaster
                                .Where(m => m.MemberCode.ToString().Contains((searchCriteria.InvoiceNo == null ? m.MemberCode.ToString() : searchCriteria.InvoiceNo))
                                         && m.MemberName.ToLower().Contains((searchCriteria.Name ?? m.MemberName).ToLower()))
                                .OrderBy(m => m.MemberCode).ToList();
                    }
                    return _membermasterList.OrderBy(m => m.MemberCode).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Vechile
        public List<TblVehicle> GetVehicles(decimal? memberCode)
        {
            try
            {
                using (Repository<TblVehicle> _repo = new Repository<TblVehicle>())
                {
                    return _repo.TblVehicle.Where(v => v.MemberCode == memberCode).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblVehicleType> GetVehicleTypes()
        {
            try
            {
                using (Repository<TblVehicleType> _repo = new Repository<TblVehicleType>())
                {
                    return _repo.TblVehicleType.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TblMemberMaster> GetMemberMastersList()
        {
            try
            {
                using Repository<TblMemberMaster> repo = new Repository<TblMemberMaster>();
                return repo.TblMemberMaster.ToList();

            }
            catch { throw; }
        }

        public TblVehicle UpdateVehicle(TblVehicle vehicle)
        {
            try
            {
                using (Repository<TblVehicle> _repo = new Repository<TblVehicle>())
                {
                    var _memberShare = GetMemberMastersList().Where(m => m.MemberCode == vehicle.MemberCode).FirstOrDefault();
                    var _vehicleType = GetVehicleTypes().Where(v => v.VehicleTypeName == vehicle.VehicleTypeName).FirstOrDefault();
                    vehicle.VehicleTypeId = _vehicleType.VehicleTypeId;
                    vehicle.MemberShares = _memberShare.TotalShares;
                    _repo.TblVehicle.Update(vehicle);
                    if (_repo.SaveChanges() > 0)
                        return vehicle;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region PASS BOOk
        public List<TblPassbookStatus> GetPassbookStatuses()
        {
            try
            {
                using (Repository<TblPassbookStatus> _repo = new Repository<TblPassbookStatus>())
                {
                    return _repo.TblPassbookStatus.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public List<TblTitle> GetTitles()
        {
            try
            {
                using (Repository<TblTitle> _repo = new Repository<TblTitle>())
                {
                    return _repo.TblTitle.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblStateWiseGst> GetStateWiseGsts(string stateId = null)
        {
            try
            {
                using (Repository<TblStateWiseGst> repo = new Repository<TblStateWiseGst>())
                {
                    return repo.TblStateWiseGst.Where(s => s.StateCode == (stateId ?? s.StateCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TblRelation> GetRelations()
        {
            try
            {
                using (Repository<TblRelation> repo = new Repository<TblRelation>())
                {
                    return repo.TblRelation.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsMemberCodeExists(decimal? memberCode)
        {
            try
            {
                using (Repository<TblMemberMaster> repo = new Repository<TblMemberMaster>())
                {
                    return repo.TblMemberMaster.Where(m => m.MemberCode == memberCode).Count() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsVechileNoExists(decimal? membercode, string vehicleRegNo)
        {
            try
            {
                using (Repository<TblVehicle> _repo = new Repository<TblVehicle>())
                {
                    return _repo.TblVehicle.Where(v => v.MemberCode == membercode && v.VehicleRegNo == vehicleRegNo).Count() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Registration
        public TblMemberMaster AddMemberMaster(TblMemberMaster memberMaster, List<TblVehicle> vehicles, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                if (IsMemberCodeExists(memberMaster.MemberCode))
                {
                    errorMessage = "Member code already exists.Please generate anothermember code.";
                    return null;
                }

                using (ERPContext context = new ERPContext())
                {
                    using (var dbTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var _memberMaster = AddMemberMaster(context, memberMaster);
                            var _accountLedger = AddAccountLedger(context, memberMaster);
                            if (_memberMaster == null)
                            {
                                errorMessage = "Rgistration failed.";
                                return null;
                            }

                            ////add vechicile
                            //if (vehicles != null && vehicles.Count() > 0)
                            //{
                            //    foreach (var vehicle in vehicles)
                            //    {
                            //        AddVechicle(context, _memberMaster, vehicle);
                            //    }
                            //}
                        }
                        catch (Exception ex)
                        {
                            dbTransaction.Rollback();
                            throw ex;
                        }

                        dbTransaction.CommitAsync();
                        return memberMaster;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblVehicle AddVehicles(decimal? memberCode, TblVehicle vehicle, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                if (memberCode == null)
                {
                    errorMessage = "MemberCode Cannot be null.";
                    return null;
                }
                if (vehicle == null)
                {
                    errorMessage = "Vehicle Cannot be null.";
                    return null;
                }

                if (IsVechileNoExists(memberCode, vehicle.VehicleRegNo))
                {
                    errorMessage = $"vehicle no :{vehicle.VehicleRegNo} is exists for member code :{memberCode}";
                    return null;
                }

                using (ERPContext context = new ERPContext())
                {
                    var _member = context.TblMemberMaster.Where(x => x.MemberCode == memberCode).FirstOrDefault();

                    var _vechile = AddVechicle(context, _member, vehicle);

                    if (_vechile == null)
                    {
                        errorMessage = "Regitration failed for vechile.";
                        return null;
                    }

                    return _vechile;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private TblMemberMaster AddMemberMaster(ERPContext context, TblMemberMaster memberMaster)
        {
            try
            {
                memberMaster.IsActive = 1;
                memberMaster.NoofShares = memberMaster.NoofShares ?? 0;
                memberMaster.IssuedShares = memberMaster.IssuedShares ?? 0;
                memberMaster.ReceivedShares = memberMaster.ReceivedShares ?? 0;
                memberMaster.CreatedDate = DateTime.Now;
                context.TblMemberMaster.Add(memberMaster);
                if (context.SaveChanges() > 0)
                    return memberMaster;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TblAccountLedger AddAccountLedger(ERPContext context, TblMemberMaster memberMaster)
        {
            try
            {
                TblAccountLedger accountLedger = new TblAccountLedger();
                var record = context.TblAccountLedger.OrderByDescending(x => x.LedgerId).FirstOrDefault();
                if (record != null)
                {
                    accountLedger.LedgerId = Convert.ToDecimal(CommonHelper.IncreaseCode(record.LedgerId.ToString()));
                }
                else
                    accountLedger.LedgerId = 1;
                accountLedger.AccountGroupId = 7577;
                accountLedger.LedgerCode = memberMaster.MemberCode.ToString();
                accountLedger.LedgerName = memberMaster.MemberName;
                accountLedger.Address = memberMaster.Address;
                accountLedger.OpeningBalance = 0;
                accountLedger.Phone = memberMaster.Phone;
                accountLedger.Mobile = memberMaster.Mobile;
                accountLedger.Email = memberMaster.Email;
                accountLedger.IsDefault = false;
                accountLedger.CrOrDr = "Credit";
                accountLedger.MailingName = memberMaster.MemberName;
                accountLedger.CreditPeriod = 0;
                accountLedger.CreditLimit = 0;
                accountLedger.PricinglevelId = 1;
                accountLedger.AccountTypeId = 3;
                accountLedger.AccountTypeName = "CREDIT A/C";
                context.TblAccountLedger.Add(accountLedger);
                if (context.SaveChanges() > 0)
                    return accountLedger;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TblVehicle AddVechicle(ERPContext context, TblMemberMaster memberMaster, TblVehicle vehicle)
        {
            try
            {
                vehicle.IsValid = 1;
                vehicle.MemberId = memberMaster.MemberId;
                vehicle.MemberCode = memberMaster.MemberCode;
                vehicle.MemberShares = memberMaster.TotalShares;
                var _vehicleType = GetVehicleTypes().Where(v=>v.VehicleTypeName==vehicle.VehicleTypeName).FirstOrDefault();
                vehicle.VehicleTypeId = _vehicleType.VehicleTypeId;
                if (context == null)
                {
                    using (context = new ERPContext())
                    {
                        context.TblVehicle.Add(vehicle);
                        if (context.SaveChanges() > 0)
                            return vehicle;

                        return null;
                    }
                }
                else
                {
                    context.TblVehicle.Add(vehicle);
                    if (context.SaveChanges() > 0)
                        return vehicle;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        public TblMemberMaster UpdateMemberMaster(TblMemberMaster memberMaster)
        {
            try
            {
                using (Repository<TblMemberMaster> _repo = new Repository<TblMemberMaster>())
                {
                    _repo.TblMemberMaster.Update(memberMaster);
                    if (_repo.SaveChanges() > 0)
                        return memberMaster;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Gift Master

        public List<TblProduct> GetGiftProducts(IConfiguration configuration)
        {
            try
            {
                decimal _productgroup = Convert.ToDecimal(configuration.GetSection($"{ConfigurationENUM.MemberMaster.ToString()}:{ConfigurationENUM.GiftProductGroup}").Value);
                return new ProductHelper().GetProductList().Where(p => p.ProductGroupCode == _productgroup).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<TblGiftMaster> GetTblGifts(TblGiftMaster giftMaster)
        {
            try
            {
                using (Repository<TblGiftMaster> _repo = new Repository<TblGiftMaster>())
                {
                    return _repo.TblGiftMaster
                                .Where(g => g.MemberCode == giftMaster.MemberCode
                                       && g.Status.Value)
                                .ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool IsGiftExists(TblGiftMaster giftMaster)
        {
            try
            {
                using (Repository<TblGiftMaster> _repo = new Repository<TblGiftMaster>())
                {
                    return _repo.TblGiftMaster
                                  .Where(gif => gif.MemberCode == giftMaster.MemberCode
                                             && gif.Year == giftMaster.Year)
                                  .Count() > 0;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public TblGiftMaster AddGift(TblGiftMaster giftMaster,out string errorMsg)
        {
            try
            {
                errorMsg = string.Empty;

                if (IsGiftExists(giftMaster))
                {
                    errorMsg = "Gift exists for member code" + giftMaster.MemberCode;
                    return null;
                }
             
                giftMaster.Status = true;
                //giftMaster.Year = DateTime.Now.Year;
                giftMaster.AddDate = DateTime.Now;

                using (Repository<TblGiftMaster> _repo=new Repository<TblGiftMaster>())
                {
                    _repo.TblGiftMaster.Add(giftMaster);
                    if (_repo.SaveChanges() > 0)
                    {
                        TblMemberMaster memberMaster = this.GetMemberMasters(new VoucherNoSearchCriteria() { VoucherNo = giftMaster.MemberCode }).FirstOrDefault();
                        memberMaster.GiftIssued = "Yes";
                        this.UpdateMemberMaster(memberMaster);

                        return giftMaster;
                    }

                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public TblGiftMaster UpdateGift(TblGiftMaster giftMaster, out string errorMsg)
        {
            try
            {
                errorMsg = string.Empty;

                giftMaster.EditDate = DateTime.Now;

                using (Repository<TblGiftMaster> _repo = new Repository<TblGiftMaster>())
                {
                    _repo.TblGiftMaster.Update(giftMaster);
                    if (_repo.SaveChanges() > 0)
                        return giftMaster;

                    errorMsg = "Updation failed for gift";
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Share Transfer And Additional Share Transfer
        public List<TblShareTransfer> GetShareTransfer(decimal? memberCode)
        {
            try
            {
                using (Repository<TblShareTransfer> _repo = new Repository<TblShareTransfer>())
                {
                    return _repo.TblShareTransfer.Where(v => v.FromMemberCode == memberCode).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetShareTransferNo(out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                string suffix = string.Empty, prefix = string.Empty, billno = string.Empty;
                TblShareTransfer _shareTransfer = null;
                using (Repository<TblShareTransfer> _repo = new Repository<TblShareTransfer>())
                {
                    _shareTransfer = _repo.TblShareTransfer.Where(x => x.FromMemberCode != 10000 ).OrderByDescending(x => x.TransferDate).FirstOrDefault();

                    if (_shareTransfer != null)
                    {
                        var invSplit = _shareTransfer.ShareTransferCode.Split('-');
                        billno = $"{invSplit[0]}-{Convert.ToDecimal(invSplit[1]) + 1}-{invSplit[2]}";
                    }
                    else
                    {
                        new Common.CommonHelper().GetSuffixPrefix(47, "1", out prefix, out suffix);
                        if (string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                        {
                            errorMessage = $"No prefix and suffix confugured for branch code: {"1"} ";
                            return billno = string.Empty;
                        }

                        billno = $"{prefix}-1-{suffix}";
                    }
                }

                if (string.IsNullOrEmpty(billno))
                {
                    errorMessage = "Share Transfer no not gererated please enter manully.";
                }

                return billno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblMemberMaster> GetShareMembersList()
        {
            try
            {
                using Repository<TblMemberMaster> repo = new Repository<TblMemberMaster>();
                return repo.TblMemberMaster.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public TblMemberMaster GetNoOfShares(decimal memberCode)
        {

            try
            {
                using Repository<TblMemberMaster> repo = new Repository<TblMemberMaster>();
                //return repo.TblMemberMaster.Where(m=>m.MemberCode==memberCode).ToList();
                var _noofShare = repo.TblMemberMaster.Where(x => x.MemberCode == memberCode).FirstOrDefault();
                return _noofShare;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblShareTransfer> GetAdditionalShareTransfer(decimal? memberCode)
        {
            try
            {
                using (Repository<TblShareTransfer> _repo = new Repository<TblShareTransfer>())
                {
                    return _repo.TblShareTransfer.Where(v => v.ToMemberCode == memberCode && v.FromMemberCode==10000).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblShareTransfer AddShareTransfer(decimal? memberCode, TblShareTransfer shareTransfer, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                if (memberCode == null)
                {
                    errorMessage = "MemberCode Cannot be null.";
                    return null;
                }
                if (shareTransfer == null)
                {
                    errorMessage = "Share Transfer Cannot be null.";
                    return null;
                }

                //if (IsVechileNoExists(memberCode, vehicle.VehicleRegNo))
                //{
                //    errorMessage = $"vehicle no :{vehicle.VehicleRegNo} is exists for member code :{memberCode}";
                //    return null;
                //}

                using (ERPContext context = new ERPContext())
                {
                    var _member = context.TblMemberMaster.Where(x => x.MemberCode == memberCode).FirstOrDefault();
                    var _Frommember = context.TblMemberMaster.Where(x => x.MemberCode == shareTransfer.FromMemberCode).FirstOrDefault();
                    var _shareTransfer = AddShare(context, _member, shareTransfer);
                    var _updatemember = UpdateMember(_Frommember,shareTransfer);
                    if (_shareTransfer == null)
                    {
                        errorMessage = "Regitration failed for Share Transfer.";
                        return null;
                    }

                    return _shareTransfer;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TblShareTransfer AddShare(ERPContext context, TblMemberMaster memberMaster, TblShareTransfer shareTransfer)
        {
            try
            {
                var _Frommember = context.TblMemberMaster.Where(x => x.MemberCode == shareTransfer.FromMemberCode).FirstOrDefault();
                shareTransfer.IsSharesTransfered = 1;
                shareTransfer.ShareCode = -1;
                shareTransfer.ToMemberCode = memberMaster.MemberCode??0;
                shareTransfer.ToMemberName = memberMaster.MemberName;
                shareTransfer.ToMemberId = memberMaster.MemberId??0;
                shareTransfer.FromMemberName = _Frommember.MemberName;
                shareTransfer.FromMemberId = _Frommember.MemberId ?? 0;
                if(shareTransfer.FromMemberCode!= 10000)
                {
                    shareTransfer.FromMemberSharesAfter = 0;
                    shareTransfer.ToMemberSharesAfter = shareTransfer.FromMemberSharesBefore + shareTransfer.ToMemberSharesBefore;
                }
                //vehicle.MemberShares = memberMaster.TotalShares;
                //var _vehicleType = GetVehicleTypes().Where(v => v.VehicleTypeName == vehicle.VehicleTypeName).FirstOrDefault();
                //vehicle.VehicleTypeId = _vehicleType.VehicleTypeId;
                if (context == null)
                {
                    using (context = new ERPContext())
                    {
                        context.TblShareTransfer.Add(shareTransfer);
                        if (context.SaveChanges() > 0)
                            return shareTransfer;

                        return null;
                    }
                }
                else
                {
                    context.TblShareTransfer.Add(shareTransfer);
                    if (context.SaveChanges() > 0)
                        return shareTransfer;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetAdditionalShareTransferNo(out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                string suffix = string.Empty, prefix = string.Empty, billno = string.Empty;
                TblShareTransfer _shareTransfer = null;
                using (Repository<TblShareTransfer> _repo = new Repository<TblShareTransfer>())
                {
                    _shareTransfer = _repo.TblShareTransfer.Where(x => x.FromMemberCode == 10000).OrderByDescending(x => x.TransferDate).FirstOrDefault();

                    if (_shareTransfer != null)
                    {
                        var invSplit = _shareTransfer.ShareTransferCode.Split('-');
                        billno = $"{invSplit[0]}-{Convert.ToDecimal(invSplit[1]) + 1}-{invSplit[2]}";
                    }
                    else
                    {
                        new Common.CommonHelper().GetSuffixPrefix(48, "1", out prefix, out suffix);
                        if (string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                        {
                            errorMessage = $"No prefix and suffix confugured for branch code: {"1"} ";
                            return billno = string.Empty;
                        }

                        billno = $"{prefix}-1-{suffix}";
                    }
                }

                if (string.IsNullOrEmpty(billno))
                {
                    errorMessage = "Additional Share Transfer no not gererated please enter manully.";
                }

                return billno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblMemberMaster UpdateMember(TblMemberMaster member, TblShareTransfer shareTransfer)
        {
            try
            {
                using (Repository<TblMemberMaster> _repo = new Repository<TblMemberMaster>())
                {
                    member.TotalShares = shareTransfer.FromMemberSharesAfter;
                    member.NoofShares = shareTransfer.FromMemberSharesAfter;
                    member.IssuedShares = shareTransfer.ToMemberSharesAfter;
                    _repo.TblMemberMaster.Update(member);
                    if (_repo.SaveChanges() > 0)
                        return member;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
