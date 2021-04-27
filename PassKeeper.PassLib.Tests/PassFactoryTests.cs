using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PassKeeper.PassLib.Tests
{
    public class PassFactoryTests
    {        
        [Fact]
        public void GenerateOnePassword_TakeRandomFromTwoDigitsFourCharsFromTwoWords_ReturnDictionaryWithPasswordAndPasswordPhrase()
        {
            var passwordCount = 1;
            var charsInPassword = 4;
            var adjeciveWords = new[] { "канониров", "глыб" };
            var nounsWors = new[] { "абажуров", "козликов" };
 
            var result = PassFactory.Create(passwordCount, charsInPassword, adjeciveWords, nounsWors);

            result.Should().HaveCount(1);
        }
    }
}
