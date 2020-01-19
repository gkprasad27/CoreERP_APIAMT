using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class ApprovalHelper
    {
        public static List<ApprovalType> GetListOfApprovals()
        {
            try
            {
                using (Repository<ApprovalType> repo = new Repository<ApprovalType>())
                {
                    return repo.ApprovalType.AsEnumerable().Where(a => a.Active == "Y").ToList();
                }
            }
            catch { throw; }
        }

        public static ApprovalType RegisterApprovalType(ApprovalType approvalType)
        {
            try
            {
                using (Repository<ApprovalType> repo = new Repository<ApprovalType>())
                {
                    approvalType.Active = "Y";
                    repo.ApprovalType.Add(approvalType);
                    if (repo.SaveChanges() > 0)
                        return approvalType;

                    return null;
                }
            }
            catch { throw; }
        }

        public static ApprovalType UpdateApprovalType(ApprovalType approvalType)
        {
            try
            {
                using (Repository<ApprovalType> repo = new Repository<ApprovalType>())
                {
                    repo.ApprovalType.Update(approvalType);
                    if (repo.SaveChanges() > 0)
                        return approvalType;

                    return null;
                }
            }
            catch { throw; }
        }

        public static ApprovalType DeleteApprovalType(int approvalTypeCode)
        {
            try
            {
                using (Repository<ApprovalType> repo = new Repository<ApprovalType>())
                {
                    var approvalType = repo.ApprovalType.Where(a => a.ApprovalId == approvalTypeCode).FirstOrDefault();
                    approvalType.Active = "N";
                    repo.ApprovalType.Remove(approvalType);
                    if (repo.SaveChanges() > 0)
                        return approvalType;

                    return null;
                }
            }
            catch { throw; }
        }
    }
}
