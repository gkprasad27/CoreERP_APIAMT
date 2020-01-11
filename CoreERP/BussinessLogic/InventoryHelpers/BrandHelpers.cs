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
        private static Repository<Brand> _repo = null;
        private static Repository<Brand> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<Brand>();
                return _repo;
            }
        }
        public static int RegisterBrand(Brand brand)
        {
            try
            {
                var record = ((from b in repo.Brand select b.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();

                if (record != 0)
                {
                    brand.Code = (record + 1).ToString();
                }
                else
                    brand.Code = "1";

                repo.Brand.Add(brand);
                return repo.SaveChanges();
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
                return repo.Brand.Select(x => x).ToList();
            }
            catch
            {
                throw;
            }
        }
        public static int UpdateBrand(Brand brand)
        {
            try
            {
                repo.Brand.Update(brand);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteBrand(string code)
        {
            try
            {
                var brand = repo.Brand.Where(x => x.Code == code).FirstOrDefault();
                repo.Brand.Remove(brand);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
