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
        public static List<TblCompany> GetCompaniesList()
        {
            try
            {
                using Repository<TblCompany> repo = new Repository<TblCompany>();
                return repo.TblCompany.Select(x => x).ToList();
                //return null;
            }
            catch (Exception ex) { throw ex; }
        }
        public static Brand RegisterBrand(Brand brand)
        {
            try
            {
                using Repository<Brand> repo = new Repository<Brand>();
                brand.Active = "Y";
                brand.AddDate = DateTime.Now;
                repo.Brand.Add(brand);
                if (repo.SaveChanges() > 0)
                    return brand;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Brand> GetList(string Code)
        {
            try
            {
                using Repository<Brand> repo = new Repository<Brand>();
                return repo.Brand
.Where(x => x.Code == Code)
.ToList();
                //return null;
            }
            catch { throw; }
        }

        public static List<Brand> GetBrands()
        {
            try
            {
                using Repository<Brand> repo = new Repository<Brand>();
                return repo.Brand.AsEnumerable().Where(x => x.Active == "Y").ToList();
               // return null;
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
                using Repository<Brand> repo = new Repository<Brand>();
                repo.Brand.Update(brand);
                if (repo.SaveChanges() > 0)
                    return brand;

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
                using Repository<Brand> repo = new Repository<Brand>();
                var brand = repo.Brand.Where(x => x.Code == code).FirstOrDefault();
                brand.Active = "N";
                repo.Brand.Remove(brand);
                if (repo.SaveChanges() > 0)
                    return brand;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
