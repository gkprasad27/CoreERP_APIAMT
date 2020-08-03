using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class StateHelper
    {
        public static IEnumerable<States> GetList(string statecode)
        {
            try
            {
                return Repository<States>.Instance.Where(x => x.StateCode == statecode);
            }
            catch { throw; }
        }

        public static IEnumerable<States> GetList()
        {
            try
            {
                return Repository<States>.Instance.GetAll().OrderBy(x => x.StateCode);
            }
            catch { throw; }
        }

        public static States Register(States state)
        {
            try
            {
                Repository<States>.Instance.Add(state);
                if (Repository<States>.Instance.SaveChanges() > 0)
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
                Repository<States>.Instance.Update(state);
                if (Repository<States>.Instance.SaveChanges() > 0)
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
                var ccode = Repository<States>.Instance.GetSingleOrDefault(x => x.StateCode == statecode);
                Repository<States>.Instance.Remove(ccode);
                if (Repository<States>.Instance.SaveChanges() > 0)
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
