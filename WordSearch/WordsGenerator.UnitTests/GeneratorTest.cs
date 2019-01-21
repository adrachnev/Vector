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
            IGenerator generator = new Generator();
            _generatedWords = generator.GetWords();
        }

        [TestMethod]
        public void WordsCount()
        {
            int numberOfPositions = 4;
            
            Assert.IsTrue(_generatedWords.Count == Math.Pow(Word.Alphabet.Count, numberOfPositions));
        }

        [TestMethod]
        public void WordsUniqueCombinations()
        {
            var distictList = _generatedWords.Distinct(new WordComparer());

            Assert.IsTrue(distictList.Count() == _generatedWords.Count);
        }

        [TestMethod]
        public void AlphabetCount()
        {
            Assert.IsTrue(Word.Alphabet.Count == 26);
        }
    }
}
