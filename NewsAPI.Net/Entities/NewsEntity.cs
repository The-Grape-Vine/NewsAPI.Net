using System.Collections.Generic;

namespace NewsAPI.Net.Entities
{
    public class NewsEntity
    {
        public string Status { get; set; }
        public List<ArticleEntity> Articles { get; set; }
    }
}