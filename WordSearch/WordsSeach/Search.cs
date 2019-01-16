using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WordsGenerator;

namespace WordsSeach
{
    public interface ISearch
    {
        List<Word> Excecute(List<Word> words, string searchString, out TimeSpan searchDuration);
    }
    public class Search : ISearch
    {
        private readonly object _lock = new object();
        Stopwatch _stopwatch = new Stopwatch();

        public List<Word> Excecute(List<Word> words, string searchString, out TimeSpan searchDuration)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return words;

            var result = new List<Word>();

            _stopwatch.Start();

            Parallel.ForEach(words,
                (x) =>
                {
                    if (x.ToString().StartsWith(searchString, StringComparison.InvariantCultureIgnoreCase))
                        lock(_lock)
                        {
                            result.Add(x);
                        }
                });

            _stopwatch.Stop();

            searchDuration = _stopwatch.Elapsed;

            return result;
        }

    }
}
