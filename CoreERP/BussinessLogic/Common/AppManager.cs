using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.Common
{
    public class AppManager
    {
        public static List<string> GetAppConfigValue(string groupName)
        {
            try
            {
                List<string> values = new List<string>();
                using (Repository<AppConfig> _repo = new Repository<AppConfig>())
                {
                    AppConfig appConfig = _repo.AppConfig.Where(app => app.GroupName == groupName).FirstOrDefault();
                    if (appConfig != null)
                    {
                        values = appConfig.Valu.Split(",").ToList();
                    }
                }

                return values;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
