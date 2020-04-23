using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class InventoryHelper
    {
        public static List<ItemMaster> GetItemMasterList()
        {
            try
            {
                //using Repository<ItemMaster> repo = new Repository<ItemMaster>();
                //return repo.ItemMaster.Select(i => i).ToList();
                return null;
            }
            catch { throw; }
        }

        public static List<Brand> GetBrandList()
        {
            try
            {
                //using Repository<Brand> repo = new Repository<Brand>();
                //return repo.Brand.Select(i => i).ToList();

                return null;
            }
            catch { throw; }
        }


      
    }
}
