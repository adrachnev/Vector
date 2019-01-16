using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordsGenerator;
using WordsSeach;

namespace WordsSearch.UnitTests
{
    [TestClass]
    public class SearchTest
    {
        private List<Word> _generatedWords;

        [TestInitialize]
        public void Init()
        {
            _generatedWords = Generator.GetWords();
        }

        [TestMethod]
        public void FindSingleTest()
        {
            TimeSpan duration;
            var result = Search.Excecute(_generatedWords, "aaaa", out duration);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(duration.Milliseconds > 0);

            result = Search.Excecute(_generatedWords, "ZZZZ", out duration);
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(duration.Milliseconds > 0);
        }

        [TestMethod]
        public void FindNoneTest()
        {
            TimeSpan duration;
            var result = Search.Excecute(_generatedWords, "AAAAA", out duration);

            Assert.IsTrue(result.Count == 0);
            Assert.IsTrue(duration.Milliseconds > 0);
        }

        [TestMethod]
        public void FindLastTest()
        {
            TimeSpan duration;
            var result = Search.Excecute(_generatedWords, "BBB", out duration);

            Assert.IsTrue(result.Count == 26);
            Assert.IsTrue(duration.Milliseconds > 0);
        }

        [TestMethod]
        public void FindLastButOneTest()
        {
            TimeSpan duration;
            var result = Search.Excecute(_generatedWords, "CC", out duration);

            Assert.IsTrue(result.Count == 26 * 26);
            Assert.IsTrue(duration.Milliseconds > 0);
        }

        [TestMethod]
        public void FindSecondTest()
        {
            TimeSpan duration;
            var result = Search.Excecute(_generatedWords, "D", out duration);

            Assert.IsTrue(result.Count == 26 * 26 * 26);
            Assert.IsTrue(duration.Milliseconds > 0);
        }

        [TestMethod]
        public void EmptyStringTest()
        {
            TimeSpan duration;
            var result = Search.Excecute(_generatedWords, string.Empty, out duration);

            Assert.IsTrue(result.Count == 26 * 26 * 26 * 26);
            Assert.IsTrue(duration.Milliseconds == 0);
        }

        

    }
}
