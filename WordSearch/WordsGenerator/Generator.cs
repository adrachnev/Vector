using System;
using System.Collections.Generic;
using System.Text;

namespace WordsGenerator
{
    public class Generator
    {
        public static List<Word> GetWords()
        {
            List<Word> result = new List<Word>();
            for (int i = 0; i < Word.Alphabet.Count; i++)
            {
                for (int j = 0; j < Word.Alphabet.Count; j++)
                {
                    for (int x = 0; x < Word.Alphabet.Count; x++)
                    {
                        for (int y = 0; y < Word.Alphabet.Count; y++)
                        {
                            result.Add(new Word
                            {
                                FirstPosition = Word.Alphabet[i],
                                SecondPosition = Word.Alphabet[j],
                                ThirdPosition = Word.Alphabet[x],
                                FourthPosition = Word.Alphabet[y]
                            });
                        }
                    }
                }
            }

            return result;
        }
    }
}
