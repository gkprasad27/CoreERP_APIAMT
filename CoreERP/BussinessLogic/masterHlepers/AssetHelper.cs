using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class AssetHelper
    {
        private static Repository<AssetMaster> _repo = null;
        private static Repository<AssetMaster> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<AssetMaster>();
                return _repo;
            }
        }


        public static List<AssetMaster> GetList()
        {
            try
            {
                return repo.AssetMaster.ToList();
            }
            catch { throw; }
        }

      

        public static int RegisterAssetMaster(AssetMaster assetMaster)
        {
            try
            {
                var record = ((from asiacc in repo.AssetMaster select asiacc.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();
                //var lstrcd = (from noasg in repo.NoSeries
                //           .OrderByDescending(p => p.Code)
                //              select noasg).FirstOrDefault();
                if (record !=0)
                {
                    // noSeries.Code = (int.Parse(lstrcd.Code) + 1).ToString(); 
                    assetMaster.Code = (record + 1).ToString();
                }
                else
                    assetMaster.Code = "1";
                
                repo.AssetMaster.Add(assetMaster);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateAssetMaster(AssetMaster assetMaster)
        {
            try
            {
                repo.AssetMaster.Update(assetMaster);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteAssetMaster(string code)
        {
            try
            {
                var assetMaster = repo.AssetMaster.Where(x => x.Code == code).FirstOrDefault();
                repo.AssetMaster.Remove(assetMaster);
                return repo.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
