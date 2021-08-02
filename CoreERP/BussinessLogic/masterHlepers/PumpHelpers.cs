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

        public List<TblProduct> GetProduct(string productName = null)
        {
            try
            {
                using (Repository<TblProduct> repo = new Repository<TblProduct>())
                {
                    return repo.TblProduct.AsEnumerable().Where(b => b.PackingName == (productName ?? b.PackingName)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblPumps Register(TblPumps pumps)
        {
            try
            {
                using Repository<TblPumps> repo = new Repository<TblPumps>();
                string name = Convert.ToString(repo.TblTanks.SingleOrDefault(obj => obj.TankNo == Convert.ToString(pumps.TankNo) && obj.BranchCode == Convert.ToString(pumps.BranchCode))?.TankId);
                pumps.TankId = int.Parse(name);
                pumps.BranchId = Convert.ToInt32(pumps.BranchCode);
                if (pumps.ProductName == "DIESEL")
                {
                    pumps.ProductCode = "D";
                    pumps.ProductId = 1840;
                }
               else
                {
                    var _product = GetProduct(pumps.ProductName).ToArray().FirstOrDefault();
                    pumps.ProductCode = _product.ProductCode;
                    pumps.ProductId = Convert.ToInt32(_product.ProductId);
                }
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
                string name = Convert.ToString(repo.TblTanks.SingleOrDefault(obj => obj.TankNo == Convert.ToString(pumps.TankNo) && obj.BranchCode==Convert.ToString(pumps.BranchCode))?.TankId);
                pumps.TankId = int.Parse(name);
                pumps.BranchId = Convert.ToInt32(pumps.BranchCode);
                pumps.PumpNo = Convert.ToInt32(pumps.PumpNo);
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

        public List<TblProductGroup> GetProductGroups()
        {
            try
            {
                using Repository<TblProductGroup> repo = new Repository<TblProductGroup>();
                return repo.TblProductGroup.ToList();
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
                return repo.TblTanks.Where(x => x.BranchName == name).ToList();
            }
            catch { throw; }
        }

        public List<TblProductGroup> GetProductGroupsNames(string code)
        {
            try
            {
                using Repository<TblProductGroup> repo = new Repository<TblProductGroup>();
                return repo.TblProductGroup.Where(x => x.GroupCode ==Convert.ToDecimal(code)).ToList();
            }
            catch { throw; }
        }
    }
}
