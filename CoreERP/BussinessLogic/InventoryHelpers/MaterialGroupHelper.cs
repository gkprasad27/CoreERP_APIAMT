using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class MaterialGroupHelper
    {
        public static MaterialGroup RegisterMaterialGroup(MaterialGroup materialGroup)
        {
            try
            {
                using (Repository<MaterialGroup> repo = new Repository<MaterialGroup>())
                {
                    var record = ((from acc in repo.MaterialGroup select acc.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();

                    if (record != 0)
                    {
                        materialGroup.Code = (record + 1).ToString();
                    }
                    else
                        materialGroup.Code = "1";

                    materialGroup.Active = "Y";
                    repo.MaterialGroup.Add(materialGroup);
                    if (repo.SaveChanges() > 0)
                        return materialGroup;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<MaterialGroup> GetMaterialGroupList()
        {
            try
            {
                using (Repository<MaterialGroup> repo = new Repository<MaterialGroup>())
                {
                    return repo.MaterialGroup.Select(x => x).ToList();
                }
            }
            catch { throw; }
        }
        public static MaterialGroup UpdateMaterialGroup(MaterialGroup materialGroup)
        {
            try
            {
                using (Repository<MaterialGroup> repo = new Repository<MaterialGroup>())
                {
                    repo.MaterialGroup.Update(materialGroup);
                    if (repo.SaveChanges() > 0)
                        return materialGroup;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static MaterialGroup DeleteMaterialGroup(string code)
        {
            try
            {
                using (Repository<MaterialGroup> repo = new Repository<MaterialGroup>())
                {
                    var materialGroup = repo.MaterialGroup.Where(x => x.Code == code).FirstOrDefault();
                    materialGroup.Active = "N";
                    repo.MaterialGroup.Remove(materialGroup);
                    if (repo.SaveChanges() > 0)
                        return materialGroup;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AccountingClass> GetAccountingClassList()
        {
            try
            {
                using (Repository<AccountingClass> repo = new Repository<AccountingClass>())
                {
                    return repo.AccountingClass.AsEnumerable().Where(x => x.Active.Equals("Y")).ToList();
                }
            }
            catch { throw; }
        }
    }
}
