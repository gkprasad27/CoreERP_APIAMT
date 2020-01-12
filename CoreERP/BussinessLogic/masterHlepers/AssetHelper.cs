using CoreERP.BussinessLogic.GenerlLedger;
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
        public static List<AssetMaster> GetList()
        {
            try
            {
                using (Repository<AssetMaster> repo = new Repository<AssetMaster>())
                {
                    return repo.AssetMaster.AsEnumerable().Where(a=> a.Active.Equals("Y",StringComparison.OrdinalIgnoreCase)).ToList();
                }
            }
            catch { throw; }
        }

        public static AssetMaster GetList(string assetNo)
        {
            try
            {
                return GetList().Where(x => x.AssetNo == assetNo).FirstOrDefault();
            }
            catch { throw; }
        }



        public static AssetMaster RegisterAssetMaster(AssetMaster assetMaster)
        {
            try
            {
                using (Repository<AssetMaster> repo = new Repository<AssetMaster>())
                {
                    var record = ((from asiacc in repo.AssetMaster select asiacc.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();
                    if (record != 0)
                    {
                        // noSeries.Code = (int.Parse(lstrcd.Code) + 1).ToString(); 
                        assetMaster.Code = (record + 1).ToString();
                    }
                    else
                        assetMaster.Code = "1";

                    assetMaster.Active = "Y";
                    repo.AssetMaster.Add(assetMaster);
                    if (repo.SaveChanges() > 0)
                        return assetMaster;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static AssetMaster UpdateAssetMaster(AssetMaster assetMaster)
        {
            try
            {
                using (Repository<AssetMaster> repo = new Repository<AssetMaster>())
                {
                    repo.AssetMaster.Update(assetMaster);
                    if (repo.SaveChanges() > 0)
                        return assetMaster;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static AssetMaster DeleteAssetMaster(string code)
        {
            try
            {
                using (Repository<AssetMaster> repo = new Repository<AssetMaster>())
                {
                    var assetMaster = repo.AssetMaster.Where(x => x.Code == code).FirstOrDefault();
                    assetMaster.Active = "N";
                    repo.AssetMaster.Update(assetMaster);
                    if (repo.SaveChanges() > 0)
                        return assetMaster;

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //return Ok( new {

        //    assetmasterlist=AssetHelper.GetList()
        //    //glAssetAccts=_unitOfWork.GLAccounts.GetAll().Where(x=>x.Nactureofaccount == "FIXEDASSETS"),
        //noSeriesAssetRcd =(from nos in _unitOfWork.NoSeries.GetAll()
        //                   join pt  in _unitOfWork.PartnerType.GetAll()
        //                   on nos.PartnerType equals pt.Code
        //                   where pt.AccountType == "FIXEDASSETS"
        //                   select nos),
        //    ////branch =BrancheHelper.GetBranches(),
        //    //company =CompaniesHelper.GetListOfCompanies()
        //});

        public static List<Glaccounts> GetGlaccounts()
        {
            try
            {
                return GLHelper.GetGLAccountsList()
                               .Where(gl=> gl.Nactureofaccount.Equals(NatureOfAccounts.FIXEDASSETS.ToString(),StringComparison.OrdinalIgnoreCase))
                               .ToList();
            }
            catch { throw; }
        }
        public static NoSeries GetNoSeries()
        {
            try
            {
                return (from nos in NoSeriesHelper.GetAllNoSeriesLists()
                        join pt in PartnerTypeHelper.GetPartnerTypeList()
                        on nos.PartnerType equals pt.Code
                        where pt.AccountType.Equals("FIXEDASSETS")
                        select nos).OrderByDescending(x => x.Code).FirstOrDefault();
            }
            catch { throw; }
        }
        
        public static string AutoIncrementAssetNo()
        {
            try
            {
                var noSeries = GetNoSeries();

                int startno = 0, endno = 0, max = 0;
                if (noSeries != null)
                {
                    if (noSeries.NoType == "AUTO")
                    {

                        var noRange = noSeries.NumberSeries.Split("-");
                        if (noRange.Count() == 1)
                        {
                            startno = Convert.ToInt32(noRange[0]);
                            endno = Convert.ToInt32(noRange[0]);
                        }
                        else
                        {
                            startno = Convert.ToInt32(noRange[0]);
                            endno = Convert.ToInt32(noRange[1]);
                        }

                        var aseetMasterObj = AssetHelper.GetList().Where(x => x.Ext2 == noSeries.Code).OrderByDescending(x => x.AssetNo).FirstOrDefault();

                        if (aseetMasterObj != null)
                        {
                            max = Convert.ToInt32(aseetMasterObj.AssetNo);
                            if ((max + 1) > endno)
                            {
                                return ("No Series Rage Exceeded");
                            }
                            else
                                max = max + 1;
                        }
                        else
                            max = startno;
                    }
                    else
                        return string.Empty;
                }
                return max.ToString();
            }
            catch { throw; }
        }
    }
}
