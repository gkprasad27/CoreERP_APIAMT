using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class CountryHelper
    {
        public static List<Countries> GetList(string countrycode)
        {
            try
            {
                using (Repository<Countries> repo = new Repository<Countries>())
                {
                    return repo.Countries.Where(x => x.CountryCode == countrycode).ToList();
                }
            }
            catch { throw; }
        }

        public static List<Countries> GetCountries()
        {
            try
            {
                using (Repository<Countries> repo = new Repository<Countries>())
                {
                    List<TblLanguage> languages = repo.TblLanguage.ToList();
                    repo.Countries.ToList()
                        .ForEach(c =>
                            {
                                c.LangName = languages.Where(l => l.LanguageCode == c.Language).FirstOrDefault()?.LanguageName;
                            });
                    return repo.Countries.ToList();
                }           
            }
            catch { throw; }
        }

        public static Countries Register(Countries country)
        {
            try
            {
                using (ERPContext repo = new ERPContext())
                {
                    repo.Countries.Add(country);
                    if (repo.SaveChanges() > 0)
                        return country;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Countries Update(Countries country)
        {
            try
            {
                using (Repository<Countries> repo = new Repository<Countries>()) 
                {
                    repo.Countries.Update(country);
                    if (repo.SaveChanges() > 0)
                        return country;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Countries Delete(string countrycode)
        {
            try
            {
                using (Repository<Countries> _repo = new Repository<Countries>())
                {
                    Countries ccode= _repo.Countries.Where(x => x.CountryCode == countrycode).FirstOrDefault();
                    _repo.Countries.Remove(ccode);
                    if (_repo.SaveChanges() > 0)
                        return ccode;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
