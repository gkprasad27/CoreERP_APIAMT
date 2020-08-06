using CoreERP.DataAccess;
using CoreERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class ProfitCenterHelper
    {

        //public static IEnumerable<ProfitCenters> GetProfitCenterList()
        //{
        //    try
        //    {
        //        return Repository<ProfitCenters>.Instance.GetAll().OrderBy(x => x.Code);
        //    }
        //    catch { throw; }
        //}
        //public static ProfitCenters RegisteProfitCenter(ProfitCenters profitCenter)
        //{
        //    try
        //    {
        //        Repository<ProfitCenters>.Instance.Add(profitCenter);
        //        if (Repository<ProfitCenters>.Instance.SaveChanges() > 0)
        //            return profitCenter;

        //        return null;
        //    }
        //    catch { throw; }
        //}
        //public static ProfitCenters UpdateProfitCenter(ProfitCenters profitCenter)
        //{
        //    try
        //    {
        //        Repository<ProfitCenters>.Instance.Update(profitCenter);
        //        if (Repository<ProfitCenters>.Instance.SaveChanges() > 0)
        //            return profitCenter;

        //        return null;
        //    }
        //    catch { throw; }
        //}
        //public static ProfitCenters DeleteProfitCenter(string seqID)
        //{
        //    try
        //    {
        //        var ccode = Repository<ProfitCenters>.Instance.GetSingleOrDefault(x => x.Code == seqID);
        //        Repository<ProfitCenters>.Instance.Remove(ccode);
        //        if (Repository<ProfitCenters>.Instance.SaveChanges() > 0)
        //            return ccode;

        //        return null;
        //    }
        //    catch { throw; }
        //}
    }
}
