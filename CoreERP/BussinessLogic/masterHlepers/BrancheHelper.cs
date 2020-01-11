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
        public static List<Branches> GetBranches()
        {
            try
            {
                using(Repository<Branches> repo=new Repository<Branches>())
                {
                    return repo.Branches.AsEnumerable().Where(b => b.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }
        public static Branches GetBranches(string code)
        {
            try
            {
                using (Repository<Branches> repo = new Repository<Branches>())
                {
                    return repo.Branches.AsEnumerable()
                               .Where(b => b.Active.Equals("Y", StringComparison.OrdinalIgnoreCase) 
                                        && b.BranchCode == code).FirstOrDefault();
                }
            }
            catch { throw; }
        }


        public static List<Branches> GetBranchesLikeSearch(string branchCode,string branchName)
        {
            try
            {
                using (Repository<Branches> repo = new Repository<Branches>())
                {
                    return repo.Branches.AsEnumerable()
                    .Where(b => b.BranchCode.Contains(branchCode ?? b.BranchCode)
                             && b.Name.Contains(branchName ?? b.Name)
                             && b.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)
                    ).ToList();
                }
            }
            catch { throw; }
        }

        public static List<Branches> SearchBranch(string branchCode)
        {
            try
            {
                using (Repository<Branches> repo = new Repository<Branches>())
                {
                    return repo.Branches.AsEnumerable()
                      .Where(b => b.BranchCode == branchCode
                               && b.Active.Equals("Y", StringComparison.OrdinalIgnoreCase)
                            )
                      .ToList();
                }
            }
            catch { throw; }
        }


        public static Branches Register(Branches branches)
        {
            try
            {
                using (Repository<Branches> repo = new Repository<Branches>())
                {
                    branches.Active = "Y";
                    repo.Branches.Add(branches);
                    if(repo.SaveChanges() > 0)
                    return branches;

                    return null;
                }
            }
            catch { throw; }
        }


        public static Branches Update(Branches branches)
        {
            try
            {
                using (Repository<Branches> repo = new Repository<Branches>())
                {
                    repo.Branches.Update(branches);
                    if (repo.SaveChanges() > 0)
                        return branches;

                    return null;
                }
            }
            catch { throw; }
        }

        public static Branches Delete(string code)
        {
            try
            {
                using (Repository<Branches> repo = new Repository<Branches>())
                {
                    var bobj = GetBranches(code);
                    bobj.Active = "N";
                    repo.Branches.Update(bobj);
                    if (repo.SaveChanges() > 0)
                        return bobj;

                    return null;
                }
            }
            catch { throw; }
        }
    }
}
