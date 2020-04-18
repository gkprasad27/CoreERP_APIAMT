using CoreERP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.Models;
using CoreERP.Helpers.SharedModels;

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

        public List<TblMemberMaster> GetMemberMasters(SearchCriteria searchCriteria)
        {
            try
            {
                searchCriteria.FromDate = searchCriteria.FromDate ?? DateTime.Today;
                searchCriteria.ToDate = searchCriteria.ToDate ?? DateTime.Today;
                
                using (Repository<TblMemberMaster> _repo = new Repository<TblMemberMaster>())
                {
                    return _repo.TblMemberMaster
                                 .Where(m =>m.MemberCode.ToString().Contains((searchCriteria.InvoiceNo == null ? m.MemberCode.ToString() : searchCriteria.InvoiceNo))
                                          && m.MemberName.Contains((searchCriteria.Name ?? m.MemberName)))
                                 .ToList();
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        
        public  List<TblTitle> GetTitles()
        {
            try
            {
                using (Repository<TblTitle> _repo = new Repository<TblTitle>())
                {
                    return _repo.TblTitle.ToList();
                }
            }
            catch(Exception ex)
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

        public bool IsVechileNoExists(decimal? membercode,string vehicleRegNo)
        {
            try
            {
                using(Repository<TblVehicle> _repo=new Repository<TblVehicle>())
                {
                    return _repo.TblVehicle.Where(v => v.MemberCode == membercode && v.VehicleRegNo == vehicleRegNo).Count() > 0;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #region Registration
        public TblMemberMaster AddMemberMaster(TblMemberMaster memberMaster,List<TblVehicle> vehicles,out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                if (IsMemberCodeExists(memberMaster.MemberCode))
                {
                    errorMessage = "Member code already exists.Please generate anothermember code.";
                    return null;
                }

                using(ERPContext context=new ERPContext())
                {
                    using(var dbTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var _memberMaster=AddMemberMaster(context, memberMaster);
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
                        catch(Exception ex)
                        {
                            dbTransaction.Rollback();
                            throw ex;
                        }

                        dbTransaction.CommitAsync();
                        return memberMaster;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public TblVehicle AddVehicles(decimal? memberCode,TblVehicle vehicle,out string errorMessage)
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

                if(IsVechileNoExists(memberCode, vehicle.VehicleRegNo))
                {
                    errorMessage = $"vehicle no :{vehicle.VehicleRegNo} is exists for member code :{memberCode}";
                    return null;
                }

                using (ERPContext context=new ERPContext())
                {
                    var _member = context.TblMemberMaster.Where(x=> x.MemberCode == memberCode).FirstOrDefault();

                   var _vechile= AddVechicle(context,_member, vehicle);

                    if (_vechile == null)
                    {
                        errorMessage = "Regitration failed for vechile.";
                        return null;
                    }

                    return _vechile;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private TblMemberMaster AddMemberMaster(ERPContext context,TblMemberMaster memberMaster)
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
        private TblVehicle AddVechicle(ERPContext context, TblMemberMaster memberMaster, TblVehicle vehicle)
        {
            try
            {
                vehicle.IsValid = 1;
                vehicle.MemberId = memberMaster.MemberId;
                vehicle.MemberCode = memberMaster.MemberCode;
                vehicle.MemberShares = memberMaster.TotalShares;
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
