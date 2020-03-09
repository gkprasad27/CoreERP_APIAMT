using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class TaxstructureHelpers
    {
        public List<TblTaxStructure> GetList()
        {
            try
            {
                using (Repository<TblTaxStructure> repo = new Repository<TblTaxStructure>())
                {
                    return repo.TblTaxStructure.ToList();
                }
            }
            catch { throw; }
        }

        public TblTaxStructure Register(TblTaxStructure taxstructure)
        {
            try
            {
                using (Repository<TblTaxStructure> repo = new Repository<TblTaxStructure>())
                {
                    var data = repo.TblTaxGroup.Where(x => x.TaxGroupName == taxstructure.TaxGroupName).FirstOrDefault();
                   // string code = Convert.ToString(repo.TblTaxGroup.SingleOrDefault(obj => obj.TaxGroupName == Convert.ToString(taxstructure.TaxGroupName))?.TaxGroupCode);
                    if (data != null)
                    {
                        taxstructure.TaxGroupCode = data.TaxGroupCode;
                        taxstructure.TaxGroupId = data.TaxGroupId;
                        repo.TblTaxStructure.Add(taxstructure);
                        if (repo.SaveChanges() > 0)
                        return taxstructure;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblTaxStructure Update(TblTaxStructure taxstructure)
        {
            try
            {
                using (Repository<TblTaxStructure> repo = new Repository<TblTaxStructure>())
                {
                    var data = repo.TblTaxGroup.Where(x => x.TaxGroupName == taxstructure.TaxGroupName).FirstOrDefault();
                    // string code = Convert.ToString(repo.TblTaxGroup.SingleOrDefault(obj => obj.TaxGroupName == Convert.ToString(taxstructure.TaxGroupName))?.TaxGroupCode);
                    if (data != null)
                    {
                        taxstructure.TaxGroupCode = data.TaxGroupCode;
                        taxstructure.TaxGroupId = data.TaxGroupId;
                        repo.TblTaxStructure.Update(taxstructure);
                        if (repo.SaveChanges() > 0)
                            return taxstructure;
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblTaxStructure Delete(string Code)
        {
            try
            {
                using (Repository<TblTaxStructure> repo = new Repository<TblTaxStructure>())
                {
                    var taxstructurecode = repo.TblTaxStructure.Where(x => x.TaxStructureId ==Convert.ToInt32(Code)).FirstOrDefault();
                    repo.TblTaxStructure.Remove(taxstructurecode);
                    if (repo.SaveChanges() > 0)
                        return taxstructurecode;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //getting taxgroups
        public List<TblTaxGroup> GetTaxGroups()
        {
            try
            {
                using (Repository<TblTaxGroup> repo = new Repository<TblTaxGroup>())
                {
                    return repo.TblTaxGroup.ToList();
                }
            }
            catch { throw; }
        }

        //getting purchaseaccounts/salesaccounts
        public   List<TblAccountLedger> GetPurchaseAccountss()
        {
            try
            {
                using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
                {
                    return repo.TblAccountLedger.ToList();
                }
            }
            catch { throw; }
        }

    }
}
