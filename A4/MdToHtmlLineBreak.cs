using System;
using System.Text;

public static class MarkdownConverter
{
    public static string ConvertToHtml(string markdown)
    {
        StringBuilder sb = new StringBuilder();
        string[] lines = markdown.Split(new string[] { "\n" }, StringSplitOptions.None); // Split by line breaks

        foreach (string line in lines)
        {
            string trimmedLine = line.Trim();
            if (!string.IsNullOrEmpty(trimmedLine))
            {
                sb.Append(trimmedLine).Append("<br>\n"); // Append each line with <br> for line breaks
            }
        }
        
        return sb.ToString();
    }
}

class Program
{
    static void Main()
    {
        string markdown = "This is the first line.\nAnd this is the second line.";
        Console.WriteLine(MarkdownConverter.ConvertToHtml(markdown));
    }
}
