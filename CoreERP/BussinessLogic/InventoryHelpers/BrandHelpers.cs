using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class BrandHelpers
    {
     
        public static Brand RegisterBrand(Brand brand)
        {
            try
            {
                using (Repository<Brand> repo = new Repository<Brand>())
                {
                    var record = ((from b in repo.Brand select b.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();

                    if (record != 0)
                    {
                        brand.Code = (record + 1).ToString();
                    }
                    else
                        brand.Code = "1";

                    brand.Active = "Y";
                    repo.Brand.Add(brand);
                    if (repo.SaveChanges() > 0)
                        return brand;

                    return null;
                }
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
                using (Repository<Brand> repo = new Repository<Brand>())
                {
                    return repo.Brand.AsEnumerable().Where(x => x.Active == "Y").ToList();
                }
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
                using (Repository<Brand> repo = new Repository<Brand>())
                {
                    repo.Brand.Update(brand);
                    if (repo.SaveChanges() > 0)
                        return brand;

                    return null;
                }
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
                using (Repository<Brand> repo = new Repository<Brand>())
                {
                    var brand = repo.Brand.Where(x => x.Code == code).FirstOrDefault();
                    brand.Active = "N";
                    repo.Brand.Remove(brand);
                    if (repo.SaveChanges() > 0)
                        return brand;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
