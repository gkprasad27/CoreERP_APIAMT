using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class SalesGroupHelper
    {
        public static IEnumerable<TblSalesGroup> GetList(string salesgrp)
        {
            try
            {
                return Repository<TblSalesGroup>.Instance.Where(x => x.Code == salesgrp);
            }
            catch { throw; }
        }

        public static IEnumerable<TblSalesGroup> GetList()
        {
            try
            {
                return Repository<TblSalesGroup>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblSalesGroup Register(TblSalesGroup salesgrp)
        {
            try
            {
                Repository<TblSalesGroup>.Instance.Add(salesgrp);
                if (Repository<TblSalesGroup>.Instance.SaveChanges() > 0)
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
                Repository<TblSalesGroup>.Instance.Update(salesogrp);
                if (Repository<TblSalesGroup>.Instance.SaveChanges() > 0)
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
                var ccode = Repository<TblSalesGroup>.Instance.GetSingleOrDefault(x => x.Code == sgcode);
                Repository<TblSalesGroup>.Instance.Remove(ccode);
                if (Repository<TblSalesGroup>.Instance.SaveChanges() > 0)
                    return ccode;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
