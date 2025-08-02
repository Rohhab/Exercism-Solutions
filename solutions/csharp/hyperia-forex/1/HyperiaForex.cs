public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // TODO: implement equality operators
    public static bool operator == (CurrencyAmount left, CurrencyAmount right)
    {
        if(left.currency != right.currency)
        {
            throw new ArgumentException("Currencies are not comparable.");
        }
        else
        {
            return (left.amount == right.amount);
        }
    }
    
    public static bool operator != (CurrencyAmount left, CurrencyAmount right)
    {
        if(left.currency != right.currency)
        {
            throw new ArgumentException("Currencies are not comparable.");
        }
        else
        {
            return (left.amount != right.amount);
        }
    }

    // TODO: implement comparison operators
    public static bool operator < (CurrencyAmount left, CurrencyAmount right)
    {
        if(left.currency != right.currency)
        {
            throw new ArgumentException("Currencies are not comparable.");
        }
        else
        {
            return (left.amount < right.amount);
        }
    }

    public static bool operator > (CurrencyAmount left, CurrencyAmount right)
    {
        if(left.currency != right.currency)
        {
            throw new ArgumentException("Currencies are not comparable.");
        }
        else
        {
            return (left.amount > right.amount);
        }
    }

    // TODO: implement arithmetic operators
    public static decimal operator + (CurrencyAmount left, CurrencyAmount right)
    {
        if(left.currency != right.currency)
        {
            throw new ArgumentException("Currencies are not comparable.");
        }
        else
        {
            return new CurrencyAmount(left.amount + right.amount, left.currency);
        }
    }

    public static decimal operator - (CurrencyAmount left, CurrencyAmount right)
    {
        if(left.currency != right.currency)
        {
            throw new ArgumentException("Currencies are not comparable.");
        }
        else
        {
            return new CurrencyAmount(left.amount - right.amount, left.currency);
        }
    }
    
    public static decimal operator * (CurrencyAmount left, CurrencyAmount right)
    {
        if(left.currency != right.currency)
        {
            throw new ArgumentException("Currencies are not comparable.");
        }
        else
        {
            return new CurrencyAmount(left.amount * right.amount, left.currency);
        }
    }

    public static decimal operator / (CurrencyAmount left, CurrencyAmount right)
    {
        if(left.currency != right.currency)
        {
            throw new ArgumentException("Currencies are not comparable.");
        }
        else
        {
            return new CurrencyAmount(left.amount / right.amount, left.currency);
        }
    }
    // TODO: implement type conversion operators
    public static implicit operator double (CurrencyAmount currencyAmount)
    {
        return (double)currencyAmount.amount;
    }

    public static implicit operator decimal (CurrencyAmount currencyAmount)
    {
        return (decimal)currencyAmount.amount;
    }
}
