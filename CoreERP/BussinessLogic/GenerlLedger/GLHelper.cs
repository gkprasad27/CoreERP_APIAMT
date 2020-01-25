﻿using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class GLHelper
    {

        public static List<GlaccGroup> GetGLAccountGroupList(string accountGroupCode=null)
        {
            try
            {
                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    if (string.IsNullOrEmpty(accountGroupCode))
                        return repo.GlaccGroup.AsEnumerable().Where(glacc => glacc.Active == "Y").ToList();
                    else
                    {
                        return repo.GlaccGroup
                                   .AsEnumerable()
                                  .Where(glacc => glacc.Active == "Y"
                                              &&  glacc.GroupCode == accountGroupCode
                                        )
                                  .ToList();
                    }
                }
            }
            catch { throw; }
        }
        public static List<MatTranTypes> GetMatTranTypesList()
        {
            try
            {
                using (Repository<MatTranTypes> repo = new Repository<MatTranTypes>())
                {
                    return repo.MatTranTypes.AsEnumerable().Where(m => m.Active == "Y").ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public static List<MaterialGroup> GetMaterialGroupsList()
        {
            try
            {
                using (Repository<MaterialGroup> repo = new Repository<MaterialGroup>())
                {
                    return repo.MaterialGroup.AsEnumerable().Where(m => m.Active == "Y").ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public static List<AsignmentAcctoAccClass> GetAccountToAccountClassList()
        {
            try
            {
                using (Repository<AsignmentAcctoAccClass> repo = new Repository<AsignmentAcctoAccClass>())
                {
                    return repo.AsignmentAcctoAccClass.AsEnumerable().Where(m => m.Active == "Y").ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public static List<TaxMasters> GetTaxMasterList()
        {
            try
            {
                using (Repository<TaxMasters> repo = new Repository<TaxMasters>())
                {
                    return repo.TaxMasters.AsEnumerable().Where(m => m.Active == "Y").ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<BrandModel> GetModelList()
        {
            try
            {
                using (Repository<BrandModel> repo = new Repository<BrandModel>())
                {
                    return repo.BrandModel.AsEnumerable().Where(m => m.Active == "Y").ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static GlaccGroup RegisterAccountsGroup(GlaccGroup glAccGroup)
        {
            try
            {
                using (Repository<GlaccGroup> repo = new Repository<GlaccGroup>())
                {
                    glAccGroup.Active = "Y";
                    repo.GlaccGroup.Add(glAccGroup);
                    if (repo.SaveChanges() > 0)
                        return glAccGroup;

                    return null;
                }
            }
            catch { throw; }
        }
        public static GlaccGroup UpdateAccountsGroup(GlaccGroup glAccGroup)
        {
            try
            {
                using (Repository<GlaccGroup> repo = new Repository<GlaccGroup>())
                {
                    repo.GlaccGroup.Update(glAccGroup);
                    if (repo.SaveChanges() > 0)
                        return glAccGroup;

                    return null;
                }
            }
            catch { throw; }
        }
        public static GlaccGroup DeleteAccountsGroup(string glAccGroupCode)
        {
            try
            {
                using (Repository<GlaccGroup> repo = new Repository<GlaccGroup>())
                {
                    var glAccGroup = repo.GlaccGroup.Where(a => a.GroupCode == glAccGroupCode).FirstOrDefault();
                    glAccGroup.Active = "N";
                    repo.GlaccGroup.Update(glAccGroup);
                    if (repo.SaveChanges() > 0)
                        return glAccGroup;

                    return null;
                }
            }
            catch { throw; }
        }

        #region GLAccount SubGroup
        public static List<GlaccSubGroup> GetGLAccountSubGroup(string accGroupCode = null)
        {
            try
            {
                using (Repository<GlaccSubGroup> repo = new Repository<GlaccSubGroup>())
                {
                    if (string.IsNullOrEmpty(accGroupCode))
                    {
                        return repo.GlaccSubGroup.AsEnumerable()
                                   .Where(glaccsub => glaccsub.Active == "Y")
                                   .ToList();
                    }
                    else
                    {
                        return repo.GlaccSubGroup.AsEnumerable()
                               .Where(glaccsub => glaccsub.Active == "Y"
                                               && glaccsub.AccGroup == accGroupCode
                               )
                               .ToList();
                    }
                }
            }
            catch { throw; }
        }
        public static List<GlaccSubGroup> GetGLAccountSubGroupList()
        {
            try
            {
                using (Repository<GlaccSubGroup> repo = new Repository<GlaccSubGroup>())
                {
                   
                        return repo.GlaccSubGroup.AsEnumerable()
                               .Where(glaccsub => glaccsub.Active == "Y")
                               .ToList();
                }
            }
            catch { throw; }
        }

        public static List<GlaccSubGroup> GetGLAccountSubGroupList(string subGroupCode)
        {
            try
            {
                using (Repository<GlaccSubGroup> repo = new Repository<GlaccSubGroup>())
                {
                    return repo.GlaccSubGroup.AsEnumerable().Where(glaccsub => glaccsub.SubGroupCode == subGroupCode).ToList();
                }
            }
            catch { throw; }
        }
        public static GlaccSubGroup RegisterAccSubGroup(GlaccSubGroup glAccSubGroup)
        {
            try
            {
                using (Repository<GlaccSubGroup> repo = new Repository<GlaccSubGroup>())
                {
                    glAccSubGroup.Active = "Y";
                    repo.GlaccSubGroup.Add(glAccSubGroup);
                    if (repo.SaveChanges() > 0)
                        return glAccSubGroup;

                    return null;
                }
            }
            catch { throw; }
        }
        public static GlaccSubGroup UpdateAccSubGroup(GlaccSubGroup glAccSubGroup)
        {
            try
            {
                using (Repository<GlaccSubGroup> repo = new Repository<GlaccSubGroup>())
                {
                    repo.GlaccSubGroup.Update(glAccSubGroup);
                    if (repo.SaveChanges() > 0)
                        return glAccSubGroup;

                    return null;
                }
            }
            catch { throw; }
        }
        public static GlaccSubGroup DeleteAccSubGroup(string glAccSubGroupCode)
        {
            try
            {
                using (Repository<GlaccSubGroup> repo = new Repository<GlaccSubGroup>())
                {
                    var glAccountSubGroup = repo.GlaccSubGroup.Where(a => a.SubGroupCode == glAccSubGroupCode).FirstOrDefault();
                    glAccountSubGroup.Active = "N";
                    repo.GlaccSubGroup.Update(glAccountSubGroup);
                    if (repo.SaveChanges() > 0)
                        return glAccountSubGroup;

                    return null;
                }
            }
            catch { throw; }
        }
        #endregion

        #region GL Under SubGroup
        public static List<GlaccUnderSubGroup> GetGLUnderSubGroupList()
        {
            try
            {
                using (Repository<GlaccUnderSubGroup> repo = new Repository<GlaccUnderSubGroup>())
                {
                    return repo.GlaccUnderSubGroup.AsEnumerable().Where(glundersub => glundersub.Active == "Y").ToList();
                }
            }
            catch { throw; }
        }
        public static List<GlaccUnderSubGroup> GetGLUnderSubGroupList(string underSubGroupCode)
        {
            try
            {
                using (Repository<GlaccUnderSubGroup> repo = new Repository<GlaccUnderSubGroup>())
                {
                    return repo.GlaccUnderSubGroup.AsEnumerable().Where(glundersub => glundersub.UnderSubGroupCode == underSubGroupCode).ToList();
                }
            }
            catch { throw; }
        }
        public static GlaccUnderSubGroup RegisterUnderSubGroup(GlaccUnderSubGroup glUnderSubGroup)
        {
            try
            {
                using (Repository<GlaccUnderSubGroup> repo = new Repository<GlaccUnderSubGroup>())
                {
                    glUnderSubGroup.Active = "Y";
                    repo.GlaccUnderSubGroup.Add(glUnderSubGroup);
                    if (repo.SaveChanges() > 0)
                        return glUnderSubGroup;

                    return null;
                }
            }
            catch { throw; }
        }
        public static GlaccUnderSubGroup UpdateUnderSubGroup(GlaccUnderSubGroup glUnderSubGroup)
        {
            try
            {
                using (Repository<GlaccUnderSubGroup> repo = new Repository<GlaccUnderSubGroup>())
                {
                    repo.GlaccUnderSubGroup.Update(glUnderSubGroup);
                    if (repo.SaveChanges() > 0)
                        return glUnderSubGroup;

                    return null;
                }
            }
            catch { throw; }
        }
        public static GlaccUnderSubGroup DeleteUnderSubGroup(string glUnderSubGroupCode)
        {
            try
            {
                using (Repository<GlaccUnderSubGroup> repo = new Repository<GlaccUnderSubGroup>())
                {
                    var glUnderSubGroup = repo.GlaccUnderSubGroup.Where(a => a.UnderSubGroupCode == glUnderSubGroupCode).FirstOrDefault();
                    glUnderSubGroup.Active = "N";
                    repo.GlaccUnderSubGroup.Update(glUnderSubGroup);
                    if (repo.SaveChanges() > 0)
                        return glUnderSubGroup;

                    return null;
                }
            }
            catch { throw; }
        }
        #endregion

        #region  GLAccounts
        public static List<string> GetAccountsTypes()
        {
            try
            {
                return Enum.GetNames(typeof(NATURESOFACCOUNTS)).ToList();
            }
            catch { throw; }
        }
        public static List<string> GetStatementTypes()
        {
            try
            {
                // string name = Enum.GetName(typeof(STATMENTTYPE));
                return Enum.GetNames(typeof(STATMENTTYPE)).ToList();
            }
            catch { throw; }
        }
        public static List<string> GetBalanceTypes()
        {
            try
            {
                List<string> balanceTypes = new List<string>()
                {
                    NATURESOFACCOUNTS .DR.ToString(),
                    NATURESOFACCOUNTS .CR.ToString()
                };
                return balanceTypes;
            }
            catch { throw; }
        }
        public static List<Glaccounts> GetGLAccountsList()
        {
            try
            {
                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    return repo.Glaccounts.AsEnumerable().Where(gl => gl.Active == "Y").ToList();
                }
            }
            catch { throw; }
        }
        public static List<Glaccounts> GetGLAccountsList(string glCode)
        {
            try
            {
                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    return repo.Glaccounts.AsEnumerable().Where(gl => gl.Glcode == glCode).ToList();
                }
            }
            catch { throw; }
        }
        public static List<Glaccounts> GetGLAccountsList(NATURESOFACCOUNTS natureOfAccounts)
        {
            try
            {
                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    return repo.Glaccounts.AsEnumerable()
                               .Where(gl => gl.Nactureofaccount == natureOfAccounts.ToString() 
                                         && gl.Active =="Y")
                               .ToList();
                }
            }
            catch { throw; }
        }
      
        public static Glaccounts RegisterGLAccounts(Glaccounts glAccounts)
        {
            try
            {
                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    glAccounts.Active = "Y";
                    repo.Glaccounts.Add(glAccounts);
                    if (repo.SaveChanges() > 0)
                        return glAccounts;
                  
                    return null;
                }
            }
            catch { throw; }
        }
        public static Glaccounts UpdateGLAccounts(Glaccounts glAccounts)
        {
            try
            {
                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    repo.Glaccounts.Update(glAccounts);
                    if (repo.SaveChanges() > 0)
                        return glAccounts;

                    return null;
                }
            }
            catch { throw; }
        }
        public static Glaccounts DeleteGLAccounts(string glAccountsCode)
        {
            try
            {
                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    var glAcc = repo.Glaccounts.Where(a => a.Glcode == glAccountsCode).FirstOrDefault();
                    glAcc.Active = "N";
                    repo.Glaccounts.Update(glAcc);
                    if (repo.SaveChanges() > 0)
                        return glAcc;

                    return null;
                }
            }
            catch { throw; }
        }

        #endregion

        #region  GL sub Code
        public static List<GlsubCode> GetGLSubCodeList()
        {
            try
            {
                using (Repository<GlsubCode> repo = new Repository<GlsubCode>())
                {
                    return repo.GlsubCode.AsEnumerable().Where(s => s.Active == "Y").ToList();
                }
            }
            catch { throw; }
        }
        public static List<GlsubCode> GetGLSubCodeList(string subCode)
        {
            try
            {
                using (Repository<GlsubCode> repo = new Repository<GlsubCode>())
                {
                    return repo.GlsubCode.AsEnumerable().Where(s => s.SubCode == subCode).ToList();
                }
            }
            catch { throw; }
        }
        public static GlsubCode RegisterGLSubCode(GlsubCode glSubCode)
        {
            try
            {
                using (Repository<GlsubCode> repo = new Repository<GlsubCode>())
                {
                    glSubCode.Active = "Y";
                    repo.GlsubCode.Add(glSubCode);
                    if (repo.SaveChanges() > 0)
                        return glSubCode;

                    return null;
                }
            }
            catch { throw; }
        }
        public static GlsubCode UpdateGLSubCode(GlsubCode glSubCode)
        {
            try
            {
                using (Repository<GlsubCode> repo = new Repository<GlsubCode>())
                {
                    repo.GlsubCode.Update(glSubCode);
                    if (repo.SaveChanges() > 0)
                        return glSubCode;

                    return null;
                }
            }
            catch { throw; }
        }
        public static GlsubCode DeleteGLSubCode(string glSubCode)
        {
            try
            {
                using (Repository<GlsubCode> repo = new Repository<GlsubCode>())
                {
                    var glsubCode = repo.GlsubCode.Where(a => a.SubCode == glSubCode).FirstOrDefault();
                    glsubCode.Active = "N";
                    repo.GlsubCode.Update(glsubCode);
                    if (repo.SaveChanges() > 0)
                        return glsubCode;

                    return null;
                }
            }
            catch { throw; }
        }

        #endregion

        #region TaxIntegration
        public static List<TaxIntegration> GetTaxIntegrationList()
        {
            try
            {
                using (Repository<TaxIntegration> repo = new Repository<TaxIntegration>())
                {
                    return repo.TaxIntegration.AsEnumerable().Where(m => m.Active == "Y").ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public static List<TaxIntegration> GetTaxIntegrationList(string taxCode)
        {
            try
            {
                using (Repository<TaxIntegration> repo = new Repository<TaxIntegration>())
                {
                    return repo.TaxIntegration.AsEnumerable().Where(m => m.TaxCode == taxCode).ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public static TaxIntegration RegisterTaxIntegration(TaxIntegration taxintegration)
        {
            try
            {
                using (Repository<TaxIntegration> repo = new Repository<TaxIntegration>())
                {
                    taxintegration.Active = "Y";
                    repo.TaxIntegration.Add(taxintegration);
                    if (repo.SaveChanges() > 0)
                        return taxintegration;

                    return null;
                }
            }
            catch { throw; }
        }
        public static TaxIntegration UpdateTaxIntegration(TaxIntegration taxintegration)
        {
            try
            {
                using (Repository<TaxIntegration> repo = new Repository<TaxIntegration>())
                {
                    repo.TaxIntegration.Update(taxintegration);
                    if (repo.SaveChanges() > 0)
                        return taxintegration;

                    return null;
                }
            }
            catch { throw; }
        }
        public static TaxIntegration DeleteTaxIntegration(string taxCode)
        {
            try
            {
                using (Repository<TaxIntegration> repo = new Repository<TaxIntegration>())
                {
                    var taxInteCode = repo.TaxIntegration.Where(a => a.TaxCode == taxCode).FirstOrDefault();
                    taxInteCode.Active = "N";
                    repo.TaxIntegration.Update(taxInteCode);
                    if (repo.SaveChanges() > 0)
                        return taxInteCode;

                    return null;
                }
            }
            catch { throw; }
        }
        #endregion
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
        public static List<Glaccounts> GetTaxAccounts()
        {
            try
            {
                //taxaccounts = (from taxacc in (from glacc in _unitOfWork.GLAccounts.GetAll()
                //                               where glacc.Nactureofaccount != null
                //                               select glacc)
                //               where taxacc.Nactureofaccount.ToLower() == "tax"
                //               select taxacc)
                return (from taxacc in GLHelper.GetGLAccountsList().Where(x=> x.Nactureofaccount != null)
                        where taxacc.Nactureofaccount.Equals("tax",StringComparison.OrdinalIgnoreCase)
                        select taxacc).ToList();
            }

            catch { throw; }
        }

        public static AsignmentCashAccBranch RegisterCashAccToBranches(AsignmentCashAccBranch assignCashToBranch)
        {
            try
            {
                using (Repository<AsignmentCashAccBranch> repo = new Repository<AsignmentCashAccBranch>())
                {
                    assignCashToBranch.Active = "Y";
                    repo.AsignmentCashAccBranch.Add(assignCashToBranch);
                    if (repo.SaveChanges() > 0)
                        return assignCashToBranch;

                    return null;
                }
            }
            catch { throw; }
        }
        public static AsignmentCashAccBranch UpdateCashAccToBranches(AsignmentCashAccBranch assignCashToBranch)
        {
            try
            {
                using (Repository<AsignmentCashAccBranch> repo = new Repository<AsignmentCashAccBranch>())
                {
                    repo.AsignmentCashAccBranch.Update(assignCashToBranch);
                    if (repo.SaveChanges() > 0)
                        return assignCashToBranch;

                    return null;
                }
            }
            catch { throw; }
        }
        public static AsignmentCashAccBranch DeleteCashAccToBranches(string assignCashToBranchCode)
        {
            try
            {
                using (Repository<AsignmentCashAccBranch> repo = new Repository<AsignmentCashAccBranch>())
                {
                    var asignCashToBranch = repo.AsignmentCashAccBranch.Where(a => a.Code == assignCashToBranchCode).FirstOrDefault();
                    asignCashToBranch.Active = "N";
                    repo.AsignmentCashAccBranch.Update(asignCashToBranch);
                    if (repo.SaveChanges() > 0)
                        return asignCashToBranch;

                    return null;
                }
            }
            catch { throw; }
        }


        public static List<TaxMasters> GetTaxMastersList()
        {
            try
            {
                using(Repository<TaxMasters> repo=new Repository<TaxMasters>())
                {
                    return repo.TaxMasters.AsEnumerable().Where(x => x.Active =="Y").ToList();
                }
                 
            }
            catch { throw; }
        }
        public static List<AsignmentCashAccBranch> GetAsignCashAccBranch()
        {
            try
            {
                using (Repository<AsignmentAcctoAccClass> repo = new Repository<AsignmentAcctoAccClass>())
                {
                    return repo.AsignmentCashAccBranch.AsEnumerable().Where(a => a.Active=="Y").ToList();
                }
            }
            catch { throw; }
        }

        #region Asignment Acc to Acc Class
        public static List<AsignmentAcctoAccClass> GetAsignAccToAccClas()
        {
            try
            {
                using (Repository<AsignmentAcctoAccClass> repo = new Repository<AsignmentAcctoAccClass>())
                {
                    return repo.AsignmentAcctoAccClass.AsEnumerable().Where(a => a.Active =="Y").ToList();
                }
            }
            catch { throw; }
        }
        public static AsignmentAcctoAccClass RegisterAccToAccClass(AsignmentAcctoAccClass assignAcctoAcc)
        {
            try
            {
                using (Repository<AsignmentAcctoAccClass> repo = new Repository<AsignmentAcctoAccClass>())
                {
                    var record = ((from asiacc in GLHelper.GetAsignAccToAccClas() select asiacc.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();
                    if (record != 0)
                    {
                        assignAcctoAcc.Code = (record + 1).ToString();
                    }
                    else
                        assignAcctoAcc.Code = "1";

                    assignAcctoAcc.Active = "Y";
                    repo.AsignmentAcctoAccClass.Add(assignAcctoAcc);
                    if (repo.SaveChanges() > 0)
                        return assignAcctoAcc;

                    return null;
                }
            }
            catch { throw; }
        }
        public static AsignmentAcctoAccClass UpdateAccToAccClass(AsignmentAcctoAccClass assignAcctoAcc)
        {
            try
            {
                using (Repository<AsignmentAcctoAccClass> repo = new Repository<AsignmentAcctoAccClass>())
                {
                    repo.AsignmentAcctoAccClass.Update(assignAcctoAcc);
                    if (repo.SaveChanges() > 0)
                        return assignAcctoAcc;

                    return null;
                }
            }
            catch { throw; }
        }
        public static AsignmentAcctoAccClass DeleteAccToAccClass(string assignAcctoAccCode)
        {
            try
            {
                using (Repository<AsignmentAcctoAccClass> repo = new Repository<AsignmentAcctoAccClass>())
                {
                    var asignAccToAccClass = repo.AsignmentAcctoAccClass.Where(a => a.Code == assignAcctoAccCode).FirstOrDefault();
                    asignAccToAccClass.Active = "N";
                    repo.AsignmentAcctoAccClass.Update(asignAccToAccClass);
                    if (repo.SaveChanges() > 0)
                        return asignAccToAccClass;

                    return null;
                }
            }
            catch { throw; }
        }

        #endregion
        public static List<AccountingClass> GetAccountingClass()
        {
            try
            {
                using (Repository<AccountingClass> repo = new Repository<AccountingClass>())
                {
                    return repo.AccountingClass.AsEnumerable().Where(a => a.Active =="Y").ToList();
                }
            }
            catch { throw; }
        }
        public static List<Glaccounts> GetInvPurchaseSalesGLAcc()
        {
            try
            {
                //        glaccoutns=(from glacc  in   (from gacc in _unitOfWork.GLAccounts.GetAll() where gacc.Nactureofaccount !=null select gacc)
                //                    where glacc.Nactureofaccount == NatureOfAccounts.PURCHASES.ToString() ||
                //                          glacc.Nactureofaccount == NatureOfAccounts.SALES.ToString()  || 
                //                          glacc.Nactureofaccount == NatureOfAccounts.INVENTORY.ToString()
                //                    select glacc),

                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    return repo.Glaccounts.Where(gacc => gacc.Nactureofaccount != null)
                                       .Where(acc => acc.Nactureofaccount == NATURESOFACCOUNTS.PURCHASES.ToString()
                                                || acc.Nactureofaccount == NATURESOFACCOUNTS.SALES.ToString()
                                                || acc.Nactureofaccount == NATURESOFACCOUNTS.INVENTORY.ToString())
                                       .ToList();

                }
            }
            catch { throw; }
        }
        public static List<VoucherClass> GetVoucherClassList()
        {
            try
            {
                using (Repository<VoucherClass> repo = new Repository<VoucherClass>())
                {
                    return repo.VoucherClass.AsEnumerable().Where(vc => vc.Active=="Y").ToList();
                }
            }
            catch { throw; }
        }

        #region Voucher Type
        public static List<VoucherTypes> GetVoucherTypeList()
        {
            try
            {
                using (Repository<VoucherTypes> repo = new Repository<VoucherTypes>())
                {
                    return repo.VoucherTypes.AsEnumerable().Where(v => v.Active=="Y").ToList();
                }
            }
            catch { throw; }
        }
        public static List<VoucherTypes> GetVoucherTypeList(string voucherCode)
        {
            try
            {
                using (Repository<VoucherTypes> repo = new Repository<VoucherTypes>())
                {
                    return repo.VoucherTypes.AsEnumerable().Where(v => v.VoucherCode == voucherCode).ToList();
                }
            }
            catch { throw; }
        }
        public static VoucherTypes RegisterVoucherType(VoucherTypes voucherTypes)
        {
            try
            {
                using (Repository<VoucherTypes> repo = new Repository<VoucherTypes>())
                {
                    var lastrecord = repo.VoucherTypes.OrderByDescending(v => v.VoucherCode).FirstOrDefault();
                    if (lastrecord != null)
                    {
                        voucherTypes.VoucherCode = (int.Parse(lastrecord.VoucherCode) + 1).ToString();
                    }
                    else
                        voucherTypes.VoucherCode = "1";

                    voucherTypes.Active = "Y";
                    repo.VoucherTypes.Add(voucherTypes);
                    if (repo.SaveChanges() > 0)
                        return voucherTypes;

                    return null;
                }
            }
            catch { throw; }
        }
        public static VoucherTypes UpdateVoucherType(VoucherTypes voucherTypes)
        {
            try
            {
                using (Repository<VoucherTypes> repo = new Repository<VoucherTypes>())
                {
                    repo.VoucherTypes.Update(voucherTypes);
                    if (repo.SaveChanges() > 0)
                        return voucherTypes;

                    return null;
                }
            }
            catch { throw; }
        }
        public static VoucherTypes DeleteVoucherType(string voucherTypeCode)
        {
            try
            {
                using (Repository<VoucherTypes> repo = new Repository<VoucherTypes>())
                {
                    var voucherType = repo.VoucherTypes.Where(v => v.VoucherCode == voucherTypeCode).FirstOrDefault();
                    voucherType.Active = "N";
                    repo.VoucherTypes.Remove(voucherType);
                    if (repo.SaveChanges() > 0)
                        return voucherType;

                    return null;
                }
            }
            catch { throw; }
        }
        #endregion
    }
}
