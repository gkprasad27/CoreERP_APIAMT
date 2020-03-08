using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.PurhaseHelpers
{
    public class PurchaseHelper
    {

        //public string GetPurchaseInvoiceNo(string branchCode)
        //{
        //    string Prefix=string.Empty,suffix = string.Empty;
        //    new Common.CommonHelper().GetSuffixPrefix(13,branchCode,out Prefix,out suffix);
        //}

        public List<TblProduct> GetProducts(string productCode,string productName)
        {
            try
            {
                productCode = productCode.ToLower();
                productName = productName.ToLower();

                using (Repository<TblProduct> repo=new Repository<TblProduct>())
                {
                    return repo.TblProduct
                               .Where(p => p.ProductCode.ToLower().Contains(productCode) && p.ProductName.ToLower().Contains(productName))
                               .ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public bool AddPurchaseInvoice(TblPurchaseInvoice purchaseInvoice,TblPurchaseInvoiceDetail purchaseInvoiceDetail)
        {
            try
            {
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
