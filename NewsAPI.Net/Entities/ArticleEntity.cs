
namespace NewsAPI.Net.Entities
{
    public class ArticleEntity
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string URLToImage { get; set; }
        public string PublishedAt { get; set; }
        public string Content { get; set; }
    }

    public class InternalSource
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}