using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class SalesGroupHelper
    {
        public static List<TblSalesGroup> GetList(string salesgrp)
        {
            try
            {
                using Repository<TblSalesGroup> repo = new Repository<TblSalesGroup>();
                return repo.TblSalesGroup.Where(x => x.Code == salesgrp).ToList();
            }
            catch { throw; }
        }

        public static List<TblSalesGroup> GetList()
        {
            try
            {
                using Repository<TblSalesGroup> repo = new Repository<TblSalesGroup>();
                return repo.TblSalesGroup.ToList();
            }
            catch { throw; }
        }

        public static TblSalesGroup Register(TblSalesGroup salesgrp)
        {
            try
            {
                using Repository<TblSalesGroup> repo = new Repository<TblSalesGroup>();
                repo.TblSalesGroup.Add(salesgrp);
                if (repo.SaveChanges() > 0)
                    return salesgrp;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblSalesGroup Update(TblSalesGroup salesogrp)
        {
            try
            {
                using Repository<TblSalesGroup> repo = new Repository<TblSalesGroup>();
                repo.TblSalesGroup.Update(salesogrp);
                if (repo.SaveChanges() > 0)
                    return salesogrp;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblSalesGroup Delete(string sgcode)
        {
            try
            {
                using Repository<TblSalesGroup> repo = new Repository<TblSalesGroup>();
                var sgccodes = repo.TblSalesGroup.Where(x => x.Code == sgcode).FirstOrDefault();
                repo.TblSalesGroup.Remove(sgccodes);
                if (repo.SaveChanges() > 0)
                    return sgccodes;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
