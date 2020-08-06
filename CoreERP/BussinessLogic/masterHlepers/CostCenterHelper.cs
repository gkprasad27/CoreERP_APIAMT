using CoreERP.DataAccess;
using CoreERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class CostCenterHelper
    {
        //public static IEnumerable<CostCenters> GetCostCenterList()
        //{
        //    try
        //    {
        //        return Repository<CostCenters>.Instance.GetAll().OrderBy(x => x.Code);
        //    }
        //    catch { throw; }
        //}

        ////public static bool IsCodeExists(string code)
        ////{
        ////    try
        ////    {
        ////        using Repository<CostCenters> repo = new Repository<CostCenters>();
        ////        return repo.CostCenters.AsEnumerable().Where(c => c.Code == code).Count() > 0;
        ////    }
        ////    catch { throw; }
        ////}

        //public static CostCenters RegisterCostCenter(CostCenters costCenter)
        //{
        //    try
        //    {
        //        Repository<CostCenters>.Instance.Add(costCenter);
        //        if (Repository<CostCenters>.Instance.SaveChanges() > 0)
        //            return costCenter;

        //        return null;
        //    }
        //    catch { throw; }
        //}



        //public static CostCenters UpdateCostCenter(CostCenters costCenters)
        //{
        //    try
        //    {
        //        Repository<CostCenters>.Instance.Update(costCenters);
        //        if (Repository<CostCenters>.Instance.SaveChanges() > 0)
        //            return costCenters;

        //        return null;
        //    }
        //    catch { throw; }
        //}



        //public static CostCenters DeleteCostCenter(string costCenterCode)
        //{
        //    try
        //    {
        //        var ccode = Repository<CostCenters>.Instance.GetSingleOrDefault(x => x.Code == costCenterCode);
        //        Repository<CostCenters>.Instance.Remove(ccode);
        //        if (Repository<CostCenters>.Instance.SaveChanges() > 0)
        //            return ccode;

        //        return null;
        //    }
        //    catch { throw; }
        //}
    }
}
