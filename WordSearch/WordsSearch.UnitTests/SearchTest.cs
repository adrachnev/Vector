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
        private ISearch _search;

        [TestInitialize]
        public void Init()
        {
            IGenerator generator = new Generator();
            _generatedWords = generator.GetWords();

            _search = new Search();


        }

        [TestMethod]
        public void FindSingle()
        {
            TimeSpan duration;
            var result = _search.Excecute(_generatedWords, "aaaa", out duration);

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(duration.TotalMilliseconds > 0);

            result = _search.Excecute(_generatedWords, "ZZZZ", out duration);
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(duration.TotalMilliseconds> 0);
        }

        [TestMethod]
        public void FindNone()
        {
            TimeSpan duration;
            var result = _search.Excecute(_generatedWords, "AAAAA", out duration);

            Assert.IsTrue(result.Count == 0);
            Assert.IsTrue(duration.TotalMilliseconds > 0);
        }

        [TestMethod]
        public void FindLast()
        {
            TimeSpan duration;
            var result = _search.Excecute(_generatedWords, "BBB", out duration);

            Assert.IsTrue(result.Count == 26);
            Assert.IsTrue(duration.TotalMilliseconds > 0);
        }

        [TestMethod]
        public void FindLastButOne()
        {
            TimeSpan duration;
            var result = _search.Excecute(_generatedWords, "CC", out duration);

            Assert.IsTrue(result.Count == 26 * 26);
            Assert.IsTrue(duration.TotalMilliseconds > 0);
        }

        [TestMethod]
        public void FindSecond()
        {
            TimeSpan duration;
            var result = _search.Excecute(_generatedWords, "D", out duration);

            Assert.IsTrue(result.Count == 26 * 26 * 26);
            Assert.IsTrue(duration.TotalMilliseconds > 0);
        }

        [TestMethod]
        public void EmptyString()
        {
            TimeSpan duration;
            var result = _search.Excecute(_generatedWords, string.Empty, out duration);

            Assert.IsTrue(result.Count == 26 * 26 * 26 * 26);
            Assert.IsTrue(duration.TotalMilliseconds == 0);

            result = _search.Excecute(_generatedWords, null, out duration);

            Assert.IsTrue(result.Count == 26 * 26 * 26 * 26);
            Assert.IsTrue(duration.TotalMilliseconds == 0);
        }

        

    }
}
