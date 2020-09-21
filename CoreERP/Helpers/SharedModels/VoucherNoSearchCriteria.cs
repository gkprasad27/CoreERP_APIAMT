using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Helpers.SharedModels
{
    public class VoucherNoSearchCriteria
    {
        private DateTime? _fromDate;
        private DateTime? _toDate;
        private string _invoiceNo;
        private string _vehicle;
        private string _name;
        public DateTime? FromDate
        {
            get
            {
                return _fromDate;
            }
            set
            {
                if (value == null)
                    _fromDate = DateTime.Now;

                _fromDate = value;
            }
        }
        public DateTime? ToDate
        {
            get
            {
                return _toDate;
            }
            set
            {
                if (value == null)
                    _toDate = DateTime.Now;

                _toDate = value;
            }
        }
        public string InvoiceNo
        {
            get
            {
                return _invoiceNo;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _invoiceNo = null;
                else
                    _invoiceNo = value;
            }
        }
        public string VoucherNo { get; set; }
        public string StockExcessNo { get; set; }
        public string OilConversionVchNo { get; set; }
        public string issueNo { get; set; }
        public string StockshortNo { get; set; }
        public string receiptNo { get; set; }
        public int Role { get; set; }

        public string BranchCode { get; set; }
        public string Vehicle
        {
            get
            {
                return _vehicle;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _vehicle = null;
                else
                    _vehicle = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _name = null;
                else
                    _name = value;
            }
        }
    }
}
