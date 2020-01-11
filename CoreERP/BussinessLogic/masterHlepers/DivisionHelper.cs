using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class DivisionHelper
    {
        
        public static List<Divisions> GetList(string divisionCode)
        {
            try
            {
                using (Repository<Divisions> repo = new Repository<Divisions>())
                {
                    return repo.Divisions
                               .Where(x => x.Code == divisionCode)
                               .ToList();
                }
            }
            catch { throw; }
        }

        public static List<Divisions> GetList()
        {
            try
            {
                using (Repository<Divisions> repo = new Repository<Divisions>())
                {
                    return repo.Divisions.AsEnumerable().Where(x => x.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }

        public static Divisions Register(Divisions divisions)
        {
            try
            {
                using (Repository<Divisions> repo = new Repository<Divisions>())
                {
                    divisions.Active = "Y";
                    repo.Divisions.Add(divisions);
                    if (repo.SaveChanges() > 0)
                        return divisions;

                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static Divisions Update(Divisions division)
        {
            try
            {
                using (Repository<Divisions> repo = new Repository<Divisions>())
                {
                    repo.Divisions.Update(division);
                    if (repo.SaveChanges() > 0)
                        return division;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Divisions Delete(string divisionCode)
        {
            try
            {
                using (Repository<Divisions> repo = new Repository<Divisions>())
                {
                    var division = repo.Divisions.Where(x => x.Code == divisionCode).FirstOrDefault();
                    division.Active = "N";
                    repo.Divisions.Update(division);
                    if (repo.SaveChanges() > 0)
                        return division;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
