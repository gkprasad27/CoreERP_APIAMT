using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class BrandModelHelper
    {
        private static Repository<BrandModel> _repo = null;
        private static Repository<BrandModel> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<BrandModel>();
                return _repo;
            }
        }
        public static int RegisterBrandModel(BrandModel brandModel)
        {
            try
            {
                var record = ((from acc in repo.BrandModel select acc.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();

                if (record != 0)
                {
                    brandModel.Code = (record + 1).ToString();
                }
                else
                    brandModel.Code = "1";

                repo.BrandModel.Add(brandModel);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<BrandModel> GetBrandModelList()
        {
            try
            {
                return repo.BrandModel.Select(x => x).ToList();
            }
            catch { throw; }
        }
        public static int UpdateBrandModelClass(BrandModel brandModel)
        {
            try
            {
                repo.BrandModel.Update(brandModel);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteBrandModelClass(string code)
        {
            try
            {
                var brandModel = repo.BrandModel.Where(x => x.Code == code).FirstOrDefault();
                repo.BrandModel.Remove(brandModel);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
