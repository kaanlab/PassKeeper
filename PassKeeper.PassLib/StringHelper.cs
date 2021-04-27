using DeepMorphy;
using DeepMorphy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassKeeper.PassLib
{
    public class StringHelper
    {
        private readonly MorphAnalyzer _morphAnalyzer;
        public StringHelper()
        {
            _morphAnalyzer = new MorphAnalyzer(withLemmatization: true);
        }

        public IEnumerable<string> ToGenitiveToPlural(string[] dictionary)
        {
            if (dictionary.Length < 0)
                return Enumerable.Empty<string>();

            dictionary = dictionary.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var morphInfos = _morphAnalyzer.Parse(dictionary);
            var tasks = new List<InflectTask>();
            foreach (var morphInfo in morphInfos)
            {
                if (morphInfo.IsNoun())
                {
                    var task = new InflectTask(morphInfo.Text,
                                                  morphInfo.BestTag,
                                                  _morphAnalyzer.TagHelper.CreateTag("сущ", gndr: "муж", @case: "рд", nmbr: "мн"));

                    tasks.Add(task);
                }

                if (morphInfo.IsAjective())
                {
                    var task = new InflectTask(morphInfo.Text,
                                              morphInfo.BestTag,
                                              _morphAnalyzer.TagHelper.CreateTag("прил", @case: "рд", nmbr: "мн"));
                    tasks.Add(task);
                }

            }

            return _morphAnalyzer.Inflect(tasks);

        }

        public (string password, string phrase) CreatePassAndPhrase(int charsInPass, string adjectiveWord, string nounWord, int digitsInPass = 0)
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
