using System;
using System.Text;

public static class MarkdownConverter
{
    public static string ConvertToHtml(string markdown)
    {
        StringBuilder sb = new StringBuilder();
        string[] lines = markdown.Split(new string[] { "\n" });

        foreach (string line in lines)
        {
            string trimmedLine = line.Trim();
            if (!string.IsNullOrEmpty(trimmedLine))
            {
                // Convert bold (**text**) to <b>text</b>
                trimmedLine = trimmedLine.Replace("**", "<b>").Replace("**", "</b>");

                // Convert italic (*text*) to <i>text</i> (using asterisks only)
                trimmedLine = trimmedLine.Replace("*", "<i>").Replace("*", "</i>");
                
                // Convert bold and italic (***text***) to <b><i>text</i></b>
                trimmedLine = trimmedLine.Replace("***", "<b><i>").Replace("***", "</i></b>");

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
        string markdown = "This is **bold** text.\nThis is *italic* text.\nThis is ***bold and italic*** text.";
        Console.WriteLine(MarkdownConverter.ConvertToHtml(markdown));
    }
}
