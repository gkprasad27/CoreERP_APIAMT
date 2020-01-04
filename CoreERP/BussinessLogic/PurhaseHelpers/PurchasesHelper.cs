using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.masterHlepers;
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
        public static Purchase GetPurchase(string code)
        {
            try
            {
                return repo.Purchase.Where(x => x.Code == code).FirstOrDefault();
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


                purchasesarr[0].Active = "Y";
                for (int i = 1; i < purchasesarr.Count(); i++)
                {
                    purchasesarr[i].Code = (Convert.ToInt32(purchasesarr[i - 1].Code) + 1).ToString();
                    purchasesarr[i].AddDate = DateTime.Now;
                    purchasesarr[i].EditDate = DateTime.Now;
                    purchasesarr[i].Active = "Y";
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

        //public static int DeletePurchase(string  code)
        //{
        //    try
        //    {
        //        var purchase = repo.Purchase.Where(x => x.Code == code).FirstOrDefault();
        //        repo.Purchase.Remove(purchase);
        //        return repo.SaveChanges();
        //    }
        //    catch { throw; }
        //}

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
        public static List<Companies> GetCompanies()
        {
            try { return masterHlepers.CompaniesHelper.GetListOfCompanies(); }
            catch { throw; }
        }
        public static List<Branches> GetBranches()
        {
            try { return masterHlepers.BrancheHelper.GetBranches(); }
            catch { throw; }
        }
        public static List<Glaccounts> GetGLAccounts()
        {
            try 
            {
                return GLHelper.GetGLAccountsList();
            }
            catch { throw; }
        }
        public static List<MatTranTypes> GetMatTranTypes()
        {
            try
            {
                // materialTranstp = (from mattran in _unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.TransactionType != null)
                //                    where mattran.TransactionType.ToUpper() == MaterialTransationType.PURCHASE.ToString()
                //                    select mattran),
                return  GLHelper.GetMatTranTypesList()
                                .Where(m=> m.TransactionType.Equals("PURCHASE",StringComparison.OrdinalIgnoreCase))
                                .ToList();
            }
            catch { throw; }
        }
        public static List<MaterialGroup> GetMaterialGroup()
        {
            try
            {
                return GLHelper.GetMaterialGroupsList();
            }
            catch { throw; }
        }
        public static List<TaxMasters> GetTAxMasterList()
        {
            try
            {
                // taxmasterlist = (from taxm in _unitOfWork.TaxMasters.GetAll()
                //                  //join taxi in _unitOfWork.TaxIntegration.GetAll()
                //                  //on taxm.Code equals taxi.TaxCode
                //                  where taxm.TaxType == "INPUT"
                //                  select taxm),
                return GLHelper.GetTaxMasterList()
                               .Where(t=> t.TaxType.Equals("INPUT",StringComparison.OrdinalIgnoreCase))
                               .ToList();
            }
            catch { throw; }
        }
        public static List<TaxIntegration> GetTaxIntegrationList()
        {
            try
            {
                // taxintegration = (from taxingr in _unitOfWork.TaxIntegration.GetAll() where taxingr.TaxCode != null select taxingr),
                return GLHelper.GetTaxIntegrationList()
                               .Where(t=> t.TaxCode !=null)
                               .ToList();
            }
            catch { throw; }
        }
        public static List<BrandModel> GetModelList()
        {
            try
            {
                // models = (from md in _unitOfWork.BrandModel.GetAll()
                //          // join itmmst in _unitOfWork.ItemMaster.GetAll()
                //         //  on md.Code equals itmmst.Model
                //           select md),

                return GLHelper.GetModelList();
            }
            catch { throw; }
        }
        public static List<ItemMaster> GetItemMasterList()
        {
            try
            {
                return InventoryHelper.GetItemMasterList();
            }
            catch { throw; }
        }
        public static List<PartnerCreation> GetPartnerCreationList()
        {
            try
            {
                // partnercreation = (from parttyp in _unitOfWork.PartnerType.GetAll()
                //                    join partcr in _unitOfWork.PartnerCreation.GetAll()
                //                    on parttyp.Code equals partcr.Partnertype
                //                    where parttyp.AccountType == NatureOfAccounts.TRADEVENDORS.ToString()
                //                    select partcr),
                var partnerCreationList = PartnerCreationHelper.GetList();
                var partnerTypeList = PartnerTypeHelper.GetPartnerTypeList();

                return (from parttyp in partnerTypeList
                 join partcr in partnerCreationList
                 on parttyp.Code equals partcr.Partnertype
                 where parttyp.AccountType.Equals("TRADEVENDORS", StringComparison.OrdinalIgnoreCase)
                 select partcr).ToList();
            }
            catch { throw; }
        }
        public static List<Brand> GetBrandList()
        {
            try
            {
                return InventoryHelper.GetBrandList();
            }
            catch { throw; }
        }
        public static List<Interpretation> GetInterpretationList()
        {
            try
            {
                return InterpretationHelper.GetInterpretationList();
            }
            catch { throw; }
        }
        public static List<AsignmentAcctoAccClass> GetAccountToAccountClassList()
        {
            try
            {
                return GLHelper.GetAccountToAccountClassList();
            }
            catch { throw; }
        }
        public static List<PurchaseReturns> GetPurchaseReturnsList()
        {
            try
            {
                using (Repository<PurchaseReturns> context = new Repository<PurchaseReturns>())
                {
                    return context.PurchaseReturns.Where(p => p.GoodsReceiptDate!=null).ToList();
                }
            }
            catch { throw; }
        }
    }
}
