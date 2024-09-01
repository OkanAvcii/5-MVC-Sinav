using BlogApp.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Dal.Interfaces
{
    public interface ITopicRepo : IBaseRepo<Topic>
    {
        IList<Topic> GetTopicsByArticle(int articleId);
    }
}
