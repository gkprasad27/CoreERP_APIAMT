using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class AlternateControlAccountHelper
    {
        public static IEnumerable<TblAlternateControlAccTrans> GetList(string code)
        {
            try
            {
                return Repository<TblAlternateControlAccTrans>.Instance.Where(x => x.Code == code);
            }
            catch { throw; }
        }

        public static IEnumerable<TblAlternateControlAccTrans> GetList()
        {
            try
            {
                return Repository<TblAlternateControlAccTrans>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblAlternateControlAccTrans Register(TblAlternateControlAccTrans alacunt)
        {
            try
            {
                Repository<TblAlternateControlAccTrans>.Instance.Add(alacunt);
                if (Repository<TblAlternateControlAccTrans>.Instance.SaveChanges() > 0)
                    return alacunt;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblAlternateControlAccTrans Update(TblAlternateControlAccTrans alacunt)
        {
            try
            {
                Repository<TblAlternateControlAccTrans>.Instance.Update(alacunt);
                if (Repository<TblAlternateControlAccTrans>.Instance.SaveChanges() > 0)
                    return alacunt;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblAlternateControlAccTrans Delete(string codes)
        {
            try
            {

                var rcode = Repository<TblAlternateControlAccTrans>.Instance.GetSingleOrDefault(x => x.Code == codes);
                Repository<TblAlternateControlAccTrans>.Instance.Remove(rcode);
                if (Repository<TblAlternateControlAccTrans>.Instance.SaveChanges() > 0)
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
