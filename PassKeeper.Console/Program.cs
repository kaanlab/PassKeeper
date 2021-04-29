using PassKeeper.PassLib;
using System;
using System.IO;

namespace PassKeeper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var nounWords = File.ReadAllLines("nouns.txt");
            var adjectiveWords = File.ReadAllLines("ajectives.txt");

            var vocaboulary = new Vocabulary();

            var ajectivesOutputFile = "ajectives_only.txt";
            foreach (var word in adjectiveWords)
            {
                if (vocaboulary.IsAjective(word))
                    ajectivesOutputFile.AppendTextToFile(word);
            }

            var nounsOutputFile = "nouns_only.txt";
            foreach (var word in nounWords)
            {
                if (vocaboulary.IsNoun(word))
                    nounsOutputFile.AppendTextToFile(word);
            }

        }
    }
}
