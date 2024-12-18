using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.DataAccess;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Helpers.SharedModels;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/StandardRate")]
    public class StandardRateController : ControllerBase
    {
        private readonly IRepository<tblQCMaster> _standardrateRepository;
        private readonly IRepository<tblQCDetails> _qcdetails;
        private readonly IRepository<TblProductionDetails> _proddetails;

        public StandardRateController(IRepository<tblQCMaster> standardrateRepository, IRepository<tblQCDetails> tblQCDetails)
        {
            _standardrateRepository = standardrateRepository;
            _qcdetails = tblQCDetails;
        }

        [HttpPost("RegisterStandardRate")]
        public async Task<IActionResult> RegisterStandardRate([FromBody] JObject obj)
        {
            var result = await Task.Run(() =>
            {
                var QCMaster = obj["qcdHdr"].ToObject<tblQCMaster>();
                var QCDetails = obj["qcdDtl"].ToObject<List<tblQCDetails>>();

                try
                {
                    if (!new TransactionsHelper().AddQCConfig(QCMaster, QCDetails))
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.QCMaster = QCMaster;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });


                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterQCResults")]
        public async Task<IActionResult> RegisterQCResults([FromBody] JObject obj)
        {
            var result = await Task.Run(() =>
            {
                var QCResults = obj["qtyResult"].ToObject<List<tblQCResults>>();
                var QcConfig = obj["qtyDtl"].ToObject<List<TblInspectionCheckMaster>>();

                try
                {
                    if (!new TransactionsHelper().AddQCResult(QCResults, QcConfig))
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.QCResults = QCResults;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });


                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("GetStandardRateList")]
        public async Task<IActionResult> GetStandardRateList([FromBody] SearchCriteria searchCriteria)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var sropList = CommonHelper.GetStandardRateOutPut(searchCriteria);
                    if (sropList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.sropList = sropList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }

                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetQCConfigDetail/{code}")]
        public async Task<IActionResult> GetSaleOrderDetail(string code)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var ConfigDetail = GetQCMastersById(code);
                    if (ConfigDetail == null)
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.QCConfigDetailMaster = ConfigDetail;
                    expdoObj.QCConfigDetail = GetQCDetails(code);
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetSaleOrderDetailbymaterialcode/{materialcode}/{tagname}/{type}/{bomkey}/{companyCode}")]
        public async Task<IActionResult> GetSaleOrderDetailbymaterialcode(string materialcode,string tagname, string type,string bomkey, string companyCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expdoObj = new ExpandoObject();

                    if (companyCode=="2000")
                    {
                        var tagsData = GetQCResult(tagname, type);
                        if (tagsData.Count == 0)
                        {
                            var tagsData1 = GetQCDetailManufacturing(bomkey);
                            expdoObj.QCConfigDetail = tagsData1;
                        }
                        else
                            expdoObj.QCConfigDetail = tagsData;
                    }
                    else
                    {
                        var tagsData = GetQCResult(materialcode, tagname, type);
                        if (tagsData.Count == 0)
                        {
                            var tagsData1 = GetQCDetail(materialcode);
                            expdoObj.QCConfigDetail = tagsData1;
                        }
                        else
                            expdoObj.QCConfigDetail = tagsData;
                    }

                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        public List<tblQCDetails> GetQCDetail(string materialcode)
        {
            using var repo = new Repository<tblQCDetails>();
            var sizes = repo.TblMaterialSize.ToList();

            var result = repo.tblQCDetails.Where(cd => cd.MaterialCode == materialcode).ToList();

            result.ForEach(c =>
            {
                c.UOMName = sizes.FirstOrDefault(s => s.unitId == c.Uom)?.unitName;
            });
            return result.ToList();
        }

        public List<tblQCDetails> GetQCDetailManufacturing(string materialcode)
        {
            using var repo = new Repository<tblQCDetails>();
            var sizes = repo.TblMaterialSize.ToList();

            var result = repo.tblQCDetails.Where(cd => cd.MaterialCode == materialcode).ToList();

            result.ForEach(c =>
            {
                c.UOMName = sizes.FirstOrDefault(s => s.unitId == c.Uom)?.unitName;
            });
            return result.ToList();
        }

        public List<tblQCResults> GetQCResult(string materialcode,string tagname, string Type)
        {
            using var repo = new Repository<tblQCResults>();
            var sizes = repo.TblMaterialSize.ToList();

            var result = repo.tblQCResults.Where(cd => cd.MaterialCode == materialcode && cd.TagName== tagname && cd.Type == Type).ToList();
            result.ForEach(c =>
            {
                c.UOMName = sizes.FirstOrDefault(s => s.unitId == c.Uom)?.unitName;
            });


            return result.ToList();
        }

        public List<tblQCResults> GetQCResult(string tagname, string Type)
        {
            using var repo = new Repository<tblQCResults>();
            var sizes = repo.TblMaterialSize.ToList();

            var result = repo.tblQCResults.Where(cd => cd.TagName == tagname && cd.Type == Type).ToList();
            result.ForEach(c =>
            {
                c.UOMName = sizes.FirstOrDefault(s => s.unitId == c.Uom)?.unitName;
            });


            return result.ToList();
        }

        public List<tblQCDetails> GetQCDetails(string Code)
        {
            using var repo = new Repository<tblQCDetails>();
           // var MaterialCodes = repo.TblMaterialMaster.ToList();
            var sizes = repo.TblMaterialSize.ToList();


           var result=  repo.tblQCDetails.Where(cd => cd.Code == Code).ToList();

            result.ForEach(c =>
            {
                c.UOMName = sizes.FirstOrDefault(s => s.unitId == c.Uom)?.unitName;
            });


            return result.ToList();

        }
        public tblQCMaster GetQCMastersById(string Code)
        {
            using var repo = new Repository<tblQCMaster>();
            return repo.tblQCMaster
                .FirstOrDefault(x => x.Code == Code);
        }


        [HttpPut("UpdateStandardRate")]
        public IActionResult UpdateStandardRate([FromBody] tblQCMaster sroutput)
        {
            if (sroutput == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(sroutput)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _standardrateRepository.Update(sroutput);
                if (_standardrateRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = sroutput };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteStandardRate/{code}")]
        public IActionResult DeleteStandardRatebyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _standardrateRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _standardrateRepository.Remove(record);
                if (_standardrateRepository.SaveChanges() > 0)
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