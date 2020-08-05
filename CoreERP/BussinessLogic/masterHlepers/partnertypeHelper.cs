using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class partnertypeHelper
    {
        public static IEnumerable<PartnerType> GetList(string code)
        {
            try
            {
                return Repository<PartnerType>.Instance.Where(x => x.Code == code);
            }
            catch { throw; }
        }

        public static IEnumerable<PartnerType> GetList()
        {
            try
            {
                return Repository<PartnerType>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static PartnerType Register(PartnerType ptype)
        {
            try
            {
                Repository<PartnerType>.Instance.Add(ptype);
                if (Repository<PartnerType>.Instance.SaveChanges() > 0)
                    return ptype;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PartnerType Update(PartnerType patype)
        {
            try
            {
                Repository<PartnerType>.Instance.Update(patype);
                if (Repository<PartnerType>.Instance.SaveChanges() > 0)
                    return patype;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PartnerType Delete(string codes)
        {
            try
            {

                var rcode = Repository<PartnerType>.Instance.GetSingleOrDefault(x => x.Code == codes);
                Repository<PartnerType>.Instance.Remove(rcode);
                if (Repository<PartnerType>.Instance.SaveChanges() > 0)
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
