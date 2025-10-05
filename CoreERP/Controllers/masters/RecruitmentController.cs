using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Recruitment")]
    public class RecruitmentController : ControllerBase
    {
        private readonly IRepository<TblRecruitment> _employeeRepository;
        private readonly IRepository<TblRecruitmentAddress> _addressRepository;
        private readonly IRepository<TblRecruitmentEducation> _edicationRepository;
        private readonly IRepository<TblRecruitmentExperiance> _experianceRepository;
        public RecruitmentController(IRepository<TblRecruitment> employeeRepository, IRepository<TblRecruitmentAddress> addressRepository, IRepository<TblRecruitmentEducation> educationRepository, IRepository<TblRecruitmentExperiance> experianceRepository)
        {
            _employeeRepository = employeeRepository;
            _addressRepository = addressRepository;
            _edicationRepository = educationRepository;
            _experianceRepository = experianceRepository;
        }

        [HttpGet("GetEmploeebycode/{empcode}")]

        public async Task<IActionResult> GetEmploeebycode(string empcode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var EducationList = _employeeRepository.GetAll().Where(x => x.EMPCode == empcode && x.Status == "Selected"); //LanguageHelper.GetList();
                    if (EducationList != null)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.EducationList = EducationList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetEmployeeList")]

        public async Task<IActionResult> GetEmployeeList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var employeesList = _employeeRepository.GetAll();
                    if (employeesList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.employeesList = employeesList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetAddressList/{empcode}")]

        public async Task<IActionResult> GetAddressList(string empcode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var AddressList = _addressRepository.GetAll().FirstOrDefault(x => x.EmpCode == empcode);
                    if (AddressList != null)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.AddressList = AddressList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetEducationList/{empcode}")]

        public async Task<IActionResult> GetEducationList(string empcode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var EducationList = _edicationRepository.GetAll().Where(x => x.EmpCode == empcode); //LanguageHelper.GetList();
                    if (EducationList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.EducationList = EducationList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }
        [HttpGet("GetExperianceList/{empcode}")]

        public async Task<IActionResult> GetExperianceList(string empcode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var ExperianceList = _experianceRepository.GetAll().Where(x => x.EmpCode == empcode); //LanguageHelper.GetList();
                    if (ExperianceList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.ExperianceList = ExperianceList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterEmployee")]

        public async Task<IActionResult> RegisterEmployee([FromBody] TblRecruitment employee)
        {
            APIResponse apiResponse;
            if (employee == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(employee)} cannot be null" });
            else
            {
                try
                {
                    _employeeRepository.Add(employee);
                    if (_employeeRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = employee };
                    else
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }

            }
        }

        [HttpPost("RegisterEmployeeAddress")]

        public async Task<IActionResult> RegisterEmployeeAddress([FromBody] TblRecruitmentAddress address)
        {
            APIResponse apiResponse;
            if (address == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(address)} cannot be null" });
            else
            {
                try
                {
                    //_addressRepository.Add(address);
                    bool addressExists = address.ID > 0;
                    bool addressNew = address.ID == 0;
                    if (addressExists)
                    {
                        _addressRepository.Update(address);
                    }
                    else
                    {
                        _addressRepository.Add(address);
                    }
                    if (_addressRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = address };
                    else
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }

            }
        }

        [HttpPost("RegisterEducation")]

        public async Task<IActionResult> RegisterEducation([FromBody] List<TblRecruitmentEducation> education)
        {
            APIResponse apiResponse;
            if (education == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(education)} cannot be null" });
            else
            {
                try
                {
                    //_edicationRepository.AddRange(education);
                    bool educationExists = education.Any(x => x.ID > 0);
                    bool educationNew = education.Any(x => x.ID > 0);
                    if (educationExists)
                    {
                        _edicationRepository.UpdateRange(education);
                    }
                    else
                    {
                        _edicationRepository.AddRange(education);
                    }
                    if (_edicationRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = education };
                    else
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }

            }
        }

        [HttpPost("RegisterExperiance")]

        public async Task<IActionResult> RegisterExperiance([FromBody] List<TblRecruitmentExperiance> experiance)
        {
            APIResponse apiResponse;
            if (experiance == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(experiance)} cannot be null" });
            else
            {
                try
                {
                    //_experianceRepository.AddRange(experiance);
                    bool experianceExists = experiance.Any(x => x.ID > 0);
                    bool experianceNew = experiance.Any(x => x.ID > 0);
                    if (experianceExists)
                    {
                        _experianceRepository.UpdateRange(experiance);
                    }
                    else
                    {
                        _experianceRepository.AddRange(experiance);
                    }
                    if (_experianceRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = experiance };
                    else
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }

            }
        }
        [HttpPut("UpdateEmployee")]

        public async Task<IActionResult> UpdateEmployee([FromBody] TblRecruitment employee)
        {
            APIResponse apiResponse = null;
            if (employee == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _employeeRepository.Update(employee);
                if (_employeeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = employee };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateAddress")]

        public async Task<IActionResult> UpdateAddress([FromBody] TblRecruitmentAddress address)
        {
            APIResponse apiResponse = null;
            if (address == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _addressRepository.Update(address);
                if (_addressRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = address };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateEducation")]

        public async Task<IActionResult> UpdateEducation([FromBody] List<TblRecruitmentEducation> education)
        {
            APIResponse apiResponse = null;
            if (education == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _edicationRepository.UpdateRange(education);
                if (_edicationRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = education };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateExperiance")]

        public async Task<IActionResult> UpdateExperiance([FromBody] List<TblRecruitmentExperiance> experiance)
        {
            APIResponse apiResponse = null;
            if (experiance == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _experianceRepository.UpdateRange(experiance);
                if (_experianceRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = experiance };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        //// Delete Branch
        [HttpDelete("DeleteEmployee/{code}")]

        public async Task<IActionResult> DeleteEmployee(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _employeeRepository.GetSingleOrDefault(x => x.EMPCode.Equals(code));
                _employeeRepository.Remove(record);
                if (_employeeRepository.SaveChanges() > 0)
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

        [HttpDelete("DeleteAddress/{code}")]

        public async Task<IActionResult> DeleteAddress(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _addressRepository.GetSingleOrDefault(x => x.EmpCode.Equals(code));
                _addressRepository.Remove(record);
                if (_addressRepository.SaveChanges() > 0)
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


        [HttpDelete("DeleteEducation/{code}")]

        public async Task<IActionResult> DeleteEducation(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _edicationRepository.GetSingleOrDefault(x => x.EmpCode.Equals(code));
                _edicationRepository.Remove(record);
                if (_edicationRepository.SaveChanges() > 0)
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

        [HttpDelete("DeleteExperiance/{code}")]

        public async Task<IActionResult> DeleteExperiance(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _experianceRepository.GetSingleOrDefault(x => x.EmpCode.Equals(code));
                _experianceRepository.Remove(record);
                if (_experianceRepository.SaveChanges() > 0)
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