using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CoreERP.BussinessLogic.masterHlepers
{
    public class postingHelper
    {
        public static IEnumerable<TblPosting> GetList(string code)
        {
            try
            {
                return Repository<TblPosting>.Instance.Where(x => x.Code == code);
            }
            catch { throw; }
        }

        public static IEnumerable<TblPosting> GetList()
        {
            try
            {
                return Repository<TblPosting>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblPosting Register(TblPosting post)
        {
            try
            {
                Repository<TblPosting>.Instance.Add(post);
                if (Repository<TblPosting>.Instance.SaveChanges() > 0)
                    return post;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblPosting Update(TblPosting post)
        {
            try
            {
                Repository<TblPosting>.Instance.Update(post);
                if (Repository<TblPosting>.Instance.SaveChanges() > 0)
                    return post;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblPosting Delete(string codes)
        {
            try
            {

                var rcode = Repository<TblPosting>.Instance.GetSingleOrDefault(x => x.Code == codes);
                Repository<TblPosting>.Instance.Remove(rcode);
                if (Repository<TblPosting>.Instance.SaveChanges() > 0)
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
