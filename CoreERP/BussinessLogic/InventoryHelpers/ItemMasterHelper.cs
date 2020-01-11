using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class ItemMasterHelper
    {
        private static Repository<ItemMaster> _repo = null;
        private static Repository<ItemMaster> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<ItemMaster>();
                return _repo;
            }
        }
        public static int RegisterItemMaster(ItemMaster itemMaster)
        {
            try
            {
                var record = ((from itm in repo.ItemMaster select itm.Code).ToList()).FirstOrDefault();

                if (record != null)
                {
                    itemMaster.Code = (int.Parse(record) + 1).ToString();
                }
                else
                    itemMaster.Code = "0001";

                repo.ItemMaster.Add(itemMaster);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ItemMaster> GetItemMasterList()
        {
            try
            {
                return repo.ItemMaster.Select(x => x).ToList();
            }
            catch { throw; }
        }
        public static int UpdateItemMaster(ItemMaster itemMaster)
        {
            try
            {
                repo.ItemMaster.Update(itemMaster);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteItemMaster(string code)
        {
            try
            {
                var itemMaster = repo.ItemMaster.Where(x => x.Code == code).FirstOrDefault();
                repo.ItemMaster.Remove(itemMaster);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
