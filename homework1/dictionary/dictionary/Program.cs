using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dictionary
{
    internal class Program
    {
        const string START = "Enter an word to get translation or one of the commands:\n" +
            "RemoveTranslation - \"1 word\"\n" +
            "ChangeTranslation - \"2 word:newWord\"";
        const string GET_INPUT = "Enter an word to get translation (or '!' to quit): ";
        const string FINISH_COMMAND = "!";
        const string DELETE_COMMAND = "1";
        const string CHANGE_COMMAND = "2";
        const string UNKNOWN_WORD = "Word not found in the dictionary.\n" +
            "If you want to add a translation then enter tranlation or \"\" to ignore";
        const string SAVE_DICTIONARY = "Dictionary saved. Program finished.";
        const string ADD_TRANSLATION = "Translation has been added";
        const string REMOVE_TRANSLATION = "Translation has been delete";
        const string NOT_REMOVE_TRANSLATION = "Can't find word";
        const string CHANGE_TRANSLATION = "Translation has been changed";
        const string NOT_CHANGE_TRANSLATION = "Can't find word";
        const string START_PRINT_TRANSLATION = "Translation: ";

        static void ReadFile(string filePath, out Dictionary<string, List<string>> dictionary)
        {
            dictionary = new Dictionary<string, List<string>>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string eng = Regex.Replace(parts[0].Trim(), @"\s+", " ");
                        string rus = Regex.Replace(parts[1].Trim(), @"\s+", " ");
                        if (dictionary.ContainsKey(eng))
                        {
                            dictionary[eng].Add(rus);
                        }
                        else
                        {
                            dictionary[eng] = new List<string> { rus };
                        }

                        if (dictionary.ContainsKey(rus))
                        {
                            dictionary[rus].Add(eng);
                        }
                        else
                        {
                            dictionary[rus] = new List<string> { eng };
                        }
                    }
                }
            }
        }

        static void WriteToFile(Dictionary<string, List<string>> dictionary, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (KeyValuePair<string, List<string>> pair in dictionary)
                {
                    if (Regex.IsMatch(pair.Key, @"^[a-zA-Z\s]+$"))
                    {
                        foreach (string tranlation in pair.Value)
                        {
                            writer.WriteLine($"{pair.Key} : {tranlation}");
                        }
                    }
                }
            }
        }

        static void PrintTranslation(Dictionary<string, List<string>> dictionary, string input)
        {
            Console.WriteLine(START_PRINT_TRANSLATION);
            for (int i = 0; i < dictionary[input].Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(dictionary[input][i]);
                }
                else
                {
                    Console.Write(", " + dictionary[input][i]);
                }
            }
            Console.WriteLine();
        }

        static void AddTranslation(Dictionary<string, List<string>> dictionary, string input, string tranlation)
        {
            string eng = Regex.Replace(input.Trim(), @"\s+", " ");
            string rus = Regex.Replace(tranlation.Trim(), @"\s+", " ");

            dictionary[eng] = new List<string> { rus };

            if (dictionary.ContainsKey(rus))
            {
                dictionary[rus].Add(eng);
            }
            else
            {
                dictionary[rus] = new List<string> { eng };
            }
            Console.WriteLine(ADD_TRANSLATION);
        }

        static void RemoveTranslation(Dictionary<string, List<string>> dictionary, string input)
        {
            int spaceIndex = input.IndexOf(' ');
            if (spaceIndex != -1)
            {
                string delWord = input.Substring(spaceIndex + 1);
                if (dictionary.ContainsKey(delWord))
                {
                    List<string> listRemovingWords = dictionary[delWord];
                    dictionary.Remove(delWord);
                    foreach (string translation in listRemovingWords)
                    {
                        if (dictionary[translation].Count == 1)
                        {
                            dictionary.Remove(translation);
                        }
                        else
                        {
                            for (int i = 0; i < dictionary[translation].Count; i++)
                            {
                                if (dictionary[translation][i] == delWord)
                                {
                                    dictionary[translation].RemoveAt(i);
                                    break;
                                }
                            }
                        }
                    }
                    Console.WriteLine(REMOVE_TRANSLATION);
                    return;
                }
                Console.WriteLine(NOT_REMOVE_TRANSLATION);
            }
        }

        static void ChangeTranslation(Dictionary<string, List<string>> dictionary, string input)
        {
            int spaceIndex = input.IndexOf(' ');
            if (spaceIndex != -1)
            {
                string[] inputWords = input.Substring(spaceIndex + 1).Split(':');
                if (inputWords.Count() != 2)
                {
                    return;
                }
                string changeWord = Regex.Replace(inputWords[0].Trim(), @"\s+", " ");
                string newWord = Regex.Replace(inputWords[1].Trim(), @"\s+", " ");
                if (dictionary.ContainsKey(changeWord))
                {
                    List<string> list = dictionary[changeWord];
                    dictionary.Remove(changeWord);
                    dictionary[newWord] = list;
                    foreach (string translation in list)
                    {
                        for (int i = 0; i < dictionary[translation].Count; i++)
                        {
                            if (dictionary[translation][i] == changeWord)
                            {
                                dictionary[translation][i] = newWord;
                                break;
                            }
                        }
                    }
                    Console.WriteLine(CHANGE_TRANSLATION);
                    return;
                }
                Console.WriteLine(NOT_CHANGE_TRANSLATION);
            }
        }

        static void Main()
        {
            string filePath = "../../dictionary.txt";

            Dictionary<string, List<string>> dictionary;
            ReadFile(filePath, out dictionary);

            Console.WriteLine(START);
            bool finish = false;
            while (!finish)
            {
                Console.WriteLine(GET_INPUT);
                string input = Console.ReadLine();
                switch (input.Split(' ')[0].ToLower())
                {
                    case FINISH_COMMAND:
                        finish = true;
                        continue;
                    case DELETE_COMMAND:
                        RemoveTranslation(dictionary, input);
                        continue;
                    case CHANGE_COMMAND:
                        ChangeTranslation(dictionary, input);
                        continue;
                }

                if (dictionary.ContainsKey(input))
                {
                    PrintTranslation(dictionary, input);
                }
                else
                {
                    Console.WriteLine(UNKNOWN_WORD);
                    string tranlation = Console.ReadLine();
                    if (tranlation.Length == 0)
                    {
                        continue;
                    }
                    AddTranslation(dictionary, input, tranlation);
                }
            }
            WriteToFile(dictionary, filePath);
            Console.WriteLine(SAVE_DICTIONARY);
        }
    }
}
