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
    }
}
