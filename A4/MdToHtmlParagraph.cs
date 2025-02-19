using System;
using System.Text;

public static class MarkdownConverter
{
    public static string ConvertToHtml(string markdown)
    {
        StringBuilder sb = new StringBuilder();
        string[] paragraphs = markdown.Split(new string[] { "\n\n" });

        foreach (string paragraph in paragraphs)
        {
            string trimmedParagraph = paragraph.Trim();
            if (!string.IsNullOrEmpty(trimmedParagraph))
            {
                sb.Append("<p>").Append(trimmedParagraph).Append("</p>\n");
            }
        }
        
        return sb.ToString();
    }
}

class Program
{
    static void Main()
    {
        string markdown = "I really like using Markdown.\n\nI think I'll use it to format all of my documents from now on.";
        Console.WriteLine(MarkdownConverter.ConvertToHtml(markdown));
    }
}
