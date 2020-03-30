using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class SizesHelper
    {
        public static Sizes RegisterSizes(Sizes sizes,out string errMsg)
        {
            try
            {
                errMsg = string.Empty;

                using Repository<Sizes> repo = new Repository<Sizes>();
                //var record = repo.Sizes.OrderByDescending(x => x.AddDate).FirstOrDefault();

                //if (record !=null)
                //{
                //    sizes.Code = CommonHelper.IncreaseCode(record.Code);
                //}
                //else
                //    sizes.Code = "1";
                if (GetSizesList(sizes.Code).Count > 0)
                {
                    errMsg = "Code Already Exists.";
                    return null;
                }

                sizes.Active = "Y";
                sizes.AddDate = DateTime.Now;
                repo.Sizes.Add(sizes);
                if (repo.SaveChanges() > 0)
                    return sizes;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Sizes> GetSizesList()
        {
            try
            {
                using Repository<Sizes> repo = new Repository<Sizes>();
                return repo.Sizes.Where(x => x.Active == "Y").ToList();
            }
            catch { throw; }
        }

        public static List<Sizes> GetSizesList(string code)
        {
            try
            {
                using Repository<Sizes> repo = new Repository<Sizes>();
                return repo.Sizes.Where(x => x.Code == code).ToList();
            }
            catch { throw; }
        }
        public static Sizes UpdateSizes(Sizes sizes)
        {
            try
            {
                using Repository<Sizes> repo = new Repository<Sizes>();
                if (sizes.AddDate == null)
                    sizes.AddDate = DateTime.Now;

                repo.Sizes.Update(sizes);
                if (repo.SaveChanges() > 0)
                    return sizes;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Sizes DeleteSizes(string code)
        {
            try
            {
                using Repository<Sizes> repo = new Repository<Sizes>();
                var accountClass = repo.Sizes.Where(x => x.Code == code).FirstOrDefault();
                accountClass.Active = "N";
                repo.Sizes.Update(accountClass);
                if (repo.SaveChanges() > 0)
                    return accountClass;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
