namespace NewsAPI.Net.Models
{
    public class ArticleModel
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string PublishedAt { get; set; }
        public string Content { get; set; }
    }

    public class InternalSource
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}