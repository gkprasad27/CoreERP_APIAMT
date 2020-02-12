using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CoreERP.BussinessLogic.Payroll
{
    public class StructureHelper
    {
        public static List<StructureCreation> GetListOfStructures()
        {
            try
            {
                using (Repository<StructureCreation> repo = new Repository<StructureCreation>())
                {
                    return repo.StructureCreation.AsEnumerable().Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }

        public static StructureCreation GetStrucutures(string compCode)
        {
            try
            {
                using (Repository<StructureCreation> repo = new Repository<StructureCreation>())
                {
                    return repo.StructureCreation.AsEnumerable()
                               .Where(x => x.CompanyCode.Equals(compCode))
                                         .FirstOrDefault();
                }
            }
            catch { throw; }
        }

        public static StructureCreation Register(StructureCreation structureCreation)
        {
            try
            {
                using (Repository<StructureCreation> repo = new Repository<StructureCreation>())
                {
                    structureCreation.Active = "Y";
                    repo.StructureCreation.Add(structureCreation);
                    if (repo.SaveChanges() > 0)
                        return structureCreation;

                    return null;
                }
            }
            catch { throw; }
        }

        public static StructureCreation Update(StructureCreation structureCreation)
        {
            try
            {
                using (Repository<StructureCreation> repo = new Repository<StructureCreation>())
                {
                    repo.StructureCreation.Update(structureCreation);
                    if (repo.SaveChanges() > 0)
                        return structureCreation;

                    return null;
                }
            }
            catch { throw; }
        }

        public static StructureCreation DeleteStructures(string code)
        {
            try
            {
                using (Repository<StructureCreation> repo = new Repository<StructureCreation>())
                {
                    var structure = repo.StructureCreation.Where(x => x.ComponentCode == code).FirstOrDefault();
                    structure.Active = "N";
                    repo.StructureCreation.Update(structure);
                    if (repo.SaveChanges() > 0)
                        return structure;

                    return null;
                }
            }
            catch { throw; }
        }

        public static List<ComponentMaster> GetComponentList()
        {
            try
            {
                using (Repository<ComponentMaster> repo = new Repository<ComponentMaster>())
                {
                    return repo.ComponentMaster.AsEnumerable().Where(m => m.Active == "Y").ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<Pfmaster> GetPFList()
        {
            try
            {
                using (Repository<Pfmaster> repo = new Repository<Pfmaster>())
                {
                    return repo.Pfmaster.AsEnumerable().Where(m => m.Active == "Y").ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }

    }
}
