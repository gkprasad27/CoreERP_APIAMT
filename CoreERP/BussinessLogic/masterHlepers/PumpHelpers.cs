using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class PumpHelpers
    {

        public List<TblPumps> GetList()
        {
            try
            {
                using Repository<TblPumps> repo = new Repository<TblPumps>();
                return repo.TblPumps.ToList();
            }
            catch { throw; }
        }

        public TblPumps Register(TblPumps pumps)
        {
            try
            {
                using Repository<TblPumps> repo = new Repository<TblPumps>();
                string name = Convert.ToString(repo.TblTanks.SingleOrDefault(obj => obj.TankNo == Convert.ToString(pumps.TankNo))?.TankId);
                pumps.TankId = int.Parse(name);
                pumps.BranchId = Convert.ToInt32(pumps.BranchCode);
                pumps.ProductId = Convert.ToInt32(pumps.ProductCode);
                repo.TblPumps.Add(pumps);
                if (repo.SaveChanges() > 0)
                    return pumps;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblPumps Update(TblPumps pumps)
        {
            try
            {
                using Repository<TblPumps> repo = new Repository<TblPumps>();
                string name = Convert.ToString(repo.TblTanks.SingleOrDefault(obj => obj.TankNo == Convert.ToString(pumps.TankNo))?.TankId);
                pumps.TankId = int.Parse(name);
                pumps.BranchId = Convert.ToInt32(pumps.BranchCode);
                pumps.ProductId = Convert.ToInt32(pumps.ProductCode);
                repo.TblPumps.Update(pumps);
                if (repo.SaveChanges() > 0)
                    return pumps;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblPumps Delete(string Code)
        {
            try
            {
                using Repository<TblPumps> repo = new Repository<TblPumps>();
                var pumpno = repo.TblPumps.Where(x => x.PumpId == Convert.ToInt32(Code)).FirstOrDefault();
                repo.TblPumps.Remove(pumpno);
                if (repo.SaveChanges() > 0)
                    return pumpno;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MaterialGroup> GetProductGroups()
        {
            try
            {
                using Repository<MaterialGroup> repo = new Repository<MaterialGroup>();
                return repo.MaterialGroup.ToList();
            }
            catch { throw; }
        }
        public List<TblBranch> GetBranches()
        {
            try
            {
               return BrancheHelper.GetBranches();
            }
            catch { throw; }
        }

        public List<TblTanks> GetBranchcodes(string name)
        {
            try
            {
                using Repository<TblTanks> repo = new Repository<TblTanks>();
                return repo.TblTanks
.Where(x => x.BranchName == name).ToList();
            }
            catch { throw; }
        }

        public List<MaterialGroup> GetProductGroupsNames(string code)
        {
            try
            {
                using Repository<MaterialGroup> repo = new Repository<MaterialGroup>();
                return repo.MaterialGroup
.Where(x => x.Code == code)
.ToList();
            }
            catch { throw; }
        }
    }
}
