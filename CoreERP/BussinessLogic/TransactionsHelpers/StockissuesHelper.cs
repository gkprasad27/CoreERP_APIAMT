using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.TransactionsHelpers
{
    public class StockissuesHelper
    {
        public  List<TblOperatorStockIssues> GetStockissuesList()
        {
            try
            {
                using (Repository<TblOperatorStockIssues> repo = new Repository<TblOperatorStockIssues>())
                {
                    return repo.TblOperatorStockIssues.ToList();
                }
            }
            catch { throw; }
        }

        public  List<Branches> Getbranchcodes(string natureofAccount)
        {
            try
            {
                using (Repository<Branches> repo = new Repository<Branches>())
                {
                    return repo.Branches
                          .Where(x => x.Active.Equals("Y")
                                  && (x.BranchCode.Equals(natureofAccount))
                                )
                          .ToList();
                }
            }
            catch { throw; }
        }

        public  List<TblOperatorStockIssues> GetStockIssueslist()
        {
            try
            {
                using (Repository<TblOperatorStockIssues> repo = new Repository<TblOperatorStockIssues>())
                {
                    return repo.TblOperatorStockIssues.ToList();
                }

            }
            catch { throw; }
        }

        public  string GetIssueNo(string branchCode)
        {
            try
            {
                var voucherNo = new StockissuesHelper().GetStockissuesList().Where(b => b.FromBranchCode == branchCode).OrderByDescending(x => x.IssueNo).FirstOrDefault();
                if (voucherNo != null)
                {
                    string[] splitString = voucherNo.IssueNo.Split('/', '-');
                    var noRange = splitString[1];
                    if (noRange.Length > 0)
                    {
                        noRange = (Convert.ToInt32(noRange) + 1).ToString();
                    }

                    return splitString[0] + "-" + noRange + "-" + splitString[2];
                }

                return "OPSI-1-" + branchCode;
            }
            catch { throw; }
        }
    }
}
