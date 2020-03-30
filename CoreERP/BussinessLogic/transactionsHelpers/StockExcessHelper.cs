using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.transactionsHelpers
{
    public class StockExcessHelper
    {
        public List<TblBranch> GetBranchesList()
        {
            try
            {
                using Repository<TblBranch> repo = new Repository<TblBranch>();
                return repo.TblBranch.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<CostCenters> GetCostCentersList()
        {
            try
            {
                using Repository<CostCenters> repo = new Repository<CostCenters>();
                return repo.CostCenters.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public decimal? GetStockSuffixPrefix(decimal? voucherTypeid, string branchCode, out string preFix, out string suffix)
        {
            preFix = string.Empty;
            suffix = string.Empty;

            using Repository<TblSuffixPrefix> repo = new Repository<TblSuffixPrefix>();
            var _suffixPrefix = repo.TblSuffixPrefix
.Where(s => s.VoucherTypeId == voucherTypeid && s.BranchCode == branchCode)
.FirstOrDefault();

            preFix = _suffixPrefix?.Prefix;
            suffix = _suffixPrefix?.Suffix;

            return _suffixPrefix.StartIndex;
        }
        public string GenerateStockENumber(decimal? voucherTypeid, string branchCode)
        {
            try
            {
                string prefix = string.Empty, sufix = string.Empty;
                var _number = GetStockSuffixPrefix(voucherTypeid, branchCode, out prefix, out sufix);

                if (_number == null)
                {
                    _number = 1;
                }
                else
                {
                    _number += 1;// prefix + "/" + (_number + 1) + "-" + sufix;
                }

                UpdateStockENumber(voucherTypeid, branchCode, _number);
                return $"{prefix}/{_number}-{sufix}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateStockENumber(decimal? voucherTypeid, string branchCode, decimal? invoieNumber)
        {
            using Repository<TblSuffixPrefix> repo = new Repository<TblSuffixPrefix>();
            var _suffixPrefix = repo.TblSuffixPrefix.Where(s => s.VoucherTypeId == voucherTypeid && s.BranchCode == branchCode).FirstOrDefault();

            _suffixPrefix.StartIndex = invoieNumber;
            repo.TblSuffixPrefix.Update(_suffixPrefix);
            repo.SaveChanges();
        }

        public string GetVoucherNo(string branchCode)
        {
            try
            {
                var voucherNo = new StockExcessHelper().GenerateStockENumber(45, branchCode);
                return voucherNo;
            }
            catch { throw; }
        }
    }
}
