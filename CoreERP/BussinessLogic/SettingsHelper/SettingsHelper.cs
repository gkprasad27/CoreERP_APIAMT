using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SettingsHelper
{
    public class SettingsHelper
    {

        public List<Menus> GetMenusList()
        {
            try
            {
                using(Repository<Menus> repo=new Repository<Menus>())
                {
                    return repo.Menus.ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public List<Menus> GetParentMenusList()
        {
            try
            {
                using (Repository<Menus> repo = new Repository<Menus>())
                {
                    return repo.Menus.Where(m=> m.Code.ToString() == m.ParentId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
