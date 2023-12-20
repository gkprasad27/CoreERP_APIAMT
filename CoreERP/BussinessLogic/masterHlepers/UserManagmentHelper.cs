using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class UserManagmentHelper
    {
        public IEnumerable<TblUserNew> GetEmployeeID(string userName)
        {
            try
            {
                return Repository<TblUserNew>.Instance.Where(x => x.UserName == userName);
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
               
                var _userNew = _repo.Erpuser.Where(u=> u.UserName  == erpuser.UserName)
                                 .FirstOrDefault();
               
                user.Role = _userNew?.Role.ToString();

                if(_userNew.Active == false)
                {
                    errorMessage = "User profile is inactive.contact to admin.";
                    return null;
                }


            }

            return user;

        }

        public static IEnumerable<Erpuser> GetErpuser(decimal seqiId)
        {
            try
            {
                return Repository<Erpuser>.Instance.Where(x => x.SeqId == seqiId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static IList<string> GetBranchesByUser(decimal SeqId)
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
        public static IEnumerable<Erpuser> GetErpusers()
        {
            try
            {
                return Repository<Erpuser>.Instance.GetAll().OrderBy(x => x.SeqId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Menus> GetMenus()
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

        #region Menus

        public static List<ExpandoObject> GetMenusForRole(string roleId)
        {
            try
            {
                List<ExpandoObject> menusbyRole = new List<ExpandoObject>();
                List<Menus> _subChilds = null;
                List<Menus> _subChilds1 = null;
                List<string> subHeader = new List<string>();

                var result = GetAuthentixatedMenus(roleId);
                var parentIDs = result.Select(m => m.ParentId).Distinct();

                foreach (var pid in parentIDs)
                {
                    //find childs menus by using parent id
                    List<Menus> menulst = GetAuthentixatedMenus(roleId, pid);

                    if (menulst.Count() > 0)
                    {
                        List<ExpandoObject> childList = new List<ExpandoObject>();
                        List<ExpandoObject> subchildList = null;
                        List<ExpandoObject> subchildList1 = null;

                        foreach (Menus m in menulst)
                        {
                            if (m.IsMasterScreen.Equals("Y", StringComparison.OrdinalIgnoreCase))
                                continue;

                            //chk weather child is parent for other or not
                            _subChilds = new List<Menus>();
                            _subChilds = GetAuthentixatedMenus(roleId, m.OperationCode);

                            if (_subChilds.Count() > 0)
                            {
                                subchildList = new List<ExpandoObject>();
                                subHeader.Add(m.OperationCode);
                                foreach (Menus subm in _subChilds)
                                {
                                    #region Depth 3
                                    _subChilds1 = GetAuthentixatedMenus(roleId, subm.OperationCode);
                                    if (_subChilds1.Count > 0)
                                    {
                                        subchildList1 = new List<ExpandoObject>();
                                        foreach (Menus subm1 in _subChilds1)
                                        {
                                            dynamic subChild1 = GetMenustructureObj(subm1, null);
                                            subchildList1.Add(subChild1);
                                        }
                                    }
                                    #endregion
                                    dynamic subChild = GetMenustructureObj(subm, subchildList1);
                                    subchildList1 = new List<ExpandoObject>();
                                    subchildList.Add(subChild);
                                }
                            }
                            dynamic expandoChild = GetMenustructureObj(m, subchildList);
                            childList.Add(expandoChild);
                        }

                        if (!subHeader.Contains(pid))
                        {
                            // parent Name along with its child menus
                            Menus mobj = GetMenu(pid);
                            if (mobj.IsMasterScreen.ToUpper() == "Y")
                            {
                                dynamic expandoObj = GetMenustructureObj(mobj, childList);

                                menusbyRole.Add(expandoObj);
                            }
                        }
                    }
                }
                return menusbyRole;
            }
            catch (Exception ex) { throw ex; }
        }


        private static List<Menus> GetAuthentixatedMenus(string roleId ,string parentId=null)
        {
            try
            {
                using(ERPContext _repo=new ERPContext())
                {
                    return (from ma in _repo.MenuAccesses
                            join m in _repo.Menus on ma.OperationCode equals m.OperationCode
                            where ma.RoleId == roleId  && ma.Access == 1 && ma.Active == true
                              && m.ParentId == (parentId ?? m.ParentId)
                            select m).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static ExpandoObject GetMenustructureObj(Menus m, List<ExpandoObject> childerns)
        {
            try
            {
                dynamic expandoObj = new ExpandoObject();
                expandoObj.displayName = m.DisplayName;
                expandoObj.screenType = m.ScreenType;
                expandoObj.route = m.Route;

                if (childerns != null && childerns.Count() > 0)
                    expandoObj.children = childerns;

                return expandoObj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Menus GetMenu(string operationCode)
        {
            try
            {
               return Repository<Menus>.Instance.Where(x => x.OperationCode == operationCode).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public TblRole GetRole(decimal roleId)
        {
            try
            {
                return Repository<TblRole>.Instance.Where(x => x.RoleId == roleId).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TblRole> GetRoles()
        {
            try
            {
                return Repository<TblRole>.Instance.GetAll().OrderBy(x => x.RoleId);
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
                List<string> parentIds = new List<string>();
                using (ERPContext _repo = new ERPContext())
                {
                    parentIds = _repo.Menus.Select(m => m.ParentId).Distinct().ToList();
                    return _repo.Menus.Where(m => parentIds.Contains(m.OperationCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public IEnumerable<MenuAccesses> GetMenus(string parentId, string roleId)
        {
            try
            {
                IEnumerable<Menus> _menus = null;
                MenuAccesses menuAccesses = null;
                List<MenuAccesses> _menusaccess = new List<MenuAccesses>();

                using (ERPContext _repo = new ERPContext())
                {
                    _menusaccess = (from ma in _repo.MenuAccesses
                                    join m in _repo.Menus on ma.OperationCode equals m.OperationCode
                                   where ma.RoleId == roleId
                                      && m.ParentId== parentId
                                   select ma).ToList();
                    //_menus = _repo.Menus.Where(m => m.ParentId == parentId).ToList();
                    _menus = Repository<Menus>.Instance.Where(x => x.ParentId == parentId);
                }


                foreach (MenuAccesses ma in _menusaccess)
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
                    ma.screenName = CommonHelper.GetMenu(ma.OperationCode)?.Route;
                    
                    if (ma.Active ==true )
                        ma.Access = 1;
                    else 
                      ma.Access = 0;

                    ma.CanView = true;

                    if (ma.MenuId == 0)
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
                using (ERPContext _repo = new ERPContext())
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
                using (ERPContext _repo = new ERPContext())
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
                var _shift = Repository<TblShift>.Instance.Where(x => x.UserId == userID
                                                            && x.BranchCode == branchCode);

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
                    //var _branch = BrancheHelper.GetBranches().Where(b => b.BranchCode == branchCode).FirstOrDefault();

                    _shift = new TblShift
                    {
                        UserId = userId,
                        Narration = "Shift in Progress.",
                        Status = 0,
                        EmployeeId = -1,
                        //BranchId = Convert.ToDecimal(_branch.BranchCode),
                        //BranchCode = _branch?.BranchCode,
                        //BranchName = _branch?.BranchName,
                        InTime = DateTime.Now,
                        OutTime = DateTime.Now
                    };

                    using (ERPContext _repo = new ERPContext())
                    {
                        _repo.TblShift.Add(_shift);
                        _repo.SaveChanges();
                    }
                }
                else
                {
                    //if user entry exists for today
                    using (ERPContext _repo = new ERPContext())
                    _shift = _repo.TblShift
.AsEnumerable()
.Where(x => DateTime.Parse(x.InTime.Value.ToShortDateString()) == DateTime.Parse((DateTime.Today).ToShortDateString())
&& x.UserId == userId
&& x.BranchCode == branchCode)
.FirstOrDefault();

                    _shift.OutTime = DateTime.Now;
                    _shift.Status = 0;
                    _shift.Narration = "Shift in Progress.";
                    Repository<TblShift>.Instance.Update(_shift);
                    if (Repository<TblCurrency>.Instance.SaveChanges() > 0) ;
                        //TblShift.Update(_shift);
                        //_repo.SaveChanges();
                }

                return _shift.ShiftId.ToString();
            }
            catch (Exception )
            {
                //throw Exception;
                return "-1";
            }
        }




        #endregion
        public TblUserNew GetUserNew(decimal userId)
        {
            try
            {
                using (ERPContext _repo = new ERPContext())
                {
                    return _repo.TblUserNew.Where(u=> u.UserId == userId).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public TblDynamicPages GetDynamicPages(string componentName)
        {
            try
            {
                componentName = componentName.Trim().ToLower();
                using (ERPContext _repo = new ERPContext())
                {
                  return  _repo.TblDynamicPages.Where(d => d.FormName.Trim().ToLower() == componentName).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       
    }
}
