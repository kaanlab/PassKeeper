using DeepMorphy;
using DeepMorphy.Model;
using System.Collections.Generic;
using System.Linq;


namespace PassKeeper.PassLib
{
    public class WordAnalizer
    {
        private readonly MorphAnalyzer _morphAnalyzer;
        public WordAnalizer()
        {
            _morphAnalyzer = new MorphAnalyzer(withLemmatization: true);
        }

        public MorphInfo GetMorphInfo(string word) => _morphAnalyzer.Parse(word).FirstOrDefault();

        public string NounToPlural(string word)
        {
            var morphInfo = GetMorphInfo(word);
            
            var task = new InflectTask(morphInfo.Text,
                                              morphInfo.BestTag,
                                              _morphAnalyzer.TagHelper.CreateTag("сущ", gndr: "муж", @case: "рд", nmbr: "мн"));

            var tasks = new List<InflectTask>();
            tasks.Add(task);
            var results = _morphAnalyzer.Inflect(tasks);

            return results.FirstOrDefault();
        }

        public string AdjectiveToPlural(string word)
        {
            var morphInfo = GetMorphInfo(word);

            var task = new InflectTask(morphInfo.Text,
                                              morphInfo.BestTag,
                                              _morphAnalyzer.TagHelper.CreateTag("прил", @case: "рд", nmbr: "мн"));

            var tasks = new List<InflectTask>();
            tasks.Add(task);
            var results = _morphAnalyzer.Inflect(tasks);

            return results.FirstOrDefault();
        }

    }
}
