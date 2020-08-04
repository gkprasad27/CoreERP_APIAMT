using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class tdsratesHelper
    {
        public static IEnumerable<TblTdsRates> GetList(string code)
        {
            try
            {
                return Repository<TblTdsRates>.Instance.Where(x => x.Code == code);
            }
            catch { throw; }
        }

        public static IEnumerable<TblTdsRates> GetList()
        {
            try
            {
                return Repository<TblTdsRates>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblTdsRates Register(TblTdsRates code)
        {
            try
            {
                Repository<TblTdsRates>.Instance.Add(code);
                if (Repository<TblTdsRates>.Instance.SaveChanges() > 0)
                    return code;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblTdsRates Update(TblTdsRates code)
        {
            try
            {
                Repository<TblTdsRates>.Instance.Update(code);
                if (Repository<TblTdsRates>.Instance.SaveChanges() > 0)
                    return code;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblTdsRates Delete(string rcodes)
        {
            try
            {

                var rcode = Repository<TblTdsRates>.Instance.GetSingleOrDefault(x => x.Code == rcodes);
                Repository<TblTdsRates>.Instance.Remove(rcode);
                if (Repository<TblTdsRates>.Instance.SaveChanges() > 0)
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
