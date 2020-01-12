namespace CoreERP
{
    public  enum MaterialTransationType
     {
        PURCHASE,
        PURCHASEDEFECTIVE,
        PURCHASERETURN,
        SALE,
        SALERETURN,
        TRANSFER,
        PURCHASEREQUISITION
    }


    public enum MaterialTransactionType
    {
        PURCHASE ,
        PURCHASEDEFECTIVE,
        PURCHASERETURN,
        SALE,
        SALERETURN,
        TRANSFER,
    }

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
}
