using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.TransactionsHelpers
{
    public class OilconversionHelper
    {
        public  List<TblOilConversionMaster> GetOilconversionList()
        {
            try
            {
                using (Repository<TblOilConversionMaster> repo = new Repository<TblOilConversionMaster>())
                {
                    return repo.TblOilConversionMaster.ToList();
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
        public  List<TblOilConversionMaster> Getstockshortlist()
        {
            try
            {
                using (Repository<TblOilConversionMaster> repo = new Repository<TblOilConversionMaster>())
                {
                    return repo.TblOilConversionMaster.ToList();
                }

            }
            catch { throw; }
        }

        public string GetVoucherNo(string branchCode)
        {
            try
            {
                var voucherNo = Getstockshortlist().Where(b => b.BranchCode == branchCode).OrderByDescending(x => x.OilConversionVchNo).FirstOrDefault();
                if (voucherNo != null)
                {
                    string[] splitString = voucherNo.OilConversionVchNo.Split('/', '-');

                   var _number = (Convert.ToInt32(splitString[1]) + 1).ToString();

                    return splitString[0] + "-" + _number + "-" + branchCode;
                }
                else
                {
                    return "OC-1-" + branchCode;
                }
            }
            catch { throw; }
        }
    }
}
