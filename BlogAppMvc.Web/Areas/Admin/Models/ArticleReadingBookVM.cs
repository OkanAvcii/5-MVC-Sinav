namespace BlogAppMvc.Web.Areas.Admin.Models
{
    public class ArticleReadingBookVM
    {
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorPicture { get; set; }
        public DateTime CreatedArticleDate { get; set; }
        public int ReadingTime { get; set; }
    }
}
