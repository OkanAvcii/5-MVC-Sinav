using BlogApp.Core.Concrete;

namespace BlogAppMvc.Web.Areas.Admin.Models
{
    public class ArticleGetVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public AppUser Author { get; set; }
        public ICollection<Topic> Topics { get; set; }


    }
}
