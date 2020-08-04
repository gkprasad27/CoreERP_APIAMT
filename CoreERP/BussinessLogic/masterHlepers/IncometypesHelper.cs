using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class IncometypesHelper
    {
        public static IEnumerable<TblIncomeTypes> GetList(string code)
        {
            try
            {
                return Repository<TblIncomeTypes>.Instance.Where(x => x.Code == code);
            }
            catch { throw; }
        }

        public static IEnumerable<TblIncomeTypes> GetList()
        {
            try
            {
                return Repository<TblIncomeTypes>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblIncomeTypes Register(TblIncomeTypes code)
        {
            try
            {
                Repository<TblIncomeTypes>.Instance.Add(code);
                if (Repository<TblIncomeTypes>.Instance.SaveChanges() > 0)
                    return code;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblIncomeTypes Update(TblIncomeTypes code)
        {
            try
            {
                Repository<TblIncomeTypes>.Instance.Update(code);
                if (Repository<TblIncomeTypes>.Instance.SaveChanges() > 0)
                    return code;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblIncomeTypes Delete(string rcodes)
        {
            try
            {

                var rcode = Repository<TblIncomeTypes>.Instance.GetSingleOrDefault(x => x.Code == rcodes);
                Repository<TblIncomeTypes>.Instance.Remove(rcode);
                if (Repository<TblIncomeTypes>.Instance.SaveChanges() > 0)
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
