using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class BrancheHelper
    {
        private static Repository<Branches> _repo = null;
        private static Repository<Branches> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<Branches>();
                return _repo;
            }
        }


        public static List<Branches> GetBranches()
        {
            try
            {
              return  repo.GetAll().ToList();
            }
            catch { throw; }
        }


        public static List<Branches> GetBranchesLikeSearch(string branchCode,string branchName)
        {
            try
            {
              return  repo.Branches
                    .Where(b => b.Code.Contains(branchCode ?? b.Code)
                            && b.Name.Contains(branchName ?? b.Name)
                    ).ToList();
            }
            catch { throw; }
        }

        public static List<Branches> SearchBranch(string branchCode)
        {
            try
            {
                return repo.Branches
                      .Where(b => b.Code ==branchCode).ToList();
            }
            catch { throw; }
        }


        public static int Register(Branches branches)
        {
            try
            {
                repo.Branches.Add(branches);
               return repo.SaveChanges();
            }
            catch { throw; }
        }


        public static int Update(Branches branches)
        {
            try
            {
                repo.Update(branches);
                return repo.SaveChanges();
            }
            catch { throw; }
        }


        public static int Delete(string branchCode)
        {
            try
            {
                var branch = repo.Branches.Where(x => x.Code == branchCode).FirstOrDefault();
                repo.Branches.Remove(branch);
                return repo.SaveChanges();
            }
            catch { throw; }
        }

    }
}
