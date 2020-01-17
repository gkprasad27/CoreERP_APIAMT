using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class BrandModelHelpers
    {

        public static BrandModel RegisterBrandModel(BrandModel brandModel)
        {
            try
            {
                using (Repository<BrandModel> repo = new Repository<BrandModel>())
                {
                    var record = ((from acc in repo.BrandModel select acc.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();
                    if (record != 0)
                    {
                        brandModel.Code = (record + 1).ToString();
                    }
                    else
                        brandModel.Code = "1";

                    brandModel.Active = "Y";
                    repo.BrandModel.Add(brandModel);
                    if (repo.SaveChanges() > 0)
                        return brandModel;

                    return null;
                }
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
                using (Repository<BrandModel> repo = new Repository<BrandModel>())
                {
                    return repo.BrandModel.Select(x => x).ToList();
                }
            }
            catch { throw; }
        }
        public static BrandModel UpdateBrandModelClass(BrandModel brandModel)
        {
            try
            {
                using (Repository<BrandModel> repo = new Repository<BrandModel>())
                {
                    repo.BrandModel.Update(brandModel);
                    if (repo.SaveChanges() > 0)
                        return brandModel;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static BrandModel DeleteBrandModelClass(string code)
        {
            try
            {
                using (Repository<BrandModel> repo = new Repository<BrandModel>())
                {
                    var brandModel = repo.BrandModel.Where(x => x.Code == code).FirstOrDefault();
                    brandModel.Active = "N";
                    repo.BrandModel.Update(brandModel);
                    if (repo.SaveChanges() > 0)
                        return brandModel;

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
