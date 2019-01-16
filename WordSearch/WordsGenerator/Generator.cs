using System;
using System.Collections.Generic;
using System.Text;

namespace WordsGenerator
{
    public interface IGenerator
    {
        List<Word> GetWords();
    }

    public class Generator : IGenerator
    {
        public List<Word> GetWords()
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
