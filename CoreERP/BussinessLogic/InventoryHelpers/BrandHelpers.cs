using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class BrandHelpers
    {
        public static List<Companies> GetCompaniesList()
        {
            try
            {
                //using Repository<Companies> repo = new Repository<Companies>();
                //return repo.Companies.Where(m => m.Active == "Y").ToList();

                return null;
            }
            catch (Exception ex) { throw ex; }
        }
        public static Brand RegisterBrand(Brand brand)
        {
            try
            {
                //using Repository<Brand> repo = new Repository<Brand>();
                //brand.Active = "Y";
                //brand.AddDate = DateTime.Now;

                //var record = repo.Brand.OrderByDescending(x => x.AddDate).FirstOrDefault();
                //if (record == null)
                //    brand.Code = "1";
                //else
                //{
                //    brand.Code = CommonHelper.IncreaseCode(record.Code);
                //}

                //repo.Brand.Add(brand);
                //if (repo.SaveChanges() > 0)
                //    return brand;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Brand> GetBrands()
        {
            try
            {
                //using Repository<Brand> repo = new Repository<Brand>();
                //return repo.Brand.AsEnumerable().Where(x => x.Active == "Y").ToList();
                return null;
            }
            catch
            {
                throw;
            }
        }
        public static Brand UpdateBrand(Brand brand)
        {
            try
            {
                //using Repository<Brand> repo = new Repository<Brand>();
                //repo.Brand.Update(brand);
                //if (repo.SaveChanges() > 0)
                //    return brand;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Brand DeleteBrand(string code)
        {
            try
            {
                //using Repository<Brand> repo = new Repository<Brand>();
                //var brand = repo.Brand.Where(x => x.Code == code).FirstOrDefault();
                //brand.Active = "N";
                //repo.Brand.Remove(brand);
                //if (repo.SaveChanges() > 0)
                //    return brand;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
