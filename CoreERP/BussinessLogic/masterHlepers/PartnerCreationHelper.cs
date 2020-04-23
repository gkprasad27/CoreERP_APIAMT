using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class PartnerCreationHelper
    {
        public static List<PartnerCreation> GetList()
        {
            try
            {
                //using Repository<PartnerCreation> repo = new Repository<PartnerCreation>();
                //return repo.PartnerCreation.ToList();
                return null;
            }
            catch { throw; }
        }

        public static PartnerCreation RegisterPartnerCreation(PartnerCreation partnerCreation)
        {
            try
            {
                //using Repository<PartnerCreation> repo = new Repository<PartnerCreation>();
                //partnerCreation.Active = "Y";
                //partnerCreation.AddDate = DateTime.Now;
                //partnerCreation.EditDate = DateTime.Now;

                //var record = ((from prtnrcrt in repo.PartnerCreation select prtnrcrt.Code).ToList()).ConvertAll<Int64>(Int64.Parse).OrderByDescending(x => x).FirstOrDefault();
                //if (record != 0)
                //{
                //    partnerCreation.Code = (record + 1).ToString();
                //}
                //else
                //    partnerCreation.Code = "1";

                //repo.PartnerCreation.Add(partnerCreation);
                //if (repo.SaveChanges() > 0)
                //    return partnerCreation;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PartnerCreation UpdatePartnerCreation(PartnerCreation partnerCreation)
        {
            try
            {
                //using Repository<PartnerCreation> repo = new Repository<PartnerCreation>();
                //repo.PartnerCreation.Update(partnerCreation);
                //if (repo.SaveChanges() > 0)
                //    return partnerCreation;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PartnerCreation DeletePartnerCreation(string code)
        {
            try
            {
                //using Repository<PartnerCreation> repo = new Repository<PartnerCreation>();
                //var partnerCreation = repo.PartnerCreation.Where(x => x.Code == code).FirstOrDefault();
                //partnerCreation.Active = "N";
                //repo.PartnerCreation.Update(partnerCreation);
                //if (repo.SaveChanges() > 0)
                //    return partnerCreation;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<string> GetBalanceType()
        {
            try
            {
                return new List<string>() { NATURESOFACCOUNTS.DR.ToString(), NATURESOFACCOUNTS.CR.ToString() };
                //return Common.CommonHelper.GetConfigurationValue("MASTER", "NUMBERSERIES", "BALANCETYPE").Split(',').ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static List<string> GetNatureList()
        //{
        //    try
        //    {
        //        return Common.CommonHelper.GetConfigurationValue("MASTER", "NUMBERSERIES", "NATURE").Split(',').ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        #region old code
        // return Ok(_unitOfWork.PartnerCreation.GetAll());
        //return Json(new {
        //    company=_unitOfWork.Companys.GetAll(),
        //    branches=_unitOfWork.Branches.GetAll(),
        //    partnertype =_unitOfWork.PartnerType.GetAll(),
        //    partnercreation=_unitOfWork.PartnerCreation.GetAll().OrderBy(x=> int.Parse(x.Code)),
        //    glaccount = (from glacc in ( from  glaccount1 in _unitOfWork.GLAccounts.GetAll()
        //                                where  glaccount1.Nactureofaccount != null
        //                               select  glaccount1)
        //                  where glacc.Nactureofaccount.ToUpper() == NatureOfAccounts.TRADECUSTOMER.ToString().ToUpper() ||
        //                        glacc.Nactureofaccount.ToUpper() == NatureOfAccounts.TRADEVENDORS.ToString().ToUpper()
        //                  select glacc)

        //});
        #endregion

        public static List<Companies> GetCompanies()
        {
            try
            {
                return CompaniesHelper.GetListOfCompanies();
            }catch
            { throw; }
        }
        //public static List<Branches> GetBranches()
        //{
        //    try
        //    {
        //        return BrancheHelper.GetBranches();
        //    }
        //    catch
        //    { throw; }
        //}
        //public static List<PartnerType> GetPartnerTypes()
        //{
        //    try
        //    {
        //        return PartnerTypeHelper.GetPartnerTypeList();
        //    }
        //    catch
        //    { throw; }
        //}
        public static List<Glaccounts> GetGlaccounts()
        {
            try
            {
                return GLHelper.GetGLAccountsList()
                               .Where(glacc => glacc.Nactureofaccount.ToUpper() == NATURESOFACCOUNTS.TRADECUSTOMER.ToString().ToUpper()
                                            || glacc.Nactureofaccount.ToUpper() == NATURESOFACCOUNTS.TRADEVENDORS.ToString().ToUpper()
                               ).ToList();
            }
            catch
            { throw; }
        }
    }
}
