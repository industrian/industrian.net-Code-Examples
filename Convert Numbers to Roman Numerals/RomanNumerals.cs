using System;

class RomanNumerals
{
    // List the total potential Roman numerals, sorted into fields of hundreds, tens, and ones.
    private static readonly string[] hundreds = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
    private static readonly string[] tens = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
    private static readonly string[] ones = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

    /// <summary>
    /// Returns the value in Roman numerals as a string (for example: 2525 is returned as "MMDXXV").
    /// </summary>
    /// <param name="value">The value to convert to Roman numerals. Negative values are not supported. Due to the limitations of Roman numerals, it is not recommended to use values in excess of 4000.</param>
    public static string ReturnRomanNumerals(ushort value)
    {
        // Immediately return a 0 value. There is no set Roman numeral value for zero, but some people used "nulla" - Latin for "nothing". It's best if you avoid sending a 0 value to this method.
        if (value == 0) { return "nulla"; }

        // This string holds the value to be returned.
        string returnValue = "";

        // Thousands: For every thousand, add an "M".
        for (int i = 0; i < value / 1000; i++)
        {
            returnValue += "M";
        }

        // Hundreds

        //Create an index for the above "hundreds" field by dividing the value by 100.
        int hundredsIndex = (value / 100);

        // Set hundredsIndex as the remainder of hundredsIndex divided by 10.
        hundredsIndex %= 10;

        // Add the value from hundreds using hundredsIndex.
        returnValue += hundreds[hundredsIndex];

        // Tens

        // Create an index for the above "tens" field by dividing the value by 10.
        int tensIndex = (value / 10);

        // Set tensIndex as the remainder of tensIndex divided by 10.
        tensIndex %= 10;

        // Add the value from tens using the tensIndex.
        returnValue += tens[tensIndex];

        //Ones

        // Create an index for the above "ones" field by getting the remainder of the value divided by 10.
        int onesIndex = value % 10;

        // Add the value from ones using the onesIndex.
        returnValue += ones[onesIndex];

        // Return the finished string.
        return returnValue;
    }
}
