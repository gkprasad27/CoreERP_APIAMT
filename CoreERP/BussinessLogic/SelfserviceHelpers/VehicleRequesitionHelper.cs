using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SelfserviceHelpers
{
    public class VehicleRequesitionHelper
    {
        public static List<VehicleRequisition> GetApplyVehicleRequesitionDetailsList(string code)
        {
            try
            {
                using (Repository<VehicleRequisition> repo = new Repository<VehicleRequisition>())
                {
                    if (code.ToLower() == "admin")
                    {
                        return repo.VehicleRequisition.ToList();

                    }
                    else
                   return repo.VehicleRequisition.Where(x => x.EmpCode == code).ToList();
                }
            }
            catch { throw; }
        }

        public static VehicleRequisition RegisterApplyVehicleRequesitiondataDetails(VehicleRequisition vehcle, LeaveBalanceMaster lbm, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                using (Repository<VehicleRequisition> repo = new Repository<VehicleRequisition>())
                {
                    var empdata = repo.TblEmployee.Where(x => x.EmployeeCode == vehcle.EmpCode).FirstOrDefault();
                    vehcle.Status = "Applied";
                    vehcle.ApplDate = DateTime.Now;
                    vehcle.ReportId = empdata.ReportedBy;
                    vehcle.ReportName = repo.TblEmployee.Where(x => x.EmployeeCode == vehcle.ReportId).SingleOrDefault()?.EmployeeName;
                    vehcle.ApprovedId = empdata.ApprovedBy;
                    vehcle.ApproveName = repo.TblEmployee.Where(x => x.EmployeeCode == vehcle.ApprovedId).SingleOrDefault()?.EmployeeName;
                    repo.VehicleRequisition.Add(vehcle);
                    if (repo.SaveChanges() > 0)
                        return vehcle;
                    return null;
                }
            }
            catch { throw; }
        }

        public static VehicleRequisition UpdateapplyVehicleRequesitiondata(VehicleRequisition vehicle, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                using (Repository<VehicleRequisition> repo = new Repository<VehicleRequisition>())
                {
                    var vehicleAplysdata = repo.VehicleRequisition.Where(x => x.Sno == vehicle.Sno).FirstOrDefault();
                    if (vehicleAplysdata.Sno > 0)
                    {
                        repo.Entry(vehicleAplysdata).State = EntityState.Detached;
                        vehicle.Status = "Applied";
                        vehicle.ApplDate = DateTime.Now;
                        repo.Entry(vehicle).State = EntityState.Modified;
                        repo.VehicleRequisition.Update(vehicle);

                        if (repo.SaveChanges() > 0)
                            return vehicle;
                        else
                            errorMessage = "Registration failed.";
                        return null;
                    }

                }
                return vehicle;
            }

            catch { throw; }

        }
    }
}
