using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class DepreciationareasHelper
    {
        public static IEnumerable<TblDepreciationAreas> GetList(string code)
        {
            try
            {
                return Repository<TblDepreciationAreas>.Instance.Where(x => x.Code == code);
            }
            catch { throw; }
        }

        public static IEnumerable<TblDepreciationAreas> GetList()
        {
            try
            {
                return Repository<TblDepreciationAreas>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblDepreciationAreas Register(TblDepreciationAreas dparea)
        {
            try
            {
                Repository<TblDepreciationAreas>.Instance.Add(dparea);
                if (Repository<TblDepreciationAreas>.Instance.SaveChanges() > 0)
                    return dparea;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblDepreciationAreas Update(TblDepreciationAreas dparea)
        {
            try
            {
                Repository<TblDepreciationAreas>.Instance.Update(dparea);
                if (Repository<TblDepreciationAreas>.Instance.SaveChanges() > 0)
                    return dparea;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblDepreciationAreas Delete(string codes)
        {
            try
            {

                var rcode = Repository<TblDepreciationAreas>.Instance.GetSingleOrDefault(x => x.Code == codes);
                Repository<TblDepreciationAreas>.Instance.Remove(rcode);
                if (Repository<TblDepreciationAreas>.Instance.SaveChanges() > 0)
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
