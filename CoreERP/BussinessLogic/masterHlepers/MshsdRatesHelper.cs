using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class MshsdRatesHelper
    {
        public List<TblMshsdrates> GetListOfMshsdRates()
        {
            try
            {
                using Repository<TblMshsdrates> repo = new Repository<TblMshsdrates>();
                return repo.TblMshsdrates.ToList();
            }
            catch { throw; }
        }

        public List<TblMshsdrates> GetMshsdRatesList(string branchCode, int role)
        {
            try
            {
                using (Repository<TblMshsdrates> repo = new Repository<TblMshsdrates>())
                {
                    if (role == 1)
                    {
                        return repo.TblMshsdrates.OrderByDescending(m => m.ID).ToList();
                    }
                    return repo.TblMshsdrates.Where(m => m.BranchCode == branchCode).OrderByDescending(m => m.ID).ToList();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public  List<TblBranch> GetBranchesList()
        {
            try
            {
               return BrancheHelper.GetBranches();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<TblBranch> GetBranches(string branchCode = null)
        {
            try
            {
                using (Repository<TblBranch> repo = new Repository<TblBranch>())
                {
                    return repo.TblBranch.AsEnumerable().Where(b => b.BranchCode == (branchCode ?? b.BranchCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblProduct> GetProduct(string productCode=null)
        {
            try
            {
                using (Repository<TblProduct> repo = new Repository<TblProduct>())
                {
                    return repo.TblProduct.AsEnumerable().Where(b => b.ProductCode == (productCode?? b.ProductCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  TblMshsdrates Register(TblMshsdrates mshsdrates)
        {
            try
            {
                using (Repository<TblMshsdrates> repo = new Repository<TblMshsdrates>())
                {
                    var record = repo.TblMshsdrates.OrderByDescending(x => x.ID).FirstOrDefault();
                    if (record != null)
                    {
                        mshsdrates.ID = Convert.ToInt32(CommonHelper.IncreaseCode(record.ID.ToString()));
                    }
                    else
                    {
                        mshsdrates.ID = 1;
                    }
                    var _branch = GetBranches(mshsdrates.BranchCode).ToArray().FirstOrDefault();
                    var _product = GetProduct(mshsdrates.ProductCode).ToArray().FirstOrDefault();
                    //mshsdrates.BranchId = _branch.BranchId;
                    mshsdrates.BranchName = _branch.BranchName;
                    mshsdrates.ProductId = _product.ProductId;
                    mshsdrates.ProductName = _product.ProductName;
                    repo.TblMshsdrates.Add(mshsdrates);
                    if (repo.SaveChanges() > 0)
                        return mshsdrates;
                }
                return null;
            }
            catch { throw; }
        }


        public  TblMshsdrates Update(TblMshsdrates mshsdrates)
        {
            try
            {
                using Repository<TblMshsdrates> repo = new Repository<TblMshsdrates>();
                repo.TblMshsdrates.Update(mshsdrates);
                if (repo.SaveChanges() > 0)
                    return mshsdrates;

                return null;
            }
            catch { throw; }
        }

        public  TblMshsdrates Delete(int code)
        {
            try
            {
                using (Repository<TblMshsdrates> repo = new Repository<TblMshsdrates>())
                {
                    var mshsd = repo.TblMshsdrates.Where(x => x.ID == code).FirstOrDefault();
                    repo.TblMshsdrates.Remove(mshsd);
                    if (repo.SaveChanges() > 0)
                        return mshsd;
                }
                return null;
            }
            catch { throw; }
        }
    }
}
