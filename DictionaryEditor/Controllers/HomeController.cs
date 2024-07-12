using DictionaryEditor.Models;
using DictionaryEditorDb;
using DictionaryEditorDb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DictionaryEditor.Controllers
{

    public class HomeController : Controller
    {
        private readonly TagsValueRepository tagsValueRepository;
        private readonly TagRepository tagRepository;
        private readonly VocabularyItemRepository vocabularyItemRepository;
        private readonly LanguagesRepository languagesRepository;
        public HomeController(TagsValueRepository tagsValueRepository,
            TagRepository tagRepository,
            VocabularyItemRepository vocabularyItemRepository,
            LanguagesRepository languagesRepository)
        {
            this.tagsValueRepository = tagsValueRepository;
            this.tagRepository = tagRepository;
            this.vocabularyItemRepository = vocabularyItemRepository;
            this.languagesRepository = languagesRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWord(string value, string tag, string tagValue)
        {
            Word word = new Word(value);
            Tag myTag = tagRepository.TryGetTag(tag);
            TagsValue tagsValue = tagsValueRepository.TryGetTagsValue(tagValue);
            var language = languagesRepository.TryGetById(Guid.Parse("66be7803-143c-4353-91f6-1642b3cab3a1"));
            word.Language = language;

            var vocabularyItem = new VocabularyItem()
            {
                Id = Guid.NewGuid(),
                Word = word,
                WordId = word.Id,
                TagsValue = tagsValue,
                TagsValueId = tagsValue.Id,
            };
            word.VocabularyItems.Add(vocabularyItem);
            tagsValue.VocabularyItems.Add(vocabularyItem);
            vocabularyItemRepository.AddWord(vocabularyItem);
            return RedirectToAction("Index");
        }
    }
}
