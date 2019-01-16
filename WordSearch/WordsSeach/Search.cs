using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WordsGenerator;

namespace WordsSeach
{
    public class Search
    {
        private static readonly object _lock = new object();
        public static List<Word> Excecute(List<Word> words, string searchString, out TimeSpan searchDuration)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return words;

            var result = new List<Word>();

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            Parallel.ForEach(words,
                (x) =>
                {
                    if (x.ToString().StartsWith(searchString, StringComparison.InvariantCultureIgnoreCase))
                        lock(_lock)
                        {
                            result.Add(x);
                        }
                });

            stopwatch.Stop();

            searchDuration = stopwatch.Elapsed;

            return result;
        }

    }
}
