using System;
using System.Text;

public static class StringExtensions
{
    public static string ToTitleCase(this string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return str;
        
        string[] words = str.Split(' ');
        StringBuilder sb = new StringBuilder();
        
        foreach (string word in words)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                sb.Append(char.ToUpper(word[0]));
                if (word.Length > 1)
                {
                    sb.Append(word.Substring(1).ToLower());
                }
            }
            sb.Append(' ');
        }
        
        return sb.ToString().Trim();
    }
}

class Program
{
    static void Main()
    {
        string sentence = "first LETTER uPPER Case";
        Console.WriteLine(sentence.ToTitleCase());
    }
}
