using System;
using System.Text;

class Program
{
    static void Main()
    {
        var words = new List<string> { "sentence", "separated", "by", "comma" };

        string result = GenerateCommaSeparatedString(words);

        Console.WriteLine(result);
    }

    static string GenerateCommaSeparatedString(List<string> words)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < words.Count; i++)
        {
            sb.Append(words[i]);

            if (i < words.Count - 1)
            {
                sb.Append(", ");
            }
        }
        return sb.ToString();
    }
}