using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class VoucherClassHelper
    {
        public static List<TblVoucherclass> GetList(string code)
        {
            try
            {
                using Repository<TblVoucherclass> repo = new Repository<TblVoucherclass>();
                return repo.TblVoucherclass
                           .Where(x => x.VoucherKey == code)
                           .ToList();
                //return null;
            }
            catch { throw; }
        }

        public static List<TblVoucherclass> GetList()
        {
            try
            {
                using Repository<TblVoucherclass> repo = new Repository<TblVoucherclass>();
                return repo.TblVoucherclass.ToList();
            }
            catch { throw; }
        }

        public static TblVoucherclass Register(TblVoucherclass vcclass)
        {
            try
            {
                using Repository<TblVoucherclass> repo = new Repository<TblVoucherclass>();
                repo.TblVoucherclass.Add(vcclass);
                if (repo.SaveChanges() > 0)
                    return vcclass;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblVoucherclass Update(TblVoucherclass vcclass)
        {
            try
            {
                using Repository<TblVoucherclass> repo = new Repository<TblVoucherclass>();
                repo.TblVoucherclass.Update(vcclass);
                if (repo.SaveChanges() > 0)
                    return vcclass;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblVoucherclass Delete(string Code)
        {
            try
            {
                using Repository<TblVoucherclass> repo = new Repository<TblVoucherclass>();
                var code = repo.TblVoucherclass.Where(x => x.VoucherKey == Code).FirstOrDefault();
                repo.TblVoucherclass.Remove(code);
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
