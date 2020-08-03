using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class SegmentHelper
    {
        public static IEnumerable<Segment> GetSegmentList()
        {
            try
            {
                return Repository<Segment>.Instance.GetAll().OrderBy(x => x.Id);
            }
            catch { throw; }
        }

        //public static bool IsSegmentIDExists(string ID)
        //{
        //    try
        //    {
        //        using Repository<Segment> repo = new Repository<Segment>();
        //        return repo.Segment.AsEnumerable().Where(s => s.Id == ID).Count() > 0;

        //        // return false;
        //    }
        //    catch { throw; }
        //}

        public static Segment RegisterSegment(Segment segment)
        {
            try
            {
                Repository<Segment>.Instance.Add(segment);
                if (Repository<Segment>.Instance.SaveChanges() > 0)
                    return segment;

                return null;
            }
            catch { throw; }
        }

        public static Segment UpdateSegment(Segment segment)
        {
            try
            {
                Repository<Segment>.Instance.Update(segment);
                if (Repository<Segment>.Instance.SaveChanges() > 0)
                    return segment;

                return null;
            }
            catch { throw; }
        }


        public static Segment DeleteSegment(string seqID)
        {
            try
            {
                var ccode = Repository<Segment>.Instance.GetSingleOrDefault(x => x.Id == seqID);
                Repository<Segment>.Instance.Remove(ccode);
                if (Repository<Segment>.Instance.SaveChanges() > 0)
                    return ccode;

                return null;
            }
            catch { throw; }
        }
    }
}
