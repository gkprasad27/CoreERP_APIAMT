using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class LanguageHelper
    {
        public static List<TblLanguage> GetList(string language)
        {
            try
            {
                using Repository<TblLanguage> repo = new Repository<TblLanguage>();
                return repo.TblLanguage.Where(x => x.LanguageCode == language).ToList();
            }
            catch { throw; }
        }

        public static List<TblLanguage> GetList()
        {
            try
            {
                using Repository<TblLanguage> repo = new Repository<TblLanguage>();
                return repo.TblLanguage.ToList();
            }
            catch { throw; }
        }

        public static TblLanguage Register(TblLanguage language)
        {
            try
            {
                using Repository<TblLanguage> repo = new Repository<TblLanguage>();
                repo.TblLanguage.Add(language);
                if (repo.SaveChanges() > 0)
                    return language;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblLanguage Update(TblLanguage language)
        {
            try
            {
                using Repository<TblLanguage> repo = new Repository<TblLanguage>();
                repo.TblLanguage.Update(language);
                if (repo.SaveChanges() > 0)
                    return language;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblLanguage Delete(string rcodes)
        {
            try
            {
                using Repository<TblLanguage> repo = new Repository<TblLanguage>();
                var rcode = repo.TblLanguage.Where(x => x.LanguageCode == rcodes).FirstOrDefault();
                repo.TblLanguage.Remove(rcode);
                if (repo.SaveChanges() > 0)
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
