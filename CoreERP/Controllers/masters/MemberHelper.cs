using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.DataAccess;
using CoreERP.Models;

namespace CoreERP.Controllers.masters
{
    public class MemberHelper
    {
        public List<TblMemberMaster> GetMembersByName(string memberName)
        {
            try
            {
                using (Repository<TblMemberMaster>    repo=new Repository<TblMemberMaster>())
                {
                    return repo.TblMemberMaster.Where(m=> m.MemberName.Contains(memberName)).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
