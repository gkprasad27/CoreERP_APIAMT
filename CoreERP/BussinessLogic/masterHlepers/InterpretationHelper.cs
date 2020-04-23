using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class InterpretationHelper
    {
        private static Repository<Interpretation> _repo = null;
        private static Repository<Interpretation> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<Interpretation>();
                return _repo;
            }
        }


        public static List<Interpretation> GetInterpretationList()
        {
            try
            {
                return null;
                //return repo.Interpretation.ToList();
            }
            catch { throw; }
        }


        public  static int RegisterInterpretation(Interpretation interpretation)
        {
            try
            {
                //var result = repo.Interpretation.Where(x => x.Code != null).OrderByDescending(x => x.Code).FirstOrDefault();
                //if (result == null)
                //    interpretation.Code = "1";
                //else
                //{
                //    string codeno = (int.Parse(result.Code) + 1).ToString();
                //    interpretation.Code = codeno;
                //}

                //repo.Interpretation.Add(interpretation);
                //return repo.SaveChanges();

                return 0;
            }
            catch
            {
                throw;
            }
        }

        public static int UpdateInterpretation(Interpretation interpretation)
        {
            try
            {
                //repo.Interpretation.Update(interpretation);
                //return repo.SaveChanges();
                return 0;
            }
            catch
            {
                throw;
            }
        }


        public static int DeleteInterpretation(string  code)
        {
            try
            {
                //var intpr = repo.Interpretation.Where(x=> x.Code == code).FirstOrDefault();
                // repo.Interpretation.Remove(intpr);
                // return repo.SaveChanges();

                return 0;
            }
            catch
            {
                throw;
            }
        }

    }
}
