using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.PurhaseHelpers
{
    public class PurchasesHelper
    {
        private static Repository<Purchase> _repo = null;
        private static Repository<Purchase> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<Purchase>();
                return _repo;
            }
        }


        public static List<Purchase> GetPurchaseList()
        {
            try
            {
                return repo.Purchase.Select(x => x).ToList();
            }
            catch { throw; }
        }


        public static int RegisterPurchase(Purchase[] purchasesarr)
        {
            try
            {

                Purchase  purchase = repo.Purchase.OrderByDescending(x => x.AddDate).FirstOrDefault();

                if (purchase !=null)
                {
                    purchasesarr[0].Code = (Convert.ToInt32(purchase.Code) + 1).ToString();
                    purchasesarr[0].AddDate = DateTime.Now;
                    purchasesarr[0].EditDate = DateTime.Now;
                }
                else
                {
                    purchasesarr[0].Code = "1";
                    purchasesarr[0].AddDate = DateTime.Now;
                    purchasesarr[0].EditDate = DateTime.Now;
                }


                for (int i = 1; i < purchasesarr.Count(); i++)
                {
                    purchasesarr[i].Code = (Convert.ToInt32(purchasesarr[i - 1].Code) + 1).ToString();
                    purchasesarr[i].AddDate = DateTime.Now;
                    purchasesarr[i].EditDate = DateTime.Now;
                }

              
                repo.Purchase.AddRange(purchasesarr);
                return repo.SaveChanges();
            }
            catch { throw; }
        }


        public static int UpdatePurchase(Purchase purchase)
        {
            try
            {
                repo.Purchase.Update(purchase);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int DeletePurchase(string  code)
        {
            try
            {
                var purchase = repo.Purchase.Where(x => x.Code == code).FirstOrDefault();
                repo.Purchase.Remove(purchase);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static List<MatTranTypes> GetPurchaseMaterialGroup()
        {
            try
            {
              //  MaterialTransationType
             return  repo.MatTranTypes
                    .Where(x=> (string.Compare(x.TransactionType,"PURCHASE",true)==0))
                    .ToList();
            }
            catch { throw; }
        }
    }
}
