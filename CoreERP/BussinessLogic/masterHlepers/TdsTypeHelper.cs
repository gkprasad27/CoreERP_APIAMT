using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class TdsTypeHelper
    {
        public static IEnumerable<TblTdstypes> GetList(string code)
        {
            try
            {
                return Repository<TblTdstypes>.Instance.Where(x => x.TdsCode == code);
            }
            catch { throw; }
        }

        public static IEnumerable<TblTdstypes> GetList()
        {
            try
            {
                return Repository<TblTdstypes>.Instance.GetAll().OrderBy(x => x.TdsCode);
            }
            catch { throw; }
        }

        public static TblTdstypes Register(TblTdstypes code)
        {
            try
            {
                Repository<TblTdstypes>.Instance.Add(code);
                if (Repository<TblTdstypes>.Instance.SaveChanges() > 0)
                    return code;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblTdstypes Update(TblTdstypes code)
        {
            try
            {
                Repository<TblTdstypes>.Instance.Update(code);
                if (Repository<TblTdstypes>.Instance.SaveChanges() > 0)
                    return code;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblTdstypes Delete(string rcodes)
        {
            try
            {

                var rcode = Repository<TblTdstypes>.Instance.GetSingleOrDefault(x => x.TdsCode == rcodes);
                Repository<TblTdstypes>.Instance.Remove(rcode);
                if (Repository<TblTdstypes>.Instance.SaveChanges() > 0)
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
