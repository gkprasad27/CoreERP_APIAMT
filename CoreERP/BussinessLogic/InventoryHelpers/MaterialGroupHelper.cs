using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class MaterialGroupHelper
    {
        public static TblProductGroup RegisterMaterialGroup(TblProductGroup materialGroup)
        {
            try
            {
                using Repository<TblProductGroup> repo = new Repository<TblProductGroup>();
                var record = repo.TblProductGroup.OrderByDescending(x => x.GroupId).FirstOrDefault();

                if (record != null)
                {
                    materialGroup.GroupId = Convert.ToDecimal(CommonHelper.IncreaseCode(record.GroupId.ToString()));
                }
                else
                    materialGroup.GroupId = 1;

                materialGroup.ExtraDate = DateTime.Now;
                repo.TblProductGroup.Add(materialGroup);
                if (repo.SaveChanges() > 0)
                    return materialGroup;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<TblProductGroup> GetMaterialGroupList()
        {
            try
            {
                using Repository<TblProductGroup> repo = new Repository<TblProductGroup>();
                return repo.TblProductGroup.Select(x => x).OrderByDescending(x => x.GroupId).ToList();

                //return null;
            }
            catch { throw; }
        }
        public static TblProductGroup UpdateMaterialGroup(TblProductGroup materialGroup)
        {
            try
            {
                using Repository<TblProductGroup> repo = new Repository<TblProductGroup>();
                repo.TblProductGroup.Update(materialGroup);
                if (repo.SaveChanges() > 0)
                    return materialGroup;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static TblProductGroup DeleteMaterialGroup(int code)
        {
            try
            {
                using Repository<TblProductGroup> repo = new Repository<TblProductGroup>();
                var materialGroup = repo.TblProductGroup.Where(x => x.GroupId == code).FirstOrDefault();
                //materialGroup.Active = "N";
                repo.TblProductGroup.Remove(materialGroup);
                if (repo.SaveChanges() > 0)
                    return materialGroup;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<AccountingClass> GetAccountingClassList()
        {
            try
            {
                //using Repository<AccountingClass> repo = new Repository<AccountingClass>();
                //return repo.AccountingClass.AsEnumerable().Where(x => x.Active.Equals("Y")).ToList();

                return null;
            }
            catch { throw; }
        }
    }
}
