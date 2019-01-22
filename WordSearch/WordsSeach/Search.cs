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
        /// Searches words using "starts with".
        /// </summary>
        /// <param name="words">The words.</param>
        /// <param name="searchString">The search string.</param>
        /// <returns>result and duration</returns>
        Tuple<List<Word>, TimeSpan> StartsWith(List<Word> words, string searchString);
        
    }
    public class Search : ISearch
    {
        private readonly object _lock = new object();

        private Stopwatch _stopwatch = new Stopwatch();


        
        public Tuple<List<Word>, TimeSpan> StartsWith(List<Word> words, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return new Tuple<List<Word>, TimeSpan>(words, new TimeSpan());

            var result = new List<Word>();

            _stopwatch.Start();

            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 5;

            Parallel.ForEach(words, options,
                (x) =>
                {
                    if (x.ToString().StartsWith(searchString, StringComparison.InvariantCultureIgnoreCase))
                    {
                        System.Diagnostics.Debug.WriteLine("Thread Id: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
                        lock (_lock)
                        {   
                            result.Add(x);
                        }
                    }
                });

            _stopwatch.Stop();

            var searchDuration = _stopwatch.Elapsed;

            return new Tuple<List<Word>, TimeSpan>( result, searchDuration);
        }

        
    }
}
