using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class VoucherSeriesHelper
    {
        public static IEnumerable<TblVoucherSeries> GetList(string code)
        {
            try
            {
                return Repository<TblVoucherSeries>.Instance.Where(x => x.VoucherSeriesKey == code);
            }
            catch { throw; }
        }

        public static IEnumerable<TblVoucherSeries> GetList()
        {
            try
            {
                return Repository<TblVoucherSeries>.Instance.GetAll().OrderBy(x => x.VoucherSeriesKey);
            }
            catch { throw; }
        }

        public static TblVoucherSeries Register(TblVoucherSeries vcclass)
        {
            try
            {
                Repository<TblVoucherSeries>.Instance.Add(vcclass);
                if (Repository<TblVoucherSeries>.Instance.SaveChanges() > 0)
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
                Repository<TblVoucherSeries>.Instance.Update(vcclass);
                if (Repository<TblVoucherSeries>.Instance.SaveChanges() > 0)
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
                var ccode = Repository<TblVoucherSeries>.Instance.GetSingleOrDefault(x => x.VoucherSeriesKey == Code);
                Repository<TblVoucherSeries>.Instance.Remove(ccode);
                if (Repository<TblVoucherSeries>.Instance.SaveChanges() > 0)
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
