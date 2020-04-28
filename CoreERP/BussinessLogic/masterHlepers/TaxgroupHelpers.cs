using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class TaxgroupHelpers
    {
        public List<TblTaxGroup> GetList(string code)
        {
            try
            {
                using Repository<TblTaxGroup> repo = new Repository<TblTaxGroup>();
                return repo.TblTaxGroup
                           .Where(x => x.TaxGroupCode == code)
                           .ToList();
            }
            catch { throw; }
        }

        public  List<TblTaxGroup> GetList()
        {
            try
            {
                using Repository<TblTaxGroup> repo = new Repository<TblTaxGroup>();
                return repo.TblTaxGroup.ToList();
            }
            catch { throw; }
        }

        public  TblTaxGroup Register(TblTaxGroup taxgroup)
        {
            try
            {
                using Repository<TblTaxGroup> repo = new Repository<TblTaxGroup>();
                string name = Convert.ToString(repo.TblProductGroup.SingleOrDefault(obj => obj.GroupName == Convert.ToString(taxgroup.ProductGroupName))?.GroupCode);
                taxgroup.ProductGroupId = int.Parse(name);
                taxgroup.ProductGroupCode = int.Parse(name);
                repo.TblTaxGroup.Add(taxgroup);
                if (repo.SaveChanges() > 0)
                    return taxgroup;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  TblTaxGroup Update(TblTaxGroup taxgroup)
        {
            try
            {
                using Repository<TblTaxGroup> repo = new Repository<TblTaxGroup>();
                string name = Convert.ToString(repo.TblProductGroup.SingleOrDefault(obj => obj.GroupName == Convert.ToString(taxgroup.ProductGroupName))?.GroupCode);
                taxgroup.ProductGroupId = int.Parse(name);
                taxgroup.ProductGroupCode = int.Parse(name);
                repo.TblTaxGroup.Update(taxgroup);
                if (repo.SaveChanges() > 0)
                    return taxgroup;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  TblTaxGroup Delete(string Code)
        {
            try
            {
                using Repository<TblTaxGroup> repo = new Repository<TblTaxGroup>();
                var taxcode = repo.TblTaxGroup.Where(x => x.TaxGroupId == Convert.ToInt32(Code)).FirstOrDefault();
                repo.TblTaxGroup.Remove(taxcode);
                if (repo.SaveChanges() > 0)
                    return taxcode;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  List<MaterialGroup> GetProductGroups()
        {
            try
            {
                using Repository<MaterialGroup> repo = new Repository<MaterialGroup>();
                return repo.MaterialGroup.ToList();
            }
            catch { throw; }
        }
    }
}
