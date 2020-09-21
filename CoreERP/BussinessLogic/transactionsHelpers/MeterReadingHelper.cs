using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.transactionsHelpers
{
    public class MeterReadingHelper
    {
        public List<TblMeterReading> GetMeterReadingList(string branchCode,int role)
        {
            try
            {
                using (Repository<TblMeterReading> repo = new Repository<TblMeterReading>())
                {
                    if(role==1)
                    {
                        return repo.TblMeterReading.OrderByDescending(m => m.MeterReadingId).ToList();
                    }
                    return repo.TblMeterReading.Where(m=>m.BranchCode==branchCode).OrderByDescending(m=>m.MeterReadingId).ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public List<TblBranch> GetBranchesList()
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    return repo.TblBranch.ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public List<TblPumps> GetPumpList(string branchCode)
        {
            try
            {
                using (Repository<TblPumps> repo = new Repository<TblPumps>())
                {
                    return repo.TblPumps.Where(p=>p.BranchCode==branchCode && p.IsWorking==1).OrderBy(p=>p.PumpNo).ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<TblShift> GetShift(decimal userId)
        {
            try
            {
                using (Repository<TblShift> repo = new Repository<TblShift>())
                {
                    return repo.TblShift.Where(s => s.UserId== userId).ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public TblMeterReading Update(TblMeterReading meterreading)
        {
            try
            {
                using (Repository<TblMeterReading> repo = new Repository<TblMeterReading>())
                {
                    meterreading.EntryDate = DateTime.Now;
                    repo.TblMeterReading.Update(meterreading);
                    if (repo.SaveChanges() > 0)
                        return meterreading;

                    return null;
                }
            }
            catch { throw; }
        }

        public TblMeterReading Delete(int code)
        {
            try
            {
                using (Repository<TblMeterReading> repo = new Repository<TblMeterReading>())
                {
                    var mtr = repo.TblMeterReading.Where(x => x.MeterReadingId == code).FirstOrDefault();
                    repo.TblMeterReading.Remove(mtr);
                    if (repo.SaveChanges() > 0)
                        return mtr;

                    return null;
                }
            }
            catch { throw; }
        }
        public List<TblBranch> GetBranches(string branchCode = null)
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    return repo.TblBranch.AsEnumerable().Where(b => b.BranchCode == (branchCode ?? b.BranchCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblPumps> GetPump(string branchCode,decimal pumpNo= 0)
        {
            try
            {
                using (Repository<TblPumps> repo = new Repository<TblPumps>())
                {
                    return repo.TblPumps.AsEnumerable().Where(b => b.PumpNo == pumpNo&& b.BranchCode==branchCode).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblMeterReading> GetOBFromPump(string branchCode,decimal pumpNo = 0)
        {
            
            try
            {
                using (Repository<TblMeterReading> repo = new Repository<TblMeterReading>())
                {
                    return repo.TblMeterReading.AsEnumerable().Where(b => b.PumpNo == pumpNo && b.BranchCode==branchCode).OrderByDescending(b=>b.EntryDate).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetSaledUnits(string branchCode, decimal pumpNo = 0, decimal shiftId =0)
        {

            try
            {
                using (Repository<TblInvoiceMaster> repo = new Repository<TblInvoiceMaster>())
                {
                    var Qty = (from IM in repo.TblInvoiceMaster
                                      join ID in repo.TblInvoiceDetail on IM.InvoiceMasterId equals ID.InvoiceMasterId
                                               where ID.PumpNo==pumpNo && IM.BranchCode==branchCode && ID.ShiftId==shiftId && IM.IsSalesReturned==false
                                               select ID).ToList();

                    decimal _saledUnits = Qty.Sum(x => Convert.ToDecimal(x.Qty ?? 0));

                    if (_saledUnits > 0)
                    {
                        return _saledUnits;
                    }

                    return 0;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblMeterReading Register(TblMeterReading meterReading)
        {
            try
            {
                using (Repository<TblMeterReading> repo = new Repository<TblMeterReading>())
                {
                    var _branch = GetBranches(meterReading.BranchCode).ToArray().FirstOrDefault();
                    var _pump = GetPump(meterReading.BranchCode,meterReading.PumpNo).ToArray().FirstOrDefault();
                    meterReading.BranchId = _branch.BranchId;
                    meterReading.BranchName = _branch.BranchName;
                    meterReading.PumpId = _pump.PumpId;
                    repo.TblMeterReading.Add(meterReading);
                    if (repo.SaveChanges() > 0)
                        return meterReading;

                    return null;
                }
            }
            catch { throw; }
        }
    }
}
