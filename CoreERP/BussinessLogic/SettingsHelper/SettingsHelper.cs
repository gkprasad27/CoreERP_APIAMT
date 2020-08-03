using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.SettingsHelper
{
    public class SettingsHelper
    {

        public IEnumerable<Menus> GetMenusList()
        {
            try
            {
                return Repository<Menus>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<Menus> GetParentMenusList()
        {
            try
            {
               return Repository<Menus>.Instance.Where(m => m.Code.ToString() == m.ParentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
