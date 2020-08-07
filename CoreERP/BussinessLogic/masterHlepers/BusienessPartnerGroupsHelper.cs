using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class BusienessPartnerGroupsHelper
    {
        //public static IEnumerable<TblBpgroup> GetList(string code)
        //{
        //    try
        //    {
        //        return Repository<TblBpgroup>.Instance.Where(x => x.Bpgroup == code);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblBpgroup> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblBpgroup>.Instance.GetAll().OrderBy(x => x.Bpgroup);
        //    }
        //    catch { throw; }
        //}

        //public static TblBpgroup Register(TblBpgroup bpgroup)
        //{
        //    try
        //    {
        //        Repository<TblBpgroup>.Instance.Add(bpgroup);
        //        if (Repository<TblBpgroup>.Instance.SaveChanges() > 0)
        //            return bpgroup;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblBpgroup Update(TblBpgroup bpgroup)
        //{
        //    try
        //    {
        //        Repository<TblBpgroup>.Instance.Update(bpgroup);
        //        if (Repository<TblBpgroup>.Instance.SaveChanges() > 0)
        //            return bpgroup;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblBpgroup Delete(string codes)
        //{
        //    try
        //    {

        //        var rcode = Repository<TblBpgroup>.Instance.GetSingleOrDefault(x => x.Bpgroup == codes);
        //        Repository<TblBpgroup>.Instance.Remove(rcode);
        //        if (Repository<TblBpgroup>.Instance.SaveChanges() > 0)
        //            return rcode;
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
