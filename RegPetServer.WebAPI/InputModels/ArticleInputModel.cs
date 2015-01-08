namespace RegPetServer.WebAPI.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ArticleInputModel
    {
        public ArticleInputModel()
        {
            this.TagNames = new HashSet<string>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<string> TagNames { get; set; }
    }
}