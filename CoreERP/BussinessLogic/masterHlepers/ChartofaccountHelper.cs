using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class ChartofaccountHelper
    {
        public static IEnumerable<TblChartAccount> GetList(string code)
        {
            try
            {
                return Repository<TblChartAccount>.Instance.Where(x => x.Code == code);
            }
            catch { throw; }
        }

        public static IEnumerable<TblChartAccount> GetList()
        {
            try
            {
                return Repository<TblChartAccount>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblChartAccount Register(TblChartAccount coa)
        {
            try
            {
                Repository<TblChartAccount>.Instance.Add(coa);
                if (Repository<TblChartAccount>.Instance.SaveChanges() > 0)
                    return coa;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblChartAccount Update(TblChartAccount coa)
        {
            try
            {
                Repository<TblChartAccount>.Instance.Update(coa);
                if (Repository<TblChartAccount>.Instance.SaveChanges() > 0)
                    return coa;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblChartAccount Delete(string codes)
        {
            try
            {

                var rcode = Repository<TblChartAccount>.Instance.GetSingleOrDefault(x => x.Code == codes);
                Repository<TblChartAccount>.Instance.Remove(rcode);
                if (Repository<TblChartAccount>.Instance.SaveChanges() > 0)
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
