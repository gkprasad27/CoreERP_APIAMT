using CoreERP.BussinessLogic.Common;
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
       
        public static ItemMaster RegisterItemMaster(ItemMaster itemMaster)
        {
            try
            {
                using (Repository<ItemMaster> repo = new Repository<ItemMaster>())
                {
                    var record =repo.ItemMaster.OrderByDescending(x=> x.AddDate).FirstOrDefault();

                    if (record != null)
                    {
                        itemMaster.Code = CommonHelper.IncreaseCode(record.Code);
                    }
                    else
                        itemMaster.Code = "1";

                    itemMaster.Active = "Y";
                    itemMaster.AddDate = DateTime.Now;
                    repo.ItemMaster.Add(itemMaster);
                    if (repo.SaveChanges() > 0)
                        return itemMaster;

                    return null;
                }
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
                using (Repository<ItemMaster> repo = new Repository<ItemMaster>())
                {
                    return repo.ItemMaster.AsEnumerable().Where(x => x.Active=="Y").ToList();
                }
            }
            catch { throw; }
        }
        public static List<ItemMaster> GetItemMasterList(string code)
        {
            try
            {
                using (Repository<ItemMaster> repo = new Repository<ItemMaster>())
                {
                    return repo.ItemMaster.AsEnumerable().Where(x => x.Code == code).ToList();
                }
            }
            catch { throw; }
        }
        public static ItemMaster UpdateItemMaster(ItemMaster itemMaster)
        {
            try
            {
                using (Repository<ItemMaster> repo = new Repository<ItemMaster>())
                {
                    repo.ItemMaster.Update(itemMaster);
                    if (repo.SaveChanges() > 0)
                        return itemMaster;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ItemMaster> UpdateItemMaster(List<ItemMaster> itemMasters)
        {
            try
            {
                using (Repository<ItemMaster> repo = new Repository<ItemMaster>())
                {
                    repo.ItemMaster.UpdateRange(itemMasters);
                    if (repo.SaveChanges() > 0)
                        return itemMasters;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ItemMaster DeleteItemMaster(string code)
        {
            try
            {
                using (Repository<ItemMaster> repo = new Repository<ItemMaster>())
                {
                    var itemMaster = repo.ItemMaster.Where(x => x.Code == code).FirstOrDefault();
                    itemMaster.Active = "N";
                    repo.ItemMaster.Remove(itemMaster);
                    if (repo.SaveChanges() > 0)
                        return itemMaster;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ItemMaster GetItemMaster(string modelcode)
        {
            try
            {
                using (Repository<ItemMaster> repo = new Repository<ItemMaster>())
                {
                    return repo.ItemMaster.Where(x => x.Model == modelcode).OrderByDescending(x=> x.AddDate).FirstOrDefault();
                }
            }
            catch { throw; }
        }
    }
}
