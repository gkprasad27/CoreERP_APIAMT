using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.Common
{
    public class CommonHelper
    {
        public decimal? GetSuffixPrefix(decimal? voucherTypeid,string branchCode,out string preFix,out string suffix)
        {
            preFix = string.Empty;
            suffix = string.Empty;
            try
            {
                using Repository<TblSuffixPrefix> repo = new Repository<TblSuffixPrefix>();
                var _suffixPrefix = repo.TblSuffixPrefix
.Where(s => s.VoucherTypeId == voucherTypeid && s.BranchCode == branchCode)
.FirstOrDefault();

                preFix = _suffixPrefix?.Prefix;
                suffix = _suffixPrefix?.Suffix;

                return _suffixPrefix?.StartIndex;
            }
            catch(Exception )
            {
                return null;
            }
        }

        public string GenerateNumber(decimal? voucherTypeid, string branchCode)
        {
            try
            {
                string  prefix = string.Empty, sufix = string.Empty;
                var _number = GetSuffixPrefix(voucherTypeid, branchCode, out prefix, out sufix);

                if (string.IsNullOrEmpty(prefix))
                {
                    return null;
                }

                if (_number == null)
                {
                    _number = 1;
                }
                else
                {
                    _number += 1;// prefix + "-" + (_number + 1) + "-" + sufix;
                }

                UpdateInvoiceNumber(voucherTypeid, branchCode, _number);
                return $"{prefix}-{_number}-{sufix}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateInvoiceNumber(decimal? voucherTypeid, string branchCode,decimal? invoieNumber)
        {
            using Repository<TblSuffixPrefix> repo = new Repository<TblSuffixPrefix>();
            var _suffixPrefix = repo.TblSuffixPrefix.Where(s => s.VoucherTypeId == voucherTypeid && s.BranchCode == branchCode).FirstOrDefault();

            _suffixPrefix.StartIndex = invoieNumber;
            repo.TblSuffixPrefix.Update(_suffixPrefix);
            repo.SaveChanges();
        }
        //public static string GetConfigurationValue(string module,string screenName,string keyName)
        //{
        //    using(Repository<ErpConfiguration> context=new Repository<ErpConfiguration>())
        //    {
        //        return context.ErpConfiguration.AsEnumerable()
        //                      .Where(ep=> ep.Active.Equals("Y",StringComparison.OrdinalIgnoreCase)
        //                              &&  ep.Module.Equals(module)
        //                              &&  ep.Screen.Equals(screenName)
        //                              &&  ep.KeyName.Equals(keyName)
        //                      ).First().Values;
        //    }
        //}
        public static int? AutonGenerateNo(string branchCode, int rangeStart, int rangeEnds,out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                var counters = GetCounter(branchCode);
                if(counters == null)
                {
                    AddNewCounter(branchCode, rangeStart);
                    return rangeStart;
                }
                
                counters.NumberRange += 1;
                if(counters.NumberRange > rangeEnds)
                {
                    errorMessage = "Range Exceedded.";
                    return null;
                }
                UpdateCounter(counters);

                return counters.NumberRange;
            }
            catch { throw; }
        }


        private static Counters GetCounter(string branchCode)
        {
            try
            {
                using Repository<Counters> repo = new Repository<Counters>();
                return repo.Counters.AsEnumerable()
.Where(c => c.BranchCode == branchCode)
.FirstOrDefault();
            }
            catch { throw; }
        }
        private static int AddNewCounter(string branchCode,int rangestarts)
        {
            try
            {
                using Repository<Counters> repo = new Repository<Counters>();
                var cntObj = new Counters() { Active = "Y", BranchCode = branchCode, NumberRange = rangestarts };
                repo.Counters.Add(cntObj);
                return repo.SaveChanges();
            }
            catch { throw; }
        }
        private static int UpdateCounter(Counters counters)
        {
            try
            {
                using Repository<Counters> repo = new Repository<Counters>();
                repo.Counters.Update(counters);
                return repo.SaveChanges();
            }
            catch { throw; }
        }
        public static string IncreaseCode(string code)
        {
            try
            {
                string strnum = string.Empty;
                string prefix = string.Empty;
                for(int i= 0; i < code.Length; i++)
                {
                    if (char.IsDigit(code[i]))
                    {
                        if(string.IsNullOrEmpty(strnum) && code[i] == '0')
                         strnum += code[i];

                        strnum += code[i];
                    }
                    else if (char.IsLetter(code[i]) || code[i] == '0')
                        prefix += code[i];
                }
               
                return prefix + (Convert.ToInt64(strnum) + 1).ToString();
            }
            catch { throw; }
        }
    }
}
