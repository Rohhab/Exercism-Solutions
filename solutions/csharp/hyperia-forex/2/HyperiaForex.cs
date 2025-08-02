public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    private static void ValidateCurrencies(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
        {
            throw new ArgumentException("Currencies are not comparable.");
        }
    }

    public static bool operator == (CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return (left.amount == right.amount);
    }
    
    public static bool operator != (CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return (left.amount != right.amount);
    }

    public static bool operator < (CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return (left.amount < right.amount);
    }

    public static bool operator > (CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return (left.amount > right.amount);
    }

    public static decimal operator + (CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return new CurrencyAmount(left.amount + right.amount, left.currency);
    }

    public static decimal operator - (CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return new CurrencyAmount(left.amount - right.amount, left.currency);
    }
    
    public static decimal operator * (CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return new CurrencyAmount(left.amount * right.amount, left.currency);
    }

    public static decimal operator / (CurrencyAmount left, CurrencyAmount right)
    {
        ValidateCurrencies(left, right);
        return new CurrencyAmount(left.amount / right.amount, left.currency);
    }
    
    public static implicit operator double (CurrencyAmount currencyAmount) => (double)currencyAmount.amount;

    public static implicit operator decimal (CurrencyAmount currencyAmount) => (decimal)currencyAmount.amount;
}
