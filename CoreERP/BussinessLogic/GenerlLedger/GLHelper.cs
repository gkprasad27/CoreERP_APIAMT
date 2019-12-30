using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.GenerlLedger
{
    public class GLHelper
    {
        private static Repository<Glaccounts> _repo = null;
        private static Repository<Glaccounts> repo
        {
            get
            {
                if (_repo == null)
                    _repo = new Repository<Glaccounts>();
                return _repo;
            }
        }


        public static List<Glaccounts> GetGLAccountsList()
        {
            try
            {
                return repo.Glaccounts.Select(gl => gl).ToList();
            }
            catch { throw; }
        }


        public static List<MatTranTypes> GetMatTranTypesList()
        {
            try
            {

                return repo.MatTranTypes.Select(m => m).ToList();
            }
            catch (Exception ex) { throw ex; }
        }


        public static List<MaterialGroup> GetMaterialGroupsList()
        {
            try
            {
                return repo.MaterialGroup.Select(m => m).ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<AsignmentAcctoAccClass> GetAccountToAccountClassList()
        {
            try
            {
                return repo.AsignmentAcctoAccClass.Select(m => m).ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<TaxMasters> GetTaxMasterList()
        {
            try
            {
                return repo.TaxMasters.Select(m => m).ToList();
            }
            catch (Exception ex) { throw ex; }
        }
        public static List<TaxIntegration> GetTaxIntegrationList()
        {
            try
            {
                return repo.TaxIntegration.Select(m => m).ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public static List<BrandModel> GetModelList()
        {
            try
            {
                return repo.BrandModel.Select(m => m).ToList();
            }
            catch (Exception ex) { throw ex; }
        }

    }
}
