using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassKeeper.PassLib
{
    public static class PassFabric
    {
        public static Dictionary<string, string> Create(int count, (IntRange digitsInPass, int charsInPass) passTemplate, (string adjectivesDictionary, string nounsDictionary) pathTo)
        {
            var passwords = new Dictionary<string, string>();
            var wordAnalizer = new WordAnalizer();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var randomInt = GetRandomInt(passTemplate.digitsInPass, random);

                var adjectiveWords = File.ReadAllLines(pathTo.adjectivesDictionary);
                var pluralAdjective = "";

                while (string.IsNullOrEmpty(pluralAdjective))
                {
                    // get random word
                    var randomWord = GetRandomWord(adjectiveWords, random);

                    // chek for adjective
                    var adjective = wordAnalizer.GetMorphInfo(randomWord).IsAjective() ? randomWord : "";

                    // translate to plural 
                    if (!string.IsNullOrEmpty(adjective))
                        pluralAdjective = wordAnalizer.AdjectiveToPlural(adjective).FirstCharUppercase();
                }

                var firstPasswordPart = ReplaceChars(pluralAdjective, passTemplate.charsInPass);

                var nounWords = File.ReadAllLines(pathTo.nounsDictionary);
                var pluralNoun = "";

                while (string.IsNullOrEmpty(pluralNoun))
                {
                    // get random word
                    var randomWord = GetRandomWord(nounWords, random);

                    // chek for noun
                    var noun = wordAnalizer.GetMorphInfo(randomWord).IsNoun() ? randomWord : "";

                    // translate to plural 
                    if (!string.IsNullOrEmpty(noun))
                        pluralNoun = wordAnalizer.NounToPlural(noun).FirstCharUppercase();
                }

                var secondPasswordPart = ReplaceChars(pluralNoun, passTemplate.charsInPass);

                passwords.Add($"{randomInt}{firstPasswordPart}{secondPasswordPart}", $"{randomInt} {pluralAdjective} {pluralNoun}");
            }

            return passwords;
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

        private static string GetRandomWord(string[] words, Random random)
        {
            var index = random.Next(words.Length - 1);
            return words[index];
        }

        private static int GetRandomInt(IntRange maxInt, Random random) => random.Next((int)maxInt);
    }
}
