using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertTxtDictionaryToDB.SQLite
{
    public class WordBuilder
    {
        public Words BuildWord(string word, List<string> definition, string metaData = null)
        {
            Words newWord = new Words();
            newWord.Word = word;

            for (int i = 0; i < definition.Count(); i++)
                newWord.Definition += definition[i];

            if (metaData != null)
            {
                newWord.MetaData = metaData;
                newWord.SyllableCount = GetSyllableCount(metaData, word);
                if (IsPartOfSpeech(metaData, "n."))
                    newWord.IsNoun = 1;
                if (IsPartOfSpeech(metaData, "pron."))
                    newWord.IsPronoun = 1;
                if (IsPartOfSpeech(metaData, "v."))
                    newWord.IsVerb = 1;
                if (IsPartOfSpeech(metaData, "adj.") || IsPartOfSpeech(metaData, "a."))
                    newWord.IsAdjective = 1;
                if (IsPartOfSpeech(metaData, "adv."))
                    newWord.IsAdverb = 1;
                if (IsPartOfSpeech(metaData, "t."))
                    newWord.IsTransitiveVerb = 1;
                if (IsPartOfSpeech(metaData, "i."))
                    newWord.IsIntransitiveVerb = 1;
                if (IsPartOfSpeech(metaData, "pre."))
                    newWord.IsPreposition = 1;
                if (IsPartOfSpeech(metaData, "conj."))
                    newWord.IsConjunction = 1;
                if (IsPartOfSpeech(metaData, "interj."))
                    newWord.IsInterjection = 1;
                if (IsPartOfSpeech(metaData, "pl."))
                    newWord.IsPlural = 1;
                if (IsPartOfSpeech(metaData, "sing."))
                    newWord.IsSingular = 1;
            }
            return newWord;
        }

        public int GetSyllableCount(string wordMetaData, string word)
        {
            // example word from metadata: Guar"an*tee`,
            string[] meta = wordMetaData.Split(',');
            string buffer;

            buffer = wordMetaData.ToLower();
            char[] charMeta = buffer.ToCharArray();

            buffer = word.ToLower();
            char[] charWord = buffer.ToCharArray();

            bool isPrevCharSymbol = false;
            bool isCounted = false;
            int count = 0;

            int x = 0;
            int y = 0;
            while(true)
            {
                if (x >= charMeta.Count() || y >= charWord.Count())
                    break;

                if (charMeta[x] != charWord[y]) // if symbol
                {
                    x++;
                    if (x >= charMeta.Count())
                        break;
                    isPrevCharSymbol = true;
                    isCounted = false;
                }

                if(charMeta[x] == charWord[y]) // if letter
                {
                    x++;
                    y++;
                    isPrevCharSymbol = false;
                }

                if(isPrevCharSymbol == false && isCounted == false)
                {
                    count++;
                    isCounted = true;
                }
            }
            return count;
        }

        public bool IsPartOfSpeech(string wordMetaData, string compare)
        {
            if (compare.Contains('.') == false) // compare examples: v. n. pl. sing. adj.
                return false;
            if (wordMetaData.Contains(compare) == true)
            {
                char[] charCompare = compare.ToCharArray();
                int charIndex = wordMetaData.IndexOf(charCompare[0]);

                if (charIndex == 0)
                    return false;

                if (char.IsLetter(wordMetaData.ElementAt(charIndex - 1)))
                {
                    return false;
                }
                return true;
            }
            else return false;
        }
    }
}
