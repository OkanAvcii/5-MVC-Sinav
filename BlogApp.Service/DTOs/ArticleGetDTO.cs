using BlogApp.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Service.DTOs
{
    public class ArticleGetDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public AppUser Author { get; set; }

        //public ICollection<Topic> Topics { get; set; }
        //public ArticleGetDTO()
        //{
        //    Topics = new List<Topic>();
        //}
    }
}
