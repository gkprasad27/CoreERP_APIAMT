using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class PaymentHelper
    {
        public static IEnumerable<TblPaymentTerms> GetList(string code)
        {
            try
            {
                return Repository<TblPaymentTerms>.Instance.Where(x => x.Code == code);
            }
            catch { throw; }
        }

        public static IEnumerable<TblPaymentTerms> GetList()
        {
            try
            {
                return Repository<TblPaymentTerms>.Instance.GetAll().OrderBy(x => x.Code);
            }
            catch { throw; }
        }

        public static TblPaymentTerms Register(TblPaymentTerms paymentterms)
        {
            try
            {
                Repository<TblPaymentTerms>.Instance.Add(paymentterms);
                if (Repository<TblPaymentTerms>.Instance.SaveChanges() > 0)
                    return paymentterms;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblPaymentTerms Update(TblPaymentTerms paymentterms)
        {
            try
            {
                Repository<TblPaymentTerms>.Instance.Update(paymentterms);
                if (Repository<TblPaymentTerms>.Instance.SaveChanges() > 0)
                    return paymentterms;

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TblPaymentTerms Delete(string codes)
        {
            try
            {

                var rcode = Repository<TblPaymentTerms>.Instance.GetSingleOrDefault(x => x.Code == codes);
                Repository<TblPaymentTerms>.Instance.Remove(rcode);
                if (Repository<TblPaymentTerms>.Instance.SaveChanges() > 0)
                    return rcode;
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
