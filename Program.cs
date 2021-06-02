using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertTxtDictionaryToDB
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertTxtDictionaryToDB.SQLite.ParseDictionary.BuildDB();
            Console.ReadLine();
        }
    }
}
