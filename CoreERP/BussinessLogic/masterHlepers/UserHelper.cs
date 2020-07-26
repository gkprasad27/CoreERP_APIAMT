using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class UserHelper
    {
        public static List<Erpuser> GetList(string user)
        {
            try
            {
                using Repository<Erpuser> repo = new Repository<Erpuser>();
                return repo.Erpuser.Where(x => x.UserName == user).ToList();
            }
            catch { throw; }
        }

        public static List<Erpuser> GetList()
        {
            try
            {
                using Repository<Erpuser> repo = new Repository<Erpuser>();
                return repo.Erpuser.ToList();
            }
            catch { throw; }
        }
        public static List<TblRole> GetRoleList()
        {
            try
            {
                using Repository<TblRole> repo = new Repository<TblRole>();
                return repo.TblRole.ToList();
            }
            catch { throw; }
        }

        public static Erpuser Register(Erpuser user)
        {
            try
            {
                using Repository<Erpuser> repo = new Repository<Erpuser>();
                user.AddDate = DateTime.Now;
                repo.Erpuser.Add(user);
                if (repo.SaveChanges() > 0)
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
                using Repository<Erpuser> repo = new Repository<Erpuser>();
                user.AddDate = DateTime.Now;
                repo.Erpuser.Update(user);
                if (repo.SaveChanges() > 0)
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
                using Repository<Erpuser> repo = new Repository<Erpuser>();
                var scodes = repo.Erpuser.Where(x => x.SeqId ==Convert.ToInt32(code)).FirstOrDefault();
                repo.Erpuser.Remove(scodes);
                if (repo.SaveChanges() > 0)
                    return scodes;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
