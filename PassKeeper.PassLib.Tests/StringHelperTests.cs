using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PassKeeper.PassLib.Tests
{
    public class StringHelperTests
    {
        private readonly StringHelper _sut;

        public StringHelperTests()
        {
            _sut = new StringHelper();
        }

        [Fact]
        public void ChangeGenitiveAndPlural_ArrayWithEmptyString_ReturnEmptyArray()
        {

            var words = new[] { "" };

            var result = _sut.ToGenitiveToPlural(words);

            result.Should().BeEquivalentTo(Enumerable.Empty<string>());
        }

        [Fact]
        public void ChangeGenitiveAndPlural_ArrayWithOneNounAndOneEmptyString_ReturnOneNounInGenitiveInPlural()
        {
            var words = new[] { "абажур", "" };

            var result = _sut.ToGenitiveToPlural(words);

            result.Should().BeEquivalentTo(new[] { "абажуров" });
        }

        [Fact]
        public void ChangeGenitiveAndPlural_EmptyArray_ReturnEmptyArray()
        {
            var words = Array.Empty<string>();

            var result = _sut.ToGenitiveToPlural(words);

            result.Should().BeEquivalentTo(Enumerable.Empty<string>());
        }

        [Fact]
        public void ChangeGenitiveAndPlural_ArrayWithOneNoun_ReturnOneNounInGenitiveInPlural()
        {
            var words = new[] { "абажур" };

            var result = _sut.ToGenitiveToPlural(words);

            result.Should().BeEquivalentTo(new[] { "абажуров" });
        }

        [Fact]
        public void ChangeGenitiveAndPlural_ArrayWithTwoNoun_ReturnTwoNounInGenitiveInPlural()
        {
            var words = new[] { "абажур", "козлик" };

            var result = _sut.ToGenitiveToPlural(words);

            result.Should().BeEquivalentTo(new[] { "абажуров", "козликов" });
        }

        [Fact]
        public void ChangeToGenitiveToPlural_ArrayWithOneAjective_ReturnOneAjeciveToGenitiveToPlural()
        {
            var words = new[] { "глыба" };

            var result = _sut.ToGenitiveToPlural(words);

            result.Should().BeEquivalentTo(new[] { "глыб" });
        }

        [Fact]
        public void ChangeGenitiveAndPlural_ArrayWithTwoAjective_ReturnTwoAjectiveInGenitiveInPlural()
        {
            var words = new[] { "глыба", "канонир" };

            var result = _sut.ToGenitiveToPlural(words);

            result.Should().BeEquivalentTo(new[] { "глыб", "канониров" });
        }

        [Fact]
        public void CreatePassAndPhrase_FourDigitsAndTwoWords_ReturnPasswordAddPhrase()
        {
            var ajectiveWord = "канониров";
            var nounWord = "козликов";

            var result = _sut.CreatePassAndPhrase(4, ajectiveWord, nounWord);

            result.Should().Be(("RfyjRjpk", $"Канониров Козликов"));
        }

        [Fact]
        public void CreatePassAndPhrase_FourDigitsAndTwoWordsAndNumbers_ReturnPasswordAddPhraseAdnNumbers()
        {
            var ajectiveWord = "канониров";
            var nounWord = "козликов";

            var result = _sut.CreatePassAndPhrase(4, ajectiveWord, nounWord, 88);

            result.Should().Be(("88RfyjRjpk", $"88 Канониров Козликов"));
        }

    }
}
