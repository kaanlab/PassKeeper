using DeepMorphy.Model;


namespace PassKeeper.PassLib
{
    public static class ExtentionsMethods
    {
        public static bool IsNoun(this MorphInfo morphInfo) => (morphInfo["чр"].BestGramKey == "сущ");

        public static bool IsAjective(this MorphInfo morphInfo) => (morphInfo["чр"].BestGramKey == "прил");

        public static string FirstCharUppercase(this string s) =>  char.ToUpper(s[0]) + s.Substring(1);
    }
}
