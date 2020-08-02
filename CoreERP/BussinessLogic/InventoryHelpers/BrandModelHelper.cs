using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.masterHlepers;
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

        //public static BrandModel RegisterBrandModel(BrandModel brandModel)
        //{
        //    try
        //    {
        //        using (Repository<BrandModel> repo = new Repository<BrandModel>())
        //        {
        //            var record = repo.BrandModel.OrderByDescending(x => x.AddDate).FirstOrDefault();
        //            if (record != null)
        //            {
        //                brandModel.Code = CommonHelper.IncreaseCode(record.Code);
        //            }
        //            else
        //                brandModel.Code = "1";

        //            brandModel.Active = "Y";
        //            repo.BrandModel.Add(brandModel);
        //            if (repo.SaveChanges() > 0)
        //                return brandModel;

        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static List<BrandModel> GetBrandModelList()
        //{
        //    try
        //    {
        //        using (Repository<BrandModel> repo = new Repository<BrandModel>())
        //        {
        //            return repo.BrandModel.Select(x => x).ToList();
        //        }
        //    }
        //    catch { throw; }
        //}

        //public static BrandModel GetBrandModelList(string modelCode)
        //{
        //    try
        //    {
        //        using (Repository<BrandModel> repo = new Repository<BrandModel>())
        //        {
        //            return repo.BrandModel.Where(x => x.Code == modelCode).FirstOrDefault();
        //        }
        //    }
        //    catch { throw; }
        //}
        //public static BrandModel UpdateBrandModelClass(BrandModel brandModel)
        //{
        //    try
        //    {
        //        using (Repository<BrandModel> repo = new Repository<BrandModel>())
        //        {
        //            repo.BrandModel.Update(brandModel);
        //            if (repo.SaveChanges() > 0)
        //                return brandModel;

        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static BrandModel DeleteBrandModelClass(string code)
        //{
        //    try
        //    {
        //        using (Repository<BrandModel> repo = new Repository<BrandModel>())
        //        {
        //            var brandModel = repo.BrandModel.Where(x => x.Code == code).FirstOrDefault();
        //            brandModel.Active = "N";
        //            repo.BrandModel.Update(brandModel);
        //            if (repo.SaveChanges() > 0)
        //                return brandModel;

        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public static List<TblCompany> GetCompanies()
        {
            try
            {
                return CompaniesHelper.GetListOfCompanies();
            }
            catch { throw; }
        }
        public static List<Sizes> GetSizes()
        {
            try
            {
                // return UomHelper.GetSizesList();
                return null;
            }
            catch { throw; }
        }
    }
}
