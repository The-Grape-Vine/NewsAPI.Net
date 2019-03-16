using System.Collections.Generic;

namespace NewsAPI.Net.Models
{
    public class NewsModel
    {
        public string Status { get; set; }
        public List<ArticleModel> Articles { get; set; }
    }
}