using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class AssignTaxacctoTaxcodeHelper
    {
        //public static IEnumerable<TblAssignTaxacctoTaxcode> GetList(string code)
        //{
        //    try
        //    {
        //        return Repository<TblAssignTaxacctoTaxcode>.Instance.Where(x => x.Code == code);
        //    }
        //    catch { throw; }
        //}

        //public static IEnumerable<TblAssignTaxacctoTaxcode> GetList()
        //{
        //    try
        //    {
        //        return Repository<TblAssignTaxacctoTaxcode>.Instance.GetAll().OrderBy(x => x.Code);
        //    }
        //    catch { throw; }
        //}

        //public static TblAssignTaxacctoTaxcode Register(TblAssignTaxacctoTaxcode taxcode)
        //{
        //    try
        //    {
        //        Repository<TblAssignTaxacctoTaxcode>.Instance.Add(taxcode);
        //        if (Repository<TblAssignTaxacctoTaxcode>.Instance.SaveChanges() > 0)
        //            return taxcode;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblAssignTaxacctoTaxcode Update(TblAssignTaxacctoTaxcode taxcode)
        //{
        //    try
        //    {
        //        Repository<TblAssignTaxacctoTaxcode>.Instance.Update(taxcode);
        //        if (Repository<TblAssignTaxacctoTaxcode>.Instance.SaveChanges()> 0)
        //            return taxcode;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static TblAssignTaxacctoTaxcode Delete(string Code)
        //{
        //    try
        //    {
        //        var ccode = Repository<TblAssignTaxacctoTaxcode>.Instance.GetSingleOrDefault(x => x.Code == Code);
        //        Repository<TblAssignTaxacctoTaxcode>.Instance.Remove(ccode);
        //        if (Repository<TblAssignTaxacctoTaxcode>.Instance.SaveChanges() > 0)
        //            return ccode;

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
