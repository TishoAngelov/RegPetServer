namespace RegPetServer.WebAPI.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class ArticleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorId { get; set; }

        public string Author { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}