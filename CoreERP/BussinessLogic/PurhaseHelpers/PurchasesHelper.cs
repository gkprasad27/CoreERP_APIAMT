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

        public static List<Purchase> GetPurchaseList()
        {
            try
            {
                using (Repository<Purchase> repo = new Repository<Purchase>())
                {
                    return repo.Purchase.AsEnumerable().Where(x => x.Active.Equals("Y")).ToList();
                }
            }
            catch { throw; }
        }
        public static List<Purchase> GetPurchase(string code)
        {
            try
            {
                using (Repository<Purchase> repo = new Repository<Purchase>())
                {
                    return repo.Purchase.AsEnumerable().Where(x => x.Active.Equals("Y")).ToList();
                }
            }
            catch { throw; }
        }
        public static List<Purchase> RegisterPurchase(Purchase[] purchasesarr)
        {
            try
            {
                using (Repository<Purchase> repo = new Repository<Purchase>())
                {
                    Purchase purchase = repo.Purchase.OrderByDescending(x => x.AddDate).FirstOrDefault();

                    if (purchase != null)
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
                    if (repo.SaveChanges() > 0)
                        return purchasesarr.ToList();

                    return null;
                }
            }
            catch { throw; }
        }
        public static Purchase UpdatePurchase(Purchase purchase)
        {
            try
            {
                using (Repository<Purchase> repo = new Repository<Purchase>())
                {
                    repo.Purchase.Update(purchase);
                    if (repo.SaveChanges() > 0)
                        return purchase;

                    return null;
                }
            }
            catch { throw; }
        }

        public static Purchase DeletePurchase(string code)
        {
            try
            {
                using (Repository<Purchase> repo = new Repository<Purchase>())
                {
                    var purchase = repo.Purchase.Where(x => x.Code == code).FirstOrDefault();
                    purchase.Active = "N";
                    repo.Purchase.Update(purchase);
                    if (repo.SaveChanges() > 0)
                        return purchase;

                    return null;
                }
            }
            catch { throw; }
        }

        public static List<MatTranTypes> GetPurchaseMaterialGroup()
        {
            try
            {
                using (Repository<Purchase> repo = new Repository<Purchase>())
                {
                    //  MaterialTransationType
                    return repo.MatTranTypes.AsEnumerable()
                    .Where(x => (string.Compare(x.TransactionType, "PURCHASE", true) == 0))
                    .ToList();
                }
            }
            catch { throw; }
        }
        public static List<Companies> GetCompanies()
        {
            try
            {
                using (Repository<Purchase> repo = new Repository<Purchase>())
                {
                    return CompaniesHelper.GetListOfCompanies();
                }
            }
            catch { throw; }
        }
        public static List<Branches> GetBranches()
        {
            try
            {
                using (Repository<Purchase> repo = new Repository<Purchase>())
                {
                    return BrancheHelper.GetBranches();
                }
            }
            catch { throw; }
        }
        public static List<Glaccounts> GetGLAccounts()
        {
            try
            {
                using (Repository<Purchase> repo = new Repository<Purchase>())
                {
                    return GLHelper.GetGLAccountsList();
                }
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
                using (Repository<Purchase> repo = new Repository<Purchase>())
                {
                    return GLHelper.GetMatTranTypesList().AsEnumerable()
                                   .Where(m => m.TransactionType.Equals("PURCHASE", StringComparison.OrdinalIgnoreCase))
                                   .ToList();
                }
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
                using (Repository<Purchase> repo = new Repository<Purchase>())
                {
                    return GLHelper.GetTaxMasterList()
                               .Where(t => t.TaxType.Equals("INPUT", StringComparison.OrdinalIgnoreCase))
                               .ToList();
                }
            }
            catch { throw; }
        }
        public static List<TaxIntegration> GetTaxIntegrationList()
        {
            try
            {
                // taxintegration = (from taxingr in _unitOfWork.TaxIntegration.GetAll() where taxingr.TaxCode != null select taxingr),
                using (Repository<Purchase> repo = new Repository<Purchase>())
                {
                    return GLHelper.GetTaxIntegrationList()
                               .Where(t => t.TaxCode != null)
                               .ToList();
                }
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
                    return context.PurchaseReturns.Where(p => p.GoodsReceiptDate != null).ToList();
                }
            }
            catch { throw; }
        }


        #region Vendor Payments
        public static VendorPayments RegisterVendorPayments(VendorPayments vendorPayments)
        {
            try
            {
                using(Repository<VendorPayments> repo=new Repository<VendorPayments>())
                {
                    var lastrecord = repo.VendorPayments.Where(v => v.Code != null).LastOrDefault();
                    if (lastrecord != null)
                        vendorPayments.Code = (Convert.ToInt32(lastrecord.Code) + 1).ToString();
                    else
                        vendorPayments.Code = "1";

                    lastrecord = null;
                    vendorPayments.Active = "Y";
                    vendorPayments.AddDate = System.DateTime.Now;
                    vendorPayments.EditDate = System.DateTime.Now;

                    repo.VendorPayments.Add(vendorPayments);

                    if (repo.SaveChanges() > 0)
                        return vendorPayments;

                    return null;
                }
            }
            catch { throw; }
        }
        public static VendorPayments UpdateVendorPayments(VendorPayments vendorPayments)
        {
            try
            {
                using (Repository<VendorPayments> repo = new Repository<VendorPayments>())
                {
                    vendorPayments.EditDate = DateTime.Now;
                    repo.VendorPayments.Update(vendorPayments);

                    if (repo.SaveChanges() > 0)
                        return vendorPayments;

                    return null;
                }
            }
            catch { throw; }
        }
        public static VendorPayments DeleteVendorPayments(string  code)
        {
            try
            {
                using (Repository<VendorPayments> repo = new Repository<VendorPayments>())
                {
                    var vendorPayments = repo.VendorPayments.Where(v => v.Code == code).FirstOrDefault();
                    vendorPayments.Active = "N";
                    vendorPayments.EditDate = DateTime.Now;
                    repo.VendorPayments.Update(vendorPayments);

                    if (repo.SaveChanges() > 0)
                        return vendorPayments;

                    return null;
                }
            }
            catch { throw; }
        }

        public static List<VendorPayments> GetVendorPaymentsList()
        {
            try
            {
                using (Repository<VendorPayments> repo = new Repository<VendorPayments>())
                {
                    return repo.VendorPayments.Where(vp => vp.Active == "Y").ToList();
                }
            }
            catch { throw; }
        }

        public static List<AsignmentCashAccBranch> GetAsignmentCashAccBranchesList()
        {
            try
            {
                return GLHelper.GetAsignCashAccBranch();
            }
            catch { throw; }
        }
        public static List<PartnerCreation> GetVendorNames()
        {
            //return (from pc in _unitOfWork.PartnerCreation.GetAll()
            //        join ptype in _unitOfWork.PartnerType.GetAll()
            //        on pc.Partnertype equals ptype.Code
            //        where ptype.AccountType == AccountType.TRADEVENDORS.ToString()
            //        select new { key = pc.Code, value = pc.Name }).ToArray();

            try
            {
                return (from pc in PartnerCreationHelper.GetList()
                        join pt in PartnerTypeHelper.GetPartnerTypeList()
                          on pc.Partnertype equals pt.Code
                       where pt.AccountType == AccountType.TRADEVENDORS.ToString()
                      select pc
                        ).ToList();
            }
            catch { throw; }
        }
        public static List<PartnerCreation> GetCutomerNamesList()
        {
            //return (from pc in _unitOfWork.PartnerCreation.GetAll()
            //        join ptype in _unitOfWork.PartnerType.GetAll()
            //        on pc.Partnertype equals ptype.Code
            //        where ptype.AccountType == AccountType.TRADECUSTOMER.ToString()
            //        select new { key = pc.Code, value = pc.Name }).ToArray();

            try
            {
                return (from pc in PartnerCreationHelper.GetList()
                        join pt in PartnerTypeHelper.GetPartnerTypeList()
                          on pc.Partnertype equals pt.Code
                        where pt.AccountType == AccountType.TRADECUSTOMER.ToString()
                        select pc
                        ).ToList();
            }
            catch { throw; }
        }

        public static List<Glaccounts> GetAsigCasNBankAcc()
        {
            try
            {
                //    accounts = (from glacc in _unitOfWork.GLAccounts.GetAll()
                //                join asigccashacc in _unitOfWork.AsignmentCashAccBranch.GetAll()
                //                on glacc.GLCode equals asigccashacc.CashGLAcc
                //                select glacc).Union(from glacc in _unitOfWork.GLAccounts.GetAll()
                //                                    join asigccashacc in _unitOfWork.AsignmentCashAccBranch.GetAll()
                //                                    on glacc.GLCode equals asigccashacc.BankGLAcc
                //                                    select glacc).ToList(),

                List<string> glCodes = GLHelper.GetAsignCashAccBranch()
                                              .Select(x => x.CashGlacc)
                                              .Union(GLHelper.GetAsignCashAccBranch().Select(x => x.BankGlacc)).ToList();

                using(Repository<Glaccounts> repo=new Repository<Glaccounts>())
                {
                    return repo.Glaccounts.AsEnumerable().Where(gl => glCodes.Contains(gl.Glcode)).ToList();
                }
            }
            catch { throw; }
        }
        #endregion
    }
}
