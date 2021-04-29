using DeepMorphy;
using DeepMorphy.Model;
using PassKeeper.PassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassKeeper.PassLib
{
    public class Vocabulary
    {
        private readonly MorphAnalyzer _morphAnalyzer;
        public Vocabulary()
        {
            _morphAnalyzer = new MorphAnalyzer(withLemmatization: true);
        }


        public string AjectiveToGenitiveToPlural(MorphInfo morphInfo)
        {
            var tasks = new[] { new InflectTask(morphInfo.Text, morphInfo.BestTag, _morphAnalyzer.TagHelper.CreateTag("прил", @case: "рд", nmbr: "мн")) };

            return _morphAnalyzer.Inflect(tasks).First();
        }

        public string AjectiveToW(MorphInfo morphInfo)
        {
            var tasks = new[] { new InflectTask(morphInfo.Text, morphInfo.BestTag, _morphAnalyzer.TagHelper.CreateTag("прил", gndr: "жен", @case: "им", nmbr: "ед")) };

            return _morphAnalyzer.Inflect(tasks).First();
        }


        public string NounToW(MorphInfo morphInfo)
        {
            var tasks = new[] { new InflectTask(morphInfo.Text, morphInfo.BestTag, _morphAnalyzer.TagHelper.CreateTag("сущ", gndr: "жен", @case: "им", nmbr: "ед")) };

            return _morphAnalyzer.Inflect(tasks).First();
        }

        public string NounToGenitiveToPlural(MorphInfo morphInfo)
        {
            var tasks = new[] { new InflectTask(morphInfo.Text, morphInfo.BestTag, _morphAnalyzer.TagHelper.CreateTag("сущ", @case: "рд", nmbr: "мн")) };

            return _morphAnalyzer.Inflect(tasks).First();
        }

        public string GetLemma(string word)
        {
            var morphInfo = _morphAnalyzer.Parse(word).First();

            return morphInfo.BestTag.Lemma;
        }

        public bool IsAjective(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            var morphInfo = _morphAnalyzer.Parse(word).First();

            return morphInfo.IsAjective();
        }

        public bool IsNoun(string word)
        {
            if (string.IsNullOrEmpty(word))
                return false;

            var morphInfo = _morphAnalyzer.Parse(word).First();

            return morphInfo.IsNoun();
        }


        public IEnumerable<Word> Add(string[] words)
        {
            List<Word> vocabulary = new();
            var morphInfos = _morphAnalyzer.Parse(words);

            foreach (var morphInfo in morphInfos)
            {
                vocabulary.Add(CreateWord(morphInfo));
            }

            return vocabulary;
        }

        public Word Add(string word)
        {
            var morphInfo = _morphAnalyzer.Parse(word).First();

            return CreateWord(morphInfo);
        }

        private Word CreateWord(MorphInfo morphInfo)
        {
            var addWord = new Word();
            if (morphInfo.IsAjective())
            {
                addWord.PartOfSpeech = PartOfSpeech.Adjective;
                addWord.NominativeM = GetLemma(morphInfo.Text);
                addWord.NominativeW = AjectiveToW(morphInfo);
                addWord.GenetivePlural = AjectiveToGenitiveToPlural(morphInfo);
            }

            if (morphInfo.IsNoun())
            {
                addWord.PartOfSpeech = PartOfSpeech.Noun;
                addWord.NominativeM = GetLemma(morphInfo.Text);
                addWord.NominativeW = NounToW(morphInfo);
                addWord.GenetivePlural = NounToGenitiveToPlural(morphInfo);
            }

            return addWord;
        }

    }
}
