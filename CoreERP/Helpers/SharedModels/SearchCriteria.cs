using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Helpers.SharedModels
{
    public class SearchCriteria
    {
        private DateTime? _fromDate;
        private DateTime? _toDate;
        private string _invoiceNo;
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
        public int? Role { get; set; }

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
