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
     
        public static List<PartnerType> GetPartnerTypeList()
        {
            try
            {
                using (Repository<PartnerType> repo = new Repository<PartnerType>())
                {
                    return repo.PartnerType.AsEnumerable().Where(p => p.Active.Equals("Y",StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }



        public static PartnerType RegistePartnerType(PartnerType partnerType)
        {
            try
            {
                using (Repository<PartnerType> repo = new Repository<PartnerType>())
                {
                    partnerType.Active = "Y";
                    repo.PartnerType.Add(partnerType);
                    if (repo.SaveChanges() > 0)
                        return partnerType;

                    return null;
                }
            }
            catch { throw; }
        }



        public static PartnerType UpdatePartnerType(PartnerType partnerType)
        {
            try
            {
                using (Repository<PartnerType> repo = new Repository<PartnerType>())
                {
                    repo.PartnerType.Update(partnerType);
                    if (repo.SaveChanges() > 0)
                        return partnerType;

                    return null;
                }
            }
            catch { throw; }
        }



        public static PartnerType DeletePartnerType(string partnerTypeCode)
        {
            try
            {
                using (Repository<PartnerType> repo = new Repository<PartnerType>())
                {
                    var prttyp = repo.PartnerType.Where(p => p.Code == partnerTypeCode).FirstOrDefault();
                    prttyp.Active = "N";
                    repo.PartnerType.Update(prttyp);
                    if (repo.SaveChanges() > 0)
                        return prttyp;

                    return null;
                }
            }
            catch { throw; }
        }
    }
}
