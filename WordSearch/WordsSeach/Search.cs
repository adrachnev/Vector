using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WordsGenerator;

namespace WordsSeach
{
    /// <summary>
    /// Words search
    /// </summary>
    public interface ISearch
    {
        /// <summary>
        /// Excecutes the specified words.
        /// </summary>
        /// <param name="words">The words.</param>
        /// <param name="searchString">The search string.</param>
        /// <param name="searchDuration">Duration of the search.</param>
        /// <returns></returns>
        List<Word> Excecute(List<Word> words, string searchString, out TimeSpan searchDuration);
    }
    public class Search : ISearch
    {
        private readonly object _lock = new object();
        private Stopwatch _stopwatch = new Stopwatch();

        public List<Word> Excecute(List<Word> words, string searchString, out TimeSpan searchDuration)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return words;

            var result = new List<Word>();

            _stopwatch.Start();

            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 5;

            Parallel.ForEach(words, options,
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
