using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SalesHelper
{
    public class AsnBillsRcvBranchHelper
    {
        public static List<AsnBillsRcvBranch> GetAsnBillsRcvBranchList()
        {
            try
            {
                using (Repository<AsnBillsRcvBranch> repo = new Repository<AsnBillsRcvBranch>())
                {
                    return repo.AsnBillsRcvBranch.Where(a => a.Active.Equals("Y",StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }

        public static List<Glaccounts> GetGLBillReceivableAccountsList()
        {
            try
            {
                //accounts = (from account in ( from glacc in _unitOfWork.GLAccounts.GetAll() where glacc.Nactureofaccount !=null select glacc)
                //            where account.Nactureofaccount.ToUpper() == "BILLSRECEIVABLES"
                //            select account).ToList(),

                string accountType = "BILLSRECEIVABLES";
                using (Repository<Glaccounts> repo = new Repository<Glaccounts>())
                {
                    return repo.Glaccounts
                               .Where(gl => accountType.Equals(gl.Nactureofaccount, StringComparison.OrdinalIgnoreCase)
                                          && gl.Active.Equals("Y"))
                               .ToList();
                }
            }
            catch { throw; }
        }

        public static List<Branches> GetBranchesList()
        {
            try
            {
                using (Repository<Branches> repo = new Repository<Branches>())
                {
                    return repo.Branches.Where(b => b.Active.Equals("Y",StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }

        public static AsnBillsRcvBranch RegisterAsnBillsRcvBranch(AsnBillsRcvBranch asnBillsRcvBranch)
        {
            try
            {
                using(Repository<AsnBillsRcvBranch> repo=new Repository<AsnBillsRcvBranch>())
                {

                    int lastreacord = 0;
                    if (repo.AsnBillsRcvBranch.Count() > 0)
                        lastreacord = repo.AsnBillsRcvBranch.Where(x => x.Code != null).Max(x => Convert.ToInt32(x.Code));

                    if (lastreacord > 0)
                        asnBillsRcvBranch.Code = (lastreacord + 1).ToString();
                    else
                        asnBillsRcvBranch.Code = "1";

                    asnBillsRcvBranch.Active = "Y";
                    repo.AsnBillsRcvBranch.Add(asnBillsRcvBranch);
                    if (repo.SaveChanges() > 0)
                        return asnBillsRcvBranch;

                    return null;
                }
            }
            catch { throw; }
        }


        public static AsnBillsRcvBranch UpdateAsnBillsRcvBranch(AsnBillsRcvBranch asnBillsRcvBranch)
        {
            try
            {
                using (Repository<AsnBillsRcvBranch> repo = new Repository<AsnBillsRcvBranch>())
                {
                    repo.AsnBillsRcvBranch.Update(asnBillsRcvBranch);
                    if (repo.SaveChanges() > 0)
                        return asnBillsRcvBranch;

                    return null;
                }
            }
            catch { throw; }
        }
    }
}
