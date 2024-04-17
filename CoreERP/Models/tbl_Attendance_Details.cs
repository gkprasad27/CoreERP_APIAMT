using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    [Table("tbl_Attendance_Details")]
    public partial class TblAttendanceDetails
    {
        public int ID { get; set; }
        public string? Emp_Code { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int? Month_Days { get; set; }

        public decimal? Pay_Days { get; set; }

        public decimal? LOP_Days { get; set; }
        public decimal? Leave_Days {  get; set; }
        public decimal? OT_Hrs { get; set; }

        public string? AddWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? AddDate { get; set; }

        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? EditDate { get; set; }



    }
}
