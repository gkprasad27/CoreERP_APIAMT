using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.TransactionsHelpers
{
    public class StockshortHelpers
    {
        public  List<TblStockshortMaster> GetStockshortsList()
        {
            try
            {
                using (Repository<TblStockshortMaster> repo = new Repository<TblStockshortMaster>())
                {
                    return repo.TblStockshortMaster.ToList();
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
        public  List<CostCenters> GetCostCenters()
        {
            try
            {
                using (Repository<CostCenters> repo = new Repository<CostCenters>())
                {
                    return repo.CostCenters.ToList();
                }
            }
            catch { throw; }
        }

        public  List<TblStockshortMaster> Getstockshortlist()
        {
            try
            {
                using (Repository<TblStockshortMaster> repo = new Repository<TblStockshortMaster>())
                {
                    return repo.TblStockshortMaster.ToList();
                }

            }
            catch { throw; }
        }

        public  string GetVoucherNo(string branchCode)
        {
            try
            {
                var voucherNo = Getstockshortlist().Where(b => b.BranchCode == branchCode).OrderByDescending(x => x.StockshortNo).FirstOrDefault();
                if (voucherNo != null)
                {
                    string[] splitString = voucherNo.StockshortNo.Split('/','-');
                    var noRange = splitString[1];
                    if (noRange.Length > 0)
                    {
                        noRange = (Convert.ToInt32(noRange) + 1).ToString();
                    }

                    return splitString[0] + "-" + noRange + "-" + splitString[2];
                }

                return "SS-1-" + branchCode;
            }
            catch { throw; }
        }
    }
}
