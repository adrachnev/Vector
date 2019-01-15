using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch
{
    public class MainViewModel
    {

        public List<WordsGenerator.Word> Words { get; set; }
        public MainViewModel()
        {
            Words = WordsGenerator.Generator.GetWords();

        }
    }
}
