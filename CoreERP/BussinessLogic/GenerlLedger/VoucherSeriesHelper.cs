using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class VoucherSeriesHelper
    {
        public static List<TblVoucherSeries> GetList(string code)
        {
            try
            {
                using Repository<TblVoucherSeries> repo = new Repository<TblVoucherSeries>();
                return repo.TblVoucherSeries
                           .Where(x => x.VoucherSeriesKey == code)
                           .ToList();
            }
            catch { throw; }
        }

        public static List<TblVoucherSeries> GetList()
        {
            try
            {
                using Repository<TblVoucherSeries> repo = new Repository<TblVoucherSeries>();
                return repo.TblVoucherSeries.ToList();
            }
            catch { throw; }
        }

        public static TblVoucherSeries Register(TblVoucherSeries vcclass)
        {
            try
            {
                using Repository<TblVoucherSeries> repo = new Repository<TblVoucherSeries>();
                repo.TblVoucherSeries.Add(vcclass);
                if (repo.SaveChanges() > 0)
                    return vcclass;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblVoucherSeries Update(TblVoucherSeries vcclass)
        {
            try
            {
                using Repository<TblVoucherSeries> repo = new Repository<TblVoucherSeries>();
                repo.TblVoucherSeries.Update(vcclass);
                if (repo.SaveChanges() > 0)
                    return vcclass;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblVoucherSeries Delete(string Code)
        {
            try
            {
                using Repository<TblVoucherSeries> repo = new Repository<TblVoucherSeries>();
                var taxcode = repo.TblVoucherSeries.Where(x => x.VoucherSeriesKey == Code).FirstOrDefault();
                repo.TblVoucherSeries.Remove(taxcode);
                if (repo.SaveChanges() > 0)
                    return taxcode;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
