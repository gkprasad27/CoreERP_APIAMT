using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.InventoryHelpers;
using CoreERP.BussinessLogic.masterHlepers;
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
       

        #region Card Type
        public static List<CardType> GetCardTypeList()
        {
            try
            {
                //using Repository<CardType> repo = new Repository<CardType>();
                //return repo.CardType.Where(c => c.Active == "Y").ToList();
                return null;
            }
            catch { throw; }
        }
        public static CardType GetCardTypeList(string code)
        {
            try
            {
                //                using Repository<CardType> repo = new Repository<CardType>();
                //                return repo.CardType.Where(c => c.Active.Equals("Y")
                //&& c.Code == code).FirstOrDefault();
                return null;
            }
            catch { throw; }
        }
        public static List<Glaccounts> GetGlAccountsDRCR(string natureofAccount)
        {
            try
            {
                //                using Repository<Glaccounts> repo = new Repository<Glaccounts>();
                //                return repo.Glaccounts
                //.Where(x => x.Active.Equals("Y")
                //&& (x.Nactureofaccount.Equals(natureofAccount))
                //)
                //.ToList();
                return null;
            }
            catch { throw; }
        }
        public static List<string> GetTypesList()
        {
            try
            {
                return new List<string>() { NATURESOFACCOUNTS.DR.ToString(), NATURESOFACCOUNTS.DR.ToString() };
            }
            catch { throw; }
        }
        public static CardType RegisterCardType(CardType cardType)
        {
            try
            {
                //using Repository<CardType> repo = new Repository<CardType>();
                //var reacord = repo.CardType.OrderByDescending(x => x.AddDate).FirstOrDefault();
                //if (reacord == null)
                //    cardType.Code = "1";
                //else
                //    cardType.Code = CommonHelper.IncreaseCode(cardType.Code);

                //cardType.Active = "Y";
                //repo.CardType.Add(cardType);
                //if (repo.SaveChanges() > 0)
                //    return cardType;

                return null;

            }
            catch { throw; }
        }
        public static CardType UpdateCardType(CardType cardType)
        {
            try
            {
                //using Repository<CardType> repo = new Repository<CardType>();
                //repo.CardType.Update(cardType);
                //if (repo.SaveChanges() > 0)
                //    return cardType;

                return null;
            }
            catch { throw; }
        }
        public static CardType DeleteCardType(string code)
        {
            try
            {
                //using Repository<CardType> repo = new Repository<CardType>();
                //var cardtype = BillingHelpers.GetCardTypeList(code);
                //cardtype.Active = "N";
                //repo.CardType.Update(cardtype);
                //if (repo.SaveChanges() > 0)
                //    return cardtype;

                return null;
            }
            catch { throw; }
        }
        #endregion

        #region Finaces
        public static List<Finance> GetFinances()
        {
            try
            {
                //using Repository<Finance> repo = new Repository<Finance>();
                //return repo.Finance.Where(x => x.Active.Equals("Y")).ToList();

                return null;
            }
            catch { throw; }
        }
        public static Finance GetFinances(string code)
        {
            try
            {
                //using Repository<Finance> repo = new Repository<Finance>();
                //return repo.Finance.Where(x => x.Active.Equals("Y") && x.Code == code).FirstOrDefault();

                return null;
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

                //                using Repository<Glaccounts> repo = new Repository<Glaccounts>();
                //                return repo.Glaccounts
                //.AsEnumerable()
                //.Where(f => f.Active == "Y"
                //&& f.Nactureofaccount == NATURESOFACCOUNTS.FINANCECUSTOMER.ToString()
                //)
                //.ToList();
                return null;
            }
            catch { throw; }
        }
        public static List<Brand> GetBrandList()
        {
            try
            {
                //                using Repository<Brand> repo = new Repository<Brand>();
                //                return repo.Brand.AsEnumerable()
                //.Where(b => b.Active.Equals("Y", StringComparison.OrdinalIgnoreCase))
                //.ToList();
                return null;
            }
            catch { throw; }
        }
        //public static List<BrandModel> GetBrandModelList()
        //{
        //    try
        //    {
        //        using (Repository<BrandModel> repo = new Repository<BrandModel>())
        //        {
        //            return repo.BrandModel.AsEnumerable()
        //                       .Where(b => b.Active.Equals("Y", StringComparison.OrdinalIgnoreCase))
        //                       .ToList();
        //        }
        //    }
        //    catch { throw; }
        //}
        public static Finance RegisterFiances(Finance finance)
        {
            try
            {
                //using Repository<Finance> repo = new Repository<Finance>();
                //finance.AddDate = DateTime.Now;
                //finance.EditDate = DateTime.Now;
                //finance.Active = "Y";

                //var reacord = repo.Finance.OrderByDescending(x => x.AddDate).FirstOrDefault();
                //if (reacord != null)
                //    finance.Code = CommonHelper.IncreaseCode(reacord.Code);
                //else
                //    finance.Code = "1";

                //repo.Finance.Add(finance);
                //if (repo.SaveChanges() > 0)
                //    return finance;

                return null;
            }
            catch { throw; }
        }
        public static Finance UpdateFinance(Finance finance)
        {
            try
            {
                //using Repository<Finance> repo = new Repository<Finance>();
                //finance.EditDate = DateTime.Now;
                //repo.Finance.Update(finance);
                //if (repo.SaveChanges() > 0)
                //    return finance;

                return null;
            }
            catch { throw; }
        }
        public static Finance DeleteFinance(string code)
        {
            try
            {
                //var financeEntity = GetFinances(code);
                //financeEntity.Active = "N";
                //using Repository<Finance> repo = new Repository<Finance>();
                //financeEntity.EditDate = DateTime.Now;
                //repo.Finance.Update(financeEntity);
                //if (repo.SaveChanges() > 0)
                //    return financeEntity;

                return null;
            }
            catch { throw; }
        }
        #endregion

        #region Cutomer Receipt
        public static List<CustomerReceipts> GetCustomerReceiptList()
        {
            try
            {
                //                using Repository<CustomerReceipts> repo = new Repository<CustomerReceipts>();
                //                return repo.CustomerReceipts.AsEnumerable()
                //.Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase))
                //.ToList();
                return null;
            }
            catch { throw; }
        }
        public static CustomerReceipts GetCustomerReceiptList(int seqID)
        {
            try
            {
                //                using Repository<CustomerReceipts> repo = new Repository<CustomerReceipts>();
                //                return repo.CustomerReceipts.AsEnumerable()
                //.Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)
                //&& c.SeqId == seqID
                //)
                //.FirstOrDefault();
                return null;
            }
            catch { throw; }
        }
        public static List<AsignmentCashAccBranch> GetAsigCashAccBranches()
        {
            try
            {
                //using Repository<AsignmentCashAccBranch> repo = new Repository<AsignmentCashAccBranch>();
                //return repo.AsignmentCashAccBranch.Select(x => x).ToList();

                return null;
            }
            catch { throw; }
        }
        public static CustomerReceipts RegisterCustomerReceipt(CustomerReceipts customerReceipt)
        {
            try
            {
                //using Repository<CustomerReceipts> repo = new Repository<CustomerReceipts>();
                //customerReceipt.AddDate = DateTime.Now;
                //customerReceipt.EditDate = DateTime.Now;

                //repo.CustomerReceipts.Add(customerReceipt);
                //if (repo.SaveChanges() > 0)
                //    return customerReceipt;

                return null;
            }
            catch { throw; }
        }
        public static CustomerReceipts UpdateCustomerReceipt(CustomerReceipts customerReceipt)
        {
            try
            {
                //using Repository<CustomerReceipts> repo = new Repository<CustomerReceipts>();
                //customerReceipt.EditDate = DateTime.Now;
                //repo.CustomerReceipts.Update(customerReceipt);
                //if (repo.SaveChanges() > 0)
                //    return customerReceipt;

                return null;
            }
            catch { throw; }
        }
        public static CustomerReceipts DeleteCustomerReceipt(int seqID)
        {
            try
            {
                //using Repository<CustomerReceipts> repo = new Repository<CustomerReceipts>();
                //var custobj = GetCustomerReceiptList(seqID);
                //custobj.Active = "N";
                //repo.CustomerReceipts.Update(custobj);
                //if (repo.SaveChanges() > 0)
                //    return custobj;

                return null;
            }
            catch { throw; }
        }
        public static List<VoucherTypes> GetVoucherTypesList()
        {
            try
            {
                //using Repository<VoucherTypes> repo = new Repository<VoucherTypes>();
                //return repo.VoucherTypes.Where(x => x.Active.Equals("Y")).ToList();

                return null;
            }
            catch { throw; }
        }
        #endregion
        public static List<Glaccounts> GetAsigAcctobranchGlAcc()
        {
            /*  var asiglcodes = ((from asig in _unitOfWork.AsignmentCashAccBranch.GetAll()
                                   where asig.BankGLAcc != null
                                   select asig.BankGLAcc).Union(from aasigcc in _unitOfWork.AsignmentCashAccBranch.GetAll()
                                                                where aasigcc.CashGLAcc != null
                                                                select aasigcc.CashGLAcc)).ToArray();
                var asigAcctobranchGlAcc = (from glacc in _unitOfWork.GLAccounts.GetAll()
                                            where asiglcodes.Contains(glacc.GLCode)
                                            select glacc).ToArray();*/
            try
            {
                List<string> accNosList = new List<string>();
                //using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                //{
                //    accNosList = ((from asig in repo.AsignmentCashAccBranch.ToList()
                //                   where asig.BankGlacc != null
                //                   select asig.BankGlacc).Union(from aasigcc in repo.AsignmentCashAccBranch.ToList()
                //                                                where aasigcc.CashGlacc != null
                //                                                select aasigcc.CashGlacc)).ToList();
                //}
                //using (Repository<Glaccounts> repo=new Repository<Glaccounts>())
                //{
                //    return (from glacc in repo.Glaccounts.ToList()
                //            where accNosList.Contains(glacc.Glcode)
                //            select glacc).ToList();
                //}

                return null;
            }
            catch { throw; }

        }


        #region Material Transaction Types
        public static List<MatTranTypes> GetMatTranTypesList()
        {
            try
            {
                //                using Repository<MatTranTypes> repo = new Repository<MatTranTypes>();
                //                return repo.MatTranTypes.AsEnumerable()
                //.Where(m => m.Active.Equals("Y", StringComparison.OrdinalIgnoreCase))
                //.ToList();
                return null;
            }
            catch { throw; }
        }
        public static MatTranTypes GetMatTranTypes(string code)
        {
            try
            {
                //                using Repository<MatTranTypes> repo = new Repository<MatTranTypes>();
                //                return repo.MatTranTypes.AsEnumerable()
                //.Where(m => m.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)
                //&& m.Code == code
                //)
                //.FirstOrDefault();
                return null;
            }
            catch { throw; }
        }
        public static List<TblBranch> GetBranchesList()
        {
            try
            {
              return  BrancheHelper.GetBranches().ToList();
            }
            catch { throw; }
        }
        public static MatTranTypes RegisterMatTransType(MatTranTypes matTranTypes)
        {
            try
            {
                //using Repository<MatTranTypes> repo = new Repository<MatTranTypes>();
                //matTranTypes.AddDate = DateTime.Now;

                //var record = repo.MatTranTypes.OrderByDescending(x => x.AddDate).FirstOrDefault();
                //if (record != null)
                //{
                //    matTranTypes.Code = CommonHelper.IncreaseCode(record.Code);
                //}
                //else
                //{
                //    matTranTypes.Code = "1";
                //}
                //repo.MatTranTypes.Add(matTranTypes);
                //if (repo.SaveChanges() > 0)
                //    return matTranTypes;

                return null;
            }
            catch { throw; }
        }
        public static MatTranTypes UpdateMatTransType(MatTranTypes matTranTypes)
        {
            try
            {
                //using Repository<MatTranTypes> repo = new Repository<MatTranTypes>();
                //repo.MatTranTypes.Update(matTranTypes);
                //if (repo.SaveChanges() > 0)
                //    return matTranTypes;

                return null;
            }
            catch { throw; }
        }
        public static MatTranTypes DeleteMatTransType(int  seqID)
        {
            try
            {
                //using Repository<MatTranTypes> repo = new Repository<MatTranTypes>();
                //var mattransObj = repo.MatTranTypes.Where(m => m.SeqId == seqID).FirstOrDefault();
                //mattransObj.Active = "N";
                //repo.MatTranTypes.Update(mattransObj);
                //if (repo.SaveChanges() > 0)
                //    return mattransObj;

                return null;
            }
            catch { throw; }
        }
        public static List<string> GetTransTypesList()
        {
            try
            {
                return ((MaterialTransationType[])Enum.GetValues(typeof(MaterialTransationType))).Select(m=> m.ToString()).ToList(); 
            }
            catch { throw; }
        }
        #endregion


        #region Billing
        public static List<TblEmployee> GetEmployee(string branchCode)
        {
            try
            {
                return (from empbr in EmployeeHelper.GetEmployeeInBranches(null,branchCode)
                        join emp in EmployeeHelper.GetEmployes()
                        on empbr.EmpCode equals emp.EmployeeCode
                        where empbr.BranchCode == branchCode
                        select emp).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         
       
       
       
        public static List<Invoice> GetBillings(string branchCode)
        {
            try
            {
                //using Repository<Invoice> repo = new Repository<Invoice>();
                //return repo.Invoice.AsEnumerable().Where(b => b.Active == "Y" && b.BranchCode == branchCode).ToList();

                return null;
            }
            catch { throw; }
        }
     

        public static List<Glaccounts> GetGlaccounts()
        {
            try
            {
                //                using Repository<Glaccounts> repo = new Repository<Glaccounts>();
                //                return repo.Glaccounts
                //.Where(gl => gl.Active == "Y"
                //&& gl.Nactureofaccount == NATURESOFACCOUNTS.CASH.ToString())
                //.ToList();
                return null;
            }
            catch { throw; }
        }
        public static List<Glaccounts> GetAsignmentCashAccBranchList(string branchcode)
        {
            try
            {
                //cashAcctobranchAccounts = (from asiacc in _unitOfWork.AsignmentCashAccBranch.GetAll() select new { key = asiacc.CashGLAcc, value = asiacc.CashGLAcc }),
                //using Repository<Glaccounts> repo = new Repository<Glaccounts>();
                //return (from gl in repo.Glaccounts.AsEnumerable()
                //        join asigacc in repo.AsignmentCashAccBranch.AsEnumerable().Where(x => x.Active == "Y")
                //         on gl.Glcode equals asigacc.CashGlacc
                //        where asigacc.BranchCode == branchcode
                //        select gl).ToList();

                return null;
            }
            catch { throw; }
        }
        //public static List<BrandModel> GetModelList(string modelName)
        //{
        //    try {
        //        using (Repository<BrandModel> repo = new Repository<BrandModel>()) 
        //        {
        //           return repo.BrandModel.AsEnumerable()
        //                      .Where(bd => bd.Description.Contains(modelName)
        //                                && bd.Active == "Y"
        //                            )
        //                      .ToList();
        //        }
        //    } catch { throw; }
        //}
        //public static BrandModel GetModelDetails(string modelCode)
        //{
        //    try
        //    {
        //       return BrandModelHelpers.GetBrandModelList(modelCode);
        //    }
        //    catch { throw; }
        //}

        public static List<PartnerCreation> GetPartnerCreationList()
        {
            try
            {
                return PartnerCreationHelper.GetList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
