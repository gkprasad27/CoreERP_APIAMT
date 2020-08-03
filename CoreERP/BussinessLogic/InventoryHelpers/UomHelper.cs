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
                Repository<TblUnit>.Instance.Add(uom);
                if (Repository<TblUnit>.Instance.SaveChanges() > 0)
                    return uom;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static IEnumerable<TblUnit> GetSizesList()
        {
            try
            {
                return Repository<TblUnit>.Instance.GetAll().OrderBy(x => x.UnitId);
            }
            catch { throw; }
        }

        public static IEnumerable<TblUnit> GetSizesList(string code)
        {
            try
            {
                return Repository<TblUnit>.Instance.Where(x => x.UnitId == code);
            }
            catch { throw; }
        }
        public static TblUnit UpdateSizes(TblUnit uoms)
        {
            try
            {
                Repository<TblUnit>.Instance.Update(uoms);
                if (Repository<TblUnit>.Instance.SaveChanges() > 0)
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
                var ccode = Repository<TblUnit>.Instance.GetSingleOrDefault(x => x.UnitId == code);
                Repository<TblUnit>.Instance.Remove(ccode);
                if (Repository<TblUnit>.Instance.SaveChanges() > 0)
                    return ccode;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
