using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class StateWiseGstHelper
    {
        public List<TblStateWiseGst> GetStatesWiseGstList()
        {
            try
            {
                using (Repository<TblStateWiseGst> repo = new Repository<TblStateWiseGst>())
                {
                    return repo.TblStateWiseGst.ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<States> GetStatesList()
        {
            try
            {
                using (Repository<States> repo = new Repository<States>())
                {
                    return repo.States.ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public TblStateWiseGst Register(TblStateWiseGst stateWiseGst)
        {
            try
            {
                using (Repository<TblStateWiseGst> repo = new Repository<TblStateWiseGst>())
                {
                    repo.TblStateWiseGst.Add(stateWiseGst);
                    if (repo.SaveChanges() > 0)
                        return stateWiseGst;

                    return null;
                }
            }
            catch { throw; }
        }
        public TblStateWiseGst Update(TblStateWiseGst stateWiseGst)
        {
            try
            {
                using (Repository<TblStateWiseGst> repo = new Repository<TblStateWiseGst>())
                {
                    repo.TblStateWiseGst.Update(stateWiseGst);
                    if (repo.SaveChanges() > 0)
                        return stateWiseGst;

                    return null;
                }
            }
            catch { throw; }
        }
        public TblStateWiseGst Delete(int code)
        {
            try
            {
                using (Repository<TblStateWiseGst> repo = new Repository<TblStateWiseGst>())
                {
                    var state = repo.TblStateWiseGst.Where(x => x.StateId == code).FirstOrDefault();
                    repo.TblStateWiseGst.Remove(state);
                    if (repo.SaveChanges() > 0)
                        return state;

                    return null;
                }
            }
            catch { throw; }
        }
    }
}
