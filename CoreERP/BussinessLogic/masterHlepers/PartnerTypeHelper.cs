using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class PartnerTypeHelper
    {
        private static Repository<PartnerType> _repo = null;
        private static Repository<PartnerType> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<PartnerType>();
                return _repo;
            }
        }



        public static List<PartnerType> GetPartnerTypeList()
        {
            try
            {
                return repo.PartnerType.Select(p => p).ToList();
            }
            catch { throw; }
        }



        public static int RegistePartnerType(PartnerType partnerType)
        {
            try
            {
                repo.PartnerType.Add(partnerType);
                return repo.SaveChanges();
            }
            catch { throw; }
        }



        public static int UpdatePartnerType(PartnerType partnerType)
        {
            try
            {
                repo.PartnerType.Update(partnerType);
                return repo.SaveChanges();
            }
            catch { throw; }
        }



        public static int DeletePartnerType(string partnerTypeCode)
        {
            try
            {
                var prttyp = repo.PartnerType.Where(p => p.Code == partnerTypeCode).FirstOrDefault();
                repo.PartnerType.Remove(prttyp);
                return repo.SaveChanges();
            }
            catch { throw; }
        }
    }
}
