using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/RoutingFile")]
    public class RoutingFileController : ControllerBase
    {
        private readonly IRepository<TblRoutingToolsEqupments> _routingToolsEqupmentsRepository;
        private readonly IRepository<TblRoutingMaterialAssignment> _routingMaterialAssignmentRepository;
        private readonly IRepository<TblRoutingActiitiesAssignment> _routingActiitiesAssignmentRepository;
        private readonly IRepository<TblRoutingBasicData> _routingBasicDataRepository;
        private readonly IRepository<TblRoutingMasterData> _routingMasterDataRepository;
        public RoutingFileController(IRepository<TblRoutingMasterData> routingMasterDataRepository
            , IRepository<TblRoutingBasicData> routingBasicDataRepository,
            IRepository<TblRoutingActiitiesAssignment> routingActiitiesAssignmentRepository,
            IRepository<TblRoutingMaterialAssignment> routingMaterialAssignmentRepository,
            IRepository<TblRoutingToolsEqupments> routingToolsEqupmentsRepository)
        {
            _routingMasterDataRepository = routingMasterDataRepository;
            _routingBasicDataRepository = routingBasicDataRepository;
            _routingMaterialAssignmentRepository = routingMaterialAssignmentRepository;
            _routingActiitiesAssignmentRepository = routingActiitiesAssignmentRepository;
            _routingToolsEqupmentsRepository = routingToolsEqupmentsRepository;
        }


        [HttpGet("GetRoutingFileDetail/{key}")]
        public IActionResult GetRoutingFileDetail(string key)
        {
            try
            {
                var transactions = new TransactionsHelper();
                var routingMasters = transactions.GetRoutingMasterById(key);
                if (routingMasters == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.routingMasters = routingMasters;
                expdoObj.routebasicDetail = new TransactionsHelper().GetRoutingBasicDataDetails(key);
                expdoObj.materialDetail = new TransactionsHelper().GetRoutingMaterialAssignmentDetails(key);
                expdoObj.activityDetail = new TransactionsHelper().GetRoutingActiitiesAssignmentDetails(key);
                expdoObj.toolsequpmentDetail = new TransactionsHelper().GetRoutingToolsEqupmentsDetails(key);
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterRoutingFile")]
        public IActionResult RegisterRoutingFile([FromBody] JObject obj)
        {
            if (obj == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                var routeHdr = obj["routeHdr"].ToObject<TblRoutingMasterData>();
                var routingDetail= obj["routingDetail"].ToObject<List<TblRoutingBasicData>>();
                var materialDetail = obj["materialDetail"].ToObject<List<TblRoutingMaterialAssignment>>();
                var activityDetail = obj["activityDetail"].ToObject<List<TblRoutingActiitiesAssignment>>();
                var equipmentDetail = obj["equipmentDetail"].ToObject<List<TblRoutingToolsEqupments>>();

                if (!new TransactionsHelper().AddRoutingFile(routeHdr,routingDetail, materialDetail, activityDetail, equipmentDetail))
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.routeHdr = routeHdr;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });


            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetRoutingFileList")]
        public IActionResult GetRoutingFileList()
        {
            try
            {
                var rmdList = _routingMasterDataRepository.GetAll();
                if (rmdList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.rmdList = rmdList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateRoutingFile")]
        public IActionResult UpdateRoutingFile([FromBody] TblRoutingMasterData rmd)
        {
            if (rmd == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(rmd)} cannot be null" });

            try
            {

                TblRoutingBasicData repo = new TblRoutingBasicData();
                repo.RoutingKey = rmd.RoutingKey;
                repo.Operation = rmd.Operation;
                repo.SubOperation = rmd.SubOperation;
                repo.WorkCenter = rmd.WorkCenter;
                repo.BaseQuantity = int.Parse(rmd.BaseQuantity);
                repo.OperationUnit = rmd.OperationUnit;
                _routingBasicDataRepository.Add(repo);
                _routingBasicDataRepository.SaveChanges();
                TblRoutingActiitiesAssignment repo1 = new TblRoutingActiitiesAssignment();
                repo1.RoutingKey = rmd.RoutingKey;
                repo1.WorkCenter = rmd.WorkCenter;
                repo1.CostCenter = rmd.CostCenter;
                repo1.Activity = rmd.Activity;
                repo1.StandardValue = rmd.StandardValue;
                repo1.Uom = rmd.UOM;
                repo1.Formula = rmd.Formula;
                _routingActiitiesAssignmentRepository.Add(repo1);
                _routingActiitiesAssignmentRepository.SaveChanges();
                TblRoutingMaterialAssignment repo2 = new TblRoutingMaterialAssignment();
                repo2.RoutingKey = rmd.RoutingKey;
                repo2.Material = rmd.Material;
                repo2.Description = rmd.Description;
                repo2.Uom = rmd.UOM;
                repo2.Qty = int.Parse(rmd.Qty);
                _routingMaterialAssignmentRepository.Add(repo2);
                _routingMaterialAssignmentRepository.SaveChanges();
                TblRoutingToolsEqupments repo3 = new TblRoutingToolsEqupments();
                repo3.RoutingKey = rmd.RoutingKey;
                repo3.ToolsEqupment = rmd.ToolsEqupment;
                repo3.Description = rmd.Description;
                repo3.Numbers = int.Parse(rmd.Numbers);
                _routingToolsEqupmentsRepository.Add(repo3);
                _routingToolsEqupmentsRepository.SaveChanges();
                APIResponse apiResponse;
                _routingMasterDataRepository.Update(rmd);
                if (_routingMasterDataRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rmd };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteRoutingFile/{code}")]
        public IActionResult DeleteRoutingFilebyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _routingMasterDataRepository.GetSingleOrDefault(x => x.OrderNumber.Equals(code));
                _routingMasterDataRepository.Remove(record);
                if (_routingMasterDataRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}