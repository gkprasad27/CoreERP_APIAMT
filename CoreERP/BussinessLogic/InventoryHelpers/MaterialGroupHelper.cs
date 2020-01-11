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
        private static Repository<MaterialGroup> _repo = null;
        private static Repository<MaterialGroup> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<MaterialGroup>();
                return _repo;
            }
        }
        public static int RegisterMaterialGroup(MaterialGroup materialGroup)
        {
            try
            {
                var record = ((from acc in repo.MaterialGroup select acc.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();

                if (record != 0)
                {
                    materialGroup.Code = (record + 1).ToString();
                }
                else
                    materialGroup.Code = "1";

                repo.MaterialGroup.Add(materialGroup);
                return repo.SaveChanges();
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
                return repo.MaterialGroup.Select(x => x).ToList();
            }
            catch { throw; }
        }
        public static int UpdateMaterialGroup(MaterialGroup materialGroup)
        {
            try
            {
                repo.MaterialGroup.Update(materialGroup);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteMaterialGroup(string code)
        {
            try
            {
                var materialGroup = repo.MaterialGroup.Where(x => x.Code == code).FirstOrDefault();
                repo.MaterialGroup.Remove(materialGroup);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
