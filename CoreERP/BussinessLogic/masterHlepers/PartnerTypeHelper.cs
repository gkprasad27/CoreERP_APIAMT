using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class PartnerTypeHelper
    {
     
        public static List<PartnerType> GetPartnerTypeList()
        {
            try
            {
                using (Repository<PartnerType> repo = new Repository<PartnerType>())
                {
                    return repo.PartnerType.AsEnumerable().Where(p => p.Active.Equals("Y",StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }



        public static PartnerType RegistePartnerType(PartnerType partnerType)
        {
            try
            {
                using (Repository<PartnerType> repo = new Repository<PartnerType>())
                {
                    partnerType.Active = "Y";
                    repo.PartnerType.Add(partnerType);
                    if (repo.SaveChanges() > 0)
                        return partnerType;

                    return null;
                }
            }
            catch { throw; }
        }



        public static PartnerType UpdatePartnerType(PartnerType partnerType)
        {
            try
            {
                using (Repository<PartnerType> repo = new Repository<PartnerType>())
                {
                    repo.PartnerType.Update(partnerType);
                    if (repo.SaveChanges() > 0)
                        return partnerType;

                    return null;
                }
            }
            catch { throw; }
        }
        public static PartnerType DeletePartnerType(string partnerTypeCode)
        {
            try
            {
                using (Repository<PartnerType> repo = new Repository<PartnerType>())
                {
                    var prttyp = repo.PartnerType.Where(p => p.Code == partnerTypeCode).FirstOrDefault();
                    prttyp.Active = "N";
                    repo.PartnerType.Update(prttyp);
                    if (repo.SaveChanges() > 0)
                        return prttyp;

                    return null;
                }
            }
            catch { throw; }
        }

        public static List<object> GetAccountTypesList()
        {
            try
            {
                List<object> accountTypeList=new List<object>();
                accountTypeList.Add(new { ID = AccountType.BILLSRECEIVABLE.ToString(), TEXT = "BILLS RECEIVABLE" });
                accountTypeList.Add(new { ID = AccountType.FIXEDASSETS.ToString(), TEXT = "FIXED ASSETS" });
                accountTypeList.Add(new { ID = AccountType.TRADECUSTOMER.ToString(), TEXT = "TRADE CUSTOMER" });
                accountTypeList.Add(new { ID = AccountType.TRADEVENDORS.ToString(), TEXT = "TRADE VENDORS" });
                return accountTypeList;
            }
            catch { throw; }
        }
    }
}
