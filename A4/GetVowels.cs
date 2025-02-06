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
        string vowels = "abcdefghijklmnop".GetVowels();
        Console.WriteLine(vowels);
    }
}
