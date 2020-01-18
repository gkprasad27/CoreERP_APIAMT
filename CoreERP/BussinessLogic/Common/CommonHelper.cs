using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.Common
{
    public class CommonHelper
    {
        public static string GetConfigurationValue(string module,string screenName,string keyName)
        {
            using(Repository<ErpConfiguration> context=new Repository<ErpConfiguration>())
            {
                return context.ErpConfiguration.AsEnumerable()
                              .Where(ep=> ep.Active.Equals("Y",StringComparison.OrdinalIgnoreCase)
                                      &&  ep.Module.Equals(module)
                                      &&  ep.Screen.Equals(screenName)
                                      &&  ep.KeyName.Equals(keyName)
                              ).First().Values;
            }
        }

        public static int? AutonGenerateNo(string groupName,string branchCode, int rangeStart, int rangeEnds,out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                var counters = GetCounter(branchCode);
                if(counters == null)
                {
                    AddNewCounter(branchCode, rangeStart);
                    return rangeStart;
                }
                
                counters.NumberRange += 1;
                if(counters.NumberRange > rangeEnds)
                {
                    errorMessage = "Range Exceedded.";
                    return null;
                }
                UpdateCounter(counters);

                return counters.NumberRange;
            }
            catch { throw; }
        }

        private static Counters GetCounter(string branchCode)
        {
            try
            {
                using (Repository<Counters> repo = new Repository<Counters>())
                {
                    return repo.Counters.AsEnumerable()
                                         .Where(c => c.BranchCode == branchCode)
                                         .FirstOrDefault();
                }
            }
            catch { throw; }
        }
        private static int AddNewCounter(string branchCode,int rangestarts)
        {
            try
            {
                using (Repository<Counters> repo = new Repository<Counters>())
                {
                    var cntObj = new Counters() {Active="Y" ,BranchCode=branchCode,NumberRange= rangestarts };
                    repo.Counters.Add(cntObj);
                    return repo.SaveChanges();
                }
            }
            catch { throw; }
        }


        private static int UpdateCounter(Counters counters)
        {
            try
            {
                using (Repository<Counters> repo = new Repository<Counters>())
                {
                    repo.Counters.Update(counters);
                    return repo.SaveChanges();
                }
            }
            catch { throw; }
        }
    }
}
