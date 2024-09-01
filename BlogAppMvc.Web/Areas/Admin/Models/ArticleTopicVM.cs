using BlogApp.Core.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogAppMvc.Web.Areas.Admin.Models
{
    public class ArticleTopicVM
    {
        public List<Article> Articles { get; set; }
        public List<Topic> Topics { get; set; }
        public Article Article { get; set; }
        public List<SelectListItem> ArticleList { get; set; }
    }
}
