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
        private static Repository<Divisions> _repo = null;
        private static Repository<Divisions> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<Divisions>();
                return _repo;
            }
        }


        public static List<Divisions> GetList(string divisionCode)
        {
            try
            {
                return repo.GetAll()
                           .Where(x=> x.Code == divisionCode)
                           .ToList();
            }
            catch { throw; }
        }

        public static List<Divisions> GetList()
        {
            try
            {
                return repo.GetAll().ToList();
            }
            catch { throw; }
        }

        public static int Register(Divisions divisions)
        {
            try
            {
                repo.Divisions.Add(divisions);
               return repo.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static int Update(Divisions division)
        {
            try
            {
                repo.Divisions.Update(division);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int Delete(string divisionCode)
        {
            try
            {
                var division = repo.Divisions.Where(x => x.Code == divisionCode).FirstOrDefault();
                repo.Divisions.Remove(division);
               return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
