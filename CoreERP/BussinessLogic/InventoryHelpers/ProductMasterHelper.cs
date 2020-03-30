using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class ProductMasterHelper
    {
        public  List<TblProduct> GetProductMasterList()
        {
            try
            {
                using Repository<TblProduct> repo = new Repository<TblProduct>();
                return repo.TblProduct.AsEnumerable().Where(x => x.IsActive == true).ToList();
            }
            catch { throw; }
        }
    }
}
