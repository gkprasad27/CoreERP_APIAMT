using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Component")]
    public class ComponentController : ControllerBase
    {
        private readonly IRepository<ComponentMaster> _componentRepository;
        public ComponentController(IRepository<ComponentMaster> ComponentRepository)
        {
            _componentRepository = ComponentRepository;
        }

        [HttpPost("RegistercomponentTypes")]
        public IActionResult RegistercomponentTypes([FromBody] ComponentMaster Component)
        {
            if (Component == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                APIResponse apiResponse;
                _componentRepository.Add(Component);
                if (_componentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = Component };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetcomponentTypesList")]
        public IActionResult GetcomponentTypesList()
        {
            try
            {
                var ComponentTypesList = _componentRepository.GetAll();
                if (!ComponentTypesList.Any())
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.ComponentTypesList = ComponentTypesList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatecomponentTypes")]
        public IActionResult UpdatecomponentTypes([FromBody] ComponentMaster Component)
        {
            if (Component == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(Component)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _componentRepository.Update(Component);
                if (_componentRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = Component };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
               
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletecomponentTypes/{code}")]
        public IActionResult DeletecomponentTypes(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _componentRepository.GetSingleOrDefault(x => x.ComponentCode.Equals(code));
                _componentRepository.Remove(record);
                if (_componentRepository.SaveChanges() > 0)
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