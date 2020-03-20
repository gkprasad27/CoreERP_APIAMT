using System;
using System.Collections.Generic;

namespace CoreERP.Models
{
    public partial class TblContraDetails
    {
        public decimal ContraDetailsId { get; set; }
        public decimal? ContraMasterId { get; set; }
        public decimal? LedgerId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? ExchangeRateId { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public DateTime? ExtraDate { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
    }
}
