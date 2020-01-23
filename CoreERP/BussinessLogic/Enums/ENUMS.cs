namespace CoreERP
{
    public  enum MaterialTransationType
     {
        PURCHASE,
        PURCHASE_DEFECTIVE,
        PURCHASE_RETURN,
        SALE,
        SALE_RETURN,
        TRANSFER,
        PURCHASE_REQUISITION
    }

    //public enum MaterialTransactionType
    //{
    //    PURCHASE ,
    //    PURCHASEDEFECTIVE,
    //    PURCHASERETURN,
    //    SALE,
    //    SALERETURN,
    //    TRANSFER,
    //}
  
   public enum TRANSACTIONREPORTTYPE
    {
        JOURNALVOUCHER,
        SALE,
        SALESRETURN,
        PURCHASE,
        PURCHASERETURN
    }
    public enum  NATURESOFACCOUNTS
    {
        CASH,
        BANK,
        TAX,
        SALES,
        PURCHASES,
        CAPITAL,
        FIXEDASSETS,
        LOAN,
        DEPOSITS,
        BRANCH,
        TRADECUSTOMER,
        TRADEVENDORS,
        FINANCECUSTOMER,
        CREDITCARD,
        BILLSRECEIVABLES,
        STOCK,
        INVENTORY,
        DR,
        CR
    }
    public enum ModeOfSale
    {
        CASH,
        CARD,
        BILLS_RECEIVABLE,
        FINANCE,
        MULTIPLE,
        PHONEPAY ,
        RTGS,
        CHECK,
        PAYTM,
        // EXCHANGE='Exchange'
    }
    public enum BillingType
    {
        LOACAL,
        INTER_STATE
    }
    public enum TAXTYPE
    {
        INPUT,
        OUTPUT
    }
    public enum STATMENTTYPE
    {
        PI,
        BS
    }

    public enum NUMBERTYPE
    {
        AUTO,
        MANUAL
    }
}
