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

        //public static StructureCreation Register(StructureCreation structureCreation)
        //{
        //    try
        //    {
        //        using Repository<StructureCreation> repo = new Repository<StructureCreation>();
        //        structureCreation.Active = "Y";
        //        repo.StructureCreation.Add(structureCreation);
        //        if (repo.SaveChanges() > 0)
        //            return structureCreation;

        //        return null;
        //    }
        //    catch { throw; }
        //}
        public bool Register(StructureCreation stdata, List<StructureComponents> stdetails)
        {
            using var repo = new Repository<StructureCreation>();
            using var context = new ERPContext();
            
            string structureCode = string.Empty;
            string structureName = string.Empty;
            try
            {
               
                    stdata.Active = "Y";
                    context.StructureCreation.Add(stdata);
                    context.SaveChanges();
               
              if (string.IsNullOrWhiteSpace(structureCode))
                    structureCode = stdata.StructureCode;
              if (string.IsNullOrWhiteSpace(structureName))
                    structureName = stdata.StructureName;

                stdetails.ForEach(x =>
                {
                    x.StructureCode = structureCode;
                    x.StructureName = structureName;
                });
                context.StructureComponents.AddRange(stdetails);
                //stDetailsExist = stdetails.Where(x => x.StructureCode > 0).ToList();
                //stDetailsNew = stdetails.Where(x => x.StructureCode == 0).ToList();


                //if (stDetailsExist.Count > 0)
                //{
                //    context.TblPurchaseOrderDetails.UpdateRange(podetails);
                //}
                //else
                //{
                //    context.TblPurchaseOrderDetails.AddRange(podetails);
                //}
                context.SaveChanges();


                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
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
