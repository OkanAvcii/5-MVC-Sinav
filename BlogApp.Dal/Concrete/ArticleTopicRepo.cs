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
    public class ArticleTopicRepo : IArticleTopicRepo
    {
        private readonly AppDbContext _context;

        public ArticleTopicRepo(AppDbContext context)
        {
            _context = context;
        }

        public int Create(int ArticleId, int TopicId)
        {
            var articleTopic = new ArticleTopic { ArticleId = ArticleId, TopicId = TopicId };
            _context.ArticleTopics.Add(articleTopic);
            return _context.SaveChanges();
        }

        public int Delete(int ArticleId, int TopicId)
        {
            var articleTopic = new ArticleTopic { ArticleId = ArticleId, TopicId = TopicId };
            _context.ArticleTopics.Remove(articleTopic);
            return _context.SaveChanges();
        }

        public int Update(int ArticleId, int TopicId)
        {
            var articleTopic = new ArticleTopic { ArticleId = ArticleId, TopicId = TopicId };
            _context.ArticleTopics.Update(articleTopic);
            return _context.SaveChanges();
        }
    }
}
