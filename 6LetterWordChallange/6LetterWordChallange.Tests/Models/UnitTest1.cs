using _6LetterWordChallange.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace _6LetterWordChallange.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CountCharTest()
        {
            var wordAssembler = new WordAssembler();
            string[] array = { "ThisIs7", "AndThisIs11" };
            List<int> list = wordAssembler.CountChar(array);
            List<int> expectedList = new List<int> { 7, 11 };
            Assert.Equal(expectedList, list);
        }

        [Fact]
        public void GetCompleteWordsTest()
        {
            var wordAssembler = new WordAssembler();
            string[] array = { "foobar", "appeal", "foo", "bar" };
            int[] arrayOfCharCount = { 6, 6, 3, 3 };
            List<string> list = wordAssembler.GetCompleteWords(array, arrayOfCharCount);
            List<string> expectedList = new List<string> { "foobar", "appeal" };
            Assert.Equal(expectedList, list);
        }

        [Fact]
        public void GetWordPiecesTest()
        {
            var wordAssembler = new WordAssembler();
            string[] array = { "foobar", "appeal", "foo", "bar" };
            int[] arrayOfCharCount = { 6, 6, 3, 3 };
            List<string> list = wordAssembler.GetWordPieces(array, arrayOfCharCount);
            List<string> expectedList = new List<string> { "foo", "bar" };
            Assert.Equal(expectedList, list);
        }

        [Fact]
        public void GenerateOutput()
        {
            var wordAssembler = new WordAssembler();
            List<string> wordPieces = new List<string> { "foo", "bar" };
            List<string> completedWords = new List<string> { "foobar" };
            string output = wordAssembler.GenerateOutput(wordPieces, completedWords);
            string expectedOutput = "foo+bar=foobar\n";
            Assert.Equal(expectedOutput, output);
        }
    }

}
