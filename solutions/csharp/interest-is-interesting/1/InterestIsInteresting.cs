static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if(balance < 0)
        {
            return 3.213F;
        }
        else if(balance >= 0 && balance < 1000)
        {
            return 0.500F;
        }
        else if(balance >= 1000 && balance < 5000)
        {
            return 1.621F;
        }
        else
        {
            return 2.475F;
        }
    }

    public static decimal Interest(decimal balance)
    {
        if(balance < 0)
        {
            return (decimal)3.213 * balance / 100;
        }
        else if(balance >= 0 && balance < 1000)
        {
            return (decimal)0.500 * balance / 100;
        }
        else if(balance >= 1000 && balance < 5000)
        {
            return (decimal)1.621 * balance / 100;
        }
        else
        {
            return (decimal)2.475 * balance / 100;
        }
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        var year = 0;

        while(targetBalance - balance > 0)
        {
            balance += Interest(balance);
            year++;
        }

        return year;
    }
}
