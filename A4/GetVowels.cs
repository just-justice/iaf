using System;

public static class StringExtensions
{
    public static string GetVowels(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }
        
        string vowels = "";
        foreach (char c in str)
        {
            if ("AEIOUaeiou".IndexOf(c) >= 0)
            {
                 vowels += c;
            }
        }
        return vowels;
    }
}

class Program
{
    static void Main()
    {
        // Example usage of GetVowels()
        string vowels = "hello world".GetVowels();
        Console.WriteLine(vowels); // Output: eoo
    }
}
