using CoreERP.DataAccess;
using CoreERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class CountryHelper
    {
        

        public static List<Countries> GetCountries()
        {
            try
            {
                using (Repository<Countries> repo = new Repository<Countries>())
                {
                    List<TblLanguage> languages = repo.TblLanguage.ToList();
                    List<TblCurrency> currencies = repo.TblCurrency.ToList();
                    repo.Countries.ToList()
                        .ForEach(c =>
                            {
                                c.LangName = languages.Where(l => l.LanguageCode == c.Language).FirstOrDefault()?.LanguageName;
                               c.CurrName = currencies.Where(cur => cur.CurrencySymbol == c.Currency).FirstOrDefault()?.CurrencyName;
                            });
                    return repo.Countries.ToList();
                }           
            }
            catch { throw; }
        }

        
    }
}
