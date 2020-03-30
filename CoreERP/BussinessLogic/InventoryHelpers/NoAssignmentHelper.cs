using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class NoAssignmentHelper
    {
     
        public static NoAssignment RegisterNoAssignment(NoAssignment noAssignment)
        {
            try
            {
                using Repository<NoAssignment> repo = new Repository<NoAssignment>();
                var record = repo.NoAssignment.OrderByDescending(x => x.AddDate).FirstOrDefault();

                if (record != null)
                {
                    noAssignment.Code = CommonHelper.IncreaseCode(record.Code);
                }
                else
                    noAssignment.Code = "1";

                noAssignment.Active = "Y";
                noAssignment.AddDate = DateTime.Now;
                repo.NoAssignment.Add(noAssignment);
                if (repo.SaveChanges() > 0)
                    return noAssignment;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<NoAssignment> GetNoAssignmentList()
        {
            try
            {
                using Repository<NoAssignment> repo = new Repository<NoAssignment>();
                return repo.NoAssignment.Select(x => x).ToList();
            }
            catch { throw; }
        }
        public static List<NoAssignment> GetNoAssignmentList(string code)
        {
            try
            {
                using Repository<NoAssignment> repo = new Repository<NoAssignment>();
                return repo.NoAssignment.Where(x => x.Code == code).ToList();
            }
            catch { throw; }
        }
        public static NoAssignment UpdateNoAssignment(NoAssignment noAssignment)
        {
            try
            {
                using Repository<NoAssignment> repo = new Repository<NoAssignment>();
                repo.NoAssignment.Update(noAssignment);
                if (repo.SaveChanges() > 0)
                    return noAssignment;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static NoAssignment DeleteNoAssignment(string code)
        {
            try
            {
                using Repository<NoAssignment> repo = new Repository<NoAssignment>();
                var accountClass = repo.NoAssignment.Where(x => x.Code == code).FirstOrDefault();
                accountClass.Active = "N";
                repo.NoAssignment.Update(accountClass);
                if (repo.SaveChanges() > 0)
                    return accountClass;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> GetNumberTypes()
        {
            try
            {
                return Enum.GetNames(typeof(NUMBERTYPE)).ToList();
            }
            catch { throw; }
        }
    }
}
