namespace BlogAPI.Models
{
    public class UpdateArticleRequest
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }

    }
}
