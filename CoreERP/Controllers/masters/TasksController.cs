using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Tasks")]
    public class TasksController : ControllerBase
    {
        private readonly IRepository<TblTaskResources> _taskResourcesRepository;
        private readonly IRepository<TblTaskMaster> _taskMasterRepository;
        public TasksController(IRepository<TblTaskMaster> taskMasterRepository,
            IRepository<TblTaskResources> taskResourcesRepository)
        {
            _taskMasterRepository = taskMasterRepository;
            _taskResourcesRepository = taskResourcesRepository;
        }

        [HttpPost("RegisterTasks")]
        public IActionResult RegisterTasks([FromBody]TblTaskMaster task)
        {
            if (task == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                TblTaskResources repo = new TblTaskResources();
                repo.TaskNumber = task.TaskNumber;
                repo.Resource = task.Resource;
                repo.MaterialCode = task.MaterialCode;
                repo.Qty =Convert.ToInt32(task.QTY);
                repo.CostCenter = task.CostCenter;
                repo.Rate = Convert.ToInt32(task.Rate);
                _taskResourcesRepository.Add(repo);
                _taskResourcesRepository.SaveChanges();
                APIResponse apiResponse;
                _taskMasterRepository.Add(task);
                if (_taskMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = task };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTasksList")]
        public IActionResult GetTasksList()
        {
            try
            {
                var taskList = _taskMasterRepository.GetAll();
                if (taskList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.taskList = taskList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateTasks")]
        public IActionResult UpdateTasks([FromBody] TblTaskMaster task)
        {
            if (task == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(task)} cannot be null" });

            try
            {
                TblTaskResources repo = new TblTaskResources();
                repo.TaskNumber = task.TaskNumber;
                repo.Resource = task.Resource;
                repo.MaterialCode = task.MaterialCode;
                repo.Qty = Convert.ToInt32(task.QTY);
                repo.CostCenter = task.CostCenter;
                repo.Rate = Convert.ToInt32(task.Rate);
                _taskResourcesRepository.Add(repo);
                _taskResourcesRepository.SaveChanges();
                APIResponse apiResponse;
                _taskMasterRepository.Update(task);
                if (_taskMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = task };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteTasks/{code}")]
        public IActionResult DeleteTasksbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _taskMasterRepository.GetSingleOrDefault(x => x.TaskNumber.Equals(code));
                _taskMasterRepository.Remove(record);
                if (_taskMasterRepository.SaveChanges() > 0)
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