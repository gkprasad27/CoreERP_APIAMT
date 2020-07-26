using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CoreERP.BussinessLogic.masterHlepers
{
    public class SalesOfficeHelper
    {
        public static List<TblSalesOffice> GetList(string salesofc)
        {
            try
            {
                using Repository<TblSalesOffice> repo = new Repository<TblSalesOffice>();
                return repo.TblSalesOffice.Where(x => x.Code == salesofc).ToList();
            }
            catch { throw; }
        }

        public static List<TblSalesOffice> GetList()
        {
            try
            {
                using Repository<TblSalesOffice> repo = new Repository<TblSalesOffice>();
                return repo.TblSalesOffice.ToList();
            }
            catch { throw; }
        }

        public static TblSalesOffice Register(TblSalesOffice salesofc)
        {
            try
            {
                using Repository<TblSalesOffice> repo = new Repository<TblSalesOffice>();
                repo.TblSalesOffice.Add(salesofc);
                if (repo.SaveChanges() > 0)
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
                using Repository<TblSalesOffice> repo = new Repository<TblSalesOffice>();
                repo.TblSalesOffice.Update(salesofc);
                if (repo.SaveChanges() > 0)
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
                using Repository<TblSalesOffice> repo = new Repository<TblSalesOffice>();
                var sfccodes = repo.TblSalesOffice.Where(x => x.Code == sfcode).FirstOrDefault();
                repo.TblSalesOffice.Remove(sfccodes);
                if (repo.SaveChanges() > 0)
                    return sfccodes;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
