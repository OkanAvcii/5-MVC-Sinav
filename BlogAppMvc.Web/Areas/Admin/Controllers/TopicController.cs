using BlogApp.Dal.Interfaces;
using BlogApp.Service.DTOs;
using BlogApp.Service.Services.TopicService;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppMvc.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        public IActionResult Index()
        {
            List<TopicGetDTO> topicGetDTO = _topicService.GetAll().Select(a => new TopicGetDTO
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,

            }).ToList();
            return View(topicGetDTO);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TopicCreateDTO model)
        {
            _topicService.Create(model);
            return RedirectToAction("Index");

        }

    }
}
