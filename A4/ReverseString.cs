using System;

public static class StringExtensions
{
    public static string ReverseString(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }

        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

class Program
{
    static void Main()
    {
        string original = "110101";
        string reversed = original.ReverseString();
        Console.WriteLine(reversed); // Output: 101011
    }
}
