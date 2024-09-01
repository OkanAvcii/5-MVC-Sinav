using BlogApp.Core.Concrete;
using BlogApp.Dal.Contexts;
using BlogApp.Service.DTOs;
using BlogApp.Service.Services.AppUserService;
using BlogApp.Service.Services.ArticleService;
using BlogApp.Service.Services.ArticleTopicService;
using BlogApp.Service.Services.TopicService;
using BlogAppMvc.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogAppMvc.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITopicService _topicService;
        private readonly AppDbContext _context;
        private readonly IArticleTopicService _articleTopicService;

        public ArticleController(IArticleService articleService, UserManager<AppUser> userManager, ITopicService topicService, AppDbContext context, IArticleTopicService articleTopicService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _topicService = topicService;
            _context = context;
            _articleTopicService = articleTopicService;
        }

        ArticleTopicVM articleTopicVM = new ArticleTopicVM();
        public IActionResult Index(int id)
        {
            articleTopicVM.Topics = id != 0 ? _context.ArticleTopics
                .Where(at => at.ArticleId == id)
                .Select(at => at.Topic)
                .ToList()
                : _context.Topics.ToList();

            articleTopicVM.Articles = _context.Articles.ToList();

            return View(articleTopicVM);
        }

        FollowTopicVM followTopicVM = new FollowTopicVM();
        [Authorize]
        public IActionResult Create()
        {
            followTopicVM.TopicForDropDown = FillTopics();
            return View(followTopicVM);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(FollowTopicVM model)
        {

            var userId = _userManager.GetUserId(User);
            _articleService.Create(model.Article, userId);
            var lastArticle = _articleService.GetArticleByAuthorId(userId);
            int lastArticleId = lastArticle.Last().Id;
            _articleTopicService.Create(lastArticleId, model.Topic.Id);
            TempData["success"] = "The article has been created successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Details()
        {
            return View();
        }

        private List<SelectListItem> FillTopics()
        {
            return _topicService.GetAll().Select(t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() }).ToList();
        }
    }
}
