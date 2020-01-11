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
        private static Repository<NoAssignment> _repo = null;
        private static Repository<NoAssignment> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<NoAssignment>();
                return _repo;
            }
        }
        public static int RegisterNoAssignment(NoAssignment noAssignment)
        {
            try
            {
                var record = ((from acc in repo.NoAssignment select acc.Code).ToList()).FirstOrDefault();

                if (record != null)
                {
                    noAssignment.Code = (int.Parse(record) + 1).ToString();
                }
                else
                    noAssignment.Code = "0001";

                repo.NoAssignment.Add(noAssignment);
                return repo.SaveChanges();
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
                return repo.NoAssignment.Select(x => x).ToList();
            }
            catch { throw; }
        }
        public static int UpdateNoAssignment(NoAssignment noAssignment)
        {
            try
            {
                repo.NoAssignment.Update(noAssignment);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteNoAssignment(string code)
        {
            try
            {
                var accountClass = repo.NoAssignment.Where(x => x.Code == code).FirstOrDefault();
                repo.NoAssignment.Remove(accountClass);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
