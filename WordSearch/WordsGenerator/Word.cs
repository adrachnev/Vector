using System;
using System.Collections.Generic;

namespace WordsGenerator
{
    public class Word
    {
        public static readonly List<string> Alphabet = new List<string> { "A", "B", "C" , "D", "E", "F", "G", "H", "I","J", "K", "L", "M", "N", "O", "P","Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public string FirstPosition { get; set; }
        public string SecondPosition { get; set; }
        public string ThirdPosition { get; set; }
        public string FourthPosition { get; set; }

        public override string ToString()
        {
            return FirstPosition + SecondPosition + ThirdPosition + FourthPosition;
        }
    }

    public class WordComparer : IEqualityComparer<Word>
    {
        public bool Equals(Word x, Word y)
        {
            if (x.FirstPosition == y.FirstPosition &&
                x.SecondPosition == y.SecondPosition &&
                x.ThirdPosition == y.ThirdPosition &&
                x.FourthPosition == y.FourthPosition)
                return true;

            return false;
        }

        public int GetHashCode(Word obj)
        {
            return obj.GetHashCode();
        }
    }



}
