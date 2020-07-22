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
        public TblUserNew GetEmployeeID(string userName)
        {
            try
            {
                using(Repository<TblUserNew> _repo=new Repository<TblUserNew>())
                {
                   return _repo.TblUserNew.Where(u => u.UserName == userName).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static Erpuser ValidateUser(Erpuser erpuser,out string errorMessage)
        {
            Erpuser user = null;
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(erpuser.UserName))
            {
                errorMessage = "Username Can not be empty.";
                return null;
            }

            if (string.IsNullOrEmpty(erpuser.Password))
            {
                errorMessage = "Password Can not be empty.";
                return null;
            }

            using (ERPContext _repo = new ERPContext())
            {
                user = _repo.Erpuser
                                .Where(u => u.UserName.Equals(erpuser.UserName)
                                && u.Password.Equals(erpuser.Password)
                                ).FirstOrDefault();


                if(user == null)
                {
                    errorMessage = "User name /password not valid.";
                    return null;
                }
               
                var _userNew = _repo.TblUserNew.Where(u=> u.UserName  == erpuser.UserName)
                                 .FirstOrDefault();
               
                user.Role = _userNew?.RoleId.ToString();

                if(_userNew.Active == false)
                {
                    errorMessage = "User profile is inactive.contact to admin.";
                    return null;
                }


            }

            return user;

        }

        public Erpuser GetErpuser(decimal seqiId)
        {
            try
            {
                using Repository<Erpuser> _repo = new Repository<Erpuser>();
                return _repo.Erpuser.Where(u => u.SeqId == seqiId).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static List<string> GetBranchesByUser(decimal SeqId)
        {
            try
            {
                using ERPContext context = new ERPContext();
                return context.TblUserBranch.Where(x => x.UserId == SeqId).FirstOrDefault().BranchName.Split(";")?.ToList();
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
                using Repository<Erpuser> repo = new Repository<Erpuser>();
                return repo.Erpuser.ToList();
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
                using (Repository<Menus> repo = new Repository<Menus>())
                {
                    return repo.Menus.ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static List<ExpandoObject> GetScreensListByUserRole(string userName)
        {
            try
            {
                List<ExpandoObject> menusbyRole = new List<ExpandoObject>();

                using (ERPContext _repo = new ERPContext())
                {
                    var _MenuAccesses = _repo.MenuAccesses.Where(m => m.Ext1.Trim() == userName.Trim()).FirstOrDefault();
                    List<string> menuAccLst = _MenuAccesses.Ext4.Split(',').ToList();
                    var parentIDs = _repo.Menus
                                         .Where(x => menuAccLst.Contains(x.OperationCode) 
                                                  && x.Active == "Y" 
                                                  && x.IsMasterScreen == "Y")
                                         .Select(m=> m.OperationCode).Distinct().ToList();

                    foreach (var pid in parentIDs)
                    {
                        //find childs menus by using parent id
                        List<Menus> menulst = _repo.Menus
                                              .Where(x => x.ParentId == pid 
                                               && x.Active =="Y")
                                              .ToList();
                       
                        // create Array structure for UI to show menus
                        if (menulst.Count() > 0)
                        {
                            List<ExpandoObject> childList = new List<ExpandoObject>();

                            // Add childs in list
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
                            Menus mobj = _repo.Menus.Where(m => m.OperationCode == pid).FirstOrDefault();
                            dynamic expandoObj = new ExpandoObject();
                            expandoObj.displayName = mobj.DisplayName;
                            expandoObj.iconName = mobj.IconName;
                            expandoObj.route = mobj.Route;
                            expandoObj.children = childList;

                            menusbyRole.Add(expandoObj);
                        }

                    }
                }
                return menusbyRole;
            }
            catch (Exception ex) { throw ex; }
        }

        #region Menus

        public static List<ExpandoObject> GetMenusForRole(string roleId)
        {
            try
            {
                List<ExpandoObject> menusbyRole = new List<ExpandoObject>();

                using (ERPContext _repo = new ERPContext())
                {

                    var result = (from ma in _repo.MenuAccesses
                                  join m in _repo.Menus on ma.OperationCode equals m.OperationCode
                                 where ma.RoleId == roleId
                                    && ma.Access == 1
                                    && ma.Active == true
                                  select m); ;

                    var parentIDs = result.Select(m => m.ParentId).Distinct();

                    foreach (var pid in parentIDs)
                    {
                        //find childs menus by using parent id
                        List<Menus> menulst = result.Where(x => x.ParentId == pid && x.Active == "Y").ToList();

                        // create Array structure for UI to show menus
                        if (menulst.Count() > 0)
                        {
                            List<ExpandoObject> childList = new List<ExpandoObject>();

                            // Add childs in list
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
                            Menus mobj = _repo.Menus.Where(m => m.OperationCode == pid).FirstOrDefault();
                            dynamic expandoObj = new ExpandoObject();
                            expandoObj.displayName = mobj.DisplayName;
                            expandoObj.iconName = mobj.IconName;
                            expandoObj.route = mobj.Route;
                            expandoObj.children = childList;

                            menusbyRole.Add(expandoObj);
                        }

                    }
                }
                return menusbyRole;
            }
            catch (Exception ex) { throw ex; }
        }

        public TblRole GetRole(decimal roleId)
        {
            try
            {
                using(Repository<TblRole> _repo=new Repository<TblRole>())
                {
                    return _repo.TblRole.Where(r => r.RoleId == roleId).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<TblRole> GetRoles()
        {
            try
            {
                using (Repository<TblRole> _repo = new Repository<TblRole>())
                {
                    return _repo.TblRole.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Menus> GetParentMenus()
        {
            try
            {
                using (Repository<Menus> _repo = new Repository<Menus>())
                {
                    return _repo.Menus.Where(x => x.IsMasterScreen == "Y").ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
       
        public List<MenuAccesses> GetMenus(string parentId, string roleId)
        {
            try
            {
                List<Menus> _menus = null;
                MenuAccesses menuAccesses = null;
                List<MenuAccesses> _menusaccess = new List<MenuAccesses>();
               
                using (Repository<Menus> _repo = new Repository<Menus>())
                {
                    _menusaccess = (from ma in _repo.MenuAccesses
                                    join m in _repo.Menus on ma.OperationCode equals m.OperationCode
                                   where ma.RoleId == roleId
                                      && m.ParentId== parentId
                                   select ma).ToList();
                    _menus = _repo.Menus.Where(m => m.ParentId == parentId).ToList();
                }


                foreach(MenuAccesses ma in _menusaccess)
                {
                    if (string.IsNullOrEmpty(ma.Ext4))
                        ma.Ext4 = _menus.Where(m => m.OperationCode == ma.OperationCode).FirstOrDefault()?.Description;

                    if (ma.Active == null)
                        ma.Active = false;

                   
                }

                foreach (Menus m in _menus)
                {
                    if (m.OperationCode == m.ParentId)
                        continue;

                    if (_menusaccess.Where(ma => ma.OperationCode == m.OperationCode).Count() > 0)
                        continue;
                    else
                    {
                        menuAccesses = new MenuAccesses();
                        menuAccesses.OperationCode = m.OperationCode;
                        menuAccesses.Ext4 = m.Description;
                        menuAccesses.Active = null;
                        menuAccesses.CanAdd = false;
                        menuAccesses.CanEdit = false;
                        menuAccesses.CanDelete = false;
                        menuAccesses.CanView = true;

                        _menusaccess.Add(menuAccesses);
                    }
                }

                return _menusaccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GiveAcces(List<MenuAccesses> menus,string roleId)
        {
            try
            {
                var  _role = GetRole(Convert.ToDecimal(roleId));
                foreach(MenuAccesses ma in menus)
                {
                    if (ma.Active ==true )
                        ma.Access = 1;
                    else 
                      ma.Access = 0;

                    ma.CanView = true;

                    if (ma.MenuId == null)
                    {
                        ma.RoleId = Convert.ToString(_role.RoleId);
                        AddMenuAccess(ma);
                    }
                    else
                        UpdateMenuAccess(ma);
                }
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private bool AddMenuAccess(MenuAccesses menuAccesses)
        {
            try
            {
                using (Repository<MenuAccesses> _repo = new Repository<MenuAccesses>())
                {
                    _repo.MenuAccesses.Add(menuAccesses);
                    return _repo.SaveChanges() > 0;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private bool UpdateMenuAccess(MenuAccesses menuAccesses)
        {
            try
            {
                using (Repository<MenuAccesses> _repo = new Repository<MenuAccesses>())
                {
                    _repo.MenuAccesses.Update(menuAccesses);
                    return _repo.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Shift master
        private bool IsShiftIdExists(decimal userID,string branchCode)
        {
            try
            {
                using Repository<TblShift> _repo = new Repository<TblShift>();
                var _shift = _repo.TblShift
.Where(x => x.UserId == userID
&& x.BranchCode == branchCode)
.ToList();
                // DateTime.Parse(x.InTime.Value.ToShortDateString()) == DateTime.Parse((DateTime.Today).ToShortDateString())
                var result = _shift.Where(x => DateTime.Parse(x.InTime.Value.ToShortDateString()) == DateTime.Parse((DateTime.Today).ToShortDateString())).Count() > 0;

                return result;
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
               
                if (string.IsNullOrEmpty(branchCode))
                {
                    var branches = GetBranchesByUser(userId);
                    branchCode = branches.FirstOrDefault();
                }

                if (!IsShiftIdExists(userId, branchCode)) 
                {
                    var _branch = BrancheHelper.GetBranches().Where(b => b.BranchCode == branchCode).FirstOrDefault();

                    _shift = new TblShift
                    {
                        UserId = userId,
                        Narration = "Shift in Progress.",
                        Status = 0,
                        EmployeeId = -1,
                        BranchId = _branch?.BranchId,
                        BranchCode = _branch?.BranchCode,
                        BranchName = _branch?.BranchName,
                        InTime = DateTime.Now,
                        OutTime = DateTime.Now
                    };

                    using (Repository<TblShift> _repo = new Repository<TblShift>())
                    {
                        _repo.TblShift.Add(_shift);
                        _repo.SaveChanges();
                    }
                }
                else
                {
                    //if user entry exists for today
                    using Repository<TblShift> _repo = new Repository<TblShift>();
                    _shift = _repo.TblShift
.AsEnumerable()
.Where(x => DateTime.Parse(x.InTime.Value.ToShortDateString()) == DateTime.Parse((DateTime.Today).ToShortDateString())
&& x.UserId == userId
&& x.BranchCode == branchCode)
.FirstOrDefault();

                    _shift.OutTime = DateTime.Now;
                    _shift.Status = 0;
                    _shift.Narration = "Shift in Progress.";

                    _repo.TblShift.Update(_shift);
                    _repo.SaveChanges();
                }

                return _shift.ShiftId.ToString();
            }
            catch (Exception )
            {
                //throw Exception;
                return "-1";
            }
        }


        public TblShift StartShift(decimal userId, string branchCode)
        {
            try
            {
                var _branch = BrancheHelper.GetBranches().Where(b => b.BranchCode == branchCode).FirstOrDefault();

                TblShift _shift = new TblShift
                {
                    UserId = userId,
                    Narration = "Shift in Progress.",
                    Status = 0,
                    EmployeeId = -1,
                    BranchId = _branch?.BranchId,
                    BranchCode = _branch?.BranchCode,
                    BranchName = _branch?.BranchName,
                    InTime = DateTime.Now,
                    OutTime = DateTime.Now
                };

                using (Repository<TblShift> _repo = new Repository<TblShift>())
                {

                    _repo.TblShift.Add(_shift);
                    _repo.SaveChanges();
                }

                return _shift;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool EndShift(decimal shiftId)
        {
            try
            {
                TblShift _shift = null;
                using (Repository<TblShift> _repo = new Repository<TblShift>())
                {
                    _shift = _repo.TblShift
                                  .Where(s => s.ShiftId == shiftId)
                                  .FirstOrDefault();

                    _shift.OutTime = DateTime.Now;
                    _shift.Status = 1;
                    _shift.Narration = "Shift Logged Out";

                    _repo.TblShift.Update(_shift);
                    if (_repo.SaveChanges() > 0)
                        return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void LogoutShiftId(decimal userId, string branchCode,out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                if (IsShiftIdExists(userId, branchCode))
                {
                    using Repository<TblShift> _repo = new Repository<TblShift>();
                    var _shift = _repo.TblShift
.Where(x => x.UserId == userId
&& x.BranchCode == branchCode)
.OrderByDescending(s => s.InTime)
.FirstOrDefault();

                    _shift.OutTime = DateTime.Now;
                    _shift.Status = 1;
                    _shift.Narration = "Shift Logged Out";

                    _repo.TblShift.Update(_shift);
                    _repo.SaveChanges();
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
        #endregion
        public TblUserNew GetUserNew(decimal userId)
        {
            try
            {
                using(Repository<TblUserNew> _repo=new Repository<TblUserNew>())
                {
                    return _repo.TblUserNew.Where(u=> u.UserId == userId).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                return null;
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