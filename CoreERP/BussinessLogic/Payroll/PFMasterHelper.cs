using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CoreERP.BussinessLogic.Payroll
{
    public class PFMasterHelper
    {
        public static List<Pfmaster> GetListOfPFTMaster()
        {
            try
            {
                using Repository<Pfmaster> repo = new Repository<Pfmaster>();
                return repo.Pfmaster.AsEnumerable().Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
            }
            catch { throw; }
        }

        public static List<ComponentMaster> GetComponentsList()
        {
            try
            {
                using (Repository<ComponentMaster> repo = new Repository<ComponentMaster>())
                {
                    return repo.ComponentMaster.AsEnumerable().Where(m => m.Active == "Y").ToList();
                }
                //return null;
            }
            catch (Exception ex) { throw ex; }
        }
        public static Pfmaster GetPF(string PFCode)
        {
            try
            {
                using (Repository<Pfmaster> repo = new Repository<Pfmaster>())
                {
                    return repo.Pfmaster.AsEnumerable()
                               .Where(x => x.PftypeName.Equals(PFCode))
                               .FirstOrDefault();
                }
                //return null;
            }
            catch { throw; }
        }

        public static Pfmaster Register(Pfmaster pfMaster, string code)
        {
            try
            {
                using (Repository<Pfmaster> repo = new Repository<Pfmaster>())
                {
                    pfMaster.CompanyCode = code;
                    pfMaster.ComponentName = GetComponentsList().Where(x => x.ComponentCode == pfMaster.ComponentCode).SingleOrDefault()?.ComponentName;
                    pfMaster.Active = "Y";
                    repo.Pfmaster.Add(pfMaster);
                    if (repo.SaveChanges() > 0)
                        return pfMaster;
                    return null;
                }
            }
            catch { throw; }
        }

        public static Pfmaster Update(Pfmaster pfMaster, string code)
        {
            try
            {
                using Repository<Pfmaster> repo = new Repository<Pfmaster>();
                pfMaster.CompanyCode = code;
                pfMaster.ComponentName = GetComponentsList().Where(x => x.ComponentCode == pfMaster.ComponentCode).SingleOrDefault()?.ComponentName;
                repo.Pfmaster.Update(pfMaster);
                if (repo.SaveChanges() > 0)
                    return pfMaster;
                return null;
            }
            catch { throw; }
        }

        public static Pfmaster DeletePF(string code)
        {
            try
            {
                using Repository<Pfmaster> repo = new Repository<Pfmaster>();
                var pf = repo.Pfmaster.Where(x => x.Id == Convert.ToInt32(code)).FirstOrDefault();
                pf.Active = "N";
                repo.Pfmaster.Update(pf);
                if (repo.SaveChanges() > 0)
                    return pf;

                return null;
            }
            catch { throw; }
        }
    }
}
