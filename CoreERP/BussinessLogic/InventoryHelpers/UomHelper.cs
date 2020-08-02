using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class UomHelper
    {
        public static TblUnit RegisterSizes(TblUnit uom)
        {
            try
            {
                using Repository<TblUnit> repo = new Repository<TblUnit>();
                repo.TblUnit.Add(uom);
                if (repo.SaveChanges() > 0)
                    return uom;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static List<TblUnit> GetSizesList()
        {
            try
            {
                using Repository<TblUnit> repo = new Repository<TblUnit>();
                return repo.TblUnit.OrderBy(x => x.UnitId).ToList();
            }
            catch { throw; }
        }

        public static List<TblUnit> GetSizesList(string code)
        {
            try
            {
                using Repository<TblUnit> repo = new Repository<TblUnit>();
                return repo.TblUnit.Where(x => x.UnitId == code).ToList();
            }
            catch { throw; }
        }
        public static TblUnit UpdateSizes(TblUnit uoms)
        {
            try
            {
                using Repository<TblUnit> repo = new Repository<TblUnit>();
                repo.TblUnit.Update(uoms);
                if (repo.SaveChanges() > 0)
                    return uoms;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static TblUnit DeleteSizes(string code)
        {
            try
            {
                using Repository<TblUnit> repo = new Repository<TblUnit>();
                var UOM = repo.TblUnit.Where(x => x.UnitId == code).FirstOrDefault();
                repo.TblUnit.Update(UOM);
                if (repo.SaveChanges() > 0)
                    return UOM;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
