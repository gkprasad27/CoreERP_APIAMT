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

    public enum ReportType
    {
        STATE,
        COMPANY,
        BRANCH,
        SALESPERSON,
        MATERIALGROUP,
        BRAND,
        ITEMNAME,
        SALEREPORT,
        FINANCE
    }


   public enum TRANSACTIONREPORTTYPE
    {
        JOURNALVOUCHER,
        SALE,
        SALESRETURN,
        PURCHASE,
        PURCHASERETURN
    }
    public enum NatureOfAccounts
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
}
