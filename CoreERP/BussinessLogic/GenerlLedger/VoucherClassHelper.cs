using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class VoucherClassHelper
    {
        public static List<VoucherClass> GetList(string code)
        {
            try
            {
                using Repository<VoucherClass> repo = new Repository<VoucherClass>();
                //return repo.VoucherClass
                //           .Where(x => x.VoucherCode == code)
                //           .ToList();
                return null;
            }
            catch { throw; }
        }

        public static List<VoucherClass> GetList()
        {
            try
            {
                using Repository<VoucherClass> repo = new Repository<VoucherClass>();
                //return repo.VoucherClass.ToList();
                return null;
            }
            catch { throw; }
        }

        public static VoucherClass Register(VoucherClass vcclass)
        {
            try
            {
                using Repository<VoucherClass> repo = new Repository<VoucherClass>();
                vcclass.Active = "Y";
                vcclass.AddDate = DateTime.Now;
                //repo.VoucherClass.Add(vcclass);
                if (repo.SaveChanges() > 0)
                    return vcclass;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static VoucherClass Update(VoucherClass vcclass)
        {
            try
            {
                using Repository<VoucherClass> repo = new Repository<VoucherClass>();
                vcclass.Active = "Y";
                vcclass.AddDate = DateTime.Now;
                //repo.VoucherClass.Update(vcclass);
                if (repo.SaveChanges() > 0)
                    return vcclass;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static VoucherClass Delete(string Code)
        {
            try
            {
                using Repository<VoucherClass> repo = new Repository<VoucherClass>();
                //var taxcode = repo.VoucherClass.Where(x => x.VoucherCode == Code).FirstOrDefault();
                //repo.VoucherClass.Remove(taxcode);
                //if (repo.SaveChanges() > 0)
                    //return taxcode;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
