using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder sentenceBuilder = new StringBuilder();

        sentenceBuilder.Append("use");
        sentenceBuilder.Append(" ");
        sentenceBuilder.Append("StringBuilder");
        sentenceBuilder.Append(" ");
        sentenceBuilder.Append("to");
        sentenceBuilder.Append(" ");
        sentenceBuilder.Append("create");
        sentenceBuilder.Append(" ");
        sentenceBuilder.Append("a");
        sentenceBuilder.Append(" ");
        sentenceBuilder.Append("sentence");

        string sentence = sentenceBuilder.ToString();

       Console.WriteLine(sentence);
    }
}