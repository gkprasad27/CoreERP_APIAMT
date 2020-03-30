using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.TransactionsHelpers
{
    public class PackageConversionHelper
    {
        public  List<TblPackageConversion> GetList(string Code)
        {
            try
            {
                using Repository<TblPackageConversion> repo = new Repository<TblPackageConversion>();
                return repo.TblPackageConversion
.Where(x => x.InputproductCode == Code)
.ToList();
            }
            catch { throw; }
        }
        public  List<TblProduct> GetInputcodeList()
        {
            try
            {
                using Repository<TblProduct> repo = new Repository<TblProduct>();
                return repo.TblProduct.ToList();
            }
            catch { throw; }
        }

        public  List<TblPackageConversion> GetList()
        {
            try
            {
                using Repository<TblPackageConversion> repo = new Repository<TblPackageConversion>();
                return repo.TblPackageConversion.ToList();
            }
            catch { throw; }
        }

        public  List<TblProduct> GetproductNames(string code)
        {
            try
            {
                using Repository<TblProduct> repo = new Repository<TblProduct>();
                return repo.TblProduct
.Where(x => x.ProductCode.Equals(code))
.ToList();
            }
            catch { throw; }
        }
      
        public  TblPackageConversion Register(TblPackageConversion packageconversion)
        {
            try
            {
                using Repository<TblPackageConversion> repo = new Repository<TblPackageConversion>();
                int outproductdata = Convert.ToInt32(repo.TblProduct.Where(x => x.ProductCode == packageconversion.OutputproductCode).Select(x => x.ProductId).FirstOrDefault());
                int inputproductdata = Convert.ToInt32(repo.TblProduct.Where(x => x.ProductCode == packageconversion.InputproductCode).Select(x => x.ProductId).FirstOrDefault());
                packageconversion.InputProductId = inputproductdata;
                packageconversion.OutputProductId = outproductdata;
                repo.TblPackageConversion.Add(packageconversion);
                if (repo.SaveChanges() > 0)
                    return packageconversion;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  TblPackageConversion Update(TblPackageConversion packageconversion)
        {
            try
            {
                using Repository<TblPackageConversion> repo = new Repository<TblPackageConversion>();
                if (packageconversion.InputProductId == 0 || packageconversion.OutputProductId == 0)
                {
                    int outproductdata = Convert.ToInt32(repo.TblProduct.Where(x => x.ProductCode == packageconversion.OutputproductCode).Select(x => x.ProductId).FirstOrDefault());
                    int inputproductdata = Convert.ToInt32(repo.TblProduct.Where(x => x.ProductCode == packageconversion.InputproductCode).Select(x => x.ProductId).FirstOrDefault());
                    packageconversion.InputProductId = inputproductdata;
                    packageconversion.OutputProductId = outproductdata;
                }

                repo.TblPackageConversion.Update(packageconversion);
                if (repo.SaveChanges() > 0)
                    return packageconversion;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  TblPackageConversion Delete(string Code)
        {
            try
            {
                using Repository<TblPackageConversion> repo = new Repository<TblPackageConversion>();
                var packgeconversion = repo.TblPackageConversion.Where(x => x.PackingConversionId == Convert.ToInt32(Code)).FirstOrDefault();
                repo.TblPackageConversion.Remove(packgeconversion);
                if (repo.SaveChanges() > 0)
                    return packgeconversion;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
