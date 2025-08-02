public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        try
        {
            return operation switch
            {
                "+" => $"{operand1} + {operand2} = {SimpleOperation.Addition(operand1, operand2)}",
                "/" => $"{operand1} / {operand2} = {SimpleOperation.Division(operand1, operand2)}",
                "*" => $"{operand1} * {operand2} = {SimpleOperation.Multiplication(operand1, operand2)}",
                "" => throw new ArgumentException("ArgumentException"),
                null => throw new ArgumentNullException("ArgumentNullException"),
                _ => throw new ArgumentOutOfRangeException("ArgumentOutOfRangeException"),
            };
        }
        catch (DivideByZeroException)
        {
            return "Division by zero is not allowed.";
        }
    }
}
