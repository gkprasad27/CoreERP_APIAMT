using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class NumberrangeHelper
    {
        public static IEnumerable<TblNumberRange> GetList(string code)
        {
            try
            {
                return Repository<TblNumberRange>.Instance.Where(x => x.Code == code);
            }
            catch { throw; }
        }

        public static IEnumerable<TblNumberRange> GetList()
        {
            try
            {
                return Repository<TblNumberRange>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblNumberRange Register(TblNumberRange numrange)
        {
            try
            {
                Repository<TblNumberRange>.Instance.Add(numrange);
                if (Repository<TblNumberRange>.Instance.SaveChanges() > 0)
                    return numrange;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblNumberRange Update(TblNumberRange numrange)
        {
            try
            {
                Repository<TblNumberRange>.Instance.Update(numrange);
                if (Repository<TblNumberRange>.Instance.SaveChanges() > 0)
                    return numrange;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblNumberRange Delete(string codes)
        {
            try
            {

                var rcode = Repository<TblNumberRange>.Instance.GetSingleOrDefault(x => x.Code == codes);
                Repository<TblNumberRange>.Instance.Remove(rcode);
                if (Repository<TblNumberRange>.Instance.SaveChanges() > 0)
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
