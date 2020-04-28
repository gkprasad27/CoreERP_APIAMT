using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class TankHelpers
    {
        public List<TblTanks> GetList(string code=null)
        {
            try
            {
                using Repository<TblTanks> repo = new Repository<TblTanks>();
                return repo.TblTanks.Where(x => x.TankNo == (code ?? x.TankNo)).ToList();
            }
            catch { throw; }
        }

        public TblTanks Register(TblTanks tanks)
        {
            try
            {
                using Repository<TblTanks> repo = new Repository<TblTanks>();
                tanks.BranchId = Convert.ToInt32(tanks.BranchCode);
                var data = repo.TblBranch.Where(x => x.BranchCode == tanks.BranchCode).FirstOrDefault();
                tanks.BranchName = data.BranchName;
                repo.TblTanks.Add(tanks);
                if (repo.SaveChanges() > 0)
                    return tanks;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblTanks Update(TblTanks tanks)
        {
            try
            {
                using Repository<TblTanks> repo = new Repository<TblTanks>();
                tanks.BranchId = Convert.ToInt32(tanks.BranchCode);
                var data = repo.TblBranch.Where(x => x.BranchCode == tanks.BranchCode).FirstOrDefault();
                tanks.BranchName = data.BranchName;
                repo.TblTanks.Update(tanks);
                if (repo.SaveChanges() > 0)
                    return tanks;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblTanks Delete(string Code)
        {
            try
            {
                using Repository<TblTanks> repo = new Repository<TblTanks>();
                var tankno = repo.TblTanks.Where(x => x.TankId == Convert.ToInt32(Code)).FirstOrDefault();
                repo.TblTanks.Remove(tankno);
                if (repo.SaveChanges() > 0)
                    return tankno;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblBranch> GetBranches()
        {
            try
            {
               return BrancheHelper.GetBranches();
            }
            catch { throw; }
        }

        //public List<Branches> Getbranchcodes(string name)
        //{
        //    try
        //    {
        //        using (Repository<Branches> repo = new Repository<Branches>())
        //        {
        //            return repo.Branches
        //                  .Where(x => x.Address1.Equals(name))
        //                  .ToList();
        //        }
        //    }
        //    catch { throw; }
        //}
    }
}
