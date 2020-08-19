using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.Common
{

    public enum ObjectState
    {
        New,
        Update,
        Delete        
    }

    public class InputWrapper
    {
        /// <summary>
        /// Indicates whether object is newly created, updated or marked for delete
        /// </summary>
        public ObjectState State { set; get; }
        /// <summary>
        /// The model entity such as TblCurrency
        /// </summary>
        public object Entity { set; get; }
        /// <summary>
        /// model entity type such as TblCurrency
        /// </summary>
        public string EType { set; get; }
    }
}
