using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CoreERP.BussinessLogic.Payroll
{
    public class ComponentMasterHelper
    {
        public static List<ComponentMaster> GetListOfComponents()
        {
            try
            {
                using (Repository<ComponentMaster> repo = new Repository<ComponentMaster>())
                {
                    return repo.ComponentMaster.AsEnumerable().Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }

        public static ComponentMaster GetComponents(string compCode)
        {
            try
            {
                using (Repository<ComponentMaster> repo = new Repository<ComponentMaster>())
                {
                    return repo.ComponentMaster.AsEnumerable()
                               .Where(x => x.CompanyCode.Equals(compCode))
                                         .FirstOrDefault();
                }
            }
            catch { throw; }
        }

        public static ComponentMaster Register(ComponentMaster componentMaster)
        {
            try
            {
                using (Repository<ComponentMaster> repo = new Repository<ComponentMaster>())
                {
                    componentMaster.Active = "Y";
                    repo.ComponentMaster.Add(componentMaster);
                    if (repo.SaveChanges() > 0)
                        return componentMaster;

                    return null;
                }
            }
            catch { throw; }
        }

        public static ComponentMaster Update(ComponentMaster componentMaster)
        {
            try
            {
                using (Repository<ComponentMaster> repo = new Repository<ComponentMaster>())
                {
                    repo.ComponentMaster.Update(componentMaster);
                    if (repo.SaveChanges() > 0)
                        return componentMaster;

                    return null;
                }
            }
            catch { throw; }
        }

        public static ComponentMaster DeleteComponents(string code)
        {
            try
            {
                using (Repository<ComponentMaster> repo = new Repository<ComponentMaster>())
                {
                    var comp = repo.ComponentMaster.Where(x => x.ComponentCode == code).FirstOrDefault();
                    comp.Active = "N";
                    repo.ComponentMaster.Update(comp);
                    if (repo.SaveChanges() > 0)
                        return comp;

                    return null;
                }
            }
            catch { throw; }
        }
    }
}
