using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();

        string result = CapitalizeSentences(input);
        Console.WriteLine($"Результат: {result}");
    }

    static string CapitalizeSentences(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        char[] delimiters = { '.', '!', '?' };
        string[] sentences = text.Split(delimiters, StringSplitOptions.None);

        for (int i = 0; i < sentences.Length; i++)
        {
            string sentence = sentences[i].Trim();
            if (sentence.Length > 0)
            {
                sentences[i] = char.ToUpper(sentence[0]) + sentence.Substring(1);
            }
        }

        string result = "";
        int sentenceIndex = 0;
        foreach (char ch in text)
        {
            result += ch;
            if (Array.Exists(delimiters, d => d == ch))
            {
                if (sentenceIndex < sentences.Length)
                {
                    result += " " + sentences[sentenceIndex++];
                }
            }
        }

        return result.Trim();
    }
}