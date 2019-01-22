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
            
            var result = _search.StartsWith(_generatedWords, "aaaa");

            Assert.IsTrue(result.Item1.Count == 1);
            Assert.IsTrue(result.Item2.TotalMilliseconds > 0);

            result = _search.StartsWith(_generatedWords, "ZZZZ");
            Assert.IsTrue(result.Item1.Count == 1);
            Assert.IsTrue(result.Item2.TotalMilliseconds> 0);
        }

        [TestMethod]
        public void FindNone()
        {
            var result = _search.StartsWith(_generatedWords, "AAAAA");

            Assert.IsTrue(result.Item1.Count == 0);
            Assert.IsTrue(result.Item2.TotalMilliseconds > 0);
        }

        [TestMethod]
        public void FindLast()
        {
            
            var result = _search.StartsWith(_generatedWords, "BBB");

            Assert.IsTrue(result.Item1.Count == 26);
            Assert.IsTrue(result.Item2.TotalMilliseconds > 0);
        }

        [TestMethod]
        public void FindLastButOne()
        {
            
            var result = _search.StartsWith(_generatedWords, "CC");

            Assert.IsTrue(result.Item1.Count == 26 * 26);
            Assert.IsTrue(result.Item2.TotalMilliseconds > 0);
        }

        [TestMethod]
        public void FindSecond()
        {
            
            var result = _search.StartsWith(_generatedWords, "D");

            Assert.IsTrue(result.Item1.Count == 26 * 26 * 26);
            Assert.IsTrue(result.Item2.TotalMilliseconds > 0);
        }

        [TestMethod]
        public void EmptyString()
        {
            
            var result = _search.StartsWith(_generatedWords, string.Empty);

            Assert.IsTrue(result.Item1.Count == 26 * 26 * 26 * 26);
            Assert.IsTrue(result.Item2.TotalMilliseconds == 0);

            result = _search.StartsWith(_generatedWords, null);

            Assert.IsTrue(result.Item1.Count == 26 * 26 * 26 * 26);
            Assert.IsTrue(result.Item2.TotalMilliseconds == 0);
        }

        

    }
}
