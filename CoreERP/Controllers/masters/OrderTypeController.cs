using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/OrderType")]
    public class OrderTypeController : ControllerBase
    {

        private readonly IRepository<TblOrderType> _orderTypeRepository;
        public OrderTypeController(IRepository<TblOrderType> orderTypeRepository)
        {
            _orderTypeRepository = orderTypeRepository;
        }

        [HttpPost("RegisterOrderType")]
        public IActionResult RegisterOrderType([FromBody]TblOrderType ordertype)

        {
            if (ordertype == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {

                APIResponse apiResponse;
                _orderTypeRepository.Add(ordertype);
                if (_orderTypeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ordertype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetOrderTypeList")]
        public IActionResult GetOrderTypeList()
        {
            try
            {
                var ordertypeList = _orderTypeRepository.GetAll();
                if (ordertypeList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.ordertypeList = ordertypeList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateOrderType")]
        public IActionResult UpdateOrderType([FromBody] TblOrderType ordertype)
        {
            if (ordertype == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(ordertype)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _orderTypeRepository.Update(ordertype);
                if (_orderTypeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ordertype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteOrderType/{code}")]
        public IActionResult DeleteOrderTypebyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _orderTypeRepository.GetSingleOrDefault(x => x.OrderType.Equals(code));
                _orderTypeRepository.Remove(record);
                if (_orderTypeRepository.SaveChanges() > 0)
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