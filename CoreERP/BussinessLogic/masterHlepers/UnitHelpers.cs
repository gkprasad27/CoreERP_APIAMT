using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class UnitHelpers
    {
        public List<TblUnit> GetList(string name=null)
        {
            try
            {
                using Repository<TblUnit> repo = new Repository<TblUnit>();
                return repo.TblUnit
.Where(x => x.UnitName == (name ?? x.UnitName))
.ToList();
            }
            catch { throw; }
        }

        public TblUnit Register(TblUnit unit)
        {
            try
            {
                using Repository<TblUnit> repo = new Repository<TblUnit>();
                repo.TblUnit.Add(unit);
                if (repo.SaveChanges() > 0)
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
                using Repository<TblUnit> repo = new Repository<TblUnit>();
                repo.TblUnit.Update(units);
                if (repo.SaveChanges() > 0)
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
                using Repository<TblUnit> repo = new Repository<TblUnit>();
                var unitno = repo.TblUnit.Where(x => x.UnitId == Convert.ToInt32(Code)).FirstOrDefault();
                repo.TblUnit.Remove(unitno);
                if (repo.SaveChanges() > 0)
                    return unitno;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
