using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CoreERP
{
    public class StructureComponentsHelper
    {
        public static List<StructureComponents> GetListOfStructures()
        {
            try
            {
                //using Repository<StructureComponents> repo = new Repository<StructureComponents>();
                //return repo.StructureComponents.Where(c => c.Active == "Y").ToList();

                return null;
            }
            catch { throw; }
        }

        public static StructureComponents GetStrucutures(string compCode)
        {
            try
            {
                //                using Repository<StructureComponents> repo = new Repository<StructureComponents>();
                //                return repo.StructureComponents
                //.Where(x => x.CompanyCode == compCode)
                //.FirstOrDefault();
                return null;
            }
            catch { throw; }
        }

        public static List<StructureComponents> Register(List<StructureComponents> structureComponents)
        {
            try
            {
                //using Repository<StructureComponents> repo = new Repository<StructureComponents>();
                //repo.StructureComponents.AddRange(structureComponents);
                //if (repo.SaveChanges() > 0)
                //    return structureComponents;

                return null;
            }
            catch { throw; }
        }

        public static List<StructureComponents> Update(List<StructureComponents> structureComponents)
        {
            try
            {
                //using Repository<StructureComponents> repo = new Repository<StructureComponents>();
                //repo.StructureComponents.UpdateRange(structureComponents);
                //if (repo.SaveChanges() > 0)
                //    return structureComponents;

                return null;
            }
            catch { throw; }
        }

        public static StructureComponents DeleteStructures(string code)
        {
            try
            {
                //using Repository<StructureComponents> repo = new Repository<StructureComponents>();
                //var structure = repo.StructureComponents.Where(x => x.StructureName == code).FirstOrDefault();
                //structure.Active = "N";
                //repo.StructureComponents.Update(structure);
                //if (repo.SaveChanges() > 0)
                //    return structure;

                return null;
            }
            catch { throw; }
        }

        public static List<ComponentMaster> GetComponentList()
        {
            try
            {
                //    using Repository<ComponentMaster> repo = new Repository<ComponentMaster>();
                //    return repo.ComponentMaster.Where(m => m.Active == "Y").ToList();
                return null;
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<StructureCreation> GetStructureCreationList()
        {
            try
            {
                //using Repository<StructureCreation> repo = new Repository<StructureCreation>();
                //return repo.StructureCreation.Where(m => m.Active == "Y").ToList();
                return null;
            }
            catch (Exception ex) { throw ex; }
        }
        public static List<Pfmaster> GetPFList()
        {
            try
            {
                //using Repository<Pfmaster> repo = new Repository<Pfmaster>();
                //return repo.Pfmaster.Where(m => m.Active == "Y").ToList();
                return null;
            }
            catch (Exception ex) { throw ex; }
        }

    }
}
