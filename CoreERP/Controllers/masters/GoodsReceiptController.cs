using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/GoodsReceipt")]
    public class GoodsReceiptController : ControllerBase
    {
        private readonly IRepository<TblLotAssignment> _assignmentrepository;
        private readonly IRepository<TblLotSeries> _seriesrepository;
       // private readonly IRepository<TblNumberRange> _numberRangerepository;
        //private readonly IRepository<TblBusinessPartnerAccount> _businessPartnerAccountRepository;
        public GoodsReceiptController(IRepository<TblBusinessPartnerAccount> businessPartnerAccountRepository,
          IRepository<TblLotAssignment> assignmentepository, IRepository<TblLotSeries> seriesrepository,
        IRepository<TblNumberRange> numberRangerepository)
        {
            //_numberRangerepository = numberRangerepository;
            //_businessPartnerAccountRepository = businessPartnerAccountRepository;
            _assignmentrepository = assignmentepository;
            _seriesrepository = seriesrepository;
        }

        [HttpGet("GetLotNumber/{code}")]
        public IActionResult GetLotNumber(string code)
        {
            try
            {
                var Getaccnolist = _assignmentrepository.Where(x => x.MaterialType == code).FirstOrDefault();
                if(Getaccnolist!=null)
                {
                    int i = Convert.ToInt32(_seriesrepository.Where(x => x.SeriesKey == Getaccnolist.LotSeries).SingleOrDefault()?.CurrentLot);

                    var numrnglist = _seriesrepository.Where(x => x.SeriesKey == Getaccnolist.LotSeries.ToString()).FirstOrDefault();
                    if (i == 0 /*&& Getaccnolist.Bpgroup == code*/)
                    {
                        var x = numrnglist.FromInterval;

                        if (Enumerable.Range(Convert.ToInt32(numrnglist.FromInterval), Convert.ToInt32(numrnglist.ToInterval)).Contains(Convert.ToInt32(x)))
                        {
                            if (x >= Convert.ToInt32(numrnglist.FromInterval) && x <= Convert.ToInt32(numrnglist.ToInterval))
                            {
                                var lotnum = x + 1;
                                if (lotnum != null)
                                {
                                    dynamic expdoObj = new ExpandoObject();
                                    expdoObj.lotNum = lotnum;
                                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                                }
                            }
                            else
                                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
                        }
                    }
                    else
                    if (Enumerable.Range(Convert.ToInt32(numrnglist.FromInterval), Convert.ToInt32(numrnglist.ToInterval)).Contains(i))
                    {
                        if (i >= Convert.ToInt32(numrnglist.FromInterval) && i <= Convert.ToInt32(numrnglist.ToInterval))
                        {
                            var lotnum = i + 1;
                            if (lotnum != null)
                            {
                                dynamic expdoObj = new ExpandoObject();
                                expdoObj.lotNum = lotnum;
                                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                            }
                        }
                        else
                            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
                    }

                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data.." });
                }

                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect Materialcode data.." });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
            return Ok();

        }

    }
}