using CoreERP.BussinessLogic.Common;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.PurhaseHelpers
{
    public class PurchasesHelper
    {
        public string GeneratePurchaseInvoiceNo(string branchCode)
        {
            try
            {
                string sufix = string.Empty, prefix = string.Empty;
                var invoiceNo =new Common.CommonHelper().GetSuffixPrefix(13, branchCode, out prefix, out sufix);
               
                if (string.IsNullOrEmpty(invoiceNo))
                {
                    invoiceNo = prefix + "-1-" + sufix;
                }

                invoiceNo = prefix+"-" + (Convert.ToInt64(invoiceNo.Split("-")[1])+1) +"-"+ sufix;

                new Common.CommonHelper().UpdateInvoiceNumber(13, branchCode, invoiceNo);

                return invoiceNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
