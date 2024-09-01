using BlogApp.Core.Concrete;
using BlogApp.Dal.Contexts;
using BlogApp.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Dal.Concrete
{
    public class TopicRepo : BaseRepo<Topic>, ITopicRepo
    {
        private readonly AppDbContext _context;
        public TopicRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IList<Topic> GetTopicsByArticle(int articleId)
        {
            return _context.ArticleTopics.Where(at => at.ArticleId == articleId)
                .Select(at => at.Topic)
                .ToList();
        }
    }
}
