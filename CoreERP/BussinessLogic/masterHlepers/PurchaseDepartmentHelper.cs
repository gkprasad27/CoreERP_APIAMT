using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class PurchaseDepartmentHelper
    {
        public static List<TblPurchaseDepartment> GetList(string prdept)
        {
            try
            {
                using Repository<TblPurchaseDepartment> repo = new Repository<TblPurchaseDepartment>();
                return repo.TblPurchaseDepartment.Where(x => x.Code == prdept).ToList();
            }
            catch { throw; }
        }

        public static List<TblPurchaseDepartment> GetList()
        {
            try
            {
                using Repository<TblPurchaseDepartment> repo = new Repository<TblPurchaseDepartment>();
                return repo.TblPurchaseDepartment.ToList();
            }
            catch { throw; }
        }

        public static TblPurchaseDepartment Register(TblPurchaseDepartment prdept)
        {
            try
            {
                using Repository<TblPurchaseDepartment> repo = new Repository<TblPurchaseDepartment>();
                repo.TblPurchaseDepartment.Add(prdept);
                if (repo.SaveChanges() > 0)
                    return prdept;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblPurchaseDepartment Update(TblPurchaseDepartment prdept)
        {
            try
            {
                using Repository<TblPurchaseDepartment> repo = new Repository<TblPurchaseDepartment>();
                repo.TblPurchaseDepartment.Update(prdept);
                if (repo.SaveChanges() > 0)
                    return prdept;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblPurchaseDepartment Delete(string prdeptcode)
        {
            try
            {
                using Repository<TblPurchaseDepartment> repo = new Repository<TblPurchaseDepartment>();
                var prcodes = repo.TblPurchaseDepartment.Where(x => x.Code == prdeptcode).FirstOrDefault();
                repo.TblPurchaseDepartment.Remove(prcodes);
                if (repo.SaveChanges() > 0)
                    return prcodes;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
