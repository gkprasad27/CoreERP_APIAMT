using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SalesHelper
{
    public class BillingHelpers
    {
        #region Billing Returns
        public static Billing  GetBilling(string billNo)
        {
            try
            {
                using(Repository<Billing> repo=new Repository<Billing>())
                {
                    return repo.Billing.Where(x => x.BillNo == billNo).FirstOrDefault();
                }
            }
            catch { throw; }
        }
        #endregion


        #region Card Type
        public static List<CardType> GetCardTypeList()
        {
            try
            {
                using(Repository<CardType> repo=new Repository<CardType>())
                {
                    return repo.CardType.Where(c => c.Active == "Y").ToList();
                }
            }
            catch { throw; }
        }

        public static CardType GetCardTypeList(string code)
        {
            try
            {
                using (Repository<CardType> repo = new Repository<CardType>())
                {
                    return repo.CardType.Where(c => c.Active.Equals("Y")
                                                 && c.Code == code).FirstOrDefault();
                }
            }
            catch { throw; }
        }

        public static List<Glaccounts> GetGlAccountsDRCR()
        {
            try
            {
                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    return repo.Glaccounts
                          .Where(x => x.Active.Equals("Y")
                                   && (x.Nactureofaccount.Equals("DR")
                                   || x.Nactureofaccount.Equals("CR"))
                                )
                          .ToList();
                }
            }
            catch { throw; }
        }

        public static CardType RegisterCardType(CardType cardType)
        {
            try
            {
                using (Repository<CardType> repo = new Repository<CardType>())
                {
                    
                    int lastreacord = repo.CardType.Where(x => x.Code != null).Max(x => Convert.ToInt32(x.Code));

                    if (lastreacord > 0)
                        cardType.Code = (lastreacord + 1).ToString();
                    else
                        cardType.Code = "1";
                  
                    cardType.Active = "Y";
                    repo.CardType.Add(cardType);
                    if (repo.SaveChanges() > 0)
                        return cardType;

                    return null;
                }

            }
            catch { throw; }
        }
        public static CardType UpdateCardType(CardType cardType)
        {
            try
            {
                using(Repository<CardType> repo=new Repository<CardType>())
                {
                    repo.CardType.Update(cardType);
                    if (repo.SaveChanges() > 0)
                        return cardType;

                    return null;
                }
            }
            catch { throw; }
        }
        #endregion

        #region Finaces
        public static List<Finance> GetFinances()
        {
            try
            {
                using(Repository<Finance> repo=new Repository<Finance>())
                {
                    return repo.Finance.Where(x => x.Active.Equals("Y")).ToList();
                }
            }
            catch { throw; }
        }

        public static List<Glaccounts> GetFinancesCutomerGLAccounts()
        {
            try
            {
                //glacccts = (from accounts in _unitOfWork.GLAccounts.GetAll()
                //            where accounts.Nactureofaccount == "FINANCECUSTOMER"
                //            select accounts)

                using(Repository<Glaccounts> repo=new Repository<Glaccounts>())
                {
                  return  repo.Glaccounts
                        .AsEnumerable()
                        .Where(f => f.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)
                                 && f.Nactureofaccount.Equals("FINANCECUSTOMER", StringComparison.OrdinalIgnoreCase)
                              )
                        .ToList();
                         
                }
            }
            catch { throw; }
        }

        public static List<Brand> GetBrandList()
        {
            try
            {
                using (Repository<Brand> repo = new Repository<Brand>())
                {
                    return repo.Brand.AsEnumerable()
                               .Where(b => b.Active.Equals("Y", StringComparison.OrdinalIgnoreCase))
                               .ToList();
                }
            }
            catch { throw; }
        }

        public static List<BrandModel> GetBrandModelList()
        {
            try
            {
                using (Repository<BrandModel> repo = new Repository<BrandModel>())
                {
                    return repo.BrandModel.AsEnumerable()
                               .Where(b => b.Active.Equals("Y", StringComparison.OrdinalIgnoreCase))
                               .ToList();
                }
            }
            catch { throw; }
        }
        #endregion
    }
}
