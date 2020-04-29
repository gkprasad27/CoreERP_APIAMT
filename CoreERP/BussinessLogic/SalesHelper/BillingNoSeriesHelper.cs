using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SalesHelper
{
    public class BillingNoSeriesHelper
    {
        //public static List<BillingNoSeries> GetBillingNoSeriesList()
        //{
        //    try
        //    {
        //        using(Repository<BillingNoSeries> repo=new Repository<BillingNoSeries>())
        //        {
        //            return repo.BillingNoSeries.Where(bno => bno.Active.Equals("Y")).ToList();
        //        }
        //    }
        //    catch { throw; }
        //}
        //public static BillingNoSeries GetBillingNoSeries(string code)
        //{
        //    try
        //    {
        //        using (Repository<BillingNoSeries> repo = new Repository<BillingNoSeries>())
        //        {
        //            return repo.BillingNoSeries
        //                       .Where(bno => bno.Active.Equals("Y")
        //                                  && bno.Code== code  
        //                       ).FirstOrDefault();
        //        }
        //    }
        //    catch { throw; }
        //}
        public static List<TblCompany> GetCompaniesList()
        {
            try
            {
                return CompaniesHelper.GetListOfCompanies();
            }
            catch { throw; }
        }
        //public static List<Branches> GetBranchesList()
        //{
        //    try
        //    {
        //        return BrancheHelper.GetBranches();
        //    }
        //    catch { throw; }
        //}
        //public static BillingNoSeries RegisterBillingNoSeries(BillingNoSeries billingNoSeries)
        //{
        //    try
        //    {
        //        using(Repository<BillingNoSeries> repo=new Repository<BillingNoSeries>())
        //        {
        //            billingNoSeries.Active = "Y";
        //            billingNoSeries.AddDate = DateTime.Now;
        //            var record = repo.BillingNoSeries.OrderByDescending(x => x.AddDate).FirstOrDefault();
        //            if (record != null)
        //                billingNoSeries.Code = CommonHelper.IncreaseCode(record.Code);
        //            else
        //                billingNoSeries.Code = "1";

                   
        //            repo.Add(billingNoSeries);

        //            if (repo.SaveChanges() > 0)
        //                return billingNoSeries;

        //            return null;
        //        }
        //    }
        //    catch { throw; }
        //}
        //public static BillingNoSeries UpdateBillingNoSeries(BillingNoSeries billingNoSeries)
        //{
        //    try
        //    {
        //        using(Repository<BillingNoSeries> repo=new Repository<BillingNoSeries>())
        //        {
        //            repo.Update(billingNoSeries);
        //            if (repo.SaveChanges() > 0)
        //                return billingNoSeries;

        //            return null;
        //        }
        //    }
        //    catch { throw; }
        //}
    }
}
