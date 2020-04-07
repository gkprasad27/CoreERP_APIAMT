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
        public List<TblMeterReading> GetMeterReadingList()
        {
            try
            {
                using (Repository<TblMeterReading> repo = new Repository<TblMeterReading>())
                {
                    return repo.TblMeterReading.ToList();
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
                    return repo.TblPumps.Where(p=>p.BranchCode==branchCode && p.IsWorking==1).ToList();
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

        public List<TblPumps> GetPump(decimal pumpNo= 0)
        {
            try
            {
                using (Repository<TblPumps> repo = new Repository<TblPumps>())
                {
                    return repo.TblPumps.AsEnumerable().Where(b => b.PumpNo == pumpNo).ToList();
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

        public TblMeterReading Register(TblMeterReading meterReading)
        {
            try
            {
                using (Repository<TblMeterReading> repo = new Repository<TblMeterReading>())
                {
                    var _branch = GetBranches(meterReading.BranchCode).ToArray().FirstOrDefault();
                    var _pump = GetPump(meterReading.PumpNo).ToArray().FirstOrDefault();
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
