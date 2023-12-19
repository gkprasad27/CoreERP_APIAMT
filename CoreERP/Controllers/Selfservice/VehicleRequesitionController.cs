using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.SelfserviceHelpers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.Selfservice
{
    [ApiController]
    [Route("api/Selfservice/VehicleRequesition")]
    public class VehicleRequesitionController : ControllerBase
    {
        [HttpGet("GetApplyVehicleRequesitionDetailsList/{code}")]
        public async Task<IActionResult> GetApplyVehicleRequesitionDetailsList(string code)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.vhclrqsnDetailsList = VehicleRequesitionHelper.GetApplyVehicleRequesitionDetailsList(code).ToList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterApplyVehicleRequesitiondataDetails")]
        public async Task<IActionResult> RegisterApplyVehicleRequesitiondataDetails([FromBody]VehicleRequisition vehicle)
        {
            if (vehicle == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                string errorMessge = string.Empty;

                VehicleRequisition result = VehicleRequesitionHelper.RegisterApplyVehicleRequesitiondataDetails(vehicle, null, out errorMessge);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessge });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateApplyVehicleRequesition")]
        public IActionResult UpdateApplyVehicleRequesition([FromBody]VehicleRequisition vehicle)
        {
            if (vehicle == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                string errorMessge = string.Empty;

                VehicleRequisition result = VehicleRequesitionHelper.UpdateapplyVehicleRequesitiondata(vehicle, out errorMessge);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessge });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}