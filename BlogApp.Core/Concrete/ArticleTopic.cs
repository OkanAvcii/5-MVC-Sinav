using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Concrete
{
    public class ArticleTopic
    {
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
