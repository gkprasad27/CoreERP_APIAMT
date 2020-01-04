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
        private static Repository<Glaccounts> _repo = null;
        private static Repository<Glaccounts> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<Glaccounts>();
                return _repo;
            }
        }


        public static List<Glaccounts> GetGLAccountsList()
        {
            try
            {
                return repo.Glaccounts.Select(gl => gl).ToList();
            }
            catch { throw; }
        }

        public static List<GlaccGroup> GetGLAccountGroupList()
        {
            try
            {
                return repo.GlaccGroup.Select(glacc => glacc).ToList();
            }
            catch { throw; }
        }


        public static List<MatTranTypes> GetMatTranTypesList()
        {
            try
            {

                return repo.MatTranTypes.Select(m => m).ToList();
            }
            catch (Exception ex) { throw ex; }
        }


        public static List<MaterialGroup> GetMaterialGroupsList()
        {
            try
            {
                return repo.MaterialGroup.Select(m => m).ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<AsignmentAcctoAccClass> GetAccountToAccountClassList()
        {
            try
            {
                return repo.AsignmentAcctoAccClass.Select(m => m).ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<TaxMasters> GetTaxMasterList()
        {
            try
            {
                return repo.TaxMasters.Select(m => m).ToList();
            }
            catch (Exception ex) { throw ex; }
        }
        public static List<TaxIntegration> GetTaxIntegrationList()
        {
            try
            {
                return repo.TaxIntegration.Select(m => m).ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<BrandModel> GetModelList()
        {
            try
            {
                return repo.BrandModel.Select(m => m).ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public static int RegisterAccountsGroup(GlaccGroup glAccGroup)
        {
            try
            {
                repo.GlaccGroup.Add(glAccGroup);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int UpdateAccountsGroup(GlaccGroup glAccGroup)
        {
            try
            {
                repo.GlaccGroup.Update(glAccGroup);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int DeleteAccountsGroup(string glAccGroupCode)
        {
            try
            {
                var glAccGroup = repo.GlaccGroup.Where(a => a.GroupCode == glAccGroupCode).FirstOrDefault();
                repo.GlaccGroup.Remove(glAccGroup);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static List<GlaccSubGroup> GetGLAccountSubGroupList()
        {
            try
            {
                return repo.GlaccSubGroup.Select(glaccsub => glaccsub).ToList();
            }
            catch { throw; }
        }
        public static int RegisterAccSubGroup(GlaccSubGroup glAccSubGroup)
        {
            try
            {
                repo.GlaccSubGroup.Add(glAccSubGroup);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int UpdateAccSubGroup(GlaccSubGroup glAccSubGroup)
        {
            try
            {
                repo.GlaccSubGroup.Update(glAccSubGroup);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int DeleteAccSubGroup(string glAccSubGroupCode)
        {
            try
            {
                var glAccountSubGroup = repo.GlaccSubGroup.Where(a => a.SubGroupCode == glAccSubGroupCode).FirstOrDefault();
                repo.GlaccSubGroup.Remove(glAccountSubGroup);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static List<GlaccUnderSubGroup> GetGLUnderSubGroupList()
        {
            try
            {
                return repo.GlaccUnderSubGroup.Select(glundersub => glundersub).ToList();
            }
            catch { throw; }
        }
        public static int RegisterUnderSubGroup(GlaccUnderSubGroup glUnderSubGroup)
        {
            try
            {
                repo.GlaccUnderSubGroup.Add(glUnderSubGroup);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int UpdateUnderSubGroup(GlaccUnderSubGroup glUnderSubGroup)
        {
            try
            {
                repo.GlaccUnderSubGroup.Update(glUnderSubGroup);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int DeleteUnderSubGroup(string glUnderSubGroupCode)
        {
            try
            {
                var glUnderSubGroup = repo.GlaccUnderSubGroup.Where(a => a.UnderSubGroupCode == glUnderSubGroupCode).FirstOrDefault();
                repo.GlaccUnderSubGroup.Remove(glUnderSubGroup);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int RegisterGLAccounts(Glaccounts glAccounts)
        {
            try
            {
                repo.Glaccounts.Add(glAccounts);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int UpdateGLAccounts(Glaccounts glAccounts)
        {
            try
            {
                repo.Glaccounts.Update(glAccounts);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int DeleteGLAccounts(string glAccountsCode)
        {
            try
            {
                var glAcc = repo.Glaccounts.Where(a => a.Glcode == glAccountsCode).FirstOrDefault();
                repo.Glaccounts.Remove(glAcc);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static List<GlsubCode> GetGLSubCodeList()
        {
            try
            {
                return repo.GlsubCode.Select(s => s).ToList();
            }
            catch { throw; }
        }
        public static int RegisterGLSubCode(GlsubCode glSubCode)
        {
            try
            {
                repo.GlsubCode.Add(glSubCode);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int UpdateGLSubCode(GlsubCode glSubCode)
        {
            try
            {
                repo.GlsubCode.Update(glSubCode);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int DeleteGLSubCode(string glSubCode)
        {
            try
            {
                var glsubCode = repo.GlsubCode.Where(a => a.Glcode == glSubCode).FirstOrDefault();
                repo.GlsubCode.Remove(glsubCode);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int RegisterTaxIntegration(TaxIntegration taxintegration)
        {
            try
            {
                repo.TaxIntegration.Add(taxintegration);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int UpdateTaxIntegration(TaxIntegration taxintegration)
        {
            try
            {
                repo.TaxIntegration.Update(taxintegration);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int DeleteTaxIntegration(string taxCode)
        {
            try
            {
                var taxInteCode = repo.TaxIntegration.Where(a => a.TaxCode == taxCode).FirstOrDefault();
                repo.TaxIntegration.Remove(taxInteCode);
                return repo.SaveChanges();
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

        public static int RegisterCashAccToBranches(AsignmentCashAccBranch assignCashToBranch)
        {
            try
            {
                repo.AsignmentCashAccBranch.Add(assignCashToBranch);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int UpdateCashAccToBranches(AsignmentCashAccBranch assignCashToBranch)
        {
            try
            {
                repo.AsignmentCashAccBranch.Update(assignCashToBranch);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int DeleteCashAccToBranches(string assignCashToBranchCode)
        {
            try
            {
                var asignCashToBranch = repo.AsignmentCashAccBranch.Where(a => a.Code == assignCashToBranchCode).FirstOrDefault();
                repo.AsignmentCashAccBranch.Remove(asignCashToBranch);
                return repo.SaveChanges();
            }
            catch { throw; }
        }


        public static List<TaxMasters> GetTaxMastersList()
        {
            try
            {
                using(Repository<TaxMasters> repo=new Repository<TaxMasters>())
                {
                    return repo.TaxMasters.Select(x => x).ToList();
                }
                 
            }
            catch { throw; }
        }
        public static List<AsignmentCashAccBranch> GetAsignCashAccBranch()
        {
            try
            {
                return repo.AsignmentCashAccBranch.Select(a => a).ToList();
            }
            catch { throw; }
        }

        public static List<AsignmentAcctoAccClass> GetAsignAccToAccClas()
        {
            try
            {
                return repo.AsignmentAcctoAccClass.Select(a => a).ToList();
            }
            catch { throw; }
        }

        public static int RegisterAccToAccClass(AsignmentAcctoAccClass assignAcctoAcc)
        {
            try
            {
                var record = ((from asiacc in GLHelper.GetAsignAccToAccClas() select asiacc.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();
                if (record != 0)
                {
                    assignAcctoAcc.Code = (record + 1).ToString();
                }
                else
                    assignAcctoAcc.Code = "1";

                repo.AsignmentAcctoAccClass.Add(assignAcctoAcc);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int UpdateAccToAccClass(AsignmentAcctoAccClass assignAcctoAcc)
        {
            try
            {
                repo.AsignmentAcctoAccClass.Update(assignAcctoAcc);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int DeleteAccToAccClass(string assignAcctoAccCode)
        {
            try
            {
                var asignAccToAccClass = repo.AsignmentAcctoAccClass.Where(a => a.Code == assignAcctoAccCode).FirstOrDefault();
                repo.AsignmentAcctoAccClass.Remove(asignAccToAccClass);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static List<AccountingClass> GetAccountingClass()
        {
            try
            {
                return repo.AccountingClass.Select(a => a).ToList();
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
                                       .Where(acc => acc.Nactureofaccount.Equals("PURCHASES", StringComparison.OrdinalIgnoreCase)
                                                || acc.Nactureofaccount.Equals("SALES", StringComparison.OrdinalIgnoreCase)
                                                || acc.Nactureofaccount.Equals("INVENTORY", StringComparison.OrdinalIgnoreCase))
                                       .ToList();

                }
            }
            catch { throw; }
        }

        public static List<VoucherClass> GetVoucherClassList()
        {
            try
            {
                return repo.VoucherClass.Select(vc => vc).ToList();
            }
            catch { throw; }
        }

        public static List<VoucherTypes> GetVoucherTypeList()
        {
            try
            {
                return repo.VoucherTypes.Select(v => v).ToList();
            }
            catch { throw; }
        }

        public static int RegisterVoucherType(VoucherTypes voucherTypes)
        {
            try
            {
                var lastrecord = repo.VoucherTypes.OrderByDescending(v => v.VoucherCode).FirstOrDefault();
                if(lastrecord!=null)
                {
                    voucherTypes.VoucherCode = (int.Parse(lastrecord.VoucherCode) + 1).ToString();
                }
                else
                    voucherTypes.VoucherCode = "01";

                repo.VoucherTypes.Add(voucherTypes);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int UpdateVoucherType(VoucherTypes voucherTypes)
        {
            try
            {
                repo.VoucherTypes.Update(voucherTypes);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

        public static int DeleteVoucherType(string voucherTypeCode)
        {
            try
            {
                var voucherType = repo.VoucherTypes.Where(v=>v.VoucherCode == voucherTypeCode).FirstOrDefault();
                repo.VoucherTypes.Remove(voucherType);
                return repo.SaveChanges();
            }
            catch { throw; }
        }
    }
}
