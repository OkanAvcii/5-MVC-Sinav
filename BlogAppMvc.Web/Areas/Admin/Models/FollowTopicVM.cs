using BlogApp.Core.Concrete;
using BlogApp.Service.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogAppMvc.Web.Areas.Admin.Models
{
    public class FollowTopicVM
    {
        //public int TopicId { get; set; }
        //public string TopicName { get; set; }
        //public bool HasFollow { get; set; }
        public ArticleCreateDTO Article { get; set; }
        public TopicGetDTO Topic { get; set; }
        public List<SelectListItem> TopicForDropDown { get; set; }

    }
}
