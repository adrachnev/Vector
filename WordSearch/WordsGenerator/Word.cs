using System;
using System.Collections.Generic;

namespace WordsGenerator
{
    public class Word
    {
        public static readonly List<string> Alphabet = new List<string> { "A", "B" };

        public string FirstPosition { get; set; }
        public string SecondPosition { get; set; }
        public string ThirdPosition { get; set; }
        public string FourthPosition { get; set; }

        public override string ToString()
        {
            return FirstPosition + SecondPosition + ThirdPosition + FourthPosition;
        }
    }

    
    
}
