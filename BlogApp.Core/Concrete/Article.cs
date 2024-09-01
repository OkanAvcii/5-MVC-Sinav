namespace BlogApp.Core.Concrete
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public int ReadingTime { get; set; } // Approximate reading time in minutes
        public string ImagePath { get; set; }

        // Foreign Key
        public string AuthorId { get; set; }

        // Navigation Properties
        public AppUser Author { get; set; }
        public ICollection<ArticleTopic> ArticleTopics { get; set; }
    }
}