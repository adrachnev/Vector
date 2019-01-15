using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordsGenerator.UnitTests
{
    [TestClass]
    public class GeneratorTest
    {
        private List<Word> _generatedWords;

        [TestInitialize]
        public void Init()
        {
            _generatedWords = Generator.GetWords();
        }

        [TestMethod]
        public void WordsCountTest()
        {
            int numberOfPositions = 4;
            
            Assert.IsTrue(_generatedWords.Count == Math.Pow(Word.Alphabet.Count, numberOfPositions));
        }

        [TestMethod]
        public void WordsUniqueCombinationsTest()
        {
            var distictList = _generatedWords.Distinct(new WordComparer());

            Assert.IsTrue(distictList.Count() == _generatedWords.Count);
        }

        [TestMethod]
        public void AlphabetCountTest()
        {
            Assert.IsTrue(Word.Alphabet.Count == 26);
        }
    }
}
