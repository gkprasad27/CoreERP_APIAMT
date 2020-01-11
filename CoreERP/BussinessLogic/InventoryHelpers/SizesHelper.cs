using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.InventoryHelpers
{
    public class SizesHelper
    {
        private static Repository<Sizes> _repo = null;
        private static Repository<Sizes> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<Sizes>();
                return _repo;
            }
        }
        public static int RegisterSizes(Sizes sizes)
        {
            try
            {
                var record = ((from acc in repo.Sizes select acc.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();

                if (record != 0)
                {
                    sizes.Code = (record + 1).ToString();
                }
                else
                    sizes.Code = "1";

                repo.Sizes.Add(sizes);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Sizes> GetSizesList()
        {
            try
            {
                return repo.Sizes.Select(x => x).ToList();
            }
            catch { throw; }
        }
        public static int UpdateSizes(Sizes sizes)
        {
            try
            {
                repo.Sizes.Update(sizes);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteSizes(string code)
        {
            try
            {
                var accountClass = repo.Sizes.Where(x => x.Code == code).FirstOrDefault();
                repo.Sizes.Remove(accountClass);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
