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
        public static List<TblBranch> GetBranches()
        {
            try
            {
                using Repository<TblBranch> repo = new Repository<TblBranch>();
                return repo.TblBranch.ToList();
            }
            catch { throw; }
        }


        public static TblBranch GetBranches(string code)
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    return repo.TblBranch.AsEnumerable()
                               .Where(b => b.BranchCode == code).FirstOrDefault();
                }
            }
            catch { throw; }
        }
        public static List<TblBranch> GetBranchesLikeSearch(string branchCode, string branchName)
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    return repo.TblBranch.AsEnumerable()
                    .Where(b => b.BranchCode.Contains(branchCode ?? b.BranchCode)
                             && b.BranchName.Contains(branchName ?? b.BranchName)
                    ).ToList();
                }
            }
            catch { throw; }
        }
        public static List<TblBranch> SearchBranch(string branchCode)
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    return repo.TblBranch.AsEnumerable()
                      .Where(b => b.BranchCode == branchCode)
                      .ToList();
                }
            }
            catch { throw; }
        }
        public static TblBranch Register(TblBranch branches)
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    repo.TblBranch.Add(branches);
                    if (repo.SaveChanges() > 0)
                        return branches;

                    return null;
                }
            }
            catch { throw; }
        }
        public static TblBranch Update(TblBranch branches)
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    repo.TblBranch.Update(branches);
                    if (repo.SaveChanges() > 0)
                        return branches;

                    return null;
                }
            }
            catch { throw; }
        }
        public static TblBranch Delete(string code)
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    var brnch = repo.TblBranch.Where(x => x.BranchCode == code).FirstOrDefault();
                    repo.TblBranch.Remove(brnch);
                    if (repo.SaveChanges() > 0)
                        return brnch;

                    return null;
                }
            }
            catch { throw; }
        }
    }
}
