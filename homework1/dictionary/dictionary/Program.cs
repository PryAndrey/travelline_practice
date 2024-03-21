using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace dictionary
{
    internal class Program
    {
        const string START = "Enter an word to get translation or one of the commands:\n\"RemoveTranslation word\"\n\"ChangeTranslation word:newWord\"";
        const string GET_INPUT = "Enter an word to get translation (or '!' to quit): ";
        const string DELETE_COMMAND = "removetranslation";
        const string CHANGE_COMMAND = "changetranslation";
        const string UNKNOWN_WORD = "Word not found in the dictionary.\n" +
            "If you want to add a translation then enter tranlation or \"\" to ignore";
        const string SAVE_DICTIONARY = "Dictionary saved. Program finished.";
        const string ADD_TRANSLATION = "Translation has been added";
        const string REMOVE_TRANSLATION = "Translation has been delete";
        const string NOT_REMOVE_TRANSLATION = "Can't find word";
        const string CHANGE_TRANSLATION = "Translation has been changed";
        const string NOT_CHANGE_TRANSLATION = "Can't find word";
        const string START_PRINT_TRANSLATION = "Translation: ";
        static void ReadFile(ref Dictionary<string, List<string>> dictionary, string filePath)
        {
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
                            dictionary[eng].Add(rus);
                        else
                            dictionary[eng] = new List<string> { rus };

                        if (dictionary.ContainsKey(rus))
                            dictionary[rus].Add(eng);
                        else
                            dictionary[rus] = new List<string> { eng };
                    }
                }
                int a = 0;
            }
        }
        static void WriteFile(ref Dictionary<string, List<string>> dictionary, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var pair in dictionary)
                {
                    if (Regex.IsMatch(pair.Key, @"^[a-zA-Z\s]+$"))
                        foreach (var tranlation in pair.Value)
                        {
                            writer.WriteLine($"{pair.Key} : {tranlation}");
                        }
                }
            }
        }
        static void PrintTranslation(ref Dictionary<string, List<string>> dictionary, string input)
        {
            Console.WriteLine(START_PRINT_TRANSLATION);
            for (int i = 0; i < dictionary[input].Count; i++)
            {
                if (i == 0)
                    Console.Write(dictionary[input][i]);
                else
                    Console.Write(", " + dictionary[input][i]);
            }
            Console.WriteLine();
        }
        static void AddTranslation(ref Dictionary<string, List<string>> dictionary, string input, string tranlation)
        {
            string eng = Regex.Replace(input.Trim(), @"\s+", " ");
            string rus = Regex.Replace(tranlation.Trim(), @"\s+", " ");

            dictionary[eng] = new List<string> { rus };

            if (dictionary.ContainsKey(rus))
                dictionary[rus].Add(eng);
            else
                dictionary[rus] = new List<string> { eng };
            Console.WriteLine(ADD_TRANSLATION);
        }
        static void RemoveTranslation(ref Dictionary<string, List<string>> dictionary, string input)
        {
            int spaceIndex = input.IndexOf(' ');
            if (spaceIndex != -1)
            {
                string delWord = input.Substring(spaceIndex + 1);
                if (dictionary.ContainsKey(delWord))
                {
                    List<string> list = dictionary[delWord];
                    dictionary.Remove(delWord);
                    foreach (var translation in list)
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
        static void ChangeTranslation(ref Dictionary<string, List<string>> dictionary, string input)
        {
            int spaceIndex = input.IndexOf(' ');
            if (spaceIndex != -1)
            {

                string[] inputWords = input.Substring(spaceIndex + 1).Split(':');
                if (inputWords.Count() != 2)
                    return;
                string changeWord = Regex.Replace(inputWords[0].Trim(), @"\s+", " ");
                string newWord = Regex.Replace(inputWords[1].Trim(), @"\s+", " ");
                if (dictionary.ContainsKey(changeWord))
                {
                    List<string> list = dictionary[changeWord];
                    dictionary.Remove(changeWord);
                    dictionary[newWord] = list;
                    foreach (var translation in list)
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
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            ReadFile(ref dictionary, filePath);

            Console.WriteLine(START);

            while (true)
            {
                Console.WriteLine(GET_INPUT);
                string input = Console.ReadLine();

                if (input.ToLower() == "!")
                    break;
                if (input.Split(' ')[0].ToLower() == DELETE_COMMAND)
                {
                    RemoveTranslation(ref dictionary, input);
                    continue;
                }
                if (input.Split(' ')[0].ToLower() == CHANGE_COMMAND)
                {
                    ChangeTranslation(ref dictionary, input);
                    continue;
                }

                if (dictionary.ContainsKey(input))
                    PrintTranslation(ref dictionary, input);
                else
                {
                    Console.WriteLine(UNKNOWN_WORD);
                    string tranlation = Console.ReadLine();
                    if (tranlation.Length == 0)
                        continue;
                    AddTranslation(ref dictionary, input, tranlation);
                }
            }
            WriteFile(ref dictionary, filePath);
            Console.WriteLine(SAVE_DICTIONARY);
        }
    }
}
