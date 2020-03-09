using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class ProductpackingHelpers
    {
        public  List<TblProductPacking> GetList(string code)
        {
            try
            {
                using (Repository<TblProductPacking> repo = new Repository<TblProductPacking>())
                {
                    return repo.TblProductPacking
                               .Where(x => x.PackingCode == code)
                               .ToList();
                }
            }
            catch { throw; }
        }

        public  List<TblProductPacking> GetList()
        {
            try
            {
                using (Repository<TblProductPacking> repo = new Repository<TblProductPacking>())
                {
                    return repo.TblProductPacking.ToList();
                }
            }
            catch { throw; }
        }

        public  TblProductPacking Register(TblProductPacking productpak)
        {
            try
            {
                using (Repository<TblProductPacking> repo = new Repository<TblProductPacking>())
                {
                    if(productpak!=null)
                    {
                        //if(productpak.BarrelVerify==true)
                        //{

                        //}
                    }
                    repo.TblProductPacking.Add(productpak);
                    if (repo.SaveChanges() > 0)
                        return productpak;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  TblProductPacking Update(TblProductPacking productpack)
        {
            try
            {
                using (Repository<TblProductPacking> repo = new Repository<TblProductPacking>())
                {
                    repo.TblProductPacking.Update(productpack);
                    if (repo.SaveChanges() > 0)
                        return productpack;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  TblProductPacking Delete(string Code)
        {
            try
            {
                using (Repository<TblProductPacking> repo = new Repository<TblProductPacking>())
                {
                    var productpack = repo.TblProductPacking.Where(x => x.PackingId ==Convert.ToUInt32(Code)).FirstOrDefault();
                    repo.TblProductPacking.Remove(productpack);
                    if (repo.SaveChanges() > 0)
                        return productpack;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
