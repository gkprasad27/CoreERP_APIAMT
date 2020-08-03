using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class TaxgroupHelpers
    {
        public IEnumerable<TblTaxGroup> GetList(string code)
        {
            try
            {
                return Repository<TblTaxGroup>.Instance.Where(x => x.TaxGroupCode == code);
            }
            catch { throw; }
        }

        public  IEnumerable<TblTaxGroup> GetList()
        {
            try
            {
                return Repository<TblTaxGroup>.Instance.GetAll().OrderBy(x => x.TaxGroupCode);
            }
            catch { throw; }
        }

        public  TblTaxGroup Register(TblTaxGroup taxgroup)
        {
            try
            {
                Repository<TblTaxGroup>.Instance.Add(taxgroup);
                if (Repository<TblTaxGroup>.Instance.SaveChanges() > 0)
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
                Repository<TblTaxGroup>.Instance.Update(taxgroup);
                if (Repository<TblTaxGroup>.Instance.SaveChanges() > 0)
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
                var ccode = Repository<TblTaxGroup>.Instance.GetSingleOrDefault(x => x.TaxGroupCode == Code);
                Repository<TblTaxGroup>.Instance.Remove(ccode);
                if (Repository<TblTaxGroup>.Instance.SaveChanges() > 0)
                    return ccode;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  IEnumerable<TblProductGroup> GetProductGroups()
        {
            try
            {
                return Repository<TblProductGroup>.Instance.GetAll().OrderBy(x => x.GroupCode);
            }
            catch { throw; }
        }
    }
}
