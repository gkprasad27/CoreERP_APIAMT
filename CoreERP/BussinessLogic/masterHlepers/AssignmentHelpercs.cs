using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class AssignmentHelpercs
    {
        public static IEnumerable<TblAssignment> GetList(string code)
        {
            try
            {
                return Repository<TblAssignment>.Instance.Where(x => x.Code == code);
            }
            catch { throw; }
        }

        public static IEnumerable<TblAssignment> GetList()
        {
            try
            {
                return Repository<TblAssignment>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblAssignment Register(TblAssignment assignment)
        {
            try
            {
                Repository<TblAssignment>.Instance.Add(assignment);
                if (Repository<TblAssignment>.Instance.SaveChanges() > 0)
                    return assignment;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblAssignment Update(TblAssignment assignment)
        {
            try
            {
                Repository<TblAssignment>.Instance.Update(assignment);
                if (Repository<TblAssignment>.Instance.SaveChanges() > 0)
                    return assignment;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblAssignment Delete(string codes)
        {
            try
            {

                var rcode = Repository<TblAssignment>.Instance.GetSingleOrDefault(x => x.Code == codes);
                Repository<TblAssignment>.Instance.Remove(rcode);
                if (Repository<TblAssignment>.Instance.SaveChanges() > 0)
                    return rcode;
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
