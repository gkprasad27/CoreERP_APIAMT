using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreERP.Models
{
    public partial class tblQCResults
    {
        public int Id { get; set; }
        public string? Result { get; set; }
        public string? Parameter { get; set; }
        public string? Uom { get; set; }
        public string? Spec { get; set; }
        public string? MinValue { get; set; }
        public string? MaxValue { get; set; }
        public string? Instrument { get; set; }
        public string? Type { get; set; }
        public bool? IsActive { get; set; }
        public string? MaterialCode { get; set; }
        public string? TagName { get; set; }
        public string? saleOrderNumber { get; set; }
       
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EditDate { get; set; }
        public string? EditWho { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime AddDate { get; set; }
        public string? AddWho { get; set; }

    }
}
