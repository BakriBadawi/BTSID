namespace BTSID;
public static class BTSID
{
    private const string Base36Chars = "0123456789abcdefghijklmnopqrstuvwxyz";
    /// <summary>
    /// Converts a string representation of a number to Base36.
    /// </summary>
    /// <param name="number">The number as a string.</param>
    /// <returns>The Base36 representation of the number.</returns>
    public static string ToBase36(this string number)
    {
        try
        {
            return GetBase36Number(Convert.ToDecimal(number));
        }
        catch
        {
            throw new ArgumentException("The number string is not a valid decimal");
        }
    }
    /// <summary>
    /// Converts a long number to Base36.
    /// </summary>
    /// <param name="number">The long number.</param>
    /// <returns>The Base36 representation of the number.</returns>
    public static string ToBase36(this long number)
    {
        return GetBase36Number(number);
    }
    /// <summary>
    /// Converts an integer to Base36.
    /// </summary>
    /// <param name="number">The integer number.</param>
    /// <returns>The Base36 representation of the number.</returns>
    public static string ToBase36(this int number)
    {
        return GetBase36Number(number);
    }
    /// <summary>
    /// Converts a DateTime to Base36.
    /// </summary>
    /// <param name="dateTime">The DateTime value.</param>
    /// <returns>The Base36 representation of the DateTime.</returns>   
    public static string ToBase36(this DateTime dateTime)
    {
        return GetBase36Number(decimal.Parse(dateTime.ToString("yyyyMMddHHmmssfff")));
    }
    /// <summary>
    /// Generates a Base36 number from a decimal value.
    /// </summary>
    /// <param name="number">The decimal number.</param>
    /// <returns>The Base36 representation of the number.</returns>
    public static string GetBase36Number(decimal number)
    {
        string result = "";
        decimal value = number;

        while (value > 0)
        {
            value = value / 36;
            long integerPart = (long)Decimal.Truncate(value);
            decimal fractionalPart = value - integerPart;
            int remainder = (int)(fractionalPart * 36);
            result = Base36Chars[remainder] + result;
            value = integerPart;
        }

        return result;
    }
    /// <summary>
    /// Generates a new Base36 number based on the specified mode.
    /// </summary>
    /// <param name="mode">The mode for generating the Base36 number.</param>
    /// <returns>The generated Base36 number.</returns>
    public static string NewBase36Number(NumberMode mode = NumberMode.Uniq)
    {
        switch (mode)
        {
            case NumberMode.Uniq:
            default:
                int processId = System.Diagnostics.Process.GetCurrentProcess().Id;
                decimal dateNumber = decimal.Parse(DateTime.Now.ToString("yyyyMMddHHmmssfff")) + processId;
                return GetBase36Number(dateNumber);
            case NumberMode.Short:
                return GetBase36Number(decimal.Parse(DateTime.Now.ToString("yyyyMMddHHmmssfff")));
            case NumberMode.Compressed:
                return GetBase36Number(decimal.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")));
        }
    }
    /// <summary>
    /// Gets the next Base36 number in sequence.
    /// </summary>
    /// <param name="currentNumber">The current Base36 number.</param>
    /// <returns>The next Base36 number in sequence.</returns>
    public static string GetNextNumber(string currentNumber)
    {
        decimal currentDecimal = ToDecimal(currentNumber);
        decimal nextDecimal = currentDecimal + 1;
        return GetBase36Number(nextDecimal);
    }
    /// <summary>
    /// Converts a Base36 number to decimal.
    /// </summary>
    /// <param name="base36Number">The Base36 number.</param>
    /// <returns>The decimal representation of the Base36 number.</returns>
    public static decimal ToDecimal(string base36Number)
    {
        decimal result = 0;
        foreach (char c in base36Number)
        {
            result = result * 36 + Base36Chars.IndexOf(c);
        }
        return result;
    }
}
