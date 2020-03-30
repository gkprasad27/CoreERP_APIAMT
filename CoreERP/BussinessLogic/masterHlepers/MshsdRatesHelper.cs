using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class MshsdRatesHelper
    {
        public List<TblMshsdrates> GetListOfMshsdRates()
        {
            try
            {
                using Repository<TblMshsdrates> repo = new Repository<TblMshsdrates>();
                return repo.TblMshsdrates.ToList();
            }
            catch { throw; }
        }

        public  List<TblBranch> GetBranchesList()
        {
            try
            {
               return BrancheHelper.GetBranches();
            }
            catch (Exception ex) { throw ex; }
        }

        public  TblMshsdrates Register(TblMshsdrates mshsdrates)
        {
            try
            {
                using Repository<TblMshsdrates> repo = new Repository<TblMshsdrates>();
                repo.TblMshsdrates.Add(mshsdrates);
                if (repo.SaveChanges() > 0)
                    return mshsdrates;

                return null;
            }
            catch { throw; }
        }


        public  TblMshsdrates Update(TblMshsdrates mshsdrates)
        {
            try
            {
                using Repository<TblMshsdrates> repo = new Repository<TblMshsdrates>();
                repo.TblMshsdrates.Update(mshsdrates);
                if (repo.SaveChanges() > 0)
                    return mshsdrates;

                return null;
            }
            catch { throw; }
        }

        public  TblMshsdrates Delete(string code)
        {
            try
            {
                using Repository<TblMshsdrates> repo = new Repository<TblMshsdrates>();
                var mshsd = repo.TblMshsdrates.Where(x => x.BranchCode == code).FirstOrDefault();
                repo.TblMshsdrates.Remove(mshsd);
                if (repo.SaveChanges() > 0)
                    return mshsd;

                return null;
            }
            catch { throw; }
        }
    }
}
