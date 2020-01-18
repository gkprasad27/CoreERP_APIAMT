﻿using CoreERP.BussinessLogic.Common;
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
        #region Billing Returns
        public static List<Billing> GetBilling(string billNo)
        {
            try
            {
                using (Repository<Billing> repo = new Repository<Billing>())
                {
                    return repo.Billing.Where(x => x.BillNo == billNo).ToList();
                }
            }
            catch { throw; }
        }

        public static bool IsBillExistsInBillReturns(string billNo)
        {
            try
            {
                using(Repository<BillingReturns> repo=new Repository<BillingReturns>())
                {
                    var result=repo.BillingReturns.Where(x => x.BillNo == billNo).ToList();

                    return (result.Count() > 0);
                }
            }
            catch { throw; }
        }
        public static List<BillingReturns> RegisterBillingReturns(BillingReturns[] billingReturns)
        {
            try
            {
                using (Repository<BillingReturns> repo = new Repository<BillingReturns>())
                {
                    /* var lastreacord = _unitOfWork.Billing.GetAll().OrderByDescending(x => x.Code).FirstOrDefault();
                if (lastreacord != null)
                    billing[0].Code = (int.Parse(lastreacord.Code) + 1).ToString();
                else
                    billing[0].Code = "1";

                for (int i = 1; i < billing.Count(); i++)
                    billing[i].Code = (int.Parse(billing[i - 1].Code) + 1).ToString();

                _unitOfWork.Billing.AddRange(billing);*/
                    repo.BillingReturns.AddRange(billingReturns);
                    if (repo.SaveChanges() > 0)
                        return billingReturns.ToList();

                    return null;
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
                using (Repository<CardType> repo = new Repository<CardType>())
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

        public static List<Glaccounts> GetGlAccountsDRCR(string natureofAccount)
        {
            try
            {
                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    return repo.Glaccounts
                          .Where(x => x.Active.Equals("Y")
                                  && (x.Nactureofaccount.Equals(natureofAccount))
                                )
                          .ToList();
                }
            }
            catch { throw; }
        }

        public static List<string> GetTypesList()
        {
            try
            {
                return new List<string>() { NatureOfAccounts.DR.ToString(), NatureOfAccounts.DR.ToString() };
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
                using (Repository<CardType> repo = new Repository<CardType>())
                {
                    repo.CardType.Update(cardType);
                    if (repo.SaveChanges() > 0)
                        return cardType;

                    return null;
                }
            }
            catch { throw; }
        }

        public static CardType DeleteCardType(string code)
        {
            try
            {
                using (Repository<CardType> repo = new Repository<CardType>())
                {

                    var cardtype = BillingHelpers.GetCardTypeList(code);
                    cardtype.Active = "N";
                    repo.CardType.Update(cardtype);
                    if (repo.SaveChanges() > 0)
                        return cardtype;

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
                using (Repository<Finance> repo = new Repository<Finance>())
                {
                    return repo.Finance.Where(x => x.Active.Equals("Y")).ToList();
                }
            }
            catch { throw; }
        }

        public static Finance GetFinances(string code)
        {
            try
            {
                using (Repository<Finance> repo = new Repository<Finance>())
                {
                    return repo.Finance.Where(x => x.Active.Equals("Y") && x.Code == code).FirstOrDefault();
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

                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    return repo.Glaccounts
                          .AsEnumerable()
                          .Where(f => f.Active =="Y"
                                   && f.Nactureofaccount   == NatureOfAccounts.FINANCECUSTOMER.ToString()
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
        public static Finance RegisterFiances(Finance finance)
        {
            try
            {
                using (Repository<Finance> repo = new Repository<Finance>())
                {
                    finance.AddDate = DateTime.Now;
                    finance.EditDate = DateTime.Now;
                    finance.Active = "Y";

                    var lastreacord = repo.Finance.OrderByDescending(x => Convert.ToInt32(x.Code ?? "0")).FirstOrDefault();
                    if (lastreacord != null)
                        finance.Code = (int.Parse(lastreacord.Code) + 1).ToString();
                    else
                        finance.Code = "1";

                    repo.Finance.Add(finance);
                    if (repo.SaveChanges() > 0)
                        return finance;

                    return null;
                }
            }
            catch { throw; }
        }

        public static Finance UpdateFinance(Finance finance)
        {
            try
            {
                using (Repository<Finance> repo = new Repository<Finance>())
                {
                    finance.EditDate = DateTime.Now;
                    repo.Finance.Update(finance);
                    if (repo.SaveChanges() > 0)
                        return finance;

                    return null;
                }
            }
            catch { throw; }
        }
        public static Finance DeleteFinance(string code)
        {
            try
            {
                var financeEntity = GetFinances(code);
                financeEntity.Active = "N";
                using (Repository<Finance> repo = new Repository<Finance>())
                {
                    financeEntity.EditDate = DateTime.Now;
                    repo.Finance.Update(financeEntity);
                    if (repo.SaveChanges() > 0)
                        return financeEntity;

                    return null;
                }
            }
            catch { throw; }
        }
        #endregion

        #region Cutomer Receipt
        public static List<CustomerReceipts> GetCustomerReceiptList()
        {
            try
            {
                using (Repository<CustomerReceipts> repo = new Repository<CustomerReceipts>())
                {
                    return repo.CustomerReceipts.AsEnumerable()
                         .Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase))
                         .ToList();
                }
            }
            catch { throw; }
        }

        public static CustomerReceipts GetCustomerReceiptList(int seqID)
        {
            try
            {
                using (Repository<CustomerReceipts> repo = new Repository<CustomerReceipts>())
                {
                    return repo.CustomerReceipts.AsEnumerable()
                         .Where(c => c.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)
                                  && c.SeqId == seqID
                         )
                         .FirstOrDefault();
                }
            }
            catch { throw; }
        }

        public static List<AsignmentCashAccBranch> GetAsigCashAccBranches()
        {
            try
            {
                using (Repository<AsignmentCashAccBranch> repo = new Repository<AsignmentCashAccBranch>())
                {
                    return repo.AsignmentCashAccBranch.Select(x => x).ToList();
                }
            }
            catch { throw; }
        }

        public static CustomerReceipts RegisterCustomerReceipt(CustomerReceipts customerReceipt)
        {
            try
            {
                using(Repository<CustomerReceipts> repo=new Repository<CustomerReceipts>())
                {
                    customerReceipt.AddDate = DateTime.Now;
                    customerReceipt.EditDate = DateTime.Now;

                    repo.CustomerReceipts.Add(customerReceipt);
                    if (repo.SaveChanges() > 0)
                        return customerReceipt;

                    return null;
                }
            }
            catch { throw; }
        }
        public static CustomerReceipts UpdateCustomerReceipt(CustomerReceipts customerReceipt)
        {
            try
            {
                using (Repository<CustomerReceipts> repo = new Repository<CustomerReceipts>())
                {
                    customerReceipt.EditDate = DateTime.Now;
                    repo.CustomerReceipts.Update(customerReceipt);
                    if (repo.SaveChanges() > 0)
                        return customerReceipt;

                    return null;
                }
            }
            catch { throw; }
        }
        public static CustomerReceipts DeleteCustomerReceipt(int seqID)
        {
            try
            {
                using (Repository<CustomerReceipts> repo = new Repository<CustomerReceipts>())
                {
                    var custobj = GetCustomerReceiptList(seqID);
                    custobj.Active = "N";
                    repo.CustomerReceipts.Update(custobj);
                    if (repo.SaveChanges() > 0)
                        return custobj;

                    return null;
                }
            }
            catch { throw; }
        }
        public static List<VoucherTypes> GetVoucherTypesList()
        {
            try
            {
                using (Repository<VoucherTypes> repo = new Repository<VoucherTypes>())
                {
                    return repo.VoucherTypes.Where(x => x.Active.Equals("Y")).ToList();
                }
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
                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    accNosList = ((from asig in repo.AsignmentCashAccBranch.ToList()
                                   where asig.BankGlacc != null
                                   select asig.BankGlacc).Union(from aasigcc in repo.AsignmentCashAccBranch.ToList()
                                                                where aasigcc.CashGlacc != null
                                                                select aasigcc.CashGlacc)).ToList();
                }
                using (Repository<Glaccounts> repo=new Repository<Glaccounts>())
                {
                    return (from glacc in repo.Glaccounts.ToList()
                            where accNosList.Contains(glacc.Glcode)
                            select glacc).ToList();
                }
            }
            catch { throw; }

        }


        #region Material Transaction Types
        public static List<MatTranTypes> GetMatTranTypesList()
        {
            try
            {
                using(Repository<MatTranTypes> repo=new Repository<MatTranTypes>())
                {
                  return  repo.MatTranTypes.AsEnumerable()
                              .Where(m => m.Active.Equals("Y", StringComparison.OrdinalIgnoreCase))
                              .ToList();
                }
            }
            catch { throw; }
        }

        public static MatTranTypes GetMatTranTypes(string code)
        {
            try
            {
                using (Repository<MatTranTypes> repo = new Repository<MatTranTypes>())
                {
                    return repo.MatTranTypes.AsEnumerable()
                                .Where(m => m.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)
                                        && m.Code == code
                                )
                                .FirstOrDefault();
                }
            }
            catch { throw; }
        }

        public static List<Branches> GetBranchesList()
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
                using (Repository<MatTranTypes> repo = new Repository<MatTranTypes>())
                {
                    //var lastreacord = repo.MatTranTypes.OrderByDescending(x => x.SeqId).FirstOrDefault();
                    //if (lastreacord != null)
                    //{
                    //    matTranTypes.Code = (int.Parse(lastreacord.Code) + 1).ToString();
                    //}
                    //else
                    //{
                    //    matTranTypes.Code = "1";
                    //}

                    repo.MatTranTypes.Add(matTranTypes);
                    if (repo.SaveChanges() > 0)
                        return matTranTypes;

                    return null;
                }
            }
            catch { throw; }
        }

        public static MatTranTypes UpdateMatTransType(MatTranTypes matTranTypes)
        {
            try
            {
                using (Repository<MatTranTypes> repo = new Repository<MatTranTypes>())
                {
                    repo.MatTranTypes.Update(matTranTypes);
                    if (repo.SaveChanges() > 0)
                        return matTranTypes;

                    return null;
                }
            }
            catch { throw; }
        }

        public static MatTranTypes DeleteMatTransType(int  seqID)
        {
            try
            {
                using (Repository<MatTranTypes> repo = new Repository<MatTranTypes>())
                {
                    var mattransObj = repo.MatTranTypes.Where(m => m.SeqId == seqID).FirstOrDefault();
                    mattransObj.Active = "N";
                    repo.MatTranTypes.Update(mattransObj);
                    if (repo.SaveChanges() > 0)
                        return mattransObj;

                    return null;
                }
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
        public static List<Employees> GetEmployee(string branchCode)
        {
            try
            {
                return (from empbr in EmployeeHelper.GetEmployeeInBranches(null,branchCode)
                        join emp in EmployeeHelper.GetEmployes()
                        on empbr.EmpCode equals emp.Code
                        where empbr.BranchCode == branchCode
                        select emp).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int? GenerateBillNo(string branchCode,out string errorMessage)
        {
            try
            {

                var billingNoSeries = BillingNoSeriesHelper.GetBillingNoSeriesList().Where(b => b.BranchCode == branchCode).OrderByDescending(x=>x.Year).FirstOrDefault();
                if (billingNoSeries != null)
                {
                    var noRange = billingNoSeries.NumberSeries.Split('-');
                    int starRange = 0, maxRange = 0;
                    if (noRange.Length == 1)
                    {
                        starRange = Convert.ToInt32(noRange[0]);
                        maxRange = Convert.ToInt32(noRange[0]);
                    }
                    else
                    {
                        starRange = Convert.ToInt32(noRange[0]);
                        maxRange = Convert.ToInt32(noRange[1]);
                    }

                    return CommonHelper.AutonGenerateNo(null, branchCode, starRange, maxRange, out errorMessage);
                }
                else
                {
                    errorMessage = "No number series is present for billing.";
                    return null;
                }
            }
            catch { throw; }
        }
        public static List<Billing> GetBillings(string branchCode)
        {
            try
            {
                using(Repository<Billing> repo=new Repository<Billing>())
                {
                   return repo.Billing.AsEnumerable().Where(b => b.Active == "Y"  && b.BranchCode== branchCode).ToList();
                }
            }
            catch { throw; }
        }
        public static List<Billing> RegisterBilling(Billing[] billings)
        {
            try
            {
                using(Repository<Billing> repo=new Repository<Billing>())
                {
                    for(int i=0;i< billings.Length;i++)
                    {
                        billings[i].AddDate = DateTime.Now;
                        billings[i].Active = "Y";
                    }
                    repo.Billing.AddRange(billings);
                    if (repo.SaveChanges() > 0)
                        return billings.ToList();

                    return new List<Billing>();
                }
            }
            catch { throw; }
        }

        public static List<Glaccounts> GetGlaccounts()
        {
            try
            {
                using(Repository<Glaccounts> repo=new Repository<Glaccounts>())
                {
                    return repo.Glaccounts.AsEnumerable().Where(gl => gl.Active == "Y").ToList();
                }
            }
            catch { throw; }
        }
        public static List<Glaccounts> GetAsignmentCashAccBranchList(string branchcode)
        {
            try
            {
                //cashAcctobranchAccounts = (from asiacc in _unitOfWork.AsignmentCashAccBranch.GetAll() select new { key = asiacc.CashGLAcc, value = asiacc.CashGLAcc }),
                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    return (from gl in repo.Glaccounts.AsEnumerable()
                            join asigacc in repo.AsignmentCashAccBranch.AsEnumerable().Where(x => x.Active == "Y")
                             on gl.Glcode equals asigacc.CashGlacc
                            where asigacc.BranchCode == branchcode
                            select gl).ToList();
                }
            }
            catch { throw; }
        }
        public static List<BrandModel> GetModelList(string modelName)
        {
            try {
                using (Repository<BrandModel> repo = new Repository<BrandModel>()) 
                {
                   return repo.BrandModel.AsEnumerable()
                              .Where(bd => bd.Description.Contains(modelName)
                                        && bd.Active == "Y"
                                    )
                              .ToList();
                }
            } catch { throw; }
        }

        #endregion
    }
}
