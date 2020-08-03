using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class UnitHelpers
    {
        public IEnumerable<TblUnit> GetList(string name=null)
        {
            try
            {
                return Repository<TblUnit>.Instance.Where(x => x.UnitName == (name ?? x.UnitName)).OrderBy(x=>x.UnitId);
            }
            catch { throw; }
        }

        public TblUnit Register(TblUnit unit)
        {
            try
            {
                Repository<TblUnit>.Instance.Add(unit);
                if (Repository<TblUnit>.Instance.SaveChanges() > 0)
                    return unit;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblUnit Update(TblUnit units)
        {
            try
            {
                Repository<TblUnit>.Instance.Update(units);
                if (Repository<TblUnit>.Instance.SaveChanges() > 0)
                    return units;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblUnit Delete(string Code)
        {
            try
            {
                var ccode = Repository<TblUnit>.Instance.GetSingleOrDefault(x => x.UnitId == Code);
                Repository<TblUnit>.Instance.Remove(ccode);
                if (Repository<TblUnit>.Instance.SaveChanges() > 0)
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
