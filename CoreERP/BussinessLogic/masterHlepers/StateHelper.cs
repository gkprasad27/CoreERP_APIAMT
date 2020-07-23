using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class StateHelper
    {
        public static List<States> GetList(string statecode)
        {
            try
            {
                using Repository<States> repo = new Repository<States>();
                return repo.States.Where(x => x.StateCode == statecode).ToList();
            }
            catch { throw; }
        }

        public static List<States> GetList()
        {
            try
            {
                using Repository<States> repo = new Repository<States>();
                return repo.States.ToList();
            }
            catch { throw; }
        }

        public static States Register(States state)
        {
            try
            {
                using Repository<States> repo = new Repository<States>();
                repo.States.Add(state);
                if (repo.SaveChanges() > 0)
                    return state;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static States Update(States state)
        {
            try
            {
                using Repository<States> repo = new Repository<States>();
                repo.States.Update(state);
                if (repo.SaveChanges() > 0)
                    return state;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static States Delete(string statecode)
        {
            try
            {
                using Repository<States> repo = new Repository<States>();
                var scode = repo.States.Where(x => x.StateCode == statecode).FirstOrDefault();
                repo.States.Remove(scode);
                if (repo.SaveChanges() > 0)
                    return scode;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
