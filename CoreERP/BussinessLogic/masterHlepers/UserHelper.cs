using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class UserHelper
    {
        public static IEnumerable<Erpuser> GetList(string user)
        {
            try
            {
                return Repository<Erpuser>.Instance.Where(x => x.UserName == user);
            }
            catch { throw; }
        }

        public static IEnumerable<Erpuser> GetList()
        {
            try
            {
                return Repository<Erpuser>.Instance.GetAll().OrderBy(x => x.UserName);
            }
            catch { throw; }
        }
        public static IEnumerable<TblRole> GetRoleList()
        {
            try
            {
                return Repository<TblRole>.Instance.GetAll().OrderBy(x => x.RoleId);
            }
            catch { throw; }
        }

        public static Erpuser Register(Erpuser user)
        {
            try
            {
                Repository<Erpuser>.Instance.Add(user);
                if (Repository<Erpuser>.Instance.SaveChanges() > 0)
                    return user;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Erpuser Update(Erpuser user)
        {
            try
            {
                Repository<Erpuser>.Instance.Update(user);
                if (Repository<Erpuser>.Instance.SaveChanges() > 0)
                    return user;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Erpuser Delete(string code)
        {
            try
            {
                var ccode = Repository<Erpuser>.Instance.GetSingleOrDefault(x => x.UserName == code);
                Repository<Erpuser>.Instance.Remove(ccode);
                if (Repository<Erpuser>.Instance.SaveChanges() > 0)
                    return ccode;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
