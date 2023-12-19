using CoreERP.DataAccess;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP
{
    public class ApprovalTypeHelper
    {
        public static List<ApprovalType> GetList(string divisionCode)
        {
            try
            {
                using Repository<ApprovalType> repo = new Repository<ApprovalType>();
                return repo.ApprovalType.Where(x => x.Approval == divisionCode).ToList();
                //return null;
            }
            catch { throw; }
        }

        public static List<ApprovalType> GetList()
        {
            try
            {
                using Repository<ApprovalType> repo = new Repository<ApprovalType>();
                return repo.ApprovalType.ToList();
                //return null;
            }
            catch { throw; }
        }

        public static ApprovalType Register(ApprovalType apptype)
        {
            try
            {
                using Repository<ApprovalType> repo = new Repository<ApprovalType>();
                repo.ApprovalType.Add(apptype);
                if (repo.SaveChanges() > 0)
                    return apptype;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ApprovalType Update(ApprovalType aptype)
        {
            try
            {
                using Repository<ApprovalType> repo = new Repository<ApprovalType>();
                repo.ApprovalType.Update(aptype);
                if (repo.SaveChanges() > 0)
                    return aptype;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ApprovalType Delete(string aptype)
        {
            try
            {
                using Repository<ApprovalType> repo = new Repository<ApprovalType>();
                var aptypes = repo.ApprovalType.Where(x => x.Id ==Convert.ToInt32(aptype)).FirstOrDefault();
               // aptypes.Active = "N";
                repo.ApprovalType.Remove(aptypes);
                if (repo.SaveChanges() > 0)
                    return aptypes;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TblEmployee> GetListOfEmployees()
        {
            try
            {
                using Repository<TblEmployee> repo = new Repository<TblEmployee>();
                return repo.TblEmployee.ToList();
            }
            catch { throw; }
        }
    }
}
