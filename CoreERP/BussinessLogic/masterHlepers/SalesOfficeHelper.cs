using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CoreERP.BussinessLogic.masterHlepers
{
    public class SalesOfficeHelper
    {
        public static IEnumerable<TblSalesOffice> GetList(string salesofc)
        {
            try
            {
                return Repository<TblSalesOffice>.Instance.Where(x => x.Code == salesofc);
            }
            catch { throw; }
        }

        public static IEnumerable<TblSalesOffice> GetList()
        {
            try
            {
                return Repository<TblSalesOffice>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblSalesOffice Register(TblSalesOffice salesofc)
        {
            try
            {
                Repository<TblSalesOffice>.Instance.Add(salesofc);
                if (Repository<TblSalesOffice>.Instance.SaveChanges() > 0)
                    return salesofc;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblSalesOffice Update(TblSalesOffice salesofc)
        {
            try
            {
                Repository<TblSalesOffice>.Instance.Update(salesofc);
                if (Repository<TblSalesOffice>.Instance.SaveChanges() > 0)
                    return salesofc;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblSalesOffice Delete(string sfcode)
        {
            try
            {
                var ccode = Repository<TblSalesOffice>.Instance.GetSingleOrDefault(x => x.Code == sfcode);
                Repository<TblSalesOffice>.Instance.Remove(ccode);
                if (Repository<TblSalesOffice>.Instance.SaveChanges() > 0)
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
