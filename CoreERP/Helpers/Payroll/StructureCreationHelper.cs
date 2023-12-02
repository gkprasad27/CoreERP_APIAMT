using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP
{
    public class StructureCreationHelper
    {
        public static List<StructureCreation> GetListOfStructures()
        {
            try
            {
                using Repository<StructureCreation> repo = new Repository<StructureCreation>();
                return repo.StructureCreation.AsEnumerable().Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
                //return null;
            }
            catch { throw; }
        }

        public static StructureCreation GetStructures(string compCode)
        {
            try
            {
                //                using Repository<StructureCreation> repo = new Repository<StructureCreation>();
                //                return repo.StructureCreation.AsEnumerable()
                //.Where(x => x.StructureCode.Equals(compCode))
                //.FirstOrDefault();
                return null;
            }
            catch { throw; }
        }

        public static StructureCreation Register(StructureCreation structureCreation)
        {
            try
            {
                //using Repository<StructureCreation> repo = new Repository<StructureCreation>();
                //structureCreation.Active = "Y";
                //repo.StructureCreation.Add(structureCreation);
                //if (repo.SaveChanges() > 0)
                //    return structureCreation;

                return null;
            }
            catch { throw; }
        }

        public static StructureCreation Update(StructureCreation structureCreation)
        {
            try
            {
                //using Repository<StructureCreation> repo = new Repository<StructureCreation>();
                //repo.StructureCreation.Update(structureCreation);
                //if (repo.SaveChanges() > 0)
                //    return structureCreation;

                return null;
            }
            catch { throw; }
        }

        public static StructureCreation Delete(string code)
        {
            try
            {
                //using Repository<StructureCreation> repo = new Repository<StructureCreation>();
                //var comp = repo.StructureCreation.Where(x => x.StructureCode == code).FirstOrDefault();
                //comp.Active = "N";
                //repo.StructureCreation.Update(comp);
                //if (repo.SaveChanges() > 0)
                //    return comp;

                return null;
            }
            catch { throw; }
        }
    }
}
