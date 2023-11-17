using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.DataAccess;
using System.Collections.Generic;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/StandardRate")]
    public class StandardRateController : ControllerBase
    {
        private readonly IRepository<tblQCMaster> _standardrateRepository;
        private readonly IRepository<tblQCDetails> _qcdetails;

        public StandardRateController(IRepository<tblQCMaster> standardrateRepository, IRepository<tblQCDetails> tblQCDetails)
        {
            _standardrateRepository = standardrateRepository;
            _qcdetails = tblQCDetails;
        }

        [HttpPost("RegisterStandardRate")]
        public async Task<IActionResult> RegisterStandardRate([FromBody] tblQCMaster sroutput)
        {
            var result = await Task.Run(() =>
            {
                if (sroutput == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _standardrateRepository.Add(sroutput);
                if (_standardrateRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = sroutput };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
            });
            return result;
        }

        [HttpGet("GetStandardRateList")]
        public async Task<IActionResult> GetStandardRateList()
        {
            var result = await Task.Run(() =>
            {
                try
            {
                var sropList = CommonHelper.GetStandardRateOutPut();
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

        [HttpGet("GetQCConfigDetail/{materialcode}")]
        public async Task<IActionResult> GetSaleOrderDetail(string materialcode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    //var transactions = new TransactionsHelper();
                    var ConfigDetail = GetQCMastersById(materialcode);
                    if (ConfigDetail == null)
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.QCConfigDetailMaster = ConfigDetail;
                    expdoObj.QCConfigDetail = GetQCDetails(materialcode);
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        public List<tblQCDetails> GetQCDetails(string materialCode)
        {
            using var repo = new Repository<tblQCDetails>();
            var MaterialCodes = repo.TblMaterialMaster.ToList();

            //repo.TblSaleOrderDetail.ToList().ForEach(c =>
            //{
            //    c.AvailableQTY = Convert.ToInt32(MaterialCodes.FirstOrDefault(l => l.MaterialCode == c.MaterialCode)?.ClosingQty);
            //    c.MaterialName = MaterialCodes.FirstOrDefault(z => z.MaterialCode == c.MaterialCode)?.Description;
            //});
            return repo.tblQCDetails.Where(cd => cd.MaterialCode == materialCode).ToList();

        }
        public tblQCMaster GetQCMastersById(string MaterialCode)
        {
            using var repo = new Repository<tblQCMaster>();
            return repo.tblQCMaster
                .FirstOrDefault(x => x.MaterialCode == MaterialCode);
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