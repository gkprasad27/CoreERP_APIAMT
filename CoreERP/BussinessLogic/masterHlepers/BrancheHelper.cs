using CoreERP.DataAccess;
using CoreERP.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class BrancheHelper
    {
        public static IEnumerable<TblBranch> GetBranches()
        {
            try
            {
                return Repository<TblBranch>.Instance.GetAll().OrderBy(x => x.BranchCode);
            }
            catch { throw; }
        }


        public static IEnumerable<TblBranch> GetBranches(string code)
        {
            try
            {
                return Repository<TblBranch>.Instance.Where(x => x.BranchCode == code);
            }
            catch { throw; }
        }
        public static IEnumerable<TblBranch> GetBranchesLikeSearch(string branchCode, string branchName)
        {
            try
            {
              return Repository<TblBranch>.Instance.Where(b => b.BranchCode.Contains(branchCode ?? b.BranchCode)
                                                            && b.BranchName.Contains(branchName ?? b.BranchName));
            }
            catch { throw; }
        }
        public static IEnumerable<TblBranch> SearchBranch(string branchCode)
        {
            try
            {
                return Repository<TblBranch>.Instance.Where(x => x.BranchCode == branchCode);
            }
            catch { throw; }
        }
        public static TblBranch Register(TblBranch branches)
        {
            try
            {
                Repository<TblBranch>.Instance.Add(branches);
                if (Repository<TblBranch>.Instance.SaveChanges() > 0)
                    return branches;

                return null;
            }
            catch { throw; }
        }
        public static TblBranch Update(TblBranch branches)
        {
            try
            {
                Repository<TblBranch>.Instance.Update(branches);
                if (Repository<TblBranch>.Instance.SaveChanges() > 0)
                    return branches;

                return null;
            }
            catch { throw; }
        }
        public static TblBranch Delete(string code)
        {
            try
            {
                var ccode = Repository<TblBranch>.Instance.GetSingleOrDefault(x => x.BranchCode == code);
                Repository<TblBranch>.Instance.Remove(ccode);
                if (Repository<TblBranch>.Instance.SaveChanges() > 0)
                    return ccode;

                return null;
            }
            catch { throw; }
        }
    }
}
