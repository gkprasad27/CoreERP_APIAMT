using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class AssignmentofcoatocompcodeHelper
    {
        public static IEnumerable<TblAssignchartaccttoCompanycode> GetList(string code)
        {
            try
            {
                return Repository<TblAssignchartaccttoCompanycode>.Instance.Where(x => x.Code == code);
            }
            catch { throw; }
        }

        public static IEnumerable<TblAssignchartaccttoCompanycode> GetList()
        {
            try
            {
                return Repository<TblAssignchartaccttoCompanycode>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblAssignchartaccttoCompanycode Register(TblAssignchartaccttoCompanycode coa)
        {
            try
            {
                Repository<TblAssignchartaccttoCompanycode>.Instance.Add(coa);
                if (Repository<TblAssignchartaccttoCompanycode>.Instance.SaveChanges() > 0)
                    return coa;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblAssignchartaccttoCompanycode Update(TblAssignchartaccttoCompanycode coa)
        {
            try
            {
                Repository<TblAssignchartaccttoCompanycode>.Instance.Update(coa);
                if (Repository<TblAssignchartaccttoCompanycode>.Instance.SaveChanges() > 0)
                    return coa;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblAssignchartaccttoCompanycode Delete(string codes)
        {
            try
            {

                var rcode = Repository<TblAssignchartaccttoCompanycode>.Instance.GetSingleOrDefault(x => x.Code == codes);
                Repository<TblAssignchartaccttoCompanycode>.Instance.Remove(rcode);
                if (Repository<TblAssignchartaccttoCompanycode>.Instance.SaveChanges() > 0)
                    return rcode;
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
