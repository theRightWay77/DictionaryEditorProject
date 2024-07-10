using DictionaryEditor.Models;
using DictionaryEditorDb;
using DictionaryEditorDb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DictionaryEditor.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext databaseContext;
        private readonly TagsValueRepository tagsValueRepository;
        public HomeController(ILogger<HomeController> logger, DatabaseContext databaseContext, TagsValueRepository tagsValueRepository)
        {
            _logger = logger;
            this.databaseContext = databaseContext;
            this.tagsValueRepository = tagsValueRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWord(string value, string tag, string tagValue)
        {
            Word word = new Word(value);
            tagsValueRepository.AddWord(word);
            return RedirectToAction("Index");
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
