using System;
using System.Collections.Generic;
using System.Linq;

namespace _6LetterWordChallange.Models
{
    public class WordAssembler
    {
        readonly int stringLengthOfCompleteWords = 6;
        readonly int stringLengthOfWordPieces = 3;

        // Get char amount every string in array into list
        public List<int> CountChar(string[] array)
        {
            List<int> charOfLines = new List<int> { };
            foreach (string s in array)
            {
                charOfLines.Add(s.Length);
            }
            return charOfLines;
        }

        // Get all words with stringLengthOfCompleteWords into list
        public List<string> GetCompleteWords(string[] array, int[] arrayOfCharCount)
        {
            List<int> indexesChar6 = Enumerable.Range(0, arrayOfCharCount.Length).Where(i => arrayOfCharCount[i] == stringLengthOfCompleteWords).ToList();
            List<string> completedWords = new List<string> { };
            foreach (var i in indexesChar6)
            {
                string completedWord = array[i];
                completedWords.Add(completedWord);
            }
            return completedWords;
        }

        // Get all words with stringLengthOfWordPieces into list
        public List<string> GetWordPieces(string[] array, int[] arrayOfCharCount)
        {
            List<int> indexesChar3 = Enumerable.Range(0, arrayOfCharCount.Length).Where(i => arrayOfCharCount[i] == stringLengthOfWordPieces).ToList();
            List<string> wordPieces = new List<string> { };
            foreach (var i in indexesChar3)
            {
                string wordPiece = array[i];
                wordPieces.Add(wordPiece);
            }
            return wordPieces;
        }

        // Combine every posseble combination of wordPieces
        public string GenerateOutput(List<string> wordPieces, List<string> completedWords)
        {
            List<string> wordPiecesCopy = wordPieces;
            string output = "";
            for (int v = 0; v < wordPieces.Count; v++)
            {
                for (int w = 0; w < wordPieces.Count; w++)
                {
                    string firstPartWord = wordPieces[v];
                    string lastPartWord = wordPiecesCopy[w];
                    if (firstPartWord == lastPartWord)
                        continue;
                    string combinedWord = firstPartWord + lastPartWord;
                    if (completedWords.Contains(combinedWord))
                    {
                        output += $"{firstPartWord}+{lastPartWord}={combinedWord}\n";
                    }
                }
            }
            return output;
        }
    }
}