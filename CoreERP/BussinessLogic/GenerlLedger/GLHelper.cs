using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class GLHelper
    {

        public static List<GlaccGroup> GetGLAccountGroupList(string accountGroupCode = null)
        {
            try
            {
                using Repository<Glaccounts> repo = new Repository<Glaccounts>();
                if (string.IsNullOrEmpty(accountGroupCode))
                    return repo.GlaccGroup.AsEnumerable().Where(glacc => glacc.Active == "Y").ToList();
                else
                {
                    return repo.GlaccGroup
                               .AsEnumerable()
                              .Where(glacc => glacc.Active == "Y"
                                          && glacc.GroupCode == accountGroupCode
                                    )
                              .ToList();
                }
            }
            catch { throw; }
        }
        public static List<MatTranTypes> GetMatTranTypesList()
        {
            try
            {
                using Repository<MatTranTypes> repo = new Repository<MatTranTypes>();
                return repo.MatTranTypes.AsEnumerable().Where(m => m.Active == "Y").ToList();
            }
            catch (Exception ex) { throw ex; }
        }
        public static List<MaterialGroup> GetMaterialGroupsList()
        {
            try
            {
                using Repository<MaterialGroup> repo = new Repository<MaterialGroup>();
                return null;//repo.MaterialGroup.AsEnumerable().Where(m => m.Active == "Y").ToList();
            }
            catch (Exception ex) { throw ex; }
        }
        public static List<AsignmentAcctoAccClass> GetAccountToAccountClassList()
        {
            try
            {
                using Repository<AsignmentAcctoAccClass> repo = new Repository<AsignmentAcctoAccClass>();
                return null; ;// repo.AsignmentAcctoAccClass.AsEnumerable().Where(m => m.Active == "Y").ToList();
            }
            catch (Exception ex) { throw ex; }
        }
        public static List<TaxMasters> GetTaxMasterList()
        {
            try
            {
                using Repository<TaxMasters> repo = new Repository<TaxMasters>();
                return null;// repo.TaxMasters.AsEnumerable().Where(m => m.Active == "Y").ToList();
            }
            catch (Exception ex) { throw ex; }
        }
        //public static List<BrandModel> GetModelList()
        //{
        //    try
        //    {
        //        using (Repository<BrandModel> repo = new Repository<BrandModel>())
        //        {
        //            return repo.BrandModel.AsEnumerable().Where(m => m.Active == "Y").ToList();
        //        }
        //    }
        //    catch (Exception ex) { throw ex; }
        //}

        #region Account Group
        public static GlaccGroup RegisterAccountsGroup(GlaccGroup glAccGroup)
        {
            try
            {
                using Repository<GlaccGroup> repo = new Repository<GlaccGroup>();
                glAccGroup.Active = "Y";
                //  glAccGroup.AddDate = DateTime.Now;
                repo.GlaccGroup.Add(glAccGroup);
                if (repo.SaveChanges() > 0)
                    return glAccGroup;

                return null;
            }
            catch { throw; }
        }
        public static GlaccGroup UpdateAccountsGroup(GlaccGroup glAccGroup)
        {
            try
            {
                using Repository<GlaccGroup> repo = new Repository<GlaccGroup>();
                repo.GlaccGroup.Update(glAccGroup);
                if (repo.SaveChanges() > 0)
                    return glAccGroup;

                return null;
            }
            catch { throw; }
        }
        public static GlaccGroup DeleteAccountsGroup(string glAccGroupCode)
        {
            try
            {
                using Repository<GlaccGroup> repo = new Repository<GlaccGroup>();
                var glAccGroup = repo.GlaccGroup.Where(a => a.GroupCode == glAccGroupCode).FirstOrDefault();
                glAccGroup.Active = "N";
                repo.GlaccGroup.Update(glAccGroup);
                if (repo.SaveChanges() > 0)
                    return glAccGroup;

                return null;
            }
            catch { throw; }
        }

        #endregion

        #region GLAccount SubGroup
        public static List<GlaccSubGroup> GetGLAccountSubGroup(string accGroupCode = null)
        {
            try
            {
                //using Repository<GlaccSubGroup> repo = new Repository<GlaccSubGroup>();
                //if (string.IsNullOrEmpty(accGroupCode))
                //{
                //    //return repo.GlaccSubGroup.AsEnumerable()
                //    //           .Where(glaccsub => glaccsub.Active == "Y")
                //    //           .ToList();
                //}
                //else
                //{
                //    return repo.GlaccSubGroup.AsEnumerable()
                //           .Where(glaccsub => glaccsub.Active == "Y"
                //                           && glaccsub.AccGroup == accGroupCode
                //           )
                //           .ToList();
                //}

                return null;
            }
            catch { throw; }
        }
        public static List<GlaccSubGroup> GetGLAccountSubGroupList()
        {
            try
            {
                //using Repository<GlaccSubGroup> repo = new Repository<GlaccSubGroup>();
                //return repo.GlaccSubGroup.AsEnumerable()
                //       .Where(glaccsub => glaccsub.Active == "Y")
                //       .ToList();

                return null;
            }
            catch { throw; }
        }
        public static List<GlaccSubGroup> GetGLAccountSubGroupList(string subGroupCode)
        {
            try
            {
                using Repository<GlaccSubGroup> repo = new Repository<GlaccSubGroup>();
                return null;// repo.GlaccSubGroup.AsEnumerable().Where(glaccsub => glaccsub.SubGroupCode == subGroupCode).ToList();
            }
            catch { throw; }
        }
        public static GlaccSubGroup RegisterAccSubGroup(GlaccSubGroup glAccSubGroup)
        {
            try
            {
                //using Repository<GlaccSubGroup> repo = new Repository<GlaccSubGroup>();
                //glAccSubGroup.Active = "Y";
                //glAccSubGroup.AddDate = DateTime.Now;
                //repo.GlaccSubGroup.Add(glAccSubGroup);
                //if (repo.SaveChanges() > 0)
                //    return glAccSubGroup;

                return null;
            }
            catch { throw; }
        }
        public static GlaccSubGroup UpdateAccSubGroup(GlaccSubGroup glAccSubGroup)
        {
            try
            {
                //using Repository<GlaccSubGroup> repo = new Repository<GlaccSubGroup>();
                //repo.GlaccSubGroup.Update(glAccSubGroup);
                //if (repo.SaveChanges() > 0)
                //    return glAccSubGroup;

                return null;
            }
            catch { throw; }
        }
        public static GlaccSubGroup DeleteAccSubGroup(string glAccSubGroupCode)
        {
            try
            {
                //using Repository<GlaccSubGroup> repo = new Repository<GlaccSubGroup>();
                //var glAccountSubGroup = repo.GlaccSubGroup.Where(a => a.SubGroupCode == glAccSubGroupCode).FirstOrDefault();
                //glAccountSubGroup.Active = "N";
                //repo.GlaccSubGroup.Update(glAccountSubGroup);
                //if (repo.SaveChanges() > 0)
                //    return glAccountSubGroup;

                return null;
            }
            catch { throw; }
        }
        #endregion

        #region Tbl Account Group
        public static List<GlaccUnderSubGroup> GetGLUnderSubGroupList()
        {
            try
            {
                //using Repository<GlaccUnderSubGroup> repo = new Repository<GlaccUnderSubGroup>();
                //return repo.GlaccUnderSubGroup.AsEnumerable().Where(glundersub => glundersub.Active == "Y").ToList();
                return null;
            }
            catch { throw; }
        }

        public List<TblAccountGroup> GetTblAccountGroupList()
        {
            try
            {
                using Repository<TblAccountGroup> repo = new Repository<TblAccountGroup>();
                return repo.TblAccountGroup.AsEnumerable().ToList();
            }
            catch { throw; }
        }
        public static List<GlaccUnderSubGroup> GetGLUnderSubGroupList(string underSubGroupCode)
        {
            try
            {
                return null;
                //using Repository<GlaccUnderSubGroup> repo = new Repository<GlaccUnderSubGroup>();
                //return repo.GlaccUnderSubGroup.AsEnumerable().Where(glundersub => glundersub.UnderSubGroupCode == underSubGroupCode).ToList();
            }
            catch { throw; }
        }

        public static GlaccUnderSubGroup RegisterUnderSubGroup(GlaccUnderSubGroup glUnderSubGroup)
        {
            try
            {
                //using Repository<GlaccUnderSubGroup> repo = new Repository<GlaccUnderSubGroup>();
                //glUnderSubGroup.Active = "Y";
                //glUnderSubGroup.AddDate = DateTime.Now;
                //repo.GlaccUnderSubGroup.Add(glUnderSubGroup);
                //if (repo.SaveChanges() > 0)
                //    return glUnderSubGroup;

                return null;
            }
            catch { throw; }
        }

        public TblAccountGroup RegisterTblAccGroup(TblAccountGroup tblAccGroup)
        {
            try
            {
                using Repository<TblAccountGroup> repo = new Repository<TblAccountGroup>();
                var record = repo.TblAccountGroup.OrderByDescending(x => x.ExtraDate).FirstOrDefault();

                if (record != null)
                {
                    tblAccGroup.AccountGroupId = Convert.ToDecimal(CommonHelper.IncreaseCode(record.AccountGroupId.ToString()));
                }
                else
                    tblAccGroup.AccountGroupId = 1;

                tblAccGroup.ExtraDate = DateTime.Now;
                tblAccGroup.IsDefault = false;
                repo.TblAccountGroup.Add(tblAccGroup);
                if (repo.SaveChanges() > 0)
                    return tblAccGroup;

                return null;
            }
            catch { throw; }
        }

        public TblAccountGroup UpdateTblAccountGroup(TblAccountGroup tblAccGrp)
        {
            try
            {
                using Repository<TblAccountGroup> repo = new Repository<TblAccountGroup>();
                tblAccGrp.ExtraDate = DateTime.Now;
                tblAccGrp.IsDefault = false;
                repo.TblAccountGroup.Update(tblAccGrp);
                if (repo.SaveChanges() > 0)
                    return tblAccGrp;

                return null;
            }
            catch { throw; }
        }
        public static GlaccUnderSubGroup UpdateUnderSubGroup(GlaccUnderSubGroup glUnderSubGroup)
        {
            try
            {
                //using Repository<GlaccUnderSubGroup> repo = new Repository<GlaccUnderSubGroup>();
                //repo.GlaccUnderSubGroup.Update(glUnderSubGroup);
                //if (repo.SaveChanges() > 0)
                //    return glUnderSubGroup;

                return null;
            }
            catch { throw; }
        }
        public static GlaccUnderSubGroup DeleteUnderSubGroup(string glUnderSubGroupCode)
        {
            try
            {
                //using Repository<GlaccUnderSubGroup> repo = new Repository<GlaccUnderSubGroup>();
                //var glUnderSubGroup = repo.GlaccUnderSubGroup.Where(a => a.UnderSubGroupCode == glUnderSubGroupCode).FirstOrDefault();
                //glUnderSubGroup.Active = "N";
                //repo.GlaccUnderSubGroup.Update(glUnderSubGroup);
                //if (repo.SaveChanges() > 0)
                //    return glUnderSubGroup;

                return null;
            }
            catch { throw; }
        }

        public TblAccountGroup DeleteTblAccountGroup(int code)
        {
            try
            {
                using Repository<TblAccountGroup> repo = new Repository<TblAccountGroup>();
                var tblAccGrp = repo.TblAccountGroup.Where(x => x.AccountGroupId == code).FirstOrDefault();
                repo.TblAccountGroup.Remove(tblAccGrp);
                if (repo.SaveChanges() > 0)
                    return tblAccGrp;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                using Repository<Glaccounts> repo = new Repository<Glaccounts>();
                return repo.Glaccounts.AsEnumerable().Where(gl => gl.Active == "Y").ToList();

                //return null;
            }
            catch { throw; }
        }
        public static List<Glaccounts> GetGLAccountsList(string glCode)
        {
            try
            {
                //using Repository<Glaccounts> repo = new Repository<Glaccounts>();
                //return repo.Glaccounts.AsEnumerable().Where(gl => gl.Glcode == glCode).ToList();
                return null;
            }
            catch { throw; }
        }
        public static List<Glaccounts> GetGLAccountsList(NATURESOFACCOUNTS natureOfAccounts)
        {
            try
            {
                using Repository<Glaccounts> repo = new Repository<Glaccounts>();
                return repo.Glaccounts.Where(gl => gl.Nactureofaccount == natureOfAccounts.ToString()
                && gl.Active == "Y").ToList();

                //return null;
            }
            catch { throw; }
        }
        public static Glaccounts RegisterGLAccounts(Glaccounts glAccounts)
        {
            try
            {
                //using Repository<Glaccounts> repo = new Repository<Glaccounts>();
                //glAccounts.Active = "Y";
                //glAccounts.AddDate = DateTime.Now;
                //repo.Glaccounts.Add(glAccounts);
                //if (repo.SaveChanges() > 0)
                //    return glAccounts;

                return null;
            }
            catch { throw; }
        }
        public static Glaccounts UpdateGLAccounts(Glaccounts glAccounts)
        {
            try
            {
                //using Repository<Glaccounts> repo = new Repository<Glaccounts>();
                //repo.Glaccounts.Update(glAccounts);
                //if (repo.SaveChanges() > 0)
                //    return glAccounts;

                return null;
            }
            catch { throw; }
        }
        public static Glaccounts DeleteGLAccounts(string glAccountsCode)
        {
            try
            {
                //using Repository<Glaccounts> repo = new Repository<Glaccounts>();
                //var glAcc = repo.Glaccounts.Where(a => a.Glcode == glAccountsCode).FirstOrDefault();
                //glAcc.Active = "N";
                //repo.Glaccounts.Update(glAcc);
                //if (repo.SaveChanges() > 0)
                //    return glAcc;

                return null;
            }
            catch { throw; }
        }

        #endregion

        #region  GL sub Code
        public static List<GlsubCode> GetGLSubCodeList()
        {
            try
            {
                //using Repository<GlsubCode> repo = new Repository<GlsubCode>();
                //return repo.GlsubCode.AsEnumerable().Where(s => s.Active == "Y").ToList();
                return null;
            }
            catch { throw; }
        }
        public static List<GlsubCode> GetGLSubCodeList(string subCode)
        {
            try
            {
                //using Repository<GlsubCode> repo = new Repository<GlsubCode>();
                //return repo.GlsubCode.AsEnumerable().Where(s => s.SubCode == subCode).ToList();
                return null;
            }
            catch { throw; }
        }
        public static GlsubCode RegisterGLSubCode(GlsubCode glSubCode)
        {
            try
            {
                //using Repository<GlsubCode> repo = new Repository<GlsubCode>();
                //glSubCode.Active = "Y";
                //glSubCode.AddDate = DateTime.Now;
                //repo.GlsubCode.Add(glSubCode);
                //if (repo.SaveChanges() > 0)
                //    return glSubCode;

                return null;
            }
            catch { throw; }
        }
        public static GlsubCode UpdateGLSubCode(GlsubCode glSubCode)
        {
            try
            {
                //using Repository<GlsubCode> repo = new Repository<GlsubCode>();
                //repo.GlsubCode.Update(glSubCode);
                //if (repo.SaveChanges() > 0)
                //    return glSubCode;

                return null;
            }
            catch { throw; }
        }
        public static GlsubCode DeleteGLSubCode(string glSubCode)
        {
            try
            {
                //using Repository<GlsubCode> repo = new Repository<GlsubCode>();
                //var glsubCode = repo.GlsubCode.Where(a => a.SubCode == glSubCode).FirstOrDefault();
                //glsubCode.Active = "N";
                //repo.GlsubCode.Update(glsubCode);
                //if (repo.SaveChanges() > 0)
                //    return glsubCode;

                return null;
            }
            catch { throw; }
        }

        #endregion

        #region TblTaxtypes
        public static List<TblTaxtypes> GetTblTaxtypesList()
        {
            try
            {
                using Repository<TblTaxtypes> repo = new Repository<TblTaxtypes>();
                return repo.TblTaxtypes.ToList();
            }
            catch (Exception ex) { throw ex; }
        }
        public static List<TblTaxtypes> GetTblTaxtypesList(string taxCode)
        {
            try
            {
                using Repository<TblTaxtypes> repo = new Repository<TblTaxtypes>();
                return repo.TblTaxtypes.AsEnumerable().Where(m => m.TaxKey == taxCode).ToList();
            }
            catch (Exception ex) { throw ex; }
        }
        public static TblTaxtypes RegisterTblTaxtypes(TblTaxtypes taxtypes)
        {
            try
            {
                using Repository<TblTaxtypes> repo = new Repository<TblTaxtypes>();
                repo.TblTaxtypes.Add(taxtypes);
                if (repo.SaveChanges() > 0)
                    return taxtypes;
                
                return null;
            }
            catch { throw; }
        }
        public static TblTaxtypes UpdateTblTaxtypes(TblTaxtypes taxtypes)
        {
            try
            {
                using Repository<TblTaxtypes> repo = new Repository<TblTaxtypes>();
                repo.TblTaxtypes.Update(taxtypes);
                if (repo.SaveChanges() > 0)
                    return taxtypes;

                return null;
            }
            catch { throw; }
        }
        public static TblTaxtypes DeleteTblTaxtypes(string taxCode)
        {
            try
            {
                using Repository<TblTaxtypes> repo = new Repository<TblTaxtypes>();
                var taxInteCode = repo.TblTaxtypes.Where(a => a.TaxKey == taxCode).FirstOrDefault();
                repo.TblTaxtypes.Remove(taxInteCode);
                if (repo.SaveChanges() > 0)
                    return taxInteCode;

                return null;
            }
            catch { throw; }
        }
        #endregion
        public static List<TblCompany> GetCompanies()
        {
            try { return masterHlepers.CompaniesHelper.GetListOfCompanies(); }
            catch { throw; }
        }
        public static List<TblBranch> GetBranches()
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
                return (from taxacc in GLHelper.GetGLAccountsList().Where(x => x.Nactureofaccount != null)
                        where taxacc.Nactureofaccount.Equals(NATURESOFACCOUNTS.TAX.ToString(), StringComparison.OrdinalIgnoreCase)
                        select taxacc).ToList();
            }

            catch { throw; }
        }

        #region Cash Account to branches
        public static AsignmentCashAccBranch RegisterCashAccToBranches(AsignmentCashAccBranch assignCashToBranch)
        {
            try
            {
                using Repository<AsignmentCashAccBranch> repo = new Repository<AsignmentCashAccBranch>();
                assignCashToBranch.Active = "Y";
                assignCashToBranch.AddDate = DateTime.Now;
                repo.AsignmentCashAccBranch.Add(assignCashToBranch);
                if (repo.SaveChanges() > 0)
                    return assignCashToBranch;

                return null;
            }
            catch { throw; }
        }
        public static AsignmentCashAccBranch UpdateCashAccToBranches(AsignmentCashAccBranch assignCashToBranch)
        {
            try
            {
                using Repository<AsignmentCashAccBranch> repo = new Repository<AsignmentCashAccBranch>();
                assignCashToBranch.AddDate = DateTime.Now;
                assignCashToBranch.Active = "Y";
                repo.AsignmentCashAccBranch.Update(assignCashToBranch);
                if (repo.SaveChanges() > 0)
                    return assignCashToBranch;

                return null;
            }
            catch { throw; }
        }
        public static AsignmentCashAccBranch DeleteCashAccToBranches(string assignCashToBranchCode)
        {
            try
            {
                using Repository<AsignmentCashAccBranch> repo = new Repository<AsignmentCashAccBranch>();
                var asignCashToBranch = repo.AsignmentCashAccBranch.Where(a => a.Code == assignCashToBranchCode).FirstOrDefault();
                asignCashToBranch.Active = "N";
                repo.AsignmentCashAccBranch.Update(asignCashToBranch);
                if (repo.SaveChanges() > 0)
                    return asignCashToBranch;

                return null;
            }
            catch { throw; }
        }

        #endregion
        public static List<TaxMasters> GetTaxMastersList()
        {
            try
            {
                using Repository<TaxMasters> repo = new Repository<TaxMasters>();
                return repo.TaxMasters.AsEnumerable().Where(x => x.Active == "Y").ToList();

                //return null;

            }
            catch { throw; }
        }
        public static List<AsignmentCashAccBranch> GetAsignCashAccBranch()
        {
            try
            {
                using Repository<AsignmentAcctoAccClass> repo = new Repository<AsignmentAcctoAccClass>();
                //return null;// 
                return repo.AsignmentCashAccBranch.AsEnumerable().Where(a => a.Active == "Y").ToList();
            }
            catch { throw; }
        }

        #region openledger
        public static List<TblOpenLedger> GetList()
        {
            try
            {
                using Repository<TblOpenLedger> repo = new Repository<TblOpenLedger>();
                return repo.TblOpenLedger.ToList();
            }
            catch { throw; }
        }
        public static List<TblOpenLedger> GetList(string code)
        {
            try
            {
                using Repository<TblOpenLedger> repo = new Repository<TblOpenLedger>();
                return repo.TblOpenLedger.Where(x=>x.LedgerKey==code).ToList();
            }
            catch { throw; }
        }
        public static TblOpenLedger Register(TblOpenLedger openledger)
        {
            try
            {
                using Repository<TblOpenLedger> repo = new Repository<TblOpenLedger>();
                repo.TblOpenLedger.Add(openledger);
                if (repo.SaveChanges() > 0)
                    return openledger;

                return null;
            }
            catch { throw; }
        }
        public static TblOpenLedger Update(TblOpenLedger openLedger)
        {
            try
            {
                using Repository<TblOpenLedger> repo = new Repository<TblOpenLedger>();
                repo.TblOpenLedger.Update(openLedger);
                if (repo.SaveChanges() > 0)
                    return openLedger;

                return null;
            }
            catch { throw; }
        }
        public static TblOpenLedger DeleteOpenLedger(string Code)
        {
            try
            {
                using Repository<TblOpenLedger> repo = new Repository<TblOpenLedger>();
                var code = repo.TblOpenLedger.Where(a =>a.LedgerKey == Code).FirstOrDefault();
                repo.TblOpenLedger.Remove(code);
                if (repo.SaveChanges() > 0)
                    return code;

                return null;
            }
            catch { throw; }
        }

        #endregion
        public static List<AccountingClass> GetAccountingClass()
        {
            try
            {
                using Repository<AccountingClass> repo = new Repository<AccountingClass>();
                return repo.AccountingClass.AsEnumerable().Where(a => a.Active == "Y").ToList();
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
                return null;
            }
            catch { throw; }
        }
        //public static List<VoucherClass> GetVoucherClassList()
        //{
        //    try
        //    {
        //        using (Repository<VoucherClass> repo = new Repository<VoucherClass>())
        //        {
        //            return repo.VoucherClass.AsEnumerable().Where(vc => vc.Active=="Y").ToList();
        //        }
        //    }
        //    catch { throw; }
        //}

        #region Voucher Type
        public static List<VoucherTypes> GetVoucherTypeList()
        {
            try
            {
                // using Repository<VoucherTypes> repo = new Repository<VoucherTypes>();
                //return repo.VoucherTypes.AsEnumerable().Where(v => v.Active == "Y").ToList();
                return null;
            }
            catch { throw; }
        }
        public static List<VoucherTypes> GetVoucherTypeList(string voucherCode)
        {
            try
            {
                //using Repository<VoucherTypes> repo = new Repository<VoucherTypes>();
                //return repo.VoucherTypes.AsEnumerable().Where(v => v.VoucherCode == voucherCode).ToList();
                return null;
            }
            catch { throw; }
        }
        public static VoucherTypes RegisterVoucherType(VoucherTypes voucherTypes)
        {
            try
            {
                using Repository<VoucherTypes> repo = new Repository<VoucherTypes>();
                voucherTypes.Active = "Y";
                voucherTypes.AddDate = DateTime.Now;
                //repo.VoucherTypes.Add(voucherTypes);
                if (repo.SaveChanges() > 0)
                    return voucherTypes;

                return null;
            }
            catch { throw; }
        }
        public static VoucherTypes UpdateVoucherType(VoucherTypes voucherTypes)
        {
            try
            {
                using Repository<VoucherTypes> repo = new Repository<VoucherTypes>();
                //repo.VoucherTypes.Update(voucherTypes);
                if (repo.SaveChanges() > 0)
                    return voucherTypes;

                return null;
            }
            catch { throw; }
        }
        public static VoucherTypes DeleteVoucherType(string voucherTypeCode)
        {
            try
            {
                using Repository<VoucherTypes> repo = new Repository<VoucherTypes>();
                //var voucherType = repo.VoucherTypes.Where(v => v.VoucherCode == voucherTypeCode).FirstOrDefault();
                //voucherType.Active = "N";
                //repo.VoucherTypes.Remove(voucherType);
                //if (repo.SaveChanges() > 0)
                //    return voucherType;

                return null;
            }
            catch { throw; }
        }
        #endregion

        #region Account Ledger

        public List<TblAccountLedger> GetTblAccountLedgerList()
        {
            try
            {
                using Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>();
                return repo.TblAccountLedger.AsEnumerable().ToList();
            }
            catch { throw; }
        }

        public List<TblPaymentType> GetTblPaymentTypeList()
        {
            try
            {
                using Repository<TblPaymentType> repo = new Repository<TblPaymentType>();
                return repo.TblPaymentType.AsEnumerable().ToList();
            }
            catch { throw; }
        }

        public List<TblAccountType> GetTblAccountTypeList()
        {
            try
            {
                using Repository<TblAccountType> repo = new Repository<TblAccountType>();
                return repo.TblAccountType.AsEnumerable().ToList();
            }
            catch { throw; }
        }

        public List<TblPricingLevel> GetTblPricingLevelList()
        {
            try
            {
                using Repository<TblPricingLevel> repo = new Repository<TblPricingLevel>();
                return repo.TblPricingLevel.AsEnumerable().ToList();
            }
            catch { throw; }
        }

        public TblAccountLedger RegisterTblAccLedger(TblAccountLedger tblAccLedger)
        {
            try
            {
                using Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>();
                var record = repo.TblAccountLedger.OrderByDescending(x => x.LedgerId).FirstOrDefault();
                var _accountTypeName = GetTblAccountTypeList().Where(x => x.TypeId == tblAccLedger.AccountTypeId).FirstOrDefault();

                if (record != null)
                {
                    tblAccLedger.LedgerId = Convert.ToDecimal(CommonHelper.IncreaseCode(record.LedgerId.ToString()));
                }
                else
                    tblAccLedger.LedgerId = 1;

                tblAccLedger.IsDefault = false;
                tblAccLedger.AccountTypeName = _accountTypeName.TypeName;
                repo.TblAccountLedger.Add(tblAccLedger);
                if (repo.SaveChanges() > 0)
                    return tblAccLedger;

                return null;
            }
            catch { throw; }
        }

        public TblAccountLedger UpdateTblAccountLedger(TblAccountLedger tblAccLedger)
        {
            try
            {
                using Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>();
                var _accountTypeName = GetTblAccountTypeList().Where(x => x.TypeId == tblAccLedger.AccountTypeId).FirstOrDefault();
                tblAccLedger.IsDefault = false;
                tblAccLedger.AccountTypeName = _accountTypeName.TypeName;
                repo.TblAccountLedger.Update(tblAccLedger);
                if (repo.SaveChanges() > 0)
                    return tblAccLedger;

                return null;
            }
            catch { throw; }
        }

        public TblAccountLedger DeleteTblAccountLedger(int code)
        {
            try
            {
                using Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>();
                var tblAccLedger = repo.TblAccountLedger.Where(x => x.LedgerId == code).FirstOrDefault();
                repo.TblAccountLedger.Remove(tblAccLedger);
                if (repo.SaveChanges() > 0)
                    return tblAccLedger;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
