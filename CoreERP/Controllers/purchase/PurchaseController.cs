using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CoreERP.BussinessLogic.PurhaseHelpers;
using CoreERP.Models;
using CoreERP.DataAccess;
using System.Dynamic;
using CoreERP.BussinessLogic.SalesHelper;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Purchase/purchases")]
    public class PurchaseController : ControllerBase
    {
        #region Purchase 

        [HttpGet("getPurchaseList")]
        public async Task<IActionResult> GetPurchaseList()
        {
            try
            {
                var purchaseList = PurchasesHelper.GetPurchaseList();
                if (purchaseList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.materialtratypes = BillingHelpers.GetMatTranTypesList();
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getCompanys")]
        public async Task<IActionResult> GetCompanys()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.companiesList = PurchasesHelper.GetCompanies().Select(x => new { ID = x.CompanyCode, TEXT = x.Name });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getBranches")]
        public async Task<IActionResult> GetBranches()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.branchesList = PurchasesHelper.GetBranches().Select(x => new { ID = x.BranchCode, TEXT = x.Name });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getGlAccounts")]
        public async Task<IActionResult> GetGlAccounts()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.glAccountsList = PurchasesHelper.GetGLAccounts().Select(x => new { ID = x.Glcode, TEXT = x.GlaccountName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getMatTranTypesList")]
        public async Task<IActionResult> GetMatTranTypes()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.matTransTypesList = PurchasesHelper.GetMatTranTypes().Select(x => new { ID = x.Code, TEXT = x.Description });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getMaterialGroupList")]
        public async Task<IActionResult> GetMaterialGroup()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.materialGroupList = PurchasesHelper.GetMaterialGroup().Select(x => new { ID = x.Code, TEXT = x.GroupName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getAccountToAccountClassList")]
        public async Task<IActionResult> GetAccountToAccountClass()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.accountToAccountClassList = PurchasesHelper.GetAccountToAccountClassList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getTAxMasterList")]
        public async Task<IActionResult> GetTAxMasterList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.tAxMasterList = PurchasesHelper.GetTAxMasterList().Select(t=> new { ID=t.Code,TEXT=t.Description});
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getTaxIntegrationList")]
        public async Task<IActionResult> GetTaxIntegrationList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.taxIntegrationList = PurchasesHelper.GetTaxIntegrationList().Select(t=> new { ID=t,TEXT=t});
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getModelList")]
        public async Task<IActionResult> GetModelList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.modelList = PurchasesHelper.GetModelList().Select(m=> new { ID=m.Code,TEXT=m.Description});
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getItemMasterList")]
        public async Task<IActionResult> GetItemMasterList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.itemMasterList = PurchasesHelper.GetItemMasterList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getPartnerCreationList")]
        public async Task<IActionResult> GetPartnerCreationList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.partnerCreationList = PurchasesHelper.GetPartnerCreationList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getBrandList")]
        public async Task<IActionResult> GetBrandList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.brandList = PurchasesHelper.GetBrandList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getAccInterpretationList")]
        public async Task<IActionResult> GetInterpretationList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.interpretationList = PurchasesHelper.GetInterpretationList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getPurchaseReturnsList")]
        public async Task<IActionResult> GetPurchaseReturnsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.purchaseReturnsList = PurchasesHelper.GetPurchaseReturnsList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("registerPurchase")]
        public async Task<IActionResult> RegisterPurchase([FromBody]Models.Purchase[] purchase)
        {
            if (purchase == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });
            try
            {
                var result = PurchasesHelper.RegisterPurchase(purchase);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("updatePurchase")]
        public async Task<IActionResult> UpdatePurchase(string code, [FromBody] Models.Purchase purchase)
        {
            if (purchase == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                var result = PurchasesHelper.UpdatePurchase(purchase);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("deletePurchase/{code}")]
        public async Task<IActionResult> DeletePurchase(string code)
        {
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                var response = PurchasesHelper.DeletePurchase(code);
                if (response !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("getPurchaseMaterialGrp")]
        public async Task<IActionResult> GetPurchaseMaterialGrp()
        {

            return Ok(
                new
                {
                    // accounts = _unitOfWork.GLAccounts.GetAll() ,  
                    // materialTranstp = (from mattran in _unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.TransactionType != null)
                    //                    where mattran.TransactionType.ToUpper() == MaterialTransationType.PURCHASE.ToString()
                    //                    select mattran),
                    //materialGroup = (from mattran in _unitOfWork.MaterialGroup.GetAll()
                    //                 select mattran),
                    // accToAccClass =(from acctoacc in _unitOfWork.AsignmentAcctoAccClass.GetAll()
                    //                 select acctoacc),
                    // taxmasterlist = (from taxm in _unitOfWork.TaxMasters.GetAll()
                    //                  //join taxi in _unitOfWork.TaxIntegration.GetAll()
                    //                  //on taxm.Code equals taxi.TaxCode
                    //                  where taxm.TaxType == "INPUT"
                    //                  select taxm),
                    // taxintegration = (from taxingr in _unitOfWork.TaxIntegration.GetAll() where taxingr.TaxCode != null select taxingr),
                    // models = (from md in _unitOfWork.BrandModel.GetAll()
                    //          // join itmmst in _unitOfWork.ItemMaster.GetAll()
                    //         //  on md.Code equals itmmst.Model
                    //           select md),
                    // itemmaster = _unitOfWork.ItemMaster.GetAll(),
                    // partnercreation = (from parttyp in _unitOfWork.PartnerType.GetAll()
                    //                    join partcr in _unitOfWork.PartnerCreation.GetAll()
                    //                    on parttyp.Code equals partcr.Partnertype
                    //                    where parttyp.AccountType == NatureOfAccounts.TRADEVENDORS.ToString()
                    //                    select partcr),
                    // brandList = (from br in _unitOfWork.Brand.GetAll()
                    //              select br),
                    // purchaseReturnsList = _unitOfWork.PurchaseReturns.GetAll().Where(x=>x.GoodsReceiptDate != null),
                    // accIntegrationList =_unitOfWork.Interpretation.GetAll(),
                    // materialGroupList =_unitOfWork.MaterialGroup.GetAll()
                });

        }

        #endregion
    }
}