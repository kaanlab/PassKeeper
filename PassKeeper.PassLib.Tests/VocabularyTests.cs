using FluentAssertions;
using PassKeeper.PassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PassKeeper.PassLib.Tests
{
    public class VocabularyTests
    {
        [InlineData("", false)]
        [InlineData("123", false)]
        [InlineData("абажур", false)]        
        [InlineData("аббат", false)]
        [InlineData("аббатство", false)]
        [InlineData("абрисный", true)]
        [InlineData("абажурный", true)]
        [InlineData("авиаспортивный", true)]
        [Theory]
        public void Check_if_the_word_is_ajective(string input, bool expected)
        {
            var sut = CreateStringHelper();
            var result = sut.IsAjective(input);

            result.Should().Be(expected);
        }


        [InlineData("", false)]
        [InlineData("123", false)]
        [InlineData("абажур", true)]
        [InlineData("аббат", true)]
        [InlineData("аббатство", true)]
        [InlineData("абрисный", false)]
        [InlineData("абажурный", false)]
        [InlineData("авиаспортивный", false)]
        [Theory]
        public void Check_if_the_word_is_noun(string input, bool expected)
        {
            var sut = CreateStringHelper();
            var result = sut.IsNoun(input);

            result.Should().Be(expected);
        }


        [MemberData(nameof(Data))]
        [Theory]
        public void Add_one_word_to_vocabulary(string word, Word expected)
        {
            var sut = CreateStringHelper();
            var result = sut.Add(word);

            result.Should().Be(expected);
        }


        private static Vocabulary CreateStringHelper() => new Vocabulary();

        public static List<object[]> Data()
        {
            return new List<object[]>
            {
                new object[] { "затейливая", new Word { PartOfSpeech = PartOfSpeech.Adjective, NominativeM = "затейливый", NominativeW="затейливая", GenetivePlural = "затейливых" } },
                new object[] { "абажурный", new Word { PartOfSpeech = PartOfSpeech.Adjective, NominativeM = "абажурный", NominativeW = "абажурная", GenetivePlural = "абажурных" } },
                new object[] { "генеалогический", new Word { PartOfSpeech = PartOfSpeech.Adjective, NominativeM = "генеалогический", NominativeW = "генеалогическая", GenetivePlural = "генеалогических" } },
                new object[] { "мнительная", new Word { PartOfSpeech = PartOfSpeech.Adjective, NominativeM = "мнительный", NominativeW = "мнительная", GenetivePlural = "мнительных" } }
            };
        }

    }
}
