using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class TaxmasterHelper
    {
       
        public static List<TaxMasters> GetListOfTaxMasters()
        {
            try
            {   using (Repository<TaxMasters> repo = new Repository<TaxMasters>())
                {
                    return repo.TaxMasters.AsEnumerable().Where(t => t.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }

        public static TaxMasters RegisterTaxMaster(TaxMasters taxMaster)
        {
            try
            {
                using (Repository<TaxMasters> repo = new Repository<TaxMasters>())
                {
                    taxMaster.Active = "Y";
                    repo.TaxMasters.Add(taxMaster);
                    if (repo.SaveChanges() > 0)
                        return taxMaster;

                    return null;
                }
            }
            catch { throw; }
        }

        public static TaxMasters UpdateTaxMaster(TaxMasters taxMaster)
        {
            try
            {
                using (Repository<TaxMasters> repo = new Repository<TaxMasters>())
                {
                    repo.TaxMasters.Update(taxMaster);
                    if (repo.SaveChanges() > 0)
                        return taxMaster;

                    return null;
                }
            }
            catch { throw; }
        }

        public static TaxMasters DeleteTaxMaster(string taxMasterCode)
        {
            try
            {
                using (Repository<TaxMasters> repo = new Repository<TaxMasters>())
                {
                    var taxmstr = repo.TaxMasters.Where(a => a.Code == taxMasterCode).FirstOrDefault();
                    taxmstr.Active = "N";
                    repo.TaxMasters.Remove(taxmstr);
                    if (repo.SaveChanges() > 0)
                        return taxmstr;

                    return null;
                }
            }
            catch { throw; }
        }
    }
}
