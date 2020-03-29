using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class UserManagmentHelper
    {
        public  static Erpuser ValidateUser(Erpuser erpuser)
        {
            Erpuser user = null;
            using (Repository<Erpuser> _repo = new Repository<Erpuser>())
            {
               user = _repo.Erpuser
                             .Where(u => u.UserName.Equals(erpuser.UserName)
                             && u.Password.Equals(erpuser.Password)
                          ).FirstOrDefault();

              


                return user;
            }
        }

        public static List<string> GetBranchesByUser(decimal SeqId)
        {
            try
            {
                using(ERPContext context=new ERPContext())
                {
                    return context.TblUserBranch.Where(x => x.UserId == SeqId).FirstOrDefault().BranchName.Split(";")?.ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static List<Erpuser> GetErpusers()
        {
            try
            {
                using(Repository<Erpuser> repo=new Repository<Erpuser>())
                {
                    return repo.Erpuser.ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<Menus> GetMenus()
        {
            try
            {
                using (Repository<Menus> repo=new Repository<Menus>())
                {
                    return repo.Menus.ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static List<ExpandoObject> GetScreensListByUserRole(string userRole)
        {
            try
            {
                List<ExpandoObject> menusbyRole = new List<ExpandoObject>();

                using (Repository<Erpuser> _repo = new Repository<Erpuser>())
                {
                    var menuAccLst = _repo.MenuAccesses
                                  //.Where(m => m.RoleId == userRole)
                                  .OrderByDescending(x => x.AddDate)
                                  .FirstOrDefault()
                                  .Ext4.Split(',')
                                  .ToList();
                    var menuList = _repo.Menus
                                        .Where(x => menuAccLst.Contains(x.Code.ToString()))
                                        .ToList();
                    var parentIDs = menuList.Where(x => x.ParentId != null).Select(x => x.ParentId).Distinct();

                    foreach (var pid in parentIDs)
                    {
                        //find child menus by using parent id
                        List<Menus> menulst = _repo.Menus
                                              .Where(x => x.ParentId == pid)
                                              .ToList();
                        // create Array structure for UI to show menus
                        if (menulst.Count() > 0)
                        {
                            List<ExpandoObject> childList = new List<ExpandoObject>();
                            Menus mobj = menuList.Where(m => m.Code.ToString() == pid).FirstOrDefault();

                            // this is for to Add headers of Parent
                            foreach (Menus m in menulst)
                            {
                                dynamic expandoChild = new ExpandoObject();
                                expandoChild.displayName = m.DisplayName;
                                expandoChild.iconName = m.IconName;
                                expandoChild.route = m.Route;

                                if (!m.IsMasterScreen.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                    childList.Add(expandoChild);
                            }

                            // parent Name along with its child menus
                            dynamic expandoObj = new ExpandoObject();
                            expandoObj.displayName = mobj.DisplayName;
                            expandoObj.iconName = mobj.IconName;
                            expandoObj.route = mobj.Route;
                            expandoObj.children = childList;

                            menusbyRole.Add(expandoObj);
                        }

                    }

                    return menusbyRole;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private bool isShiftIdExists(decimal userID,string branchCode)
        {
            try
            {
                using (Repository<TblShift> _repo=new Repository<TblShift>())
                {
                    var _shift= _repo.TblShift
                                .Where(x => x.UserId == userID 
                                        && x.BranchCode == branchCode)
                                .ToList();
                    // DateTime.Parse(x.InTime.Value.ToShortDateString()) == DateTime.Parse((DateTime.Today).ToShortDateString())
                    var result = _shift.Where(x=> DateTime.Parse(x.InTime.Value.ToShortDateString()) == DateTime.Parse((DateTime.Today).ToShortDateString())).Count() > 0;

                    return result;
                }
            }
            catch
            {
                return false;
            }
        }

        public string GetShiftId(decimal userId,string branchCode)
        {
            try
            {
                TblShift _shift = null;

                if (!isShiftIdExists(userId, branchCode)) 
                {
                    var _branch = BrancheHelper.GetBranches().Where(b => b.BranchCode == branchCode).FirstOrDefault();
                  
                    _shift = new TblShift();
                    _shift.UserId = userId;
                    _shift.Narration = "Shift in Progress.";
                    _shift.Status = 0;
                    _shift.EmployeeId = -1;
                    _shift.BranchId = _branch?.BranchId;
                    _shift.BranchCode = _branch?.BranchCode;
                    _shift.BranchName = _branch?.BranchName;
                    _shift.InTime = DateTime.Now;
                    _shift.OutTime = DateTime.Now;

                    using (Repository<TblShift> _repo = new Repository<TblShift>())
                    {
                        _repo.TblShift.Add(_shift);
                        _repo.SaveChanges();
                    } 
                }
                else
                {
                    //if user entry exists for today
                    using (Repository<TblShift> _repo = new Repository<TblShift>())
                    {
                        _shift = _repo.TblShift
                                  .AsEnumerable()
                                .Where(x => DateTime.Parse(x.InTime.Value.ToShortDateString()) == DateTime.Parse((DateTime.Today).ToShortDateString())
                                        && x.UserId == userId
                                        && x.BranchCode == branchCode)
                                 .FirstOrDefault();
                    }
                }

                return _shift.ShiftId.ToString();
            }
            catch (Exception ex)
            {
                //throw Exception;
                return "-1";
            }
        }

        public void LogoutShiftId(decimal userId, string branchCode,out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                if (isShiftIdExists(userId, branchCode))
                {
                    using (Repository<TblShift> _repo = new Repository<TblShift>())
                    {
                     var  _shift = _repo.TblShift
                                  .Where(x => x.UserId == userId
                                         && x.BranchCode == branchCode)
                                .OrderByDescending(s=> s.InTime)
                                .FirstOrDefault();

                        _shift.OutTime = DateTime.Now;
                        _shift.Narration = "Shift Logged Out";

                        _repo.TblShift.Update(_shift);
                        _repo.SaveChanges();
                    }
                }
                else
                {
                    errorMessage = $"No Shift created for user  {userId} and branch Code {branchCode}";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
 //{
 //     displayName: 'dashboard',
 //     iconName: 'recent_actors',
 //     route: 'dashboard',
 //     children: [
 //       {
 //         displayName: 'table',
 //         iconName: 'group',
 //         route: 'dashboard/table'
 //       },
 //       {
 //         displayName: 'Sessions',
 //         iconName: 'speaker_notes',
 //         route: 'devfestfl/sessions'
 //       },
 //       {
 //         displayName: 'Feedback',
 //         iconName: 'feedback',
 //         route: 'devfestfl/feedback'
 //       }
 //     ]
 //   }