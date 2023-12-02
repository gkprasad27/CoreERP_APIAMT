using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CoreERP.BussinessLogic.Payroll
{
    public class PTMasterHelper
    {
        public static List<Ptmaster> GetListOfPTMaster()
        {
            try
            {
                using Repository<Ptmaster> repo = new Repository<Ptmaster>();
                return repo.Ptmaster.AsEnumerable().Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
            }
            catch { throw; }
        }

        public static Ptmaster GetPT(string PTCode)
        {
            try
            {
                //                using Repository<Ptmaster> repo = new Repository<Ptmaster>();
                //                return repo.Ptmaster.AsEnumerable()
                //.Where(x => x.Ptslab.Equals(PTCode))
                //.FirstOrDefault();
                return null;
            }
            catch { throw; }
        }

        public static Ptmaster Register(Ptmaster ptMaster)
        {
            try
            {
                using Repository<Ptmaster> repo = new Repository<Ptmaster>();
                ptMaster.Active = "Y";
                repo.Ptmaster.Add(ptMaster);
                if (repo.SaveChanges() > 0)
                    return ptMaster;

                return null;
            }
            catch { throw; }
        }

        public static Ptmaster Update(Ptmaster ptMaster)
        {
            try
            {
                using Repository<Ptmaster> repo = new Repository<Ptmaster>();
                repo.Ptmaster.Update(ptMaster);
                if (repo.SaveChanges() > 0)
                    return ptMaster;

                return null;
            }
            catch { throw; }
        }

        public static Ptmaster DeletePT(string code)
        {
            try
            {
                using Repository<Ptmaster> repo = new Repository<Ptmaster>();
                var pt = repo.Ptmaster.Where(x => x.Id == Convert.ToInt32(code)).FirstOrDefault();
                pt.Active = "N";
                repo.Ptmaster.Update(pt);
                if (repo.SaveChanges() > 0)
                    return pt;

                return null;
            }
            catch { throw; }
        }
    }
}
