using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassKeeper.PassLib
{
    public static class PassFactory
    {
        public static Dictionary<string, string> Create(int count, int charsInPass, string[] adjectivesWords, string[] nounsWords, IntRange digits = IntRange.empty)
        {
            var passwords = new Dictionary<string, string>();
            var random = new Random();
            var strigHelper = new StringHelper();

            for (int i = 0; i < count; i++)
            {
                var randomInt = IntRange.empty == digits ? 0 : GetRandomInt(digits, random);
                var randomAdjectiveWord = GetRandomWord(adjectivesWords, random);
                var randomNounWord = GetRandomWord(nounsWords, random);
                var result = strigHelper.CreatePassAndPhrase(charsInPass, randomAdjectiveWord, randomNounWord, randomInt);
                passwords.Add(result.password, result.phrase);
            }

            return passwords;
        }

        private static string GetRandomWord(string[] words, Random random)
        {
            var index = random.Next(words.Length);
            return words[index];
        }

        private static int GetRandomInt(IntRange maxInt, Random random) => random.Next((int)maxInt);
    }
}
