using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class assignmentvoucherseriestovouchertypeHelper
    {
        public static List<TblAssignmentVoucherSeriestoVoucherType> GetList(string code)
        {
            try
            {
                using Repository<TblAssignmentVoucherSeriestoVoucherType> repo = new Repository<TblAssignmentVoucherSeriestoVoucherType>();
                return repo.TblAssignmentVoucherSeriestoVoucherType
                           .Where(x => x.Code == code)
                           .ToList();
            }
            catch { throw; }
        }

        public static List<TblAssignmentVoucherSeriestoVoucherType> GetList()
        {
            try
            {
                using Repository<TblAssignmentVoucherSeriestoVoucherType> repo = new Repository<TblAssignmentVoucherSeriestoVoucherType>();
                return repo.TblAssignmentVoucherSeriestoVoucherType.ToList();
            }
            catch { throw; }
        }

        public static TblAssignmentVoucherSeriestoVoucherType Register(TblAssignmentVoucherSeriestoVoucherType asvtype)
        {
            try
            {
                using Repository<TblAssignmentVoucherSeriestoVoucherType> repo = new Repository<TblAssignmentVoucherSeriestoVoucherType>();
                repo.TblAssignmentVoucherSeriestoVoucherType.Add(asvtype);
                if (repo.SaveChanges() > 0)
                    return asvtype;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblAssignmentVoucherSeriestoVoucherType Update(TblAssignmentVoucherSeriestoVoucherType asvtype)
        {
            try
            {
                using Repository<TblAssignmentVoucherSeriestoVoucherType> repo = new Repository<TblAssignmentVoucherSeriestoVoucherType>();
                repo.TblAssignmentVoucherSeriestoVoucherType.Update(asvtype);
                if (repo.SaveChanges() > 0)
                    return asvtype;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblAssignmentVoucherSeriestoVoucherType Delete(string Code)
        {
            try
            {
                using Repository<TblAssignmentVoucherSeriestoVoucherType> repo = new Repository<TblAssignmentVoucherSeriestoVoucherType>();
                var code = repo.TblAssignmentVoucherSeriestoVoucherType.Where(x => x.Code == Code).FirstOrDefault();
                repo.TblAssignmentVoucherSeriestoVoucherType.Remove(code);
                if (repo.SaveChanges() > 0)
                    return code;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
