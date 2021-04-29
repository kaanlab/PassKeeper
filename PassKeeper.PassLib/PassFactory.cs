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
            var strigHelper = new Vocabulary();

            //for (int i = 0; i < count; i++)
            //{
            //    var randomInt = IntRange.empty == digits ? 0 : GetRandomInt(digits, random);
            //    var randomAdjectiveWord = GetRandomWord(adjectivesWords, random);
            //    var randomNounWord = GetRandomWord(nounsWords, random);
            //    var result = strigHelper.CreatePassAndPhrase(charsInPass, randomAdjectiveWord, randomNounWord, randomInt);
            //    passwords.TryAdd(result.password, result.phrase);
            //}

            return passwords;
        }

        private static string GetRandomWord(string[] words, Random random)
        {
            var index = random.Next(words.Length);
            return words[index];
        }

        private static int GetRandomInt(IntRange maxInt, Random random) => random.Next((int)maxInt);

        public static (string password, string phrase) CreatePassAndPhrase(int charsInPass, string adjectiveWord, string nounWord, int digitsInPass = 0)
        {
            var firtsPasswordWord = !string.IsNullOrEmpty(adjectiveWord) ? adjectiveWord.FirstCharUppercase() : "";
            var firstPasswordPart = ReplaceChars(firtsPasswordWord, charsInPass);
            var secondPasswordWord = !string.IsNullOrEmpty(nounWord) ? nounWord.FirstCharUppercase() : "";
            var secondPasswordPart = ReplaceChars(secondPasswordWord, charsInPass);

            var password = digitsInPass == 0 ? $"{firstPasswordPart}{ secondPasswordPart}" : $"{digitsInPass}{ firstPasswordPart}{ secondPasswordPart}";
            var phrase = digitsInPass == 0 ? $"{firtsPasswordWord} {secondPasswordWord}" : $"{digitsInPass} {firtsPasswordWord} {secondPasswordWord}";

            return (password, phrase);

        }

        private static string ReplaceChars(string inputWord, int wordLenth)
        {
            var rusKey = "Ё!\"№;%:?*()_+ЙЦУКЕНГШЩЗХЪ/ФЫВАПРОЛДЖЭЯЧСМИТЬБЮ,ё1234567890-=йцукенгшщзхъ\\фывапролджэячсмитьбю. ".ToArray();
            var engKey = "~!@#$%^&*()_+QWERTYUIOP{}|ASDFGHJKL:\"ZXCVBNM<>?`1234567890-=qwertyuiop[]\\asdfghjkl;'zxcvbnm,./ ".ToArray();

            var substring = inputWord.Substring(0, wordLenth);
            var sub = substring.ToCharArray();

            var outString = new StringBuilder();
            for (int i = 0; i < sub.Length; i++)
            {
                var rusIndex = sub[i];
                var index = Array.IndexOf(rusKey, rusIndex);
                outString.Append(engKey[index]);
            }

            return outString.ToString();
        }
    }
}
