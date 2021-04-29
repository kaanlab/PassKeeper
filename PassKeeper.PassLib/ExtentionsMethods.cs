using DeepMorphy.Model;
using System.IO;

namespace PassKeeper.PassLib
{
    public static class ExtentionsMethods
    {
        public static bool IsNoun(this MorphInfo morphInfo) => morphInfo["чр"].BestGramKey == "сущ";

        public static bool IsAjective(this MorphInfo morphInfo) => morphInfo["чр"].BestGramKey == "прил";

        public static string FirstCharUppercase(this string s) =>  char.ToUpper(s[0]) + s.Substring(1);


        public static void AppendTextToFile(this string path, string text)
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text);
                }
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(text);
            }
        }
    }
}
