using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertTxtDictionaryToDB.SQLite
{
    public static class ParseDictionary
    {
        public static void BuildDB()
        {
            DatabaseContext context = new DatabaseContext();
            Words newWord = new Words();
            WordBuilder wordBuilder = new WordBuilder();
            DateTime timeStart = DateTime.Now;
            double secondsElapsed = 0;
            StreamReader reader = File.OpenText("pg29765.txt"); // copy can be found for free online. txt file is public domain.
            string line = string.Empty;
            string word = string.Empty;
            string wordMetaData = string.Empty;
            List<string> definition = new List<string>();
            List<string> noMetaData = new List<string>(); // Used for output to the console
            List<Words> wordsList = new List<Words>();

            line = reader.ReadLine(); // prime the loop
            while (true) // begin
            {
                if (line == null)
                    break;

                word = string.Empty;
                wordMetaData = string.Empty;
                definition.Clear();

                if (line.All(char.IsUpper))
                {
                    word = line;
                }


                if(word != string.Empty) // word found
                {
                    line = reader.ReadLine(); // diction and use always follows the word to be defined.
                    wordMetaData = line;

                    while (true) // begin definition
                    {
                        line = reader.ReadLine();

                        if (line == null)
                            break;
                        else if (line.All(char.IsUpper) == true && line.All(char.IsWhiteSpace) == false) // white space == uppercase for some reason
                            break;

                        if(line.All(char.IsWhiteSpace) == false)
                            definition.Add(line);
                    }

                    if (definition.Count > 0 && word != string.Empty && wordMetaData != string.Empty)
                    {
                        wordsList.Add(wordBuilder.BuildWord(word, definition, wordMetaData));
                        //context.Words.Add(wordBuilder.BuildWord(word, definition, wordMetaData));
                        Console.WriteLine(word);
                    }
                    else
                    {
                        wordsList.Add(wordBuilder.BuildWord(word, definition));
                        //context.Words.Add(wordBuilder.BuildWord(word, definition));
                        noMetaData.Add(word);
                    }


                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < noMetaData.Count(); i++)
                Console.WriteLine(noMetaData[i]);
            Console.ResetColor();

            Console.WriteLine("Saving database...");
            for(int i = 0; i < wordsList.Count; i++)
            {
                context.Words.Add(wordsList[i]);
            }
            context.SaveChanges(); 
            Console.WriteLine("Save complete!");

            secondsElapsed = (DateTime.Now - timeStart).TotalSeconds;
            Console.WriteLine(string.Format("The process took {0} seconds", secondsElapsed));
        }
    }
}
