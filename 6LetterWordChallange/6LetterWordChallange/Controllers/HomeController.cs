using _6LetterWordChallange.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _6LetterWordChallange.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["output"] = WordAssembler();
            return View();
        }

        private string WordAssembler()
        {
            string[] lines = null;
            //read all lines from txt file into string array
            try
            {
                lines = System.IO.File.ReadAllLines(@"..\6LetterWordChallange\Data\input.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            if (lines != null)
            {
                WordAssembler wordAssembler = new WordAssembler();
                List<int> countCharList = wordAssembler.CountChar(lines);
                List<string> completedWordsList = wordAssembler.GetCompleteWords(lines, countCharList.ToArray());
                List<string> wordPiecesList = wordAssembler.GetWordPieces(lines, countCharList.ToArray());
                string output = wordAssembler.GenerateOutput(wordPiecesList, completedWordsList);
                return output;
            }
            else
            {
                return "something went wrong";
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
