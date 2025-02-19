using System;
using System.Text;

public static class MarkdownConverter
{
    public static string ConvertToHtml(string markdown)
    {
        if (string.IsNullOrWhiteSpace(markdown))
            return string.Empty;

        StringBuilder sb = new StringBuilder();
        string[] lines = markdown.Split('\n');

        foreach (string line in lines)
        {
            string trimmedLine = line.Trim();
            if (trimmedLine.StartsWith("# "))
            {
                sb.Append("<h1>").Append(trimmedLine.Substring(2)).Append("</h1>\n"); //trimmedLine.Substring(2) returns remainder string after first two char
            }
            else if (trimmedLine.StartsWith("## "))
            {
                sb.Append("<h2>").Append(trimmedLine.Substring(3)).Append("</h2>\n");
            }
            else if (trimmedLine.StartsWith("### "))
            {
                sb.Append("<h3>").Append(trimmedLine.Substring(4)).Append("</h3>\n");
            }
            else if (trimmedLine.StartsWith("#### "))
            {
                sb.Append("<h4>").Append(trimmedLine.Substring(5)).Append("</h4>\n");
            }
            else if (trimmedLine.StartsWith("##### "))
            {
                sb.Append("<h5>").Append(trimmedLine.Substring(6)).Append("</h5>\n");
            }
            else if (trimmedLine.StartsWith("###### "))
            {
                sb.Append("<h6>").Append(trimmedLine.Substring(7)).Append("</h6>\n");
            }
        }
        
        return sb.ToString();
    }
}

class Program
{
    static void Main()
    {
        string markdown = "# Heading 1\n## Heading 2\n### Heading 3\n";
        Console.WriteLine(MarkdownConverter.ConvertToHtml(markdown));
    }
}
