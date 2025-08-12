using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class OpeningBalanceHelper
    {
        public List<TblOpeningBalance> GetList()
        {
            try
            {
                using Repository<TblOpeningBalance> repo = new Repository<TblOpeningBalance>();
                return repo.TblOpeningBalance.ToList();
            }
            catch { throw; }
        }
        public List<TblBranch> GetBranchesList()
        {
            try
            {
                using Repository<TblBranch> repo = new Repository<TblBranch>();
                return repo.TblBranch.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<TblPaymentType> GetPaymentType()
        {
            try
            {
                using Repository<TblPaymentType> repo = new Repository<TblPaymentType>();
                return repo.TblPaymentType.ToList();
            }
            catch (Exception ex) { throw ex; }
        }
        public string GetVoucherNo(string branchCode, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                string suffix = string.Empty, prefix = string.Empty, billno = string.Empty;
                TblOpeningBalance _openingBalance = null;
                using (Repository<TblOpeningBalance> _repo = new Repository<TblOpeningBalance>())
                {
                    _openingBalance = _repo.TblOpeningBalance.Where(x => x.BranchCode == branchCode).OrderByDescending(x => x.OpeningBalanceDate).FirstOrDefault();

                    if (_openingBalance != null)
                    {
                        var invSplit = _openingBalance.VoucherNo.Split('-');
                        billno = $"{invSplit[0]}-{Convert.ToDecimal(invSplit[1]) + 1}-{invSplit[2]}";
                    }
                    else
                    {
                        //new Common.CommonHelper().GetSuffixPrefix(51, branchCode, out prefix, out suffix);
                        if (string.IsNullOrEmpty(prefix) || string.IsNullOrEmpty(suffix))
                        {
                            errorMessage = $"No prefix and suffix confugured for branch code: {branchCode} ";
                            return billno = string.Empty;
                        }

                        billno = $"{prefix}-1-{suffix}";
                    }
                }

                if (string.IsNullOrEmpty(billno))
                {
                    errorMessage = "BankPayment no not gererated please enter manully.";
                }

                return billno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TblOpeningBalance> GetOBList(string voucherNo)
        {
            try
            {
                using Repository<TblOpeningBalance> repo = new Repository<TblOpeningBalance>();
                return repo.TblOpeningBalance.Where(x => x.VoucherNo == voucherNo).ToList();

                //return null;
            }
            catch { throw; }
        }
        public static TblOpeningBalance Register(TblOpeningBalance openingBalance)
        {
            try
            {
                using Repository<TblOpeningBalance> repo = new Repository<TblOpeningBalance>();
                repo.TblOpeningBalance.Add(openingBalance);
                if (repo.SaveChanges() > 0)
                    return openingBalance;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
