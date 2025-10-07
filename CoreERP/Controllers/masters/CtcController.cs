﻿using CoreERP.BussinessLogic.Payroll;
using CoreERP.DataAccess;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/CTC")]
    public class CtcController : ControllerBase
    {
        private readonly IRepository<Ctcbreakup> _ctcRepository;
        private readonly IRepository<TblEmployee> _employeeRepository;
        public CtcController(IRepository<Ctcbreakup> ctcRepository, IRepository<TblEmployee> employeeRepository)
        {
            _ctcRepository = ctcRepository;
            _employeeRepository = employeeRepository;
        }

        [HttpPost("RegisterctcTypes")]
        public async Task<IActionResult> RegisterctcTypes([FromBody] JObject obj)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    if (obj == null)
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });

                    var structure = obj["structure"].ToObject<Ctcbreakup>();
                    var components = obj["components"].ToObject<List<Ctcbreakup>>();
                    ///var username = User.Identities.ToList();

                    if (!new CTCHelper().Register(structure, components))
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.invoi = structure;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetStructures/{structure}/{ctc}")]
        public async Task<IActionResult> GetStructures(string structure, int ctc)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.structureList = new CTCHelper().GetStructures(structure, ctc);
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetEmployeeList/{empCode}/{companyCode}")]
        public async Task<IActionResult> GetEmployeeList(string empCode, string companyCode)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    // Pass both empCode and companyCode to GetEmployeesList
                    expando.EmployeeList = new CTCHelper().GetEmployeesList(empCode, companyCode)
                        .OrderBy(emp => emp.EmployeeCode.Length)
                        .Select(x => new { ID = x.EmployeeCode, TEXT = x.EmployeeName });

                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        //[HttpGet("GetEmployeeList/{empCode}")]
        //public async Task<IActionResult> GetEmployeeList(string empCode)
        //{
        //    var result = await Task.Run(() =>
        //    {
        //        try
        //        {
        //            dynamic expando = new ExpandoObject();
        //            expando.EmployeeList = new CTCHelper().GetEmployeesList(empCode).OrderBy(emp => emp.EmployeeCode.Length).Select(x => new { ID = x.EmployeeCode, TEXT = x.EmployeeName });
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //        }
        //        catch (Exception ex)
        //        {
        //            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //        }
        //    });
        //    return result;
        //}

        [HttpGet("GetctcDetailList/{empCode}")]
        public IActionResult GetctcDetailList(string empcode)
        {
            try
            {
                var ctcdetailList = _ctcRepository.GetAll().Where(x => x.EmpCode.Equals(empcode));
                if (ctcdetailList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.ctcDetailList = ctcdetailList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });



            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetctcTypesList")]
        public IActionResult GetctcTypesList()
        {
            try
            {
                //var ctcTypesList = _ctcRepository.GetAll().DistinctBy(x => x.EmpCode).ToList();
                var ctcTypesList = _ctcRepository.GetAll().Join(_employeeRepository.GetAll(),
                                      ctc => ctc.EmpCode,
                                      emp => emp.EmployeeCode,
                                      (ctc, emp) => new
                                      {
                                          emp.EmployeeName,
                                          ctc
                                      })
                                .DistinctBy(x => x.ctc.EmpCode)
                                .ToList();

                //using var repo = new Repository<TblSaleOrderDetail>();
                //var ctcTypesList = _ctcRepository.GetAll().DistinctBy(x => x.EmpCode).ToList();
                //var Employee = repo.TblEmployee.ToList();

                //repo.Ctcbreakup.ToList().ForEach(c =>
                //{
                //    c.EmpName = Employee.FirstOrDefault(l => l.EmployeeCode == c.EmpCode)?.EmployeeName;
                //});

                if (ctcTypesList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.ctcTypesList = ctcTypesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });



            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatectcTypes")]
        public async Task<IActionResult> UpdatectcTypes([FromBody] JObject obj)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    if (obj == null)
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });

                    var structure = obj["structure"].ToObject<Ctcbreakup>();
                    var components = obj["components"].ToObject<List<Ctcbreakup>>();
                    ///var username = User.Identities.ToList();

                    if (!new CTCHelper().Update(structure, components))
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.invoi = structure;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
            //if (ctcComponent == null)
            //    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(ctcComponent)} cannot be null" });

            //try
            //{
            //    APIResponse apiResponse;
            //    _ctcRepository.Update(ctcComponent);
            //    if (_ctcRepository.SaveChanges() > 0)
            //        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ctcComponent };
            //    else
            //        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

            //    return Ok(apiResponse);
            //}
            //catch (Exception ex)
            //{
            //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            //}
        }

        [HttpDelete("DeletectcTypes/{code}")]
        public IActionResult DeletectcTypes(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _ctcRepository.GetSingleOrDefault(x => x.Id.Equals(code));
                _ctcRepository.Remove(record);
                if (_ctcRepository.SaveChanges() > 0)
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